using CTS.Core;

namespace CTS
{
	public abstract class UI_ManagerFeature<TManager> : CTSBehaviour, IRepaint where TManager : UI_Manager<TManager>
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		protected TManager _parent;

		public void Repaint()
		{
			OnRepaint();
		}

		protected abstract void OnRepaint();
	}
}
