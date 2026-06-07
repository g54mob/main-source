using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone
{
	[Serializable]
	public class NimbatusClimateZoneLayer
	{
		public bool HasCustomMaterial;

		[ShowIf("HasCustomMaterial", true)]
		public Material CustomMaterial;

		[HideInInspector]
		public Material Material;

		[ColorUsage(true, true)]
		public Color Color;

		public bool IsCollectable;

		[HideIf("HasCustomMaterial", true)]
		public bool IsEmissive;

		[ShowIf("IsEmissive", true)]
		public float Glow = 1f;

		[ValidateInput("IsDefined", null, InfoMessageType.Error)]
		public ETerrainMaterial TerrainMaterial;

		public float MaterialStrength;

		[OdinSerialize]
		public List<NimbatusDataGenerator> DataGenerators = new List<NimbatusDataGenerator>();

		public bool IsDefined(ETerrainMaterial mat)
		{
			return Enum.IsDefined(typeof(ETerrainMaterial), mat);
		}

		public float GetMaterialStrength(EAmmunitionType ammo)
		{
			if (!IsCollectable && ammo == EAmmunitionType.Bio)
			{
				return -1f * MaterialStrength;
			}
			return MaterialStrength;
		}

		public void Init(NimbatusTerrainClimateZone zone, System.Random rnd, ref VariableSet variables)
		{
			foreach (NimbatusDataGenerator dataGenerator in DataGenerators)
			{
				dataGenerator.Init(zone, rnd, ref variables);
			}
		}

		public float GetData(Vector2 worldPosition, float previousLayer = 1f)
		{
			float num = previousLayer;
			float result = 1f;
			foreach (NimbatusDataGenerator dataGenerator in DataGenerators)
			{
				num = dataGenerator.GetValue(worldPosition, num);
				result = num;
			}
			return result;
		}
	}
}
