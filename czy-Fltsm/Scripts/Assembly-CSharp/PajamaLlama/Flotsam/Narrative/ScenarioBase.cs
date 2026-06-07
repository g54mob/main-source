using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using M4.Session;
using PajamaLlama.Flotsam.World;
using UnityEngine;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.Narrative
{
	public abstract class ScenarioBase : PersistentProperties
	{
		[Serializable]
		public abstract class PersistentDataBase : IScenarioPersistentData
		{
			[OptionalField(VersionAdded = 1)]
			private readonly int _propertiesIndex = -1;

			[OptionalField(VersionAdded = 1)]
			private readonly ScenarioWorldTileProvider.QueuedWorldTilePersistentData[] _queuedWorldTiles;

			[OptionalField(VersionAdded = 2)]
			private readonly List<long> _triggered = new List<long>();

			public int ScenarioIndex => _propertiesIndex;

			public PersistentDataBase(ScenarioBase instance)
			{
				_propertiesIndex = instance.GetIndex();
				IReadOnlyList<ScenarioWorldTileProvider.QueuedWorldTile> queuedWorldTiles = instance._worldTilesProvider.QueuedWorldTiles;
				long[] managedReferenceIds = ManagedReferenceUtility.GetManagedReferenceIds(instance);
				foreach (long num in managedReferenceIds)
				{
					if (ManagedReferenceUtility.GetManagedReference(instance, num) is ScenarioTriggerableBase { WasTriggered: not false })
					{
						_triggered.Add(num);
					}
				}
				if (!queuedWorldTiles.IsNullOrEmpty())
				{
					_queuedWorldTiles = new ScenarioWorldTileProvider.QueuedWorldTilePersistentData[queuedWorldTiles.Count];
					for (int j = 0; j < _queuedWorldTiles.Length; j++)
					{
						_queuedWorldTiles[j] = new ScenarioWorldTileProvider.QueuedWorldTilePersistentData(queuedWorldTiles[j]);
					}
				}
			}

			public virtual ScenarioBase Restore(PrototypeScenario fallbackScenario = null)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<ScenarioBase>(ScenarioIndex, out var reference))
				{
					ScenarioBase instance = reference.GetInstance();
					instance.Restored = true;
					RestoreQueuedWorldTiles(instance);
					RestoreTriggerables(instance);
					return instance;
				}
				return null;
			}

			protected void RestoreQueuedWorldTiles(ScenarioBase instance)
			{
				if (!_queuedWorldTiles.IsNullOrEmpty())
				{
					instance._worldTilesProvider.Restore(_queuedWorldTiles);
				}
			}

			protected void RestoreTriggerables(ScenarioBase instance)
			{
				if (_triggered.IsNullOrEmpty())
				{
					return;
				}
				foreach (long item in _triggered)
				{
					if (ManagedReferenceUtility.GetManagedReference(instance, item) is ScenarioTriggerableBase scenarioTriggerableBase)
					{
						scenarioTriggerableBase.RestoreWasTriggered();
					}
				}
			}
		}

		[SerializeField]
		private ScenarioBase _successor;

		[SerializeField]
		private ScenarioWorldTileProvider _worldTilesProvider = new ScenarioWorldTileProvider();

		public override Types Type => Types.Scenario;

		protected global::World World { get; private set; }

		public ScenarioWorldTileProvider WorldTileProvider => _worldTilesProvider;

		public bool Restored { get; private set; }

		public virtual void Update()
		{
		}

		public virtual void LateUpdate()
		{
		}

		public new ScenarioBase GetInstance()
		{
			return base.GetInstance() as ScenarioBase;
		}

		public void Start()
		{
			GameManager.WorldManager.World.SetWorldTileProvider(WorldTileProvider);
			OnRegionEntered();
			GameEventDispatcher.AddListener(GameEventType.RegionEntered, OnRegionEntered);
			if (!Restored)
			{
				OnFirstStart();
			}
			else
			{
				Community.PlayerCommunity?.QueueGlobalProjects(GameSettings.Instance.ProjectSettings);
			}
			OnStart();
		}

		public virtual void OnFirstStart()
		{
		}

		protected abstract void OnStart();

		public virtual void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.RegionEntered, OnRegionEntered);
		}

		public virtual void QueueWorldTile(TileGeneratorBase worldTile, int indexOffset = 0, int minimumIndex = 0)
		{
			_worldTilesProvider.QueueWorldTile(worldTile, indexOffset, minimumIndex);
		}

		protected virtual void OnRegionEntered(GameEvent gameEvent = null)
		{
			if (GameManager.WorldManager.CurrentRegion.TryReturnScoutingLandmark(out var scoutingLandmark) && scoutingLandmark.ScoutingState < ScoutingState.Rumored)
			{
				scoutingLandmark.SetScoutingState(ScoutingState.Rumored);
			}
		}

		protected void SpawnTownheartAndStartingResources()
		{
			if (Construction.Townheart != null)
			{
				return;
			}
			Vector3 positionTownheart = GameManager.Settings.SessionSettings.StartingScenario.PositionTownheart;
			Buildable buildable = ((!Session.Profile.ActiveRun.TownheartProperties) ? GameManager.Settings.SessionSettings.StartingScenario.Townheart : Session.Profile.ActiveRun.TownheartProperties.Prefab);
			Buildable buildable2 = Buildable.Place(buildable, positionTownheart, Quaternion.identity, 0, instantPlacement: true);
			if (buildable2.TryReturnBuildableExtendable<MooringPoint>(out var buildableExtendable))
			{
				buildableExtendable.SpawnStartingBoat();
			}
			Construction.Townheart = buildable2.ReturnExtendable<Construction>();
			List<CountedItemProperty> startingResources = GameManager.Settings.SessionSettings.StartingScenario.StartingResources;
			for (int i = 0; i < startingResources.Count; i++)
			{
				CountedItemProperty countedItemProperty = startingResources[i];
				for (int j = 0; j < countedItemProperty.Amount; j++)
				{
					Community.PlayerCommunity.SpawnItemToAvailableStorage(countedItemProperty.ItemProperties);
				}
			}
		}

		public bool TryGetSuccessor(out ScenarioBase successor)
		{
			successor = _successor;
			return successor != null;
		}

		public abstract IScenarioPersistentData GetPersistentData();
	}
}
