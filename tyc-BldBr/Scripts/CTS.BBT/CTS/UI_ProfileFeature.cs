using CTS.Core;

namespace CTS
{
	public abstract class UI_ProfileFeature : CTSBehaviour, IRepaint
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		protected ICareerProfileReference _careerMetaData;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Repaint();
		}

		public abstract void Repaint();
	}
}
