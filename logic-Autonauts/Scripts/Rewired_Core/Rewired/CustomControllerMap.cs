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
			_categoryId = categoryId;
			_layoutId = layoutId;
		}

		internal static CustomControllerMap Blank(int sourceControllerId, int categoryId, int layoutId)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			while (true)
			{
				int num = 769048394;
				while (true)
				{
					switch (num ^ 0x2DD6BF4B)
					{
					case 0:
						break;
					case 1:
						customControllerMap._sourceControllerId = sourceControllerId;
						num = 769048393;
						continue;
					case 2:
						customControllerMap._sourceMapId = -1;
						customControllerMap._categoryId = categoryId;
						customControllerMap._layoutId = layoutId;
						num = 769048392;
						continue;
					default:
						return customControllerMap;
					}
					break;
				}
			}
		}
	}
}
