using System;
using CTS.Core;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Rendering;

namespace CTS.Utilities
{
	public class VolumeTween : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Volume _volume;

		[SerializeField]
		private float _tweenDuration = 0.25f;

		private DOGetter<float> _getter;

		private DOSetter<float> _setter;

		protected override void OnAwake()
		{
			base.OnAwake();
			_getter = () => _volume.weight;
			_setter = delegate(float value)
			{
				_volume.weight = value;
			};
		}

		public void SetValue(float value)
		{
			float num = Math.Abs(value - _volume.weight);
			if (!(num <= float.Epsilon))
			{
				_volume.DOKill();
				if (num < 0.025f)
				{
					_volume.weight = value;
					return;
				}
				float duration = num * _tweenDuration;
				DOTween.To(_getter, _setter, value, duration).SetUpdate(isIndependentUpdate: true).SetTarget(_volume);
			}
		}

		public void Show()
		{
			SetValue(1f);
		}

		public void Hide()
		{
			SetValue(0f);
		}
	}
}
