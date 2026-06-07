using UnityEngine;

namespace Funly.SkyStudio
{
	public class TransitionBetweenProfiles : MonoBehaviour
	{
		public SkyProfile daySkyProfile;

		public SkyProfile nightSkyProfile;

		[Range(0.1f, 30f)]
		[Tooltip("How long the transition animation will last.")]
		public float transitionDuration;

		public TimeOfDayController timeOfDayController;

		private SkyProfile m_CurrentSkyProfile;

		private void Start()
		{
		}

		public void ToggleSkyProfiles()
		{
		}
	}
}
