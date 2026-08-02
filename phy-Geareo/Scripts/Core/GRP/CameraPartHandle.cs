namespace GRP
{
	public class CameraPartHandle : PartHandle<CameraPart, CameraPartView>
	{
		public AxisHandle handleDistance;

		public AxisHandle handleAround;

		public AxisHandle handleHeight;

		public CameraSize helperTransform;

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
