namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element LghnkCMopbcrdaMntqKmFuqJXReW;

		private AxisRange jOimQVFitSbwgMXohGdZbOJkvSJ;

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

		public ControllerElementTarget(ActionElementMap actionElementMap)
		{
			LghnkCMopbcrdaMntqKmFuqJXReW = null;
			jOimQVFitSbwgMXohGdZbOJkvSJ = default(AxisRange);
		}

		public ControllerElementTarget(ControllerElementTarget other)
		{
			LghnkCMopbcrdaMntqKmFuqJXReW = null;
			jOimQVFitSbwgMXohGdZbOJkvSJ = default(AxisRange);
		}

		public ControllerElementTarget(IControllerElementTarget other)
		{
			LghnkCMopbcrdaMntqKmFuqJXReW = null;
			jOimQVFitSbwgMXohGdZbOJkvSJ = default(AxisRange);
		}

		public static implicit operator ControllerElementTarget(ActionElementMap actionElementMap)
		{
			return default(ControllerElementTarget);
		}
	}
}
