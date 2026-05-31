using UnityEngine;

namespace Gadd420
{
	public class NitrousManager : MonoBehaviour
	{
		[HideInInspector]
		public bool isBoosting;

		[Header("Either Torque or Force Depending on Forward Force")]
		public float nitrousPower;

		[Header("Nitrous Adds Torque if this is false")]
		public bool forwardForce;

		[Header("Time in Seconds")]
		public float timeToEmptyTank;

		public float timeToRefil;

		public int numberOfTanks;

		[Header("So you're not forced to use all the nitrous at once")]
		public bool saveNitrous;

		[Header("Effects")]
		public GameObject vfx;

		public AudioSource nitrousSFX;

		private bool isHoldingNitrous;

		private float ogTimeToRefilTanks;

		[HideInInspector]
		public float ogTimeToEmptyTanks;

		private float ogNoTanks;

		private bool startBoost;

		public bool hasNitrous;

		private RB_Controller rbScript;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void HoldNitrous()
		{
		}

		private void BoostNitrous()
		{
		}

		private void NitrousRefil()
		{
		}
	}
}
