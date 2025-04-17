public class DotDrawer
{
  public List<(int,int,string)> ToDraw{get;set;}
  public DotDrawer()
  {
    this.ToDraw = new();
  }
  public void DrawDot(int x, int y)
  {
    if(ToDraw.Any(td => td.Item1 == x && td.Item2 == y))
      return;
    ToDraw.Add((x, y,"x"));
  }
}
