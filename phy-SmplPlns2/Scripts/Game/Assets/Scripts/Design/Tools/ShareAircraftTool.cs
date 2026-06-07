namespace Assets.Scripts.Design.Tools
{
	public class ShareAircraftTool : DesignerTool
	{
		public ShareAircraftTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowFingerAid = false;
		}

		public override void Start()
		{
			base.Start();
			base.Designer.DeselectPart();
		}
	}
}
