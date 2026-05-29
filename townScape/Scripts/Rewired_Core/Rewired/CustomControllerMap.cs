namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int _sourceControllerId;

		public int sourceControllerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public CustomControllerMap()
		{
		}

		public CustomControllerMap(CustomControllerMap customControllerMap)
		{
		}

		internal void SetIdentity(int sourceControllerId, int categoryId, int layoutId)
		{
		}

		internal static CustomControllerMap Blank(int sourceControllerId, int categoryId, int layoutId)
		{
			return null;
		}
	}
}
