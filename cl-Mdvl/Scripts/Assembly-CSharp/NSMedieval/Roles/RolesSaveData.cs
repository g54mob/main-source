using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSMedieval.Serialization;
using NSMedieval.State;

namespace NSMedieval.Roles
{
	[FVSerializableKey("RolesSaveData", "")]
	public class RolesSaveData : IFVSerializable
	{
		private bool viewShown;

		private bool anyRoleAssigned;

		private readonly Dictionary<int, RoleLevelSaveData> workerRoleNotificationShown;

		private const string WorkerRoleNotificationShownKey = "workerRoleNotificationShown";

		public bool ViewShown => viewShown;

		public Dictionary<int, RoleLevelSaveData> WorkerRoleNotificationShown => workerRoleNotificationShown;

		public bool AnyRoleAssigned => anyRoleAssigned;

		public RolesSaveData()
		{
			workerRoleNotificationShown = new Dictionary<int, RoleLevelSaveData>();
		}

		public bool AddWorkerRoleNotification(HumanoidInstance humanoidInstance, string roleId, int level)
		{
			if (!workerRoleNotificationShown.ContainsKey(humanoidInstance.UniqueId))
			{
				workerRoleNotificationShown.Add(humanoidInstance.UniqueId, new RoleLevelSaveData(humanoidInstance.UniqueId));
			}
			return workerRoleNotificationShown[humanoidInstance.UniqueId].AddRoleLevel(roleId, level);
		}

		public void SetAnyRoleAssigned()
		{
			anyRoleAssigned = true;
		}

		public void SetViewShown()
		{
			viewShown = true;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("viewShown", viewShown);
			serializer.Write("firstRoleAssigned", anyRoleAssigned);
			SerializeWorkerRoles("workerRoleNotificationShown", workerRoleNotificationShown, serializer);
		}

		public RolesSaveData(FVDeserializer deserializer)
		{
			viewShown = deserializer.ReadBool("viewShown");
			anyRoleAssigned = deserializer.ReadBool("firstRoleAssigned");
			workerRoleNotificationShown = DeserializeWorkerRoles("workerRoleNotificationShown", deserializer);
		}

		private void SerializeWorkerRoles(string key, Dictionary<int, RoleLevelSaveData> workerRoles, FVSerializer serializer)
		{
			List<int> value = workerRoles.Select((KeyValuePair<int, RoleLevelSaveData> pair) => pair.Key).ToList();
			List<RoleLevelSaveData> value2 = workerRoles.Select((KeyValuePair<int, RoleLevelSaveData> pair) => pair.Value).ToList();
			serializer.Write(key + "_workerUniqueIds", value);
			serializer.Write(key + "_roleInstances", value2);
		}

		private Dictionary<int, RoleLevelSaveData> DeserializeWorkerRoles(string key, FVDeserializer deserializer)
		{
			List<int> list = deserializer.ReadIntList(key + "_workerUniqueIds");
			List<RoleLevelSaveData> values = deserializer.ReadObjectList<RoleLevelSaveData>(key + "_roleInstances");
			if (list == null || values == null)
			{
				return new Dictionary<int, RoleLevelSaveData>();
			}
			try
			{
				return list.Select((int t, int i) => new KeyValuePair<int, RoleLevelSaveData>(t, values[i])).ToDictionary((KeyValuePair<int, RoleLevelSaveData> pair) => pair.Key, (KeyValuePair<int, RoleLevelSaveData> pair) => pair.Value);
			}
			catch (Exception ex)
			{
				Log.Error("Error occurred in DeserializeWorkerRoles:", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\RolesSaveData.cs");
				Log.Error(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\RolesSaveData.cs");
				return new Dictionary<int, RoleLevelSaveData>();
			}
		}
	}
}
