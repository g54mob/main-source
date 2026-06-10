using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.Tools.Math;

namespace NSMedieval.State
{
	public class HumanoidRoleOwner : IRoleOwner
	{
		private const int RoleCooldownHours = 2;

		private const int RoleAchievementCount = 5;

		private int cooldownTimer;

		private HumanoidInstance humanoid;

		public Dictionary<Role, RoleInstance> RoleInstanceDictionary { get; set; }

		public int RoleLevel
		{
			get
			{
				if (!AssignedRole)
				{
					return -1;
				}
				return RoleInstance.Level;
			}
		}

		public RoleInstance RoleInstance { get; set; }

		public bool AssignedRole => RoleInstance != null;

		public HumanoidRoleOwner(HumanoidInstance humanoidOwner)
		{
			humanoid = humanoidOwner;
			RoleInstanceDictionary = new Dictionary<Role, RoleInstance>();
		}

		public void SetHumanOwner(HumanoidInstance humanoid)
		{
			this.humanoid = humanoid;
		}

		public bool InsInCooldown(out int hoursLeft)
		{
			hoursLeft = cooldownTimer;
			return cooldownTimer > 0;
		}

		public bool HasRole(string roleId)
		{
			if (AssignedRole)
			{
				return RoleInstance.Blueprint.GetID().Equals(roleId);
			}
			return false;
		}

		public bool HasRole(Role role)
		{
			if (AssignedRole)
			{
				return RoleInstance.Blueprint == role;
			}
			return false;
		}

		public int GetHoursInRole(Role role)
		{
			if (RoleInstanceDictionary.ContainsKey(role))
			{
				return RoleInstanceDictionary[role].HoursActive;
			}
			return 0;
		}

		public void RetractRole()
		{
			cooldownTimer = 2;
			string[] onRetractEffectorIds = RoleInstance.GetOnRetractEffectorIds();
			foreach (string effectorId in onRetractEffectorIds)
			{
				humanoid.Stats.StartEffector(effectorId);
			}
			humanoid.GoalPreferences.SetDefaultGoalPreferenceSkillModifiers();
			RoleInstance.Retract();
			Role blueprint = RoleInstance.Blueprint;
			RoleInstance = null;
			MonoSingleton<RoleManager>.Instance.OnRoleRetracted(blueprint, humanoid);
		}

		public void LevelUpRole(Role role)
		{
			cooldownTimer = 2;
			if (RoleInstanceDictionary.TryGetValue(role, out var value))
			{
				RoleInstance = value;
			}
			else
			{
				RoleInstance = new RoleInstance(role, humanoid.UniqueId);
				RoleInstanceDictionary.Add(role, RoleInstance);
			}
			if (RoleLevel == role.MaxLevel)
			{
				return;
			}
			if (RoleLevel > -1)
			{
				string[] bannedEffectors = RoleInstance.GetBannedEffectors();
				if (bannedEffectors != null && bannedEffectors.Length > 0)
				{
					string[] array = bannedEffectors;
					foreach (string name in array)
					{
						humanoid.Stats.UnBanEffector(name);
					}
				}
				string[] allowedEffectors = RoleInstance.GetAllowedEffectors();
				if (allowedEffectors != null && allowedEffectors.Length > 0)
				{
					string[] array = allowedEffectors;
					foreach (string name2 in array)
					{
						humanoid.Stats.UnAllowEffector(name2);
					}
				}
			}
			RoleInstance.LevelUp();
			OnRoleAssign();
			MonoSingleton<RoleManager>.Instance.OnRoleChanged(RoleInstance.Blueprint, humanoid);
		}

		public void LevelDownRole()
		{
			if (RoleLevel == 0)
			{
				return;
			}
			if (RoleLevel > -1)
			{
				string[] bannedEffectors = RoleInstance.GetBannedEffectors();
				if (bannedEffectors != null && bannedEffectors.Length > 0)
				{
					string[] array = bannedEffectors;
					foreach (string name in array)
					{
						humanoid.Stats.UnBanEffector(name);
					}
				}
				string[] allowedEffectors = RoleInstance.GetAllowedEffectors();
				if (allowedEffectors != null && allowedEffectors.Length > 0)
				{
					string[] array = allowedEffectors;
					foreach (string name2 in array)
					{
						humanoid.Stats.UnAllowEffector(name2);
					}
				}
			}
			RoleInstance.LevelDown();
			OnRoleAssign();
			MonoSingleton<RoleManager>.Instance.OnRoleChanged(RoleInstance.Blueprint, humanoid);
		}

		private void OnRoleAssign()
		{
			RoleBanAllowEffectors();
			string[] onAssignEffectorIds = RoleInstance.GetOnAssignEffectorIds();
			foreach (string effectorId in onAssignEffectorIds)
			{
				humanoid.Stats.StartEffector(effectorId);
			}
			humanoid.GoalPreferences.SetSecondaryGoalPreferences(RoleInstance.GetGoalPreferences());
			if (MonoSingleton<AchievementManager>.Instance.IsUnlocked("WORKER_ROLES"))
			{
				return;
			}
			int num = 0;
			foreach (HumanoidInstance item in WorkerManager.WorkersEverywhere)
			{
				if (!item.HasDied)
				{
					HumanoidRoleOwner humanoidRoleOwner = item.WorkerBehaviour?.HumanoidRoleOwner;
					if (humanoidRoleOwner != null && humanoidRoleOwner.AssignedRole)
					{
						num++;
					}
				}
			}
			if (num >= 5)
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("WORKER_ROLES");
			}
		}

		private void RoleBanAllowEffectors()
		{
			if (RoleInstance == null)
			{
				return;
			}
			string[] bannedEffectors = RoleInstance.GetBannedEffectors();
			if (bannedEffectors != null && bannedEffectors.Length > 0)
			{
				string[] array = bannedEffectors;
				foreach (string name in array)
				{
					humanoid.Stats.BanEffector(name);
				}
			}
			string[] allowedEffectors = RoleInstance.GetAllowedEffectors();
			if (allowedEffectors != null && allowedEffectors.Length > 0)
			{
				string[] array = allowedEffectors;
				foreach (string name2 in array)
				{
					humanoid.Stats.AllowEffector(name2);
				}
			}
		}

		public bool CanRoleBeLeveledUp(Role role)
		{
			if (humanoid == null || humanoid.HasDied || humanoid.HasDisposed)
			{
				return false;
			}
			if (RoleLevel == role.MaxLevel)
			{
				return false;
			}
			if (GetHoursInRole(role) < role.RoleLevels[RoleLevel + 1].HoursRequirement)
			{
				return false;
			}
			return role.CanRoleBeLeveledUp(humanoid);
		}

		public void SetRole(string roleId, int level = -1)
		{
			Role byID = Repository<RoleRepository, Role>.Instance.GetByID(roleId);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\HumanoidRoleOwner.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Role with id ");
					messageBuilder.AppendFormatted(roleId);
					messageBuilder.AppendLiteral(" not found");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				if (level == -1)
				{
					level = Random.Range(0, byID.RoleLevels.Length);
				}
				RoleInstance = new RoleInstance(byID, humanoid.UniqueId, level);
			}
		}

		public string GetDefaultDisplayNameRole()
		{
			if (humanoid.WorkerBehaviour != null)
			{
				if (!AssignedRole)
				{
					return humanoid.Info.GetDefaultDisplayName();
				}
				return RoleInstance.Blueprint.GetSpriteAsset() + " " + humanoid.Info.GetDefaultDisplayName();
			}
			if (!AssignedRole)
			{
				return humanoid.Info.GetDefaultDisplayName();
			}
			return RoleInstance.Blueprint.GetSpriteAsset() + " " + humanoid.Info.GetFullName();
		}

		public void HandleHourChange()
		{
			if (AssignedRole)
			{
				if (cooldownTimer > 0)
				{
					cooldownTimer--;
				}
				RoleInstance.Tick();
			}
		}

		public void HandleQuarterHourChange()
		{
			CheckRoleRoomEffectors();
		}

		public void CheckRoleRoomEffectors()
		{
			Room room = humanoid.Room;
			if (room == null)
			{
				return;
			}
			if (room.RolePresent != null && room.RolePresent != this)
			{
				if (humanoid.OnEnterRoomEffectors.Count == 0)
				{
					IEnumerable<RoleEffectorData> roleRoomEnterEffectors = room.GetRoleRoomEnterEffectors();
					if (roleRoomEnterEffectors != null)
					{
						humanoid.OnEnterRoomEffectors = roleRoomEnterEffectors.ToList();
						foreach (RoleEffectorData onEnterRoomEffector in humanoid.OnEnterRoomEffectors)
						{
							humanoid.Stats.StartEffector(onEnterRoomEffector.EffectorId);
						}
					}
				}
				if (humanoid.OnStayRoomEffectors.Count == 0)
				{
					IEnumerable<RoleEffectorData> roleRoomStayEffectors = room.GetRoleRoomStayEffectors();
					if (roleRoomStayEffectors != null)
					{
						humanoid.OnStayRoomEffectors = roleRoomStayEffectors.ToList();
						foreach (RoleEffectorData onStayRoomEffector in humanoid.OnStayRoomEffectors)
						{
							humanoid.Stats.StartEffector(onStayRoomEffector.EffectorId);
						}
					}
				}
			}
			if (room.RolePresent != null || humanoid.OnStayRoomEffectors.Count <= 0)
			{
				return;
			}
			foreach (RoleEffectorData onStayRoomEffector2 in humanoid.OnStayRoomEffectors)
			{
				humanoid.Stats.EndEffector(onStayRoomEffector2.EffectorId);
			}
			humanoid.OnStayRoomEffectors.Clear();
		}

		public void OnSetupRole()
		{
			if (RoleInstanceDictionary == null)
			{
				Dictionary<Role, RoleInstance> dictionary = (RoleInstanceDictionary = new Dictionary<Role, RoleInstance>());
			}
			foreach (RoleInstance value in RoleInstanceDictionary.Values)
			{
				value.SetupAfterLoad();
			}
			if (AssignedRole)
			{
				OnRoleAssign();
			}
		}
	}
}
