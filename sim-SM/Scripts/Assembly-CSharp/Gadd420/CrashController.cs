using UnityEngine;

namespace Gadd420
{
	public class CrashController : MonoBehaviour
	{
		private RB_Controller rbScript;

		public bool isCrashed;

		public string[] crashTag;

		private Rigidbody rb;

		[HideInInspector]
		public float rbSpeed;

		[HideInInspector]
		public float lateRbSpeed;

		private float counter;

		public float decelerationSpeedForCrash;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}
	}
}
