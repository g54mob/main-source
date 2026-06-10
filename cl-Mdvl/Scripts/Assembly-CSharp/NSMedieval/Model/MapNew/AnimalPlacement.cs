using System;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	[FVSerializableKey("AnimalPlacement", "")]
	public class AnimalPlacement : NSEipix.Base.Model, IFVSerializable
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private string animalId = string.Empty;

		[SerializeField]
		private float spawnerChance = 1f;

		[SerializeField]
		private IntRange initialCount = new IntRange(5, 10);

		[SerializeField]
		private int maxCount = 100;

		[SerializeField]
		private float spawnSpeedMultiplier = 1f;

		[SerializeField]
		private FloatRange temperature = new FloatRange(-10f, 35f);

		[SerializeField]
		private float optimalTemperature = 20f;

		public string AnimalId => animalId;

		public float SpawnerChance => spawnerChance;

		public IntRange InitialCount => initialCount;

		public int MaxCount => maxCount;

		public float SpawnSpeedMultiplier => spawnSpeedMultiplier;

		public FloatRange Temperature => temperature;

		public float OptimalTemperature => optimalTemperature;

		public AnimalPlacement()
		{
		}

		public override string GetID()
		{
			return id;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("animalId", animalId);
			serializer.Write("spawnerChance", spawnerChance);
			serializer.Write("initialCount", initialCount);
			serializer.Write("maxCount", maxCount);
			serializer.Write("spawnSpeedMultiplier", spawnSpeedMultiplier);
			serializer.Write("temperature", temperature);
			serializer.Write("optimalTemperature", optimalTemperature);
		}

		public AnimalPlacement(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			animalId = deserializer.ReadString("animalId");
			spawnerChance = deserializer.ReadFloat("spawnerChance");
			initialCount = deserializer.ReadObject<IntRange>("initialCount");
			maxCount = deserializer.ReadInt("maxCount");
			spawnSpeedMultiplier = deserializer.ReadFloat("spawnSpeedMultiplier");
			temperature = deserializer.ReadObject<FloatRange>("temperature");
			optimalTemperature = deserializer.ReadFloat("optimalTemperature");
		}
	}
}
