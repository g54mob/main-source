using Funly.SkyStudio;
using UnityEngine;

namespace ScheduleOne.FX
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
	public class SkyProfileTransitionTrigger : MonoBehaviour
	{
		public SkyProfile TransitionToOnEnter;

		public SkyProfile TransitionToOnExit;

		public float TransitionDuration;

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}
	}
}
