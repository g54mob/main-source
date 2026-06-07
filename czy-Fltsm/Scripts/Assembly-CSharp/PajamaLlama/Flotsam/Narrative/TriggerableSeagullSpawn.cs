using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableSeagullSpawn : ScenarioTriggerableBase, ILandmarkBehaviourProvider
	{
		[Serializable]
		private struct RegionLandmarkBehaviourProvider
		{
			public WorldRegionType Region;

			public LandmarkBehaviourProviderReference LandmarkBehaviourProvider;
		}

		[Header("Spawn Seagull")]
		[SerializeField]
		private RegionLandmarkBehaviourProvider[] _landmarkBehaviourProviders;

		[SerializeReference]
		[SubclassSelector]
		private ILandmarkPickerSettings _landmarkPickerSettings;

		public string Name => "Seagull Spawner";

		public string EditorName => "Seagull Spawner";

		public Sprite EditorIcon => null;

		public float Radius => 0f;

		protected override bool Trigger(AgentDescriptor actor = null)
		{
			if (_landmarkPickerSettings.Spawn(out var landmarkSpawner, this) && landmarkSpawner.LandmarkBehaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.TryReturnAction<LandmarkActionRescue>(out var action, false))
			{
				action.SetLandmarkRescueableActorType(ActorType.Seagull);
				Debug.Log("A seagull was spawned!");
				return true;
			}
			return false;
		}

		public LandmarkBehaviour ReturnLandmarkBehaviour(WorldRegionType region)
		{
			RegionLandmarkBehaviourProvider[] landmarkBehaviourProviders = _landmarkBehaviourProviders;
			for (int i = 0; i < landmarkBehaviourProviders.Length; i++)
			{
				RegionLandmarkBehaviourProvider regionLandmarkBehaviourProvider = landmarkBehaviourProviders[i];
				if (regionLandmarkBehaviourProvider.Region == region)
				{
					LandmarkBehaviourProviderReference landmarkBehaviourProvider = regionLandmarkBehaviourProvider.LandmarkBehaviourProvider;
					return landmarkBehaviourProvider.ReturnLandmarkBehaviour(region);
				}
			}
			return null;
		}

		public MooringPointBase[] ReturnMooringPoints()
		{
			return null;
		}

		public bool ReturnIsInteractable()
		{
			return false;
		}

		public bool ReturnHasLandmarkActionReference<T>() where T : LandmarkAction
		{
			return typeof(T) == typeof(LandmarkActionRescue);
		}

		public bool ReturnIsLandmarkBehaviour(LandmarkBehaviour behaviour)
		{
			return false;
		}
	}
}
