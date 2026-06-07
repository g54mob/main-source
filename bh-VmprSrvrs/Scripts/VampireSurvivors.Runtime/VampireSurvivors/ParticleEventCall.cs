using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivors
{
	public class ParticleEventCall : MonoBehaviour
	{
		[Tooltip("Time in seconds after which the event will be triggered (EventTriggerTime).")]
		public float EventTriggerTime;

		[Tooltip("The UnityEvent to invoke after the specified time.")]
		public UnityEvent onEventTriggered;

		[SerializeField]
		private bool CallEventsOnParticleSystemStopped;

		[HideInInspector]
		public UnityEvent OnParticleSystemStoppedEvent;

		private ParticleSystem _particleSystem;

		private bool _eventCalled;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void CallEvents()
		{
		}

		public void RestartEventTimer()
		{
		}

		private void OnParticleSystemStopped()
		{
		}

		private void PlayFX()
		{
		}

		private void StopFX()
		{
		}
	}
}
