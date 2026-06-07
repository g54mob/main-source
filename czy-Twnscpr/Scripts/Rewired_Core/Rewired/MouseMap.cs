namespace Rewired
{
	public sealed class MouseMap : ControllerMapWithAxes
	{
		public MouseMap()
		{
		}

		public MouseMap(MouseMap mouseMap)
		{
		}

		internal void SetIdentity(int categoryId, int layoutId)
		{
		}

		internal static MouseMap Blank(int categoryId, int layoutId)
		{
			return null;
		}
	}
}
