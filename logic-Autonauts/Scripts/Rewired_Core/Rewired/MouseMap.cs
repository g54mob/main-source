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
			mouseMap._categoryId = categoryId;
			mouseMap._layoutId = layoutId;
			mouseMap._sourceMapId = -1;
			return mouseMap;
		}
	}
}
