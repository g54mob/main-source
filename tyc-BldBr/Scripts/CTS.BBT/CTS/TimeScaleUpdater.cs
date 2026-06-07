using DG.Tweening;
using DG.Tweening.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class TimeScaleUpdater : MonoBehaviour
	{
		[SerializeField]
		private float _endValue = 5f;

		[SerializeField]
		private float _duration = 9f;

		[SerializeField]
		private AnimationCurve _curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		private DOGetter<float> _getter;

		private DOSetter<float> _setter;

		private void Awake()
		{
			_getter = () => Time.timeScale;
			_setter = delegate(float f)
			{
				Time.timeScale = f;
			};
		}

		[Button(null, EButtonEnableMode.Playmode)]
		public void Play()
		{
			DOTween.Kill(this);
			DOTween.To(_getter, _setter, _endValue, _duration).SetEase(_curve).SetUpdate(isIndependentUpdate: true);
		}
	}
}
