using FluffyUnderware.Curvy.Controllers;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class E21_VolumeControllerInput : MonoBehaviour
	{
		public float AngularVelocity;

		public ParticleSystem explosionEmitter;

		public VolumeController volumeController;

		public Transform rotatedTransform;

		public float maxSpeed;

		public float accelerationForward;

		public float accelerationBackward;

		private bool mGameOver;

		[UsedImplicitly]
		private void Awake()
		{
		}

		[UsedImplicitly]
		private void Start()
		{
		}

		[UsedImplicitly]
		private void ResetController()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		public void OnCollisionEnter(Collision collision)
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		[UsedImplicitly]
		private void StartOver()
		{
		}
	}
}
