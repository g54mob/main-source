using DG.Tweening.Timeline.Core;

namespace DG.Tweening.Timeline
{
	public class DOTweenClipVariantComponent : DOTweenClipComponentBase
	{
		public DOTweenClipVariant clipVariant;

		internal override DOTweenClipBase clipBase => null;

		private void Start()
		{
		}
	}
}
