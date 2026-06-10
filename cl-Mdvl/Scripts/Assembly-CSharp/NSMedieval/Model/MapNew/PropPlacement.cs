using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	[FVSerializableKey("PropPlacement", "")]
	public class PropPlacement : NSEipix.Base.Model, IFVSerializable
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private List<string> propsToPlace;

		[SerializeField]
		private int count;

		[SerializeField]
		private float terrainPercent;

		[SerializeField]
		private List<string> placeOnlyOnVoxels;

		[SerializeField]
		private bool placeOnlyInWater;

		[SerializeField]
		private bool brushControlsDensity;

		[SerializeField]
		private bool invertBrushDensity;

		[SerializeField]
		private IntRange resourcePileAmount = new IntRange(1, 1);

		[SerializeField]
		private int minDistanceFromWorkers = 6;

		[NonSerialized]
		private HashSet<VoxelType> placeOnlyOnVoxelsCache;

		[NonSerialized]
		private bool placeOnlyOnVoxelsCacheInitialized;

		[NonSerialized]
		private List<MapPropType> propsToPlaceCache;

		public List<MapPropType> PropsToPlace
		{
			get
			{
				if (propsToPlaceCache == null)
				{
					propsToPlaceCache = new List<MapPropType>();
					if (propsToPlace != null)
					{
						foreach (string item in propsToPlace)
						{
							MapPropType byID = Repository<MapPropTypeRepository, MapPropType>.Instance.GetByID(item);
							if (byID != null)
							{
								propsToPlaceCache.Add(byID);
							}
						}
					}
				}
				return propsToPlaceCache;
			}
		}

		public int Count => count;

		public float TerrainPercent => terrainPercent;

		public HashSet<VoxelType> PlaceOnlyOnVoxels
		{
			get
			{
				if (!placeOnlyOnVoxelsCacheInitialized)
				{
					placeOnlyOnVoxelsCacheInitialized = true;
					placeOnlyOnVoxelsCache = new HashSet<VoxelType>();
					foreach (string placeOnlyOnVoxel in placeOnlyOnVoxels)
					{
						VoxelType byID = VoxelTypeRepository.FastInstance.GetByID(placeOnlyOnVoxel);
						if (byID != null)
						{
							placeOnlyOnVoxelsCache.Add(byID);
						}
					}
				}
				return placeOnlyOnVoxelsCache;
			}
		}

		public bool PlaceOnlyInWater => placeOnlyInWater;

		public bool BrushControlsDensity => brushControlsDensity;

		public bool InvertBrushDensity => invertBrushDensity;

		public IntRange ResourcePileAmount => resourcePileAmount;

		public int MinDistanceFromWorkers => minDistanceFromWorkers;

		public PropPlacement()
		{
		}

		public override string GetID()
		{
			return id;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("propsToPlace", propsToPlace);
			serializer.Write("count", count);
			serializer.Write("terrainPercent", terrainPercent);
			serializer.Write("placeOnlyOnVoxels", placeOnlyOnVoxels);
			serializer.Write("brushControlsDensity", brushControlsDensity);
			serializer.Write("invertBrushDensity", invertBrushDensity);
			serializer.Write("resourcePileAmount", resourcePileAmount);
			serializer.Write("minDistanceFromWorkers", minDistanceFromWorkers);
		}

		public PropPlacement(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			propsToPlace = deserializer.ReadStringList("propsToPlace");
			count = deserializer.ReadInt("count");
			terrainPercent = deserializer.ReadFloat("terrainPercent");
			placeOnlyOnVoxels = deserializer.ReadStringList("placeOnlyOnVoxels");
			brushControlsDensity = deserializer.ReadBool("brushControlsDensity");
			invertBrushDensity = deserializer.ReadBool("invertBrushDensity");
			resourcePileAmount = deserializer.ReadObject<IntRange>("resourcePileAmount");
			minDistanceFromWorkers = deserializer.ReadInt("minDistanceFromWorkers");
		}
	}
}
