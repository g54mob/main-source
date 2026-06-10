using NSEipix.Base;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class BirdsScare : MonoBehaviour
	{
		[SerializeField]
		private string scareBirdsParticlesName;

		[Range(0f, 100f)]
		[SerializeField]
		private float birdScareChance;

		[SerializeField]
		private Transform birdsScareLaunchPosition;

		private bool birdsScareFirstTimeLaunch;

		public void LaunchParticlesConditions(PlantMapResourceInstance plant)
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.BirdsEffect && plant != null && !birdsScareFirstTimeLaunch)
			{
				birdsScareFirstTimeLaunch = true;
				Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
				if (!GlobalSaveController.CurrentVillageData.DateAndTime.IsNightTime && season.Index != 3 && plant.CurrentPhase >= 1 && plant.CurrentPhase != plant.Blueprint.LifePhases[plant.CurrentPhase].DeathPhaseIndex && ChanceToSendBirds())
				{
					InstantiateBirds();
				}
			}
		}

		private bool ChanceToSendBirds()
		{
			return (float)Random.Range(1, 100) <= birdScareChance;
		}

		private void InstantiateBirds()
		{
			Vector3 position = ((birdsScareLaunchPosition != null) ? birdsScareLaunchPosition.position : base.transform.position);
			MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(scareBirdsParticlesName, position);
		}
	}
}
