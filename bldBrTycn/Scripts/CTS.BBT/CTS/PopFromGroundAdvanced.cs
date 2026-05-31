using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class PopFromGroundAdvanced : PopFromGround
	{
		[SerializeField]
		private Vector3 _scalePunch = Vector3.one;

		[SerializeField]
		private AnimationCurve _scaleYCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private AnimationCurve _scaleXZCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		private Vector3 _restScale;

		protected override void Awake()
		{
			base.Awake();
			_restScale = base.transform.localScale;
		}

		public override void Pop()
		{
			Popped.Invoke();
			ResetPos();
			if (_inverse)
			{
				_actualTarget.DOMoveY(_restPosition.y + _upPosition, _duration).SetEase(_ease).SetUpdate(isIndependentUpdate: true);
				_actualTarget.DOScaleY(0f, _duration).SetEase(_scaleYCurve).SetUpdate(isIndependentUpdate: true);
				_actualTarget.DOScaleX(0f, _duration).SetEase(_scaleXZCurve).SetUpdate(isIndependentUpdate: true);
				_actualTarget.DOScaleZ(0f, _duration).SetEase(_scaleXZCurve).SetUpdate(isIndependentUpdate: true);
			}
			else
			{
				_actualTarget.DOMoveY(_restPosition.y, _duration).SetEase(_ease).SetUpdate(isIndependentUpdate: true);
				_actualTarget.DOPunchScale(_scalePunch, _duration).SetEase(_scaleYCurve).SetUpdate(isIndependentUpdate: true);
			}
		}

		public override void ResetPos()
		{
			base.ResetPos();
			_actualTarget.localScale = _restScale;
		}
	}
}
