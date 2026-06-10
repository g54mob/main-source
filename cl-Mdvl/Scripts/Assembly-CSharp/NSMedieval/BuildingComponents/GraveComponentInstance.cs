using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("GraveComponentInstance", "")]
	public class GraveComponentInstance : BaseComponentInstance
	{
		[SerializeField]
		private Storage graveStorage;

		[SerializeField]
		private List<string> allowedBodies = new List<string>();

		[SerializeField]
		private string bodyName;

		[NonSerialized]
		private GraveComponentBlueprint blueprint;

		public GraveComponentBlueprint Blueprint => blueprint;

		public List<string> AllowedBodies => allowedBodies;

		public event Action AddBodyEvent;

		public GraveComponentInstance(BaseBuildingInstance ownerBuilding, GraveComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			graveStorage = new Storage(new StorageBase(1, ignoreWeigth: true));
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				graveStorage?.GetSingleResource()?.Stats?.Controller.RemoveListener(OnFreshnessDepleted);
				this.AddBodyEvent = null;
				DropBody();
				base.Map.GraveComponentManager.RemoveFromCache(this);
				graveStorage?.Dispose();
				graveStorage = null;
				base.Dispose();
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			base.SetupAfterLoading(baseBuildingInstance);
			foreach (ResourceInstance resource in graveStorage.Resources)
			{
				ResourceStatsProducer.ProduceResourceStats(resource, resource.Blueprint, resource.Stats);
			}
			graveStorage.SetResourcesOwner();
		}

		public LinkedList<LifeEventLogStruct> GetLifeEventLogs()
		{
			if (!Empty() && graveStorage.GetSingleResource() is CarcassResourceInstance carcassResourceInstance)
			{
				return carcassResourceInstance.LifeEventLogs;
			}
			return null;
		}

		public bool Empty()
		{
			return graveStorage.IsEmpty();
		}

		public bool HasFreeSpace()
		{
			return graveStorage.GetFreeSpace() > 0f;
		}

		public bool CanStore(CarcassResourceInstance carcassResourceInstance)
		{
			if (HasBody())
			{
				return false;
			}
			if (!HasFreeSpace())
			{
				return false;
			}
			return allowedBodies.Contains(carcassResourceInstance.BodyType);
		}

		public void AddBody(CarcassResourceInstance body)
		{
			graveStorage.Add(body, 1);
			bodyName = body.GetName();
			this.AddBodyEvent?.Invoke();
			body.Stats.Controller.RegisterListener(StatEventType.MinimumValueReached, StatType.Freshness, OnFreshnessDepleted);
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool underWater = waterDepthLevel != WaterDepthLevel.None;
			base.OwnerBuilding.SetUnderWater(underWater);
		}

		private void DropBody()
		{
			if (LoadingController.IsSceneTransition || Empty())
			{
				return;
			}
			bodyName = string.Empty;
			if (GetBody(out var body))
			{
				StatInstance statInstance = body.Stats?.GetStat(StatType.Health);
				body.Stats?.Controller.RemoveListener(OnFreshnessDepleted);
				if (statInstance != null && !statInstance.IsAtMinimum())
				{
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(body.Clone(), GetPosition());
					graveStorage.ClearAll(isSilent: true);
				}
			}
			else
			{
				ResourceInstance singleResource = graveStorage.GetSingleResource();
				if (singleResource != null)
				{
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(singleResource.Clone(), GetPosition());
					graveStorage.ClearAll(isSilent: true);
				}
			}
		}

		public string GetBodyName()
		{
			if (!string.IsNullOrEmpty(bodyName))
			{
				return bodyName;
			}
			return MonoSingleton<LocalizationController>.Instance.GetText("general_empty");
		}

		public bool GetBody(out CarcassResourceInstance body)
		{
			body = null;
			if (graveStorage.IsEmpty())
			{
				return false;
			}
			if (!(graveStorage.GetSingleResource() is CarcassResourceInstance carcassResourceInstance))
			{
				return false;
			}
			body = carcassResourceInstance;
			return true;
		}

		public void AllowBody(string bodyID)
		{
			if (!allowedBodies.Contains(bodyID))
			{
				allowedBodies.Add(bodyID);
			}
		}

		public void ForbidBody(string bodyID)
		{
			if (allowedBodies.Contains(bodyID))
			{
				allowedBodies.Remove(bodyID);
			}
		}

		public bool HasBody()
		{
			return !graveStorage.IsEmpty();
		}

		private void OnFreshnessDepleted(object stat)
		{
			if (!base.HasDisposed)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(HandleRot);
			}
		}

		private void HandleRot()
		{
			if (!LoadingController.IsSceneTransition && !base.HasDisposed && graveStorage.GetSingleResource() is CarcassResourceInstance carcassResourceInstance)
			{
				string rottenId = carcassResourceInstance.Blueprint.RottenId;
				carcassResourceInstance.Stats.Controller.RemoveListener(OnFreshnessDepleted);
				if (!string.IsNullOrEmpty(rottenId))
				{
					ResourceInstance resourceInstance = new ResourceInstance(Repository<ResourceRepository, Resource>.Instance.GetByID(rottenId), 1);
					resourceInstance.GetStat(StatType.Health).SetCurrent(carcassResourceInstance.GetStatValue(StatType.Health));
					graveStorage.DeleteResource(carcassResourceInstance);
					graveStorage.Add(resourceInstance, 1);
				}
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("graveStorage", graveStorage);
			serializer.Write("allowedBodies", allowedBodies);
			serializer.Write("bodyName", bodyName);
		}

		public GraveComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<GraveComponentRepository, GraveComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Graves\\GraveComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in GraveComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				graveStorage = deserializer.ReadObject<Storage>("graveStorage");
				allowedBodies = deserializer.ReadStringList("allowedBodies");
				bodyName = deserializer.ReadString("bodyName");
				if (string.IsNullOrEmpty(bodyName) && graveStorage.GetSingleResource() is CarcassResourceInstance carcassResourceInstance)
				{
					bodyName = carcassResourceInstance.GetName();
				}
			}
		}
	}
}
