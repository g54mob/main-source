public class LineActor
{
	public delegate void LineCellAction(int x, int y, float dist);

	public static void ActOnLine(int x, int y, int tx, int ty, int width, LineCellAction cellAction)
	{
	}

	private static int Dist2(int x0, int y0, int x1, int y1)
	{
		return 0;
	}
}
