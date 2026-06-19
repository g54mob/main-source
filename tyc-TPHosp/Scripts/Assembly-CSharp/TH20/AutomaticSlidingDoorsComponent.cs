using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AutomaticSlidingDoorsComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform _leftDoor;

		[SerializeField]
		private Transform _rightDoor;

		private int _containedCharacters;

		private float _openAmount;

		private float _openVelocity;

		[SerializeField]
		private float _openTime = 2f;

		[SerializeField]
		private float _openDistance = 2f;

		private float _leftOriginalX;

		private float _rightOriginalX;

		private void Awake()
		{
			_leftOriginalX = _leftDoor.localPosition.x;
			_rightOriginalX = _rightDoor.localPosition.x;
		}

		public void OnCharacterEnter()
		{
			if (_containedCharacters == 0)
			{
				AudioManager.Instance.Play("DoorOpen:Sliding", base.gameObject);
			}
			_containedCharacters++;
		}

		public void OnCharacterExit()
		{
			_containedCharacters--;
			if (_containedCharacters == 0)
			{
				AudioManager.Instance.Play("DoorClose:Sliding", base.gameObject);
			}
		}

		private void Update()
		{
			bool flag = _containedCharacters > 0;
			_openAmount = ((Time.deltaTime <= 0f) ? _openAmount : Mathf.SmoothDamp(_openAmount, flag ? 1f : 0f, ref _openVelocity, _openTime, float.PositiveInfinity, Time.deltaTime));
			_openAmount = Mathf.Clamp01(_openAmount);
			float x = Mathf.Lerp(_leftOriginalX, _leftOriginalX - _openDistance, _openAmount);
			float x2 = Mathf.Lerp(_rightOriginalX, _rightOriginalX + _openDistance, _openAmount);
			_leftDoor.localPosition = new Vector3(x, _leftDoor.localPosition.y, _leftDoor.localPosition.z);
			_rightDoor.localPosition = new Vector3(x2, _leftDoor.localPosition.y, _leftDoor.localPosition.z);
		}
	}
}
