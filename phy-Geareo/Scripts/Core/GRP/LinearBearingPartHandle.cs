namespace GRP
{
	public class LinearBearingPartHandle : PartHandle<LinearBearingPart, LinearBearingPartView>
	{
		public AxisHandle handleBodyUp;

		public AxisHandle handleBodyDown;

		public AxisHandle handleBodyRight;

		public AxisHandle handleBodyLeft;

		public AxisHandle handleBodyForward;

		public AxisHandle handleBodyBack;

		public AxisHandle handleShaftTop;

		public AxisHandle handleShaftBottom;

		public AxisHandle handleShaftTopPosition;

		public AxisHandle handleShaftBottomPosition;

		protected override void Setup()
		{
		}

		protected override void OnCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
