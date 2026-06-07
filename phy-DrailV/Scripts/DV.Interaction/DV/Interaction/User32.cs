using System.Runtime.InteropServices;

namespace DV.Interaction
{
	public static class User32
	{
		public struct POINT
		{
			public int x;

			public int y;
		}

		[DllImport("user32.dll")]
		public static extern long GetCursorPos(ref POINT point);

		[DllImport("user32.dll")]
		public static extern long SetCursorPos(int x, int y);
	}
}
