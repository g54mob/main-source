using UnityEngine;

namespace Placemaker.Props
{
	public class PropClock : MonoBehaviour
	{
		[SerializeField]
		private Transform hour;

		[SerializeField]
		private Transform minute;

		private static int frame;

		private static Quaternion hourQ;

		private static Quaternion minuteQ;

		private void Update()
		{
		}

		private void OnValidate()
		{
		}
	}
}
