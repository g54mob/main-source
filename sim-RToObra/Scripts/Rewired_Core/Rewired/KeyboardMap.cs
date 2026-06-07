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
			while (true)
			{
				int num = 1173896784;
				while (true)
				{
					switch (num ^ 0x45F83E51)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0025;
					case 2:
						return;
					}
					break;
					IL_0025:
					_layoutId = layoutId;
					num = 1173896787;
				}
			}
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
