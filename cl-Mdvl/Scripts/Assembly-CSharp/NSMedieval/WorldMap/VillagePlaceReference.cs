using System;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	[Serializable]
	[FVSerializableKey("VillagePlaceReference", "")]
	public class VillagePlaceReference : IWorldMapPlaceReference, IFVSerializable
	{
		[SerializeField]
		private string factionId;

		[SerializeField]
		private string villageName;

		[NonSerialized]
		private VillagePlace villagePlace;

		[NonSerialized]
		private bool isInitialized;

		[NonSerialized]
		private FactionInstance factionInstance;

		public VillagePlace VillageValue
		{
			get
			{
				if (!isInitialized && !string.IsNullOrEmpty(factionId) && !string.IsNullOrEmpty(villageName))
				{
					villagePlace = MonoSingleton<WorldMap>.Instance?.Data?.VillagePlaces?.FirstOrDefault((VillagePlace v) => v.Name.Equals(villageName) && v.FactionInstance.BlueprintId.Equals(factionId));
					isInitialized = villagePlace != null;
				}
				return villagePlace;
			}
		}

		public WorldMapPlace Value => VillageValue;

		public bool HasValue
		{
			get
			{
				if (!string.IsNullOrEmpty(factionId))
				{
					return !string.IsNullOrEmpty(villageName);
				}
				return false;
			}
		}

		public FactionInstance FactionInstance
		{
			get
			{
				if (factionInstance == null)
				{
					factionInstance = Value?.FactionInstance;
					if (factionInstance == null)
					{
						foreach (FactionInstance factionInstance in MonoSingleton<WorldMap>.Instance.Data.FactionInstances)
						{
							if (factionInstance.BlueprintId.Equals(factionId))
							{
								this.factionInstance = factionInstance;
								break;
							}
						}
					}
				}
				return this.factionInstance;
			}
		}

		public string FactionId => factionId;

		public VillagePlaceReference(VillagePlace villagePlace)
		{
			if (villagePlace != null)
			{
				this.villagePlace = villagePlace;
				factionId = villagePlace.FactionInstance.BlueprintId;
				villageName = villagePlace.Name;
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("factionId", factionId);
			serializer.Write("villageName", villageName);
		}

		public VillagePlaceReference(FVDeserializer deserializer)
		{
			factionId = deserializer.ReadString("factionId");
			villageName = deserializer.ReadString("villageName");
		}
	}
}
