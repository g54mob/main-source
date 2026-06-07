namespace Rewired
{
	public sealed class KeyboardMap : ControllerMap
	{
		public KeyboardMap()
		{
		}

		public KeyboardMap(KeyboardMap keyboardMap)
			: base(keyboardMap)
		{
		}

		internal void SetIdentity(int categoryId, int layoutId)
		{
			_categoryId = categoryId;
			_layoutId = layoutId;
		}

		internal static KeyboardMap Blank(int categoryId, int layoutId)
		{
			KeyboardMap keyboardMap = new KeyboardMap();
			keyboardMap._categoryId = categoryId;
			keyboardMap._layoutId = layoutId;
			keyboardMap._sourceMapId = -1;
			return keyboardMap;
		}
	}
}
