using UnityEngine;

namespace DV.Wheels
{
	public class DriveGearPositionSetter : MonoBehaviour
	{
		public Transform[] transformsToMove;

		private TrainCar car;

		private void Awake()
		{
			car = GetComponentInParent<TrainCar>();
			if (car == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: DriveGearPositionSetter is missing car! Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void LateUpdate()
		{
			if (!car.derailed)
			{
				Transform obj = car.RearBogie.transform;
				Transform transform = car.FrontBogie.transform;
				Vector3 vector = (obj.localPosition + transform.localPosition) * 0.5f;
				Transform[] array = transformsToMove;
				foreach (Transform obj2 in array)
				{
					Vector3 localPosition = obj2.localPosition;
					localPosition.y = vector.y;
					obj2.localPosition = localPosition;
				}
			}
		}
	}
}
