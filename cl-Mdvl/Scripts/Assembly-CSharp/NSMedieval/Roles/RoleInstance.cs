using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Roles
{
	[FVSerializableKey("RoleInstance", "")]
	public class RoleInstance : IFVSerializable
	{
		private Role blueprint;

		private readonly int roleOwnerUniqueId;

		private int level;

		private int hoursActive;

		private readonly List<string> firedRequirementsLostEffectors;

		private Room roleRoom;

		private HumanoidInstance roleOwner;

		private const string fvs_blueprintId = "blueprintId";

		private const string fvs_roleOwnerUniqueId = "roleOwnerUniqueId";

		private const string fvs_level = "level";

		private const string fvs_hoursActive = "hoursActive";

		private const string fvs_firedRequirementsLostEffectors = "firedRequirementsLostEffectors";

		public int Level => Mathf.Clamp(level, -1, blueprint.MaxLevel);

		public Role Blueprint => blueprint;

		public int HoursActive => hoursActive;

		public HumanoidInstance RoleOwner => roleOwner;

		public RoleInstance(Role blueprint, int roleOwnerUniqueId, int level = -1)
		{
			this.blueprint = blueprint;
			this.roleOwnerUniqueId = roleOwnerUniqueId;
			this.level = level;
			hoursActive = 0;
			firedRequirementsLostEffectors = new List<string>();
			SetupAfterLoad();
		}

		public RoleLevel GetRoleLevel()
		{
			if (level <= -1 || level > blueprint.MaxLevel)
			{
				return null;
			}
			return Blueprint.RoleLevels[level];
		}

		public string GetID()
		{
			return blueprint.GetID();
		}

		public bool GetAllRoleRooms(out List<Room> rooms)
		{
			return Blueprint.GetLevelRoleRooms(Level, out rooms);
		}

		public Room GetRoleRoom()
		{
			if (roleRoom != null)
			{
				return roleRoom;
			}
			if (Blueprint.GetLevelRoleRooms(Level, out var rooms))
			{
				roleRoom = rooms[0];
			}
			return null;
		}

		public void ClearRoleRoom()
		{
			roleRoom = null;
		}

		public string[] GetOnAssignEffectorIds()
		{
			return Blueprint.RoleLevels[Level].OnAssignEffectorIds;
		}

		public string[] GetOnRetractEffectorIds()
		{
			return Blueprint.RoleLevels[Level].OnRetractEffectorIds;
		}

		public string[] GetBannedEffectors()
		{
			return Blueprint.RoleLevels[Level].BannedEffectors;
		}

		public string[] GetAllowedEffectors()
		{
			return Blueprint.RoleLevels[Level].AllowedEffectors;
		}

		public List<StringIntPair> GetGoalPreferences()
		{
			return Blueprint.RoleLevels[Level].GoalPreferences;
		}

		public Transform GetDefaultLookAtPosition()
		{
			Room room = GetRoleRoom();
			if (room == null)
			{
				return null;
			}
			string[] roomDefaultFurniture = Blueprint.RoomDefaultFurniture;
			foreach (string furnitureId in roomDefaultFurniture)
			{
				BaseBuildingInstance furnitureById = room.GetFurnitureById(furnitureId);
				if (furnitureById != null)
				{
					return furnitureById.GetTransform();
				}
			}
			return null;
		}

		public void Retract()
		{
			level = -1;
			ClearRoleRoom();
		}

		public void LevelUp()
		{
			level++;
		}

		public void LevelDown()
		{
			level--;
		}

		public void Tick()
		{
			hoursActive++;
			CheckRequirements();
		}

		public IEnumerable<RoleEffectorData> GetOnRoleRoomEnterEffectorIds()
		{
			return Blueprint.RoleLevels[Level].OnRoleRoomEnterEffectors.Select((string effectorId) => new RoleEffectorData(effectorId, this));
		}

		public IEnumerable<RoleEffectorData> GetOnRoleRoomStayEffectorIds()
		{
			return Blueprint.RoleLevels[Level].OnRoleRoomStayEffectors.Select((string effectorId) => new RoleEffectorData(effectorId, this));
		}

		private void CheckRequirements()
		{
			HumanoidInstance humanoidInstance = RoleOwner;
			if (humanoidInstance == null || humanoidInstance.HasDisposed || humanoidInstance.HasDied)
			{
				return;
			}
			if (Blueprint.HasLevelRequirements(humanoidInstance, Level))
			{
				if (firedRequirementsLostEffectors.Count <= 0)
				{
					return;
				}
				foreach (string firedRequirementsLostEffector in firedRequirementsLostEffectors)
				{
					RoleOwner.Stats.EndEffector(firedRequirementsLostEffector);
				}
				firedRequirementsLostEffectors.Clear();
			}
			else if (firedRequirementsLostEffectors.Count <= 0 && Blueprint.RoleLevels[Level].OnRequirementsLostEffectors != null)
			{
				string[] onRequirementsLostEffectors = Blueprint.RoleLevels[Level].OnRequirementsLostEffectors;
				foreach (string text in onRequirementsLostEffectors)
				{
					RoleOwner.Stats.StartEffector(text);
					firedRequirementsLostEffectors.Add(text);
				}
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprintId", blueprint.GetID());
			serializer.Write("roleOwnerUniqueId", roleOwnerUniqueId);
			serializer.Write("level", level);
			serializer.Write("hoursActive", hoursActive);
			serializer.Write("firedRequirementsLostEffectors", firedRequirementsLostEffectors);
		}

		public RoleInstance(FVDeserializer deserializer)
		{
			string id = deserializer.ReadString("blueprintId");
			blueprint = Repository<RoleRepository, Role>.Instance.GetByID(id);
			roleOwnerUniqueId = deserializer.ReadInt("roleOwnerUniqueId");
			level = deserializer.ReadInt("level");
			hoursActive = deserializer.ReadInt("hoursActive");
			firedRequirementsLostEffectors = deserializer.ReadStringList("firedRequirementsLostEffectors");
		}

		public void SetupAfterLoad()
		{
			if (roleOwner == null)
			{
				roleOwner = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.FirstOrDefault((HumanoidInstance worker) => worker.UniqueId == roleOwnerUniqueId) ?? MonoSingleton<NPCManager>.Instance.GetFirstOrDefault((HumanoidInstance npc) => npc.UniqueId == roleOwnerUniqueId);
				level = Mathf.Clamp(level, -1, blueprint.MaxLevel);
			}
		}
	}
}
