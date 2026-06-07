using DG.Tweening;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class WidgetTweenAnimation : IWidgetAnimation
	{
		private Tween _tween;

		public event WidgetAnimationDelegate Complete;

		public WidgetTweenAnimation(Tween tween)
		{
			_tween = tween;
			_tween.OnComplete(delegate
			{
				OnTweenComplete();
			});
		}

		public void Start()
		{
			_tween.Play();
		}

		public void Stop(bool complete)
		{
			_tween.Kill(complete);
		}

		private void OnTweenComplete()
		{
			this.Complete?.Invoke(this);
		}
	}
}
