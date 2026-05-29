namespace Rewired
{
	public sealed class KeyboardMap : ControllerMap
	{
		public KeyboardMap()
		{
		}

		public KeyboardMap(KeyboardMap keyboardMap)
		{
		}

		internal void SetIdentity(int categoryId, int layoutId)
		{
		}

		internal static KeyboardMap Blank(int categoryId, int layoutId)
		{
			return null;
		}
	}
}
