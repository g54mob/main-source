using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Roles
{
	[Serializable]
	public class Role : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string iconPath;

		[SerializeField]
		private string walkAnimation;

		[SerializeField]
		private string idleAnimation;

		[SerializeField]
		private bool roleHoursWaningSkip;

		[SerializeField]
		private string[] roomDefaultFurniture;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private RoleLevel[] roleLevels;

		public LocKeys[] LocKeys => locKeys;

		public RoleLevel[] RoleLevels => roleLevels;

		public string IconPath => iconPath;

		public string WalkAnimation => walkAnimation;

		public string IdleAnimation => idleAnimation;

		public string[] RoomDefaultFurniture => roomDefaultFurniture;

		public int MaxLevel => RoleLevels.Length - 1;

		public bool RoleHoursWaningSkip => roleHoursWaningSkip;

		public override string GetID()
		{
			return id;
		}

		public string GetSpriteAsset()
		{
			return AssetUtils.GetSpriteAsset(iconPath);
		}

		public bool CanRoleBeLeveledUp(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance.WorkerBehaviour == null)
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.AssignedRole && humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleInstance.Blueprint != this)
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.HasRole(this) && humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleLevel == RoleLevels.Length - 1)
			{
				return false;
			}
			int level = humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleLevel + 1;
			return HasLevelRequirements(humanoidInstance, level);
		}

		public bool HasLevelRequirements(HumanoidInstance humanoidInstance, int level)
		{
			if (!HasRoleSkillRequirements(humanoidInstance, level))
			{
				return false;
			}
			if (!HasRoleReligiousRequirements(humanoidInstance, level))
			{
				return false;
			}
			if (!HasRoleRoomRequirements(level))
			{
				return false;
			}
			if (!HasOwnRoomAndFurnitureRequirements(humanoidInstance, level))
			{
				return false;
			}
			if (!HasGlobalResourceRequirements(humanoidInstance, level))
			{
				return false;
			}
			return true;
		}

		public bool GetLevelRoleRooms(int level, out List<Room> rooms)
		{
			bool allRoomsOfType = VillageManager.ActiveVillage.Map.RoomDetection.GetAllRoomsOfType(RoleLevels[level].RoomRequirement, out rooms);
			if (allRoomsOfType)
			{
				rooms.ShuffleInPlace();
				rooms.Sort((Room a, Room b) => b.RoomType.Priority - a.RoomType.Priority);
			}
			return allRoomsOfType;
		}

		public bool GetAllRoleRooms(out HashSet<string> roomIds)
		{
			roomIds = new HashSet<string>();
			RoleLevel[] array = RoleLevels;
			for (int i = 0; i < array.Length; i++)
			{
				string[] roomRequirement = array[i].RoomRequirement;
				foreach (string item in roomRequirement)
				{
					roomIds.Add(item);
				}
			}
			return roomIds.Count > 0;
		}

		private bool HasRoleSkillRequirements(HumanoidInstance humanoidInstance, int level)
		{
			foreach (SkillLevelPair skillRequirement in roleLevels[level].SkillRequirements)
			{
				WorkerSkill skill = humanoidInstance.Skills.GetSkill(skillRequirement.Key);
				if (skill != null && skill.Level < skillRequirement.Value)
				{
					return false;
				}
			}
			return true;
		}

		private bool HasRoleReligiousRequirements(HumanoidInstance humanoidInstance, int level)
		{
			if (string.IsNullOrEmpty(RoleLevels[level].ReligiousRequirement))
			{
				return true;
			}
			return humanoidInstance.HumanoidBelief.GetThresholdName(humanoidInstance.Stats.GetStat(StatType.ReligiousAlignment).Current).Equals(RoleLevels[level].ReligiousRequirement);
		}

		private bool HasOwnRoomAndFurnitureRequirements(HumanoidInstance humanoidInstance, int level)
		{
			if (!RoleLevels[level].OwnRoomRequirement)
			{
				return true;
			}
			Room singleOwnerRoom = VillageManager.ActiveVillage.Map.RoomDetection.GetSingleOwnerRoom(humanoidInstance);
			if (singleOwnerRoom == null)
			{
				return false;
			}
			foreach (RoomTypeMustHave item in roleLevels[level].OwnRoomRequiredFurniture)
			{
				int num = 0;
				foreach (string furnitureId in item.Content)
				{
					num += singleOwnerRoom.IterateRoomFurniture().Count((BaseBuildingInstance baseBuildableObject) => baseBuildableObject.Blueprint.ProtoId.Equals(furnitureId) || baseBuildableObject.Blueprint.GetID().Equals(furnitureId));
				}
				if (num < item.MinCount)
				{
					return false;
				}
			}
			return true;
		}

		private bool HasRoleRoomRequirements(int level)
		{
			if (RoleLevels[level].RoomRequirement == null || RoleLevels[level].RoomRequirement.Length == 0)
			{
				return true;
			}
			if (!GetLevelRoleRooms(level, out var rooms))
			{
				return false;
			}
			foreach (RoomTypeMustHave item in roleLevels[level].RoomRequiredFurniture)
			{
				int num = 0;
				foreach (string furnitureId in item.Content)
				{
					num += rooms.Sum((Room room) => room.IterateRoomFurniture().Count((BaseBuildingInstance buildableObject) => buildableObject.Blueprint.ProtoId.Equals(furnitureId) || buildableObject.Blueprint.GetID().Equals(furnitureId)));
				}
				if (num < item.MinCount)
				{
					return false;
				}
			}
			return true;
		}

		private bool HasGlobalResourceRequirements(HumanoidInstance humanoidInstance, int level)
		{
			if (roleLevels[level].GlobalRequiredStoredResources == null || roleLevels[level].GlobalRequiredStoredResources.Count == 0)
			{
				return true;
			}
			foreach (StringIntPair globalRequiredStoredResource in roleLevels[level].GlobalRequiredStoredResources)
			{
				if (MonoSingleton<ResourcePileTracker>.Instance.GetCount(globalRequiredStoredResource.Key).TotalCount < globalRequiredStoredResource.Value)
				{
					return false;
				}
			}
			return true;
		}
	}
}
