using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Dictionary;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameDifficulty
{
	[Serializable]
	[FVSerializableKey("GameDifficultyInstance", "")]
	public class GameParametersInstance : IFVSerializable
	{
		[SerializeField]
		private StringKeyPair optionsDictionary;

		private SerializableIdValuePair[] defaultParameters;

		public SerializableIdValuePair[] ToIdValuePairs
		{
			get
			{
				SerializableIdValuePair[] array = new SerializableIdValuePair[OptionsDictionary.Dictionary.Count];
				int num = 0;
				foreach (KeyValuePair<string, float> item in optionsDictionary.Dictionary)
				{
					array[num] = new SerializableIdValuePair(item.Key, item.Value);
					num++;
				}
				return array;
			}
		}

		public StringKeyPair OptionsDictionary => optionsDictionary;

		public float RaidPointsMultiplier => GetById("raidPointsMultiplier");

		public float WoundSeverityMultiplier => GetById("woundSeverityMultiplier");

		public float AnimalSpawnMultiplier
		{
			get
			{
				if (!(GetById("animalSpawnMultiplier") <= 0f))
				{
					return GetById("animalSpawnMultiplier");
				}
				return 1f;
			}
		}

		public float PlantYieldMultiplier
		{
			get
			{
				if (!(GetById("plantYieldMultiplier") <= 0f))
				{
					return GetById("plantYieldMultiplier");
				}
				return 1f;
			}
		}

		public float MineYieldMultiplier
		{
			get
			{
				if (!(GetById("mineYieldMultiplier") <= 0f))
				{
					return GetById("mineYieldMultiplier");
				}
				return 1f;
			}
		}

		public float RaidStrengthMultiplier => GetById("raidStrengthMultiplier");

		public GameParametersInstance(GameParametersInstance instance)
		{
			defaultParameters = new SerializableIdValuePair[instance.OptionsDictionary.Dictionary.Keys.Count];
			optionsDictionary = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();
			int num = 0;
			foreach (KeyValuePair<string, float> item in instance.OptionsDictionary.Dictionary)
			{
				optionsDictionary.Dictionary[item.Key] = item.Value;
				defaultParameters[num] = new SerializableIdValuePair(item.Key, item.Value);
				num++;
			}
		}

		public GameParametersInstance(SerializableIdValuePair[] parameters)
		{
			defaultParameters = parameters;
			ResetToDefaults();
		}

		public void ResetToDefaults()
		{
			if (defaultParameters == null)
			{
				defaultParameters = (from p in Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters()
					select new SerializableIdValuePair(p.Id, p.Value)).ToArray();
			}
			optionsDictionary = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();
			SerializableIdValuePair[] array = defaultParameters;
			foreach (SerializableIdValuePair serializableIdValuePair in array)
			{
				optionsDictionary.Dictionary[serializableIdValuePair.Id] = serializableIdValuePair.Value;
			}
		}

		public GameParametersInstance()
		{
		}

		public bool HasOption(string id)
		{
			return OptionsDictionary.Dictionary.ContainsKey(id);
		}

		public void SetById(string difficultyOptionId, float value)
		{
			if (OptionsDictionary.Dictionary.ContainsKey(difficultyOptionId))
			{
				OptionsDictionary.Dictionary[difficultyOptionId] = value;
			}
		}

		public float GetById(string difficultyOptionId)
		{
			return OptionsDictionary.Dictionary[difficultyOptionId];
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("optionsDictionary", optionsDictionary);
		}

		public GameParametersInstance(FVDeserializer deserializer)
		{
			optionsDictionary = deserializer.ReadObject<StringKeyPair>("optionsDictionary");
			OnAfterDeserialize();
		}

		private void OnAfterDeserialize()
		{
			SerializableIdValuePair[] defaultGameParameters = Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters();
			foreach (SerializableIdValuePair serializableIdValuePair in defaultGameParameters)
			{
				if (!OptionsDictionary.Dictionary.ContainsKey(serializableIdValuePair.Id))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(9, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameDifficulty\\GameParametersInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Adding ");
						messageBuilder.AppendFormatted(serializableIdValuePair.Id);
						messageBuilder.AppendLiteral(": ");
						messageBuilder.AppendFormatted(serializableIdValuePair.Value);
					}
					Log.Trace(messageBuilder);
					OptionsDictionary.Dictionary[serializableIdValuePair.Id] = serializableIdValuePair.Value;
				}
			}
		}
	}
}
