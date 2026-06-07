using Assets.Scripts.Input.Events;

namespace Assets.Scripts.Design.Tools
{
	public class ViewTool : DesignerTool
	{
		protected override bool PartHighlightEnabled => true;

		public ViewTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowPartSelection = true;
		}

		public override void HandleInput(InputEvent e)
		{
			base.HandleInput(e);
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Stop()
		{
			base.Stop();
		}
	}
}
