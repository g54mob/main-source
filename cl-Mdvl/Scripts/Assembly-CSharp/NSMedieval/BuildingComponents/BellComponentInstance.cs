using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Serialization;
using NSMedieval.Sound;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("BellComponentInstance", "")]
	public class BellComponentInstance : BaseComponentInstance
	{
		private BellComponentBlueprint blueprint;

		private readonly HashSet<int> rallyPointIds;

		public string Name { get; set; }

		public bool IsActivated { get; private set; }

		public BellComponentInstance(BaseBuildingInstance ownerBuilding, BellComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), BuildingType.Decoration)
		{
			this.blueprint = blueprint;
			string text = MonoSingleton<LocalizationController>.Instance.GetText("bell_default_name");
			int componentCount = base.Map.BellComponentManager.ComponentCount;
			Name = $"{text} ({componentCount})";
			rallyPointIds = new HashSet<int>();
			foreach (RallyPointMarkerComponentInstance componentInstance in base.Map.RallyPointMarkerComponentManager.ComponentInstances)
			{
				rallyPointIds.Add(componentInstance.UniqueID);
			}
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.BellComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		public void Activate()
		{
			MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition("BellActivate", base.WorldPosition);
			IsActivated = true;
			foreach (RallyPointMarkerComponentInstance componentInstance in base.Map.RallyPointMarkerComponentManager.ComponentInstances)
			{
				if (rallyPointIds.Contains(componentInstance.UniqueID))
				{
					componentInstance.StartDraft();
				}
			}
		}

		public void Deactivate()
		{
			MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition("BellDeactivate", base.WorldPosition);
			IsActivated = false;
			foreach (RallyPointMarkerComponentInstance componentInstance in base.Map.RallyPointMarkerComponentManager.ComponentInstances)
			{
				if (rallyPointIds.Contains(componentInstance.UniqueID))
				{
					componentInstance.EndDraft();
				}
			}
		}

		public void AssignRallyPoint(RallyPointMarkerComponentInstance rallyPoint)
		{
			rallyPointIds.Add(rallyPoint.UniqueID);
		}

		public void RemoveRallyPoint(RallyPointMarkerComponentInstance rallyPoint)
		{
			rallyPointIds.Remove(rallyPoint.UniqueID);
		}

		public void AssignAllRallyPoints()
		{
			foreach (RallyPointMarkerComponentInstance componentInstance in base.Map.RallyPointMarkerComponentManager.ComponentInstances)
			{
				rallyPointIds.Add(componentInstance.UniqueID);
			}
		}

		public void ClearAllRallyPoints()
		{
			rallyPointIds.Clear();
		}

		public bool IsRallyPointAssigned(RallyPointMarkerComponentInstance rallyPoint)
		{
			return rallyPointIds.Contains(rallyPoint.UniqueID);
		}

		public override string ToString()
		{
			return $"Bell '{Name}' at {base.OwnerBuilding.GridDataPosition}";
		}

		public void RemoveDisposedRallyPoints()
		{
			using PooledList<int> pooledList = ListPool<int>.GetJanitor();
			using PooledList<RallyPointMarkerComponentInstance> pooledList2 = base.Map.RallyPointMarkerComponentManager.ComponentInstances.ToPooledListJanitor();
			foreach (int rallyPointId in rallyPointIds)
			{
				if (pooledList2.FirstOrDefault((RallyPointMarkerComponentInstance rallyPoint) => rallyPoint.UniqueID == rallyPointId) == null)
				{
					pooledList.Add(rallyPointId);
				}
			}
			foreach (int item in pooledList)
			{
				rallyPointIds.Remove(item);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("name", Name);
			serializer.Write("rallyPointIds", rallyPointIds);
			serializer.Write("isActivated", IsActivated);
		}

		public BellComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<BellComponentRepository, BellComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(38, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Bell\\BellComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in ");
					messageBuilder.AppendFormatted("BellComponentRepository");
					messageBuilder.AppendLiteral(". ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Name = deserializer.ReadString("name");
				rallyPointIds = deserializer.ReadIntHashSet("rallyPointIds");
				IsActivated = deserializer.ReadBool("isActivated");
			}
		}
	}
}
