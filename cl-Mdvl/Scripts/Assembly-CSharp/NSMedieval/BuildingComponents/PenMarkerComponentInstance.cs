using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("PenMarkerComponentInstance", "")]
	public class PenMarkerComponentInstance : BaseComponentInstance
	{
		[SerializeField]
		private HashSet<string> animals = new HashSet<string>();

		[NonSerialized]
		private PenMarkerComponentBlueprint blueprint;

		[field: SerializeField]
		public string Name { get; private set; }

		public PenMarkerComponentBlueprint Blueprint => blueprint;

		public HashSet<string> Animals => animals;

		public PenMarkerComponentInstance(BaseBuildingInstance ownerBuilding, PenMarkerComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			SetName(MonoSingleton<LocalizationController>.Instance.GetText("animal_pen_panel_title"));
			List<PenMarkerComponentInstance> sharedMarkerInstances = GetSharedMarkerInstances();
			if (sharedMarkerInstances != null && sharedMarkerInstances.Count > 0)
			{
				SetName(sharedMarkerInstances.First().Name);
				foreach (PenMarkerComponentInstance item in sharedMarkerInstances)
				{
					if (item != this)
					{
						animals.UnionWith(item.animals);
					}
				}
			}
			if (animals.Any())
			{
				return;
			}
			foreach (Animal item2 in Repository<AnimalBaseRepository, Animal>.Instance.AnimalsCanBeInPen)
			{
				SetAnimalAllowed(item2, allowed: true);
			}
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.PenMarkerComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool underWater = waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High;
			base.OwnerBuilding.SetUnderWater(underWater);
		}

		public AnimalPenInstance GetAnimalPen()
		{
			return MonoSingleton<PenDetection>.Instance.GetPen(GetNode());
		}

		public void SetNameToAllInPen(string name)
		{
			SetName(name);
			List<PenMarkerComponentInstance> sharedMarkerInstances = GetSharedMarkerInstances();
			if (sharedMarkerInstances == null)
			{
				return;
			}
			foreach (PenMarkerComponentInstance item in sharedMarkerInstances)
			{
				if (item != this)
				{
					item.SetName(name);
				}
			}
		}

		public void SetName(string name)
		{
			Name = name;
		}

		public bool IsAnimalAllowed(Animal animal)
		{
			if (animal == null)
			{
				return false;
			}
			return animals.Contains(animal.GetID());
		}

		public void SetAnimalAllowed(Animal animal, bool allowed)
		{
			if (allowed && !animals.Contains(animal.GetID()))
			{
				animals.Add(animal.GetID());
			}
			if (!allowed && animals.Contains(animal.GetID()))
			{
				animals.Remove(animal.GetID());
			}
		}

		public void SetAnimalsAllowed(IEnumerable<string> animals, bool allowed)
		{
			if (allowed)
			{
				this.animals.UnionWith(animals);
			}
			else
			{
				this.animals.ExceptWith(animals);
			}
		}

		private List<PenMarkerComponentInstance> GetSharedMarkerInstances()
		{
			return MonoSingleton<PenDetection>.Instance.GetPen(GetNode())?.PenMarkers;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("name", Name);
			serializer.Write("animals", animals);
		}

		public PenMarkerComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<PenMarkerComponentRepository, PenMarkerComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(66, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\PenMarkers\\PenMarkerComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in PenMarkerComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Name = deserializer.ReadString("name");
				animals = deserializer.ReadStringHashSet("animals");
			}
		}
	}
}
