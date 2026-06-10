using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Views.Resources;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class CarcassBirds : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 100f)]
		private int sendBirdsPercent;

		[SerializeField]
		private string birdsPrefabName;

		[SerializeField]
		private GameObject eatingBirds;

		[SerializeField]
		private string eatingBirdsScareName;

		[SerializeField]
		private int eatingBirdsDurationHours = 3;

		private Vector3 birdsPosition;

		[NonSerialized]
		private ResourcePileInstance pile;

		[NonSerialized]
		private CreatureBase creatureBase;

		private int eatingBirdsDurationHoursPassed;

		private void SendCarcassBirds()
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.BirdsEffect && !EatingBirdsDuration() && !CombatUtils.IsNullOrDisposed(pile) && !GlobalSaveController.CurrentVillageData.DateAndTime.IsNightTime && !pile.Map.HomeArea.IsHomeArea(pile.GridDataPosition))
			{
				MapNode node = pile.GetNode();
				if (node.Coverage != CoverageType.Roofed && node.WaterLevel == WaterDepthLevel.None && ChanceToSendBirds())
				{
					InstantiateBirds();
				}
			}
		}

		private bool ChanceToSendBirds()
		{
			return UnityEngine.Random.Range(1, 100) <= sendBirdsPercent;
		}

		private void InstantiateBirds()
		{
			switch (UnityEngine.Random.Range(0, 2))
			{
			case 0:
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(birdsPrefabName, birdsPosition);
				break;
			case 1:
				eatingBirds.SetActive(value: true);
				break;
			case 2:
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(birdsPrefabName, birdsPosition);
				eatingBirds.SetActive(value: true);
				break;
			}
		}

		public void ScareEatingBirds()
		{
			if (!(eatingBirds == null) && eatingBirds.activeSelf)
			{
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(eatingBirdsScareName, eatingBirds.transform.position);
				eatingBirdsDurationHoursPassed = 0;
				eatingBirds.SetActive(value: false);
			}
		}

		private bool EatingBirdsDuration()
		{
			if (!eatingBirds.activeSelf)
			{
				return false;
			}
			eatingBirdsDurationHoursPassed++;
			bool num = eatingBirdsDurationHoursPassed >= eatingBirdsDurationHours;
			if (num)
			{
				ScareEatingBirds();
			}
			return num;
		}

		private void Start()
		{
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += SendCarcassBirds;
			MonoSingleton<OptionsController>.Instance.BirdsDisableEvent += ScareEatingBirds;
			Vector3 position = base.transform.position;
			birdsPosition = new Vector3(position.x, position.y + 20f, position.z);
			if (TryGetComponent<ResourcePileView>(out var component))
			{
				pile = component.ResourcePileInstance;
			}
		}

		private void OnDestroy()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= SendCarcassBirds;
			}
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.BirdsDisableEvent -= ScareEatingBirds;
			}
			pile = null;
			creatureBase = null;
		}
	}
}
