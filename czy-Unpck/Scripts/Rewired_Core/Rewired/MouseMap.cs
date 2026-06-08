namespace Rewired
{
	public sealed class MouseMap : ControllerMapWithAxes
	{
		public MouseMap()
		{
		}

		public MouseMap(MouseMap mouseMap)
			: base(mouseMap)
		{
		}

		internal void SetIdentity(int categoryId, int layoutId)
		{
			_categoryId = categoryId;
			_layoutId = layoutId;
		}

		internal static MouseMap Blank(int categoryId, int layoutId)
		{
			MouseMap mouseMap = new MouseMap();
			while (true)
			{
				int num = 1473319770;
				while (true)
				{
					switch (num ^ 0x57D1135B)
					{
					case 3:
						break;
					case 1:
						mouseMap._categoryId = categoryId;
						num = 1473319769;
						continue;
					case 2:
						mouseMap._layoutId = layoutId;
						mouseMap._sourceMapId = -1;
						num = 1473319771;
						continue;
					default:
						return mouseMap;
					}
					break;
				}
			}
		}
	}
}
