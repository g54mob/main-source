using CTS.Core;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace CTS
{
	public class ObjectSwapUpdater : CTSBehaviour
	{
		[SerializeField]
		private float _duration = 0.25f;

		[SerializeField]
		private AnimationCurve _ease = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private float _targetValue;

		[SerializeField]
		private bool _useUnscaledTime;

		private float _startValue;

		[Inject(false)]
		private ISwap _swapper;

		private DOGetter<float> _percentGetter;

		private DOSetter<float> _percentSetter;

		protected override void OnAwake()
		{
			base.OnAwake();
			_percentGetter = () => _swapper.GetCurrentPercent();
			_percentSetter = delegate(float f)
			{
				_swapper.SwapByPercent(f);
			};
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_swapper.SwapByPercent(_swapper.GetStartPercent());
			DOTween.To(_percentGetter, _percentSetter, _targetValue, _duration).SetTarget(_swapper).SetEase(_ease)
				.SetUpdate(_useUnscaledTime);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			DOTween.Kill(_swapper);
		}
	}
}
