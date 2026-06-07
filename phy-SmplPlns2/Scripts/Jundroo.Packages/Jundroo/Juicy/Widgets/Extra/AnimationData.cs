using DG.Tweening;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class AnimationData
	{
		public float Delay { get; set; }

		public float Duration { get; set; }

		public EaseType Ease { get; set; }

		public string From { get; set; }

		public LoopType LoopType { get; set; }

		public int NumLoops { get; set; }

		public float Overshoot { get; set; }

		public string Target { get; set; }

		public void ApplyEase(Tweener tween)
		{
			if (Ease == EaseType.Step)
			{
				EaseFunction customEase = (float time, float duration, float overshootOrAmplitude, float period) => (!(time < duration / 2f)) ? 1f : 0f;
				tween.SetEase(customEase);
			}
			else
			{
				tween.SetEase(ConvertEaseType(Ease), Overshoot);
			}
		}

		private static Ease ConvertEaseType(EaseType juicyEaseType)
		{
			return juicyEaseType switch
			{
				EaseType.Linear => DG.Tweening.Ease.Linear, 
				EaseType.InSine => DG.Tweening.Ease.InSine, 
				EaseType.OutSine => DG.Tweening.Ease.OutSine, 
				EaseType.InOutSine => DG.Tweening.Ease.InOutSine, 
				EaseType.InQuad => DG.Tweening.Ease.InQuad, 
				EaseType.OutQuad => DG.Tweening.Ease.OutQuad, 
				EaseType.InOutQuad => DG.Tweening.Ease.InOutQuad, 
				EaseType.InCubic => DG.Tweening.Ease.InCubic, 
				EaseType.OutCubic => DG.Tweening.Ease.OutCubic, 
				EaseType.InOutCubic => DG.Tweening.Ease.InOutCubic, 
				EaseType.InQuart => DG.Tweening.Ease.InQuart, 
				EaseType.OutQuart => DG.Tweening.Ease.OutQuart, 
				EaseType.InOutQuart => DG.Tweening.Ease.InOutQuart, 
				EaseType.InQuint => DG.Tweening.Ease.InQuint, 
				EaseType.OutQuint => DG.Tweening.Ease.OutQuint, 
				EaseType.InOutQuint => DG.Tweening.Ease.InOutQuint, 
				EaseType.InExpo => DG.Tweening.Ease.InExpo, 
				EaseType.OutExpo => DG.Tweening.Ease.OutExpo, 
				EaseType.InOutExpo => DG.Tweening.Ease.InOutExpo, 
				EaseType.InCirc => DG.Tweening.Ease.InCirc, 
				EaseType.OutCirc => DG.Tweening.Ease.OutCirc, 
				EaseType.InOutCirc => DG.Tweening.Ease.InOutCirc, 
				EaseType.InElastic => DG.Tweening.Ease.InElastic, 
				EaseType.OutElastic => DG.Tweening.Ease.OutElastic, 
				EaseType.InOutElastic => DG.Tweening.Ease.InOutElastic, 
				EaseType.InBack => DG.Tweening.Ease.InBack, 
				EaseType.OutBack => DG.Tweening.Ease.OutBack, 
				EaseType.InOutBack => DG.Tweening.Ease.InOutBack, 
				EaseType.InBounce => DG.Tweening.Ease.InBounce, 
				EaseType.OutBounce => DG.Tweening.Ease.OutBounce, 
				EaseType.InOutBounce => DG.Tweening.Ease.InOutBounce, 
				EaseType.Flash => DG.Tweening.Ease.Flash, 
				EaseType.InFlash => DG.Tweening.Ease.InFlash, 
				EaseType.OutFlash => DG.Tweening.Ease.OutFlash, 
				EaseType.InOutFlash => DG.Tweening.Ease.InOutFlash, 
				_ => DG.Tweening.Ease.Unset, 
			};
		}
	}
}
