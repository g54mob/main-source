using CTS.Core;

namespace CTS
{
	public abstract class CutsceneFeature : CTSBehaviour, IRepaint
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		protected NewsCutscene _manager;

		public void Repaint()
		{
			if (base.isActiveAndEnabled)
			{
				OnRepaint();
			}
		}

		protected abstract void OnRepaint();
	}
}
