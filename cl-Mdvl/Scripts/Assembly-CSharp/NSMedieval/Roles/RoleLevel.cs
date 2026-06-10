using System;
using System.Collections.Generic;
using NSMedieval.Model;
using NSMedieval.RoomDetection;
using UnityEngine;

namespace NSMedieval.Roles
{
	[Serializable]
	public class RoleLevel
	{
		[SerializeField]
		private string[] onAssignEffectorIds;

		[SerializeField]
		private string[] onRetractEffectorIds;

		[SerializeField]
		private string[] onRequirementsLostEffectors;

		[SerializeField]
		private string[] onRoleRoomEnterEffectors;

		[SerializeField]
		private string[] onRoleRoomStayEffectors;

		[SerializeField]
		private string[] bannedEffectors;

		[SerializeField]
		private string[] allowedEffectors;

		[SerializeField]
		private List<StringIntPair> goalPreferences;

		[SerializeField]
		private int hoursRequirement;

		[SerializeField]
		private List<SkillLevelPair> skillRequirements;

		[SerializeField]
		private string religiousRequirement;

		[SerializeField]
		private string[] roomRequirement;

		[SerializeField]
		private List<RoomTypeMustHave> roomRequiredFurniture;

		[SerializeField]
		private bool ownRoomRequirement;

		[SerializeField]
		private List<RoomTypeMustHave> ownRoomRequiredFurniture;

		[SerializeField]
		private List<StringIntPair> globalRequiredStoredResources;

		[SerializeField]
		private GlobalStatRoleModifier globalStatModifier;

		public string[] OnAssignEffectorIds => onAssignEffectorIds;

		public string[] OnRetractEffectorIds => onRetractEffectorIds;

		public string[] OnRequirementsLostEffectors => onRequirementsLostEffectors;

		public List<StringIntPair> GoalPreferences => goalPreferences;

		public List<SkillLevelPair> SkillRequirements => skillRequirements;

		public string ReligiousRequirement => religiousRequirement;

		public string[] RoomRequirement => roomRequirement;

		public int HoursRequirement => hoursRequirement;

		public bool OwnRoomRequirement => ownRoomRequirement;

		public List<RoomTypeMustHave> OwnRoomRequiredFurniture => ownRoomRequiredFurniture;

		public List<RoomTypeMustHave> RoomRequiredFurniture => roomRequiredFurniture;

		public List<StringIntPair> GlobalRequiredStoredResources => globalRequiredStoredResources;

		public string[] OnRoleRoomEnterEffectors => onRoleRoomEnterEffectors ?? (onRoleRoomEnterEffectors = Array.Empty<string>());

		public string[] OnRoleRoomStayEffectors => onRoleRoomStayEffectors ?? (onRoleRoomStayEffectors = Array.Empty<string>());

		public string[] BannedEffectors => bannedEffectors ?? (bannedEffectors = Array.Empty<string>());

		public string[] AllowedEffectors => allowedEffectors ?? (allowedEffectors = Array.Empty<string>());

		public GlobalStatRoleModifier GlobalStatModifier => globalStatModifier;
	}
}
