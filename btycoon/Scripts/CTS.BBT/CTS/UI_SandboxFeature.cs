using CTS.Core;

namespace CTS
{
	public abstract class UI_SandboxFeature : CTSBehaviour, IRepaint
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		protected UI_SandboxProfile _profile;

		public void Repaint()
		{
			OnRepaint();
		}

		protected abstract void OnRepaint();
	}
}
