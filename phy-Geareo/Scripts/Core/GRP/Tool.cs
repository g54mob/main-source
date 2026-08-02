using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public abstract class Tool : Thing<ToolConfig>
	{
		public StateSelector<bool> selected;

		public Project project;

		public virtual bool canInteractPart => false;

		public override void OnContext()
		{
		}

		public void Toggle()
		{
		}

		public void Select()
		{
		}

		public ToolViewable CreateViewable()
		{
			return null;
		}

		protected abstract ToolViewable DoCreateViewable();
	}
	public abstract class Tool<TConfig> : Tool where TConfig : ToolConfig
	{
		public new TConfig config => null;
	}
}
