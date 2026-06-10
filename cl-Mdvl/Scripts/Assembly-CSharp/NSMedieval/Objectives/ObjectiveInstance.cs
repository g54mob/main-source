using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using Objectives;
using TMPro;
using UnityEngine;

namespace NSMedieval.Objectives
{
	[Serializable]
	[FVSerializableKey("ObjectiveInstance", "")]
	public class ObjectiveInstance : IFVSerializable
	{
		private readonly string blueprintId;

		private HashSet<string> requirementsCompleted;

		private Dictionary<string, int> requirementsCount;

		private HashSet<string> tasksCompleted;

		private bool completed;

		[NonSerialized]
		private bool blueprintSet;

		[NonSerialized]
		private Objective blueprint;

		public bool Completed => completed;

		public string BlueprintId => blueprintId;

		public Objective Blueprint
		{
			get
			{
				if (!blueprintSet)
				{
					blueprint = Repository<ObjectiveRepository, Objective>.Instance.GetByID(blueprintId);
					blueprintSet = true;
				}
				return blueprint;
			}
		}

		public ObjectiveInstance(Objective objectiveBlueprint)
		{
			blueprintId = objectiveBlueprint.GetID();
			blueprint = objectiveBlueprint;
			blueprintSet = true;
			requirementsCompleted = new HashSet<string>();
			requirementsCount = new Dictionary<string, int>();
			tasksCompleted = new HashSet<string>();
			UnlockRoomTypes();
			UnlockGameEvents();
			PlaceBanditCamps();
		}

		public bool IsBlockingEvent(GameEvent gameEvent)
		{
			if (Completed)
			{
				return false;
			}
			if (!gameEvent.NonBlocking && Blueprint.BypassBlockingEvents)
			{
				return true;
			}
			if (!Blueprint.BlockGameEvents.Contains(gameEvent.GetID()))
			{
				return Blueprint.BlockGameEvents.Contains(gameEvent.ClassName);
			}
			return true;
		}

		public void SetCompleted(bool value)
		{
			completed = value;
			if (Blueprint.StartEventOnCompleted != null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(57, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trying to start game event '");
					messageBuilder.AppendFormatted(Blueprint.StartEventOnCompleted);
					messageBuilder.AppendLiteral("' on completing objective '");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral("'.");
				}
				Log.Info(messageBuilder);
				MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent(Blueprint.StartEventOnCompleted);
			}
			MonoSingleton<ObjectiveController>.Instance.ObjectiveCompleted(this, completed);
			MonoSingleton<AchievementManager>.Instance.UnlockAchievement(Blueprint.UnlockAchievementOnCompleted);
		}

		public void UnlockRoomTypes()
		{
			if (Blueprint.UnlockRoomTypes == null)
			{
				return;
			}
			string[] unlockRoomTypes = blueprint.UnlockRoomTypes;
			foreach (string id in unlockRoomTypes)
			{
				RoomType byID = Repository<RoomTypeRepository, RoomType>.Instance.GetByID(id);
				if (byID != null)
				{
					bool t = byID.Unlock();
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(48, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Objective ");
						messageBuilder.AppendFormatted(blueprintId);
						messageBuilder.AppendLiteral(" tried to unlock room type ");
						messageBuilder.AppendFormatted(byID);
						messageBuilder.AppendLiteral("; success: ");
						messageBuilder.AppendFormatted(t);
					}
					Log.Info(messageBuilder);
				}
			}
		}

		public void UnlockGameEvents()
		{
			if (Blueprint.UnlockGameEvents == null)
			{
				return;
			}
			string[] unlockGameEvents = blueprint.UnlockGameEvents;
			foreach (string id in unlockGameEvents)
			{
				GameEvent byID = Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID(id);
				if (byID != null)
				{
					bool t = byID.Unlock();
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(49, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Objective ");
						messageBuilder.AppendFormatted(blueprintId);
						messageBuilder.AppendLiteral(" tried to unlock game event ");
						messageBuilder.AppendFormatted(byID.GetID());
						messageBuilder.AppendLiteral("; success: ");
						messageBuilder.AppendFormatted(t);
					}
					Log.Info(messageBuilder);
				}
			}
		}

		public void TurnFactionsIntoPermanentlyHostile()
		{
			if (Blueprint == null || Blueprint.TurnIntoPermanentlyHostile == null)
			{
				return;
			}
			foreach (FactionInstance factionInstance in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances)
			{
				if (blueprint.TurnIntoPermanentlyHostile.Contains(factionInstance.BlueprintId))
				{
					factionInstance.SetPermanentlyHostile();
				}
			}
		}

		public void TurnFactionsIntoFullyFriendly()
		{
			if (Blueprint.TurnIntoFullyFriendly == null)
			{
				return;
			}
			foreach (FactionInstance factionInstance in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances)
			{
				if (blueprint.TurnIntoFullyFriendly.Contains(factionInstance.BlueprintId))
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Turning faction ");
						messageBuilder.AppendFormatted(blueprintId);
						messageBuilder.AppendLiteral(" into fully friendly.");
					}
					Log.Info(messageBuilder);
					factionInstance.SetPlayerFriendliness(100f, showNotification: true, processRelatedFactions: false);
				}
			}
		}

		public void GetRequirementAchievedCount(ObjectiveTask task, out int achievedCount, out int neededCount)
		{
			neededCount = 0;
			achievedCount = -1;
			if (task.Requirements == null)
			{
				return;
			}
			ObjectiveTaskRequirement[] requirements = task.Requirements;
			foreach (ObjectiveTaskRequirement objectiveTaskRequirement in requirements)
			{
				if (objectiveTaskRequirement.IncludeCountInText)
				{
					string key = task.Id + "/" + objectiveTaskRequirement.Id;
					requirementsCount.TryGetValue(key, out var value);
					neededCount = objectiveTaskRequirement.MinCount;
					achievedCount = value;
					break;
				}
			}
		}

		public void SetTaskRequirementCompleted(ObjectiveTask task, ObjectiveTaskRequirement requirement, bool isCompleted, int countAchieved)
		{
			string text = task.Id + "/" + requirement.Id;
			requirementsCount.TryGetValue(text, out var value);
			if (!requirementsCount.TryAdd(text, countAchieved))
			{
				requirementsCount[text] = countAchieved;
			}
			if (value != countAchieved)
			{
				MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskRequirementChanged(this, task, requirement);
			}
			if (isCompleted)
			{
				if (requirementsCompleted.Add(text))
				{
					MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskRequirementCompleted(this, task, requirement, isCompleted);
				}
			}
			else if (requirementsCompleted.Remove(text))
			{
				MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskRequirementCompleted(this, task, requirement, isCompleted);
			}
		}

		public bool IsRequirementCompleted(string taskId, string requirementId)
		{
			string item = taskId + "/" + requirementId;
			return requirementsCompleted.Contains(item);
		}

		public bool IsTaskCompleted(string taskID)
		{
			return tasksCompleted.Contains(taskID);
		}

		public bool IsTaskCompleted(ObjectiveTask task)
		{
			return tasksCompleted.Contains(task.Id);
		}

		public void SetTaskCompleted(string taskId, bool taskCompleted)
		{
			ObjectiveTask objectiveTask = null;
			ObjectiveTask[] tasks = Blueprint.Tasks;
			foreach (ObjectiveTask objectiveTask2 in tasks)
			{
				if (objectiveTask2.Id == taskId)
				{
					objectiveTask = objectiveTask2;
					break;
				}
			}
			if (objectiveTask == null)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(39, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot find task with ID ");
					messageBuilder.AppendFormatted(taskId);
					messageBuilder.AppendLiteral(" in objective ");
					messageBuilder.AppendFormatted(blueprintId);
				}
				Log.Debug(messageBuilder);
			}
			else
			{
				SetTaskCompleted(objectiveTask, taskCompleted);
			}
		}

		public void SetTaskCompleted(ObjectiveTask task, bool taskCompleted)
		{
			if (taskCompleted)
			{
				if (tasksCompleted.Add(task.Id))
				{
					MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskCompleted(this, task, taskCompleted);
				}
			}
			else if (tasksCompleted.Remove(task.Id))
			{
				MonoSingleton<ObjectiveController>.Instance.ObjectiveTaskCompleted(this, task, taskCompleted);
			}
		}

		public bool IsTaskEnabled(ObjectiveTask task)
		{
			if (task.Conditions == null || task.Conditions.Length == 0)
			{
				return true;
			}
			return tasksCompleted.IsSupersetOf(task.Conditions);
		}

		public override string ToString()
		{
			return blueprintId;
		}

		public void FillUITaskView(ObjectiveTask task, LayoutGroupItemView view)
		{
			GameObject gameObject = view.GroupItems[0];
			TMP_Text component = gameObject.GetComponent<TMP_Text>();
			GameObject gameObject2 = view.GroupItems[1];
			SoundButton component2 = gameObject2.GetComponent<SoundButton>();
			bool flag = IsTaskEnabled(task);
			bool flag2 = false;
			bool flag3 = false;
			if (task.IsButton)
			{
				gameObject.SetActive(value: false);
				gameObject2.SetActive(value: true);
				TMP_Text componentInChildren = component2.GetComponentInChildren<TMP_Text>();
				flag2 = IsTaskCompleted(task);
				component2.interactable = flag && !flag2;
				if (component2.interactable && MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsBlockingObjectiveButton())
				{
					component2.interactable = false;
					flag3 = true;
				}
				if (!string.IsNullOrEmpty(task.StartGameEventOnClick))
				{
					if (component2.interactable && !string.IsNullOrEmpty(task.StartGameEventOnClick) && MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning(task.StartGameEventOnClick))
					{
						component2.interactable = false;
					}
					if (MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning(task.StartGameEventOnClick))
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					componentInChildren.SetText(GetTextWithCheckmark(task, checkboxState: true));
				}
				else
				{
					componentInChildren.SetText(task.GetNameText());
				}
				component2.onClick.RemoveAllListeners();
				component2.onClick.AddListener(delegate
				{
					OnActivateTaskClick(task);
				});
			}
			else
			{
				view.SetText(0, GetTextWithCheckmark(task, IsTaskCompleted(task)));
				gameObject.SetActive(value: true);
				gameObject2.SetActive(value: false);
				component.alpha = (flag ? 1f : 0.7f);
			}
			if (flag2)
			{
				view.SetTooltipLine(FormatTooltipText(task.GetCompletedTooltipText()));
			}
			else if (flag3)
			{
				view.SetTooltipLine(FormatTooltipText(MonoSingleton<LocalizationController>.Instance.GetText("objective_button_blocked_by_event") + "\n" + task.GetTooltipText()));
			}
			else
			{
				view.SetTooltipLine(FormatTooltipText(task.GetTooltipText()));
			}
		}

		private void PlaceBanditCamps()
		{
			MonoSingleton<ObjectiveManager>.Instance.TrySpawnBanditCampsForObjective(this);
		}

		private string GetTextWithCheckmark(ObjectiveTask task, bool checkboxState)
		{
			GetRequirementAchievedCount(task, out var achievedCount, out var neededCount);
			bool num = achievedCount != -1;
			string nameTextWithCheckmark = task.GetNameTextWithCheckmark(checkboxState);
			if (!num)
			{
				return nameTextWithCheckmark;
			}
			return $"{nameTextWithCheckmark} {Math.Min(neededCount, achievedCount)} / {neededCount}";
		}

		private string FormatTooltipText(string text)
		{
			if (!text.Contains("<village_name>"))
			{
				return text;
			}
			return text.Replace("<village_name>", GlobalSaveController.CurrentVillageData.Name);
		}

		private void OnActivateTaskClick(ObjectiveTask task)
		{
			if (task.StartGameEventOnClick != null)
			{
				MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent(task.StartGameEventOnClick);
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprintId", blueprintId);
			serializer.Write("requirementsCompleted", requirementsCompleted);
			serializer.Write("requirementsCount", requirementsCount);
			serializer.Write("tasksCompleted", tasksCompleted);
			serializer.Write("completed", completed);
		}

		public ObjectiveInstance(FVDeserializer deserializer)
		{
			blueprintId = deserializer.ReadString("blueprintId");
			requirementsCompleted = deserializer.ReadStringHashSet("requirementsCompleted") ?? new HashSet<string>();
			requirementsCount = deserializer.ReadStringIntDict("requirementsCount") ?? new Dictionary<string, int>();
			tasksCompleted = deserializer.ReadStringHashSet("tasksCompleted") ?? new HashSet<string>();
			completed = deserializer.ReadBool("completed");
		}
	}
}
