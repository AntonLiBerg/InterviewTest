public class Game
{
    private readonly DotDrawer dotDrawer;
    private readonly WASDInput input;
    public Game(DotDrawer render, WASDInput kb)
    {
        dotDrawer = render;
        input = kb;
    }

    public void UpdateGame()
    {
      RenderExampleCode();
    }
    private void RenderExampleCode()
    {
      dotDrawer.DrawDot(1, 1);
      dotDrawer.DrawDot(2, 2);
      dotDrawer.DrawDot(3, 3);
      dotDrawer.DrawDot(9, 11);
      dotDrawer.DrawDot(9, 12);
      dotDrawer.DrawDot(10, 11);
      dotDrawer.DrawDot(10, 12);

      if (input.WKeyDown)
        dotDrawer.DrawDot(6, 5);
      else if (input.AKeyDown)
        dotDrawer.DrawDot(5, 6);
      else if (input.SKeyDown)
        dotDrawer.DrawDot(6, 7);
      else if (input.DKeyDown)
        dotDrawer.DrawDot(7, 6);
      else
        dotDrawer.DrawDot(6,6);
    }
}
