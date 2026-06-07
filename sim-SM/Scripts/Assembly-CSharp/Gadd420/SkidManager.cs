using UnityEngine;

namespace Gadd420
{
	public class SkidManager : MonoBehaviour
	{
		public bool enableSkidSettings;

		public bool frontWheelSkids;

		[Range(0f, 1f)]
		public float minForwadSlipForSkid;

		[Range(0f, 1f)]
		public float minSidewaysSlipForSkid;

		private RB_Controller rbController;

		public Transform skidTrail;

		private Transform[] skidTrails;

		public ParticleSystem smokePrefab;

		private ParticleSystem[] skidSmoke;

		public AudioSource skidSound;

		public float soundStopDelay;

		public float skidMarkStopDelay;

		private float soundTimer;

		private float skidMarkTimer;

		public void StartSkidTrail(int i)
		{
		}

		public void EndSkidTrail(int i)
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void CheckForSkid()
		{
		}
	}
}
