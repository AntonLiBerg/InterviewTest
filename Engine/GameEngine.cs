public class GameEngine
{
    private Dictionary<(int, int), string> _map;
    private DotDrawer _dotDrawer;
    private WASDInput _input;
    private Game _game;
    private System.Timers.Timer aTimer;
    public bool ShouldEnd = false;
    
    public GameEngine(int width = 40, int height = 20, int interval = 200)
    {
        Console.TreatControlCAsInput = true;
        Console.WindowWidth = width;
        Console.WindowHeight = height;
        Console.CursorVisible = false;

        _map = new Dictionary<(int, int), string>();
        
        _dotDrawer = new DotDrawer();
        _input = new WASDInput();
        _game = new Game(_dotDrawer, _input);

        aTimer = new System.Timers.Timer();
        aTimer.Elapsed += delegate { RunGame(); };
        aTimer.Interval = interval;

        Console.Clear();
        for (int x = 0; x < 12; x++)
        {
          for (int y = 0; y < 14; y++)
          {
            if (x == 0 || x == 11 || y == 0 || y == 13)
            {
              _map[(x, y)] = "#";
            }
            else
            {
              _map[(x, y)] = "";
            }
          }
        }
    }

    public void Run()
    {
        aTimer.Enabled = true;
    }

    private void RunGame()
    {
        if (!_input.AnyKeyDown && Console.KeyAvailable && !ShouldEnd)
        {
            var key = Console.ReadKey(true).KeyChar;
            if (key == 'w' || key == 'W')
                _input.WKeyDown = true;
            if (key == 'a' || key == 'A')
                _input.AKeyDown = true;
            if (key == 's' || key == 'S')
                _input.SKeyDown = true;
            if (key == 'd' || key == 'D')
                _input.DKeyDown = true;

            if (key == 'q' || key == 'Q')
            {
               ShouldEnd = true;
               return;
            }
        }
        
        _game.UpdateGame();
        RenderBoard();
    }

    private void RenderBoard()
    {
      Console.CursorVisible = false; 

      for (int x = 1; x < 11; x++)
      {
        for (int y = 1; y < 13; y++)
        {

            _map[(x, y)] = " ";
        }
      }

      foreach(var c in _dotDrawer.ToDraw)
        _map[(c.Item1,c.Item2)] = c.Item3;

      foreach(var kvp in _map)
      {
        Console.SetCursorPosition(kvp.Key.Item1,kvp.Key.Item2);
        Console.Write(kvp.Value);
      }

      _dotDrawer.ToDraw.Clear();
      _input.Clear();
    }
}
