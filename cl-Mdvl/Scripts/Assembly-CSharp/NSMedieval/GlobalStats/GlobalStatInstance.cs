using System;
using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Objectives;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using Objectives;
using UnityEngine;

namespace NSMedieval.GlobalStats
{
	[FVSerializableKey("GlobalStatInstance", "")]
	public class GlobalStatInstance : IFVSerializable
	{
		private readonly string blueprintId;

		private float value;

		private HashSet<string> triggersActivated;

		private string offeringObjective;

		private bool isShown;

		private bool blueprintSet;

		private GlobalStat blueprint;

		private bool objectiveIdCacheSet;

		private string objectiveIdCache;

		public GlobalStat Blueprint
		{
			get
			{
				if (!blueprintSet)
				{
					blueprint = Repository<GlobalStatRepository, GlobalStat>.Instance.GetByID(blueprintId);
					blueprintSet = true;
				}
				return blueprint;
			}
		}

		public float Value => value;

		public float NormalizedValue => (value - blueprint.Min) / (blueprint.Max - blueprint.Min);

		public string BlueprintId => blueprintId;

		public string OfferingObjective => offeringObjective;

		public string ObjectiveToActivate
		{
			get
			{
				if (!objectiveIdCacheSet)
				{
					if (Blueprint != null)
					{
						GlobalStatTrigger[] triggers = Blueprint.Triggers;
						foreach (GlobalStatTrigger globalStatTrigger in triggers)
						{
							if (!string.IsNullOrEmpty(globalStatTrigger.OfferObjective))
							{
								objectiveIdCache = globalStatTrigger.OfferObjective;
								break;
							}
						}
					}
					objectiveIdCacheSet = true;
				}
				return objectiveIdCache;
			}
		}

		public bool ShouldShowMessages
		{
			get
			{
				if (Blueprint == null)
				{
					return false;
				}
				if (Blueprint.AlwaysShowMessages || string.IsNullOrEmpty(ObjectiveToActivate))
				{
					return true;
				}
				if (!MonoSingleton<ObjectiveManager>.IsInstantiated())
				{
					return false;
				}
				ObjectiveInstance activeObjective = MonoSingleton<ObjectiveManager>.Instance.ActiveObjective;
				if (activeObjective == null)
				{
					return true;
				}
				return ObjectiveToActivate == activeObjective.BlueprintId;
			}
		}

		public GlobalStatInstance(GlobalStat blueprint)
		{
			this.blueprint = blueprint;
			blueprintId = blueprint.GetID();
			blueprintSet = true;
			value = blueprint.DefaultValue;
			triggersActivated = new HashSet<string>();
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Created GlobalStatInstance: ");
				messageBuilder.AppendFormatted(BlueprintId);
			}
			Log.Debug(messageBuilder);
		}

		public void SetValue(float newValue, bool allowShowBbt)
		{
			if (Blueprint == null)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot set global stat ");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral(" - it does not exist.");
				}
				Log.Debug(messageBuilder);
			}
			else
			{
				newValue = Mathf.Clamp(newValue, Blueprint.Min, Blueprint.Max);
				if (!Mathf.Approximately(newValue, value))
				{
					float oldValue = value;
					value = newValue;
					MonoSingleton<GlobalStatController>.Instance.GlobalStatValueSet(this, oldValue, allowShowBbt);
					CheckActivateTrigger();
				}
			}
		}

		public void AddToValue(float toAdd)
		{
			if (Blueprint == null)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot add to global stat ");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral(" - it does not exist.");
				}
				Log.Debug(messageBuilder);
			}
			else
			{
				float num = value;
				float a = Mathf.Clamp(num + toAdd, Blueprint.Min, Blueprint.Max);
				if (!Mathf.Approximately(a, value))
				{
					value = a;
					MonoSingleton<GlobalStatController>.Instance.GlobalStatValueSet(this, num);
					CheckActivateTrigger();
				}
			}
		}

		public void TickDailyFalloff()
		{
			if (!(Blueprint == null) && !Mathf.Approximately(Blueprint.DailyFalloff, 0f))
			{
				if (Blueprint.DailyFalloffThreshold <= 0f)
				{
					value -= Blueprint.DailyFalloff;
				}
				else if (!(value >= Blueprint.DailyFalloffThreshold))
				{
					value = Math.Clamp(value - Blueprint.DailyFalloff, 0f, Blueprint.DailyFalloffThreshold);
				}
			}
		}

		public void CheckActivateTrigger()
		{
			if (Blueprint == null)
			{
				return;
			}
			GlobalStatTrigger[] triggers = Blueprint.Triggers;
			foreach (GlobalStatTrigger globalStatTrigger in triggers)
			{
				if (value >= globalStatTrigger.Value && !triggersActivated.Contains(globalStatTrigger.ID))
				{
					ActivateTrigger(globalStatTrigger);
				}
			}
		}

		public string GetNameLocalized()
		{
			if (Blueprint == null)
			{
				return string.Empty;
			}
			return LocKeyUtils.GetName(Blueprint.LocKeys).ToLocalized();
		}

		public string GetTooltipLocalized()
		{
			if (Blueprint == null)
			{
				return string.Empty;
			}
			string result = LocKeyUtils.GetDescription(Blueprint.LocKeys).ToLocalized();
			if (0 == 0)
			{
				return result;
			}
			if (Blueprint.Triggers == null || Blueprint.Triggers.Length == 0)
			{
				return result;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(result);
			stringBuilder.Append("[DEV] Triggers:\n");
			GlobalStatTrigger[] triggers = Blueprint.Triggers;
			int num = 0;
			while (num < triggers.Length)
			{
				GlobalStatTrigger globalStatTrigger = triggers[num];
				stringBuilder.Append(string.Format("   * {0} ( > {1}){2}\n", globalStatTrigger.ID, globalStatTrigger.Value, triggersActivated.Contains(globalStatTrigger.ID) ? " - Activated" : string.Empty));
				num++;
			}
			return stringBuilder.ToString();
		}

		public string GetObjectiveButtonTooltipLocalized()
		{
			if (string.IsNullOrEmpty(offeringObjective))
			{
				return string.Empty;
			}
			Objective byID = Repository<ObjectiveRepository, Objective>.Instance.GetByID(offeringObjective);
			if (byID == null)
			{
				return string.Empty;
			}
			return byID.GetTooltipLocalized();
		}

		public string GetObjectiveButtonText()
		{
			if (string.IsNullOrEmpty(offeringObjective))
			{
				return string.Empty;
			}
			Objective byID = Repository<ObjectiveRepository, Objective>.Instance.GetByID(offeringObjective);
			if (byID == null)
			{
				return string.Empty;
			}
			return byID.GetNameLocalized();
		}

		public bool IsHidden()
		{
			if (Blueprint == null)
			{
				return true;
			}
			if (Blueprint.HideInUi)
			{
				return !isShown;
			}
			return false;
		}

		private void ActivateTrigger(GlobalStatTrigger trigger)
		{
			if (!MonoSingleton<ObjectiveManager>.Instance.IsObjectiveEnabledInScenario(ObjectiveToActivate) || trigger == null || !triggersActivated.Add(trigger.ID) || !ShouldShowMessages)
			{
				return;
			}
			bool isEnabled;
			if (!string.IsNullOrEmpty(trigger.OfferObjective))
			{
				if (trigger.SkipAcceptButton)
				{
					offeringObjective = null;
					Objective byID = Repository<ObjectiveRepository, Objective>.Instance.GetByID(trigger.OfferObjective);
					if (byID != null)
					{
						MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.SetActiveObjective(byID);
					}
					else
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatInstance.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Objective with ID ");
							messageBuilder.AppendFormatted(trigger.OfferObjective);
							messageBuilder.AppendLiteral(" not found.");
						}
						Log.Error(messageBuilder);
					}
				}
				else
				{
					offeringObjective = trigger.OfferObjective;
				}
			}
			if (!string.IsNullOrEmpty(trigger.StartEvent))
			{
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(43, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatInstance.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Starting event ");
					messageBuilder2.AppendFormatted(trigger.StartEvent);
					messageBuilder2.AppendLiteral(" on global stat ");
					messageBuilder2.AppendFormatted(blueprintId);
					messageBuilder2.AppendLiteral(" - trigger: ");
					messageBuilder2.AppendFormatted(trigger.ID);
				}
				Log.Info(messageBuilder2);
				MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent(trigger.StartEvent);
			}
			if (!string.IsNullOrEmpty(trigger.ShowBbt))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText(trigger.ShowBbt));
			}
			if (trigger.StartShowing && !isShown)
			{
				isShown = true;
			}
			MonoSingleton<GlobalStatController>.Instance.StatTriggerActivated(this, trigger);
			MonoSingleton<AchievementManager>.Instance.UnlockAchievement(trigger.UnlockAchievementOnTrigger);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprintId", blueprintId);
			serializer.Write("value", value);
			serializer.Write("triggersActivated", triggersActivated);
			serializer.Write("offeringObjective", offeringObjective);
			serializer.Write("isShown", isShown);
		}

		public GlobalStatInstance(FVDeserializer deserializer)
		{
			blueprintId = deserializer.ReadString("blueprintId");
			value = deserializer.ReadFloat("value");
			offeringObjective = deserializer.ReadString("offeringObjective");
			triggersActivated = deserializer.ReadStringHashSet("triggersActivated");
			isShown = deserializer.ReadBool("isShown");
			if (triggersActivated == null)
			{
				triggersActivated = new HashSet<string>();
			}
		}
	}
}
