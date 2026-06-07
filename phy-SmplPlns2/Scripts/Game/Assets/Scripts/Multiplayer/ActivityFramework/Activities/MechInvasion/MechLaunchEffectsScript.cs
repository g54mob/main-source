using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.MechInvasion
{
	public class MechLaunchEffectsScript : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _landingAudio;

		[SerializeField]
		private ParticleSystem _trail;

		[SerializeField]
		private AudioSource _trailAudio;

		public AudioSource LandingAudio => _landingAudio;

		public bool MechLanded { get; private set; }

		public ParticleSystem Trail => _trail;

		public AudioSource TrailAudio => _trailAudio;

		public void OnLaunchUpdate(float launchProgress)
		{
			if (launchProgress >= 1f && !MechLanded)
			{
				OnMechLanded();
			}
		}

		public void OnMechLaunched(float launchProgress)
		{
			_trailAudio.Play();
		}

		public void OnMechSpawned()
		{
			if (!MechLanded)
			{
				OnMechLanded();
			}
			ParticleSystem.EmissionModule emission = _trail.emission;
			emission.enabled = false;
			Object.Destroy(_trail.gameObject, 20f);
		}

		private void OnMechLanded()
		{
			MechLanded = true;
			_trailAudio.Stop();
			_landingAudio.Play();
		}
	}
}
