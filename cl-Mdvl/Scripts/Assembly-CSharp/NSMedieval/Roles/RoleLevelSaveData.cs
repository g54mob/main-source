using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Serialization;

namespace NSMedieval.Roles
{
	[FVSerializableKey("RoleLevelSaveData", "")]
	public class RoleLevelSaveData : IFVSerializable
	{
		private readonly int ownerUniqueId;

		private readonly List<KeyValuePair<string, int>> roleBlueprintIdToLevel;

		private const string RoleBlueprintIdToLevel = "roleBlueprintIdToLevel";

		public int OwnerUniqueId => ownerUniqueId;

		public RoleLevelSaveData(int workerId)
		{
			ownerUniqueId = workerId;
			roleBlueprintIdToLevel = new List<KeyValuePair<string, int>>();
		}

		public bool AddRoleLevel(string roleBlueprintId, int level)
		{
			bool flag = false;
			foreach (KeyValuePair<string, int> item in roleBlueprintIdToLevel)
			{
				if (!(item.Key != roleBlueprintId) && item.Value == level)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return false;
			}
			roleBlueprintIdToLevel.Add(new KeyValuePair<string, int>(roleBlueprintId, level));
			return true;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("workerInstance", ownerUniqueId);
			SerializeRoleLevels("roleBlueprintIdToLevel", roleBlueprintIdToLevel, serializer);
		}

		public RoleLevelSaveData(FVDeserializer deserializer)
		{
			ownerUniqueId = deserializer.ReadInt("workerInstance");
			roleBlueprintIdToLevel = DeserializeRoleLevels("roleBlueprintIdToLevel", deserializer);
		}

		private void SerializeRoleLevels(string key, List<KeyValuePair<string, int>> roleLevels, FVSerializer serializer)
		{
			List<string> value = roleLevels.Select((KeyValuePair<string, int> pair) => pair.Key).ToList();
			List<int> value2 = roleLevels.Select((KeyValuePair<string, int> pair) => pair.Value).ToList();
			serializer.Write(key + "_keys", value);
			serializer.Write(key + "_values", value2);
		}

		private List<KeyValuePair<string, int>> DeserializeRoleLevels(string key, FVDeserializer deserializer)
		{
			List<string> list = deserializer.ReadStringList(key + "_keys");
			List<int> values = deserializer.ReadIntList(key + "_values");
			if (list.Count != values.Count)
			{
				throw new Exception($"Corrupted save data, keys and values must be of same length (keys is {list.Count}, values is {values.Count})");
			}
			return list.Select((string t, int i) => new KeyValuePair<string, int>(t, values[i])).ToList();
		}
	}
}
