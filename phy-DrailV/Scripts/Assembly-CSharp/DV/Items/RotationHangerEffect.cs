using UnityEngine;

namespace DV.Items
{
	public class RotationHangerEffect : MonoBehaviour, IHangerEffect
	{
		public Vector3 rotationOff;

		public Vector3 rotationOn;

		public Transform target;

		public void SetHanging(bool isHanging)
		{
			target.localRotation = Quaternion.Euler(isHanging ? rotationOn : rotationOff);
		}
	}
}
