namespace Assets.Scripts.Design.Tools
{
	public class ScreenshotTool : DesignerToolBase
	{
		public override bool IsBaseTool => false;

		public ScreenshotTool(DesignerScript designer)
			: base(designer)
		{
		}

		public override void Activate()
		{
			base.Activate();
			base.Designer.AllowPartSelection = false;
			base.Designer.DeselectPart();
			base.Designer.HighlightedPart = null;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			base.Designer.AllowPartSelection = true;
		}
	}
}
