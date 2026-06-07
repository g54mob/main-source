namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element KXtIEOHJGbfeBheGUkdWZBGkMCtCA;

		private AxisRange WlvoHWkQtjQWWGHDTrljCDyNNrCA;

		public int elementIdentifierId => 0;

		public AxisRange axisRange
		{
			get
			{
				return default(AxisRange);
			}
			set
			{
			}
		}

		public bool hasTarget => false;

		public ControllerElementType elementType => default(ControllerElementType);

		public string descriptiveName => null;

		public Controller controller => null;

		public Controller.Element element
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			KXtIEOHJGbfeBheGUkdWZBGkMCtCA = null;
			WlvoHWkQtjQWWGHDTrljCDyNNrCA = default(AxisRange);
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			KXtIEOHJGbfeBheGUkdWZBGkMCtCA = null;
			WlvoHWkQtjQWWGHDTrljCDyNNrCA = default(AxisRange);
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			KXtIEOHJGbfeBheGUkdWZBGkMCtCA = null;
			WlvoHWkQtjQWWGHDTrljCDyNNrCA = default(AxisRange);
		}

		public static implicit operator ControllerElementTarget(ActionElementMap actionElementMap)
		{
			return default(ControllerElementTarget);
		}
	}
}
