using System;
using CTS.BBT;
using CTS.Core;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Rendering;

namespace CTS
{
	public class TimeScalePostProcess : MonoSingleton<TimeScalePostProcess>
	{
		[SerializeField]
		private Volume _slowVolume;

		[SerializeField]
		private Volume _fastVolume;

		[SerializeField]
		private float _fastTarget = 0.25f;

		[SerializeField]
		private AnimationCurve _slowCurve;

		[SerializeField]
		private float _slowDuration = 3f;

		[SerializeField]
		private AnimationCurve _slowCurveOut;

		[SerializeField]
		private float _slowOutDuration = 1f;

		[SerializeField]
		private AnimationCurve _fastCurve;

		[SerializeField]
		private float _fastDuration = 3f;

		[SerializeField]
		private AnimationCurve _fastCurveOut;

		[SerializeField]
		private float _fastOutDuration = 0.5f;

		private DOGetter<float> _getSlowWeight;

		private DOSetter<float> _setSlowWeight;

		private DOGetter<float> _getFastWeight;

		private DOSetter<float> _setFastWeight;

		private float _previousTimeScale;

		protected override void SingletonAwake()
		{
			_getSlowWeight = () => _slowVolume.weight;
			_setSlowWeight = delegate(float x)
			{
				_slowVolume.weight = x;
			};
			_getFastWeight = () => _fastVolume.weight;
			_setFastWeight = delegate(float x)
			{
				_fastVolume.weight = x;
			};
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			TimeController.OnTimeScaleChanged += OnTimeScaleChanged;
			TimeController instance = MonoSingleton<TimeController>.Instance;
			instance.LockStateChanged = (Action<bool>)Delegate.Combine(instance.LockStateChanged, new Action<bool>(OnTimeControllerActive));
		}

		private void OnDisable()
		{
			TimeController.OnTimeScaleChanged -= OnTimeScaleChanged;
			TimeController instance = MonoSingleton<TimeController>.Instance;
			instance.LockStateChanged = (Action<bool>)Delegate.Remove(instance.LockStateChanged, new Action<bool>(OnTimeControllerActive));
		}

		private void OnTimeControllerActive(bool value)
		{
			if (value)
			{
				OnTimeScaleChanged(MonoSingleton<TimeController>.Instance.GameScale);
				return;
			}
			this.DOKill();
			DOTween.To(_getSlowWeight, _setSlowWeight, 0f, 0.5f).SetTarget(this).SetUpdate(isIndependentUpdate: true)
				.SetEase(_slowCurveOut);
			DOTween.To(_getFastWeight, _setFastWeight, 0f, 0.5f).SetTarget(this).SetUpdate(isIndependentUpdate: true)
				.SetEase(_fastCurveOut);
		}

		private void OnTimeScaleChanged(float scale)
		{
			this.DOKill();
			if (scale > 0f)
			{
				if (!(scale < 1f))
				{
					if (scale == 1f)
					{
						goto IL_0033;
					}
					Sequence sequence = DOTween.Sequence();
					sequence.Append(DOTween.To(_getFastWeight, _setFastWeight, _fastTarget, _fastDuration).SetUpdate(isIndependentUpdate: true).SetEase(_fastCurve));
					sequence.Play().SetUpdate(isIndependentUpdate: true).SetTarget(this);
					DOTween.To(_getSlowWeight, _setSlowWeight, 0f, _slowOutDuration).SetTarget(this).SetUpdate(isIndependentUpdate: true)
						.SetEase(_slowCurveOut);
				}
				else
				{
					Sequence sequence2 = DOTween.Sequence();
					sequence2.Append(DOTween.To(_getSlowWeight, _setSlowWeight, 1f, _slowDuration).SetUpdate(isIndependentUpdate: true).SetEase(_slowCurve));
					sequence2.Append(DOTween.To(_getSlowWeight, _setSlowWeight, 0f, _slowOutDuration).SetUpdate(isIndependentUpdate: true).SetEase(_slowCurveOut));
					sequence2.Play().SetUpdate(isIndependentUpdate: true).SetTarget(this);
					DOTween.To(_getFastWeight, _setFastWeight, 0f, _fastOutDuration).SetTarget(this).SetUpdate(isIndependentUpdate: true)
						.SetEase(_fastCurveOut);
				}
			}
			else if (scale == 0f)
			{
				goto IL_0033;
			}
			goto IL_01d8;
			IL_0033:
			DOTween.To(_getSlowWeight, _setSlowWeight, 0f, _slowOutDuration).SetTarget(this).SetUpdate(isIndependentUpdate: true)
				.SetEase(_slowCurveOut);
			DOTween.To(_getFastWeight, _setFastWeight, 0f, _fastOutDuration).SetTarget(this).SetUpdate(isIndependentUpdate: true)
				.SetEase(_fastCurveOut);
			goto IL_01d8;
			IL_01d8:
			_previousTimeScale = scale;
		}
	}
}
