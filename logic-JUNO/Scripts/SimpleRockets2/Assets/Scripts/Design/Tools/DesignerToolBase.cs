using ModApi.Design;

namespace Assets.Scripts.Design.Tools
{
	public abstract class DesignerToolBase : DesignerTool
	{
		public DesignerScript DesignerScript { get; private set; }

		public DesignerToolBase(DesignerScript designer)
			: base(designer)
		{
			DesignerScript = designer;
		}
	}
}
