namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int _sourceControllerId;

		public int sourceControllerId
		{
			get
			{
				return _sourceControllerId;
			}
			set
			{
				_sourceControllerId = value;
			}
		}

		public CustomControllerMap()
		{
		}

		public CustomControllerMap(CustomControllerMap customControllerMap)
			: base(customControllerMap)
		{
			_sourceControllerId = customControllerMap._sourceControllerId;
		}

		internal void SetIdentity(int sourceControllerId, int categoryId, int layoutId)
		{
			_sourceControllerId = sourceControllerId;
			while (true)
			{
				int num = -1229209763;
				while (true)
				{
					switch (num ^ -1229209764)
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
					_categoryId = categoryId;
					_layoutId = layoutId;
					num = -1229209762;
				}
			}
		}

		internal static CustomControllerMap Blank(int sourceControllerId, int categoryId, int layoutId)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			customControllerMap._sourceControllerId = sourceControllerId;
			customControllerMap._sourceMapId = -1;
			customControllerMap._categoryId = categoryId;
			customControllerMap._layoutId = layoutId;
			return customControllerMap;
		}
	}
}
