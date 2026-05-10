using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class PopFromGround : MonoBehaviour
	{
		[SerializeField]
		private bool _autoStart;

		[SerializeField]
		private Transform _target;

		[SerializeField]
		protected float _upPosition = -3f;

		[SerializeField]
		protected float _duration = 0.25f;

		[SerializeField]
		protected AnimationCurve _ease = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		protected bool _inverse;

		protected Vector3 _restPosition;

		protected Transform _actualTarget;

		[SerializeField]
		protected UnityEvent Popped;

		protected virtual void Awake()
		{
			_actualTarget = (_target ? _target : base.transform);
			_restPosition = _actualTarget.position;
		}

		private void OnEnable()
		{
			if (_autoStart)
			{
				Pop();
			}
		}

		[Button(null, EButtonEnableMode.Playmode)]
		private void PlayPop()
		{
			Pop();
		}

		public virtual void Pop()
		{
			Popped.Invoke();
			ResetPos();
			if (_inverse)
			{
				_actualTarget.DOMoveY(_restPosition.y + _upPosition, _duration).SetEase(_ease).SetUpdate(isIndependentUpdate: true);
			}
			else
			{
				_actualTarget.DOMoveY(_restPosition.y, _duration).SetEase(_ease).SetUpdate(isIndependentUpdate: true);
			}
		}

		public virtual void ResetPos()
		{
			OnDisable();
			if (_inverse)
			{
				_actualTarget.position = _restPosition;
			}
			else
			{
				_actualTarget.position = _restPosition + Vector3.up * _upPosition;
			}
		}

		private void OnDisable()
		{
			if (base.transform == _actualTarget)
			{
				_actualTarget.DOKill();
			}
		}
	}
}
