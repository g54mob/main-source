namespace Assets.Scripts.Design.Tools
{
	public class PartConnectionsTool : DesignerToolBase
	{
		private bool _enableGizmosRestore;

		public override bool IsBaseTool => false;

		public PartConnectionsTool(DesignerScript designer)
			: base(designer)
		{
		}

		public override void Activate()
		{
			base.Activate();
			base.Designer.HighlightedPart = null;
			_enableGizmosRestore = Game.Instance.Settings.Game.Designer.EnableGizmos.Value;
			Game.Instance.Settings.Game.Designer.EnableGizmos.Value = false;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			Game.Instance.Settings.Game.Designer.EnableGizmos.Value = _enableGizmosRestore;
		}
	}
}
