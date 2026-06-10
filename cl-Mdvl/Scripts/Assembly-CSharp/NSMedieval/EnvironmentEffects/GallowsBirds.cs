using System;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Scripts.Pooler;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	[RequireComponent(typeof(GallowsComponent))]
	public class GallowsBirds : MonoBehaviour
	{
		private const float CirclingBirdsHeight = 10f;

		[SerializeField]
		private GameObject birdsOnGallows;

		[SerializeField]
		private string circlingBirdsPrefabName;

		[SerializeField]
		private string scareBirdsPrefabName;

		[NonSerialized]
		private BaseBuildingInstance gallowsInstance;

		private Vector3 birdsCirclingPosition;

		private HangingEventInstance runningEvent;

		private GameObject circlingParticleObject;

		private void ShowBirdsOnGallows(bool show)
		{
			birdsOnGallows.SetActive(show);
		}

		private void ShowBirdsCircling(bool show)
		{
			if (show)
			{
				circlingParticleObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(circlingBirdsPrefabName, birdsCirclingPosition, autoStop: false);
			}
			else if (!(circlingParticleObject == null))
			{
				MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(circlingParticleObject);
				circlingParticleObject = null;
			}
		}

		public void ShowBirdsScared()
		{
			Vector3 position = birdsOnGallows.transform.position;
			MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(scareBirdsPrefabName, new Vector3(position.x, position.y + 3f, position.z));
		}

		private void OnEventStateChanged(EventState state)
		{
			if (gallowsInstance != null && gallowsInstance.EligibleForEvent())
			{
				switch (state)
				{
				case EventState.NotStarted:
				case EventState.Gathering:
					ShowBirdsCircling(show: true);
					break;
				case EventState.Started:
					ShowBirdsCircling(show: false);
					ShowBirdsOnGallows(show: true);
					break;
				case EventState.Ended:
				case EventState.Disposed:
					Dispose();
					ShowBirdsOnGallows(show: false);
					ShowBirdsScared();
					break;
				default:
					throw new ArgumentOutOfRangeException("state", state, null);
				}
			}
		}

		private void OnEventStarted(PlayerTriggeredEventInstance pte)
		{
			if (!(pte is HangingEventInstance hangingEventInstance))
			{
				return;
			}
			if (gallowsInstance == null)
			{
				gallowsInstance = GetComponent<GallowsComponent>()?.ComponentInstance?.OwnerBuilding;
			}
			if (gallowsInstance != null && hangingEventInstance.HostBuilding == gallowsInstance)
			{
				MapNode node = gallowsInstance.GetNode();
				if (node.Coverage != CoverageType.Roofed && node.WaterLevel == WaterDepthLevel.None)
				{
					runningEvent = hangingEventInstance;
					hangingEventInstance.StateChangedEvent += OnEventStateChanged;
					OnEventStateChanged(EventState.NotStarted);
				}
			}
		}

		private void Start()
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.BirdsEffect)
			{
				Vector3 position = base.transform.position;
				birdsCirclingPosition = new Vector3(position.x, position.y + 10f, position.z);
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent += OnEventStarted;
			}
		}

		private void OnDestroy()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent -= OnEventStarted;
			}
		}

		private void Dispose()
		{
			runningEvent.StateChangedEvent -= OnEventStateChanged;
			ShowBirdsCircling(show: false);
		}
	}
}
