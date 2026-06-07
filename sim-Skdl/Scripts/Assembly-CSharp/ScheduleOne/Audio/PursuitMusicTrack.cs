using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Audio
{
	public class PursuitMusicTrack : MusicTrack
	{
		private const float OutOfSightTimeToDipMusic = 8f;

		private const float MinMusicVolume = 0.6f;

		private const float MusicChangeRate_Down = 0.04f;

		private const float MusicChangeRate_Up = 2f;

		[SerializeField]
		private PlayerCrimeData.EPursuitLevel _pursuitLevelToActivate;

		protected virtual void Start()
		{
		}

		private void OnLoadComplete()
		{
		}

		private void RegisterEvent()
		{
		}

		protected override void Update()
		{
		}

		private void PursuitLevelChange(PlayerCrimeData.EPursuitLevel oldLevel, PlayerCrimeData.EPursuitLevel newLevel)
		{
		}

		private float GetNewVolume()
		{
			return 0f;
		}
	}
}
