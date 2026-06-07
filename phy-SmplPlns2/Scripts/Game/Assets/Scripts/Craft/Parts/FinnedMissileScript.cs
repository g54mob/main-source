using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class FinnedMissileScript : MonoBehaviour
	{
		[SerializeField]
		private float _deployFinDelay = 0.5f;

		[SerializeField]
		private float _deployWingDelay = 0.25f;

		[SerializeField]
		private Vector3 _finLeftDeployedRotation = Vector3.zero;

		[SerializeField]
		private Transform _finLeftRear;

		[SerializeField]
		private Vector3 _finRightDeployedRotation = Vector3.zero;

		[SerializeField]
		private Transform _finRightRear;

		[SerializeField]
		private Vector3 _finTopDeployedRotation = Vector3.zero;

		[SerializeField]
		private Transform _finTopRear;

		private bool _firstFrame = true;

		private MissileScript _missile;

		private float _timeSinceFired;

		[SerializeField]
		private Transform _wingLeft;

		[SerializeField]
		private Vector3 _wingLeftDeployedRotation = Vector3.zero;

		[SerializeField]
		private Transform _wingRight;

		[SerializeField]
		private Vector3 _wingRightDeployedRotation = Vector3.zero;

		protected virtual void LateUpdate()
		{
			if (_firstFrame)
			{
				FirstFrameLateUpdate();
				_firstFrame = false;
			}
		}

		protected virtual void Update()
		{
			if (_missile == null || PauseManager.Paused || _missile.LoadContext != CraftLoadContext.Flight || !_missile.Fired)
			{
				return;
			}
			_timeSinceFired += Time.deltaTime;
			if (_timeSinceFired >= _deployWingDelay)
			{
				_wingLeft.localRotation = Quaternion.RotateTowards(_wingLeft.localRotation, Quaternion.Euler(_wingLeftDeployedRotation), Time.deltaTime * 200f);
				_wingRight.localRotation = Quaternion.RotateTowards(_wingRight.localRotation, Quaternion.Euler(_wingRightDeployedRotation), Time.deltaTime * 200f);
				if (!_missile.OutOfFuel)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, 0f), Time.deltaTime);
				}
			}
			if (_timeSinceFired >= _deployFinDelay)
			{
				_finTopRear.localRotation = Quaternion.RotateTowards(_finTopRear.localRotation, Quaternion.Euler(_finTopDeployedRotation), Time.deltaTime * 200f);
				_finRightRear.localRotation = Quaternion.RotateTowards(_finRightRear.localRotation, Quaternion.Euler(_finRightDeployedRotation), Time.deltaTime * 200f);
				_finLeftRear.localRotation = Quaternion.RotateTowards(_finLeftRear.localRotation, Quaternion.Euler(_finLeftDeployedRotation), Time.deltaTime * 200f);
			}
		}

		private void FirstFrameLateUpdate()
		{
			_missile = GetComponent<MissileScript>();
		}
	}
}
