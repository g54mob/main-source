using UnityEngine;

namespace Port
{
	public class LighthouseBeam : MonoBehaviour
	{
		[Header("Assignments")]
		[Tooltip("The physical light object that rotates")]
		[SerializeField]
		private Transform lightBulb;

		[Tooltip("The transparent beam mesh (child of light bulb)")]
		[SerializeField]
		private GameObject beamMesh;

		[Header("Rotation")]
		[Tooltip("Degrees per second")]
		[SerializeField]
		private float rotationSpeed;

		[Tooltip("Rotation axis")]
		[SerializeField]
		private Vector3 axis;

		[Header("Schedule")]
		[Tooltip("Hour when beam turns on (e.g. 19 = 7pm)")]
		[SerializeField]
		private int nightStartHour;

		[Tooltip("Hour when beam turns off (e.g. 6 = 6am)")]
		[SerializeField]
		private int nightEndHour;

		private bool isNight;

		private void Update()
		{
		}

		private bool IsNightTime()
		{
			return false;
		}
	}
}
