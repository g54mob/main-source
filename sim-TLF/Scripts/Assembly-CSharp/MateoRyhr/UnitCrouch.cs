using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class UnitCrouch : MonoBehaviour
	{
		[SerializeField]
		private CapsuleCollider _collider;

		[SerializeField]
		private FloatVariable _crochingHeightProportion;

		[SerializeField]
		private FloatVariable _time;

		[SerializeField]
		private AnimationCurve _curve;

		private float _standingHeight;

		private float _crouchingHeight;

		private float _yAxisOffsetProportion;

		private bool _isStanding;

		public UnityEvent CrouchEvent;

		public UnityEvent StandUpEvent;

		private void Start()
		{
			_isStanding = true;
			_standingHeight = _collider.height;
			_yAxisOffsetProportion = _collider.center.y / _collider.height;
			_crouchingHeight = _collider.height * _crochingHeightProportion.Value;
		}

		public void CrouchOrStand()
		{
			if (_isStanding)
			{
				Crouch();
			}
			else
			{
				StandUp();
			}
		}

		public void Crouch()
		{
			if (_isStanding)
			{
				_isStanding = false;
				this.LerpFloat(_collider.height, _crouchingHeight, _time.Value, ModifyHeight, fixedUpdate: true, _curve);
				CrouchEvent?.Invoke();
			}
		}

		public void StandUp()
		{
			if (!_isStanding)
			{
				_isStanding = true;
				this.LerpFloat(_collider.height, _standingHeight, _time.Value, ModifyHeight, fixedUpdate: true, _curve);
				StandUpEvent?.Invoke();
			}
		}

		private void ModifyHeight(float newHeight)
		{
			_collider.height = newHeight;
			_collider.center = new Vector3(_collider.center.x, newHeight * _yAxisOffsetProportion, _collider.center.z);
		}
	}
}
