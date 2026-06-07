using DG.Tweening.Timeline.Core;

namespace DG.Tweening.Timeline
{
	public class DOTweenClipComponent : DOTweenClipComponentBase
	{
		public DOTweenClip clip;

		internal override DOTweenClipBase clipBase => null;

		private void Start()
		{
		}
	}
}
