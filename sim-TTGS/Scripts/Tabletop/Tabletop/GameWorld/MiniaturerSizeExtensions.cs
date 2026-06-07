namespace Tabletop.GameWorld
{
	public static class MiniaturerSizeExtensions
	{
		public static int PiecesCount(this EMiniatureSize size)
		{
			return size switch
			{
				EMiniatureSize.SIMPLE => 5, 
				EMiniatureSize.LARGE => 10, 
				_ => 0, 
			};
		}
	}
}
