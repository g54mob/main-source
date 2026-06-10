using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Almanac;
using NSMedieval.Model;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.InfoMessages
{
	public class GameplayTipsMessagesController : MonoBehaviour, IObserver
	{
		[NonSerialized]
		private Dictionary<string, WarningMessageData> warningMessageByTutorialID = new Dictionary<string, WarningMessageData>();

		[NonSerialized]
		private Dictionary<WarningMessageData, GameplayTipsSchedule> scheduleByWarningData = new Dictionary<WarningMessageData, GameplayTipsSchedule>();

		public void ShowTutorialMessage()
		{
		}

		private void Start()
		{
			MonoSingleton<GameplayTipsController>.Instance.Attach(this);
			InitializeTutorialWarningMessages();
		}

		private void OnDestroy()
		{
			if (MonoSingleton<GameplayTipsController>.IsInstantiated())
			{
				MonoSingleton<GameplayTipsController>.Instance.Detach(this);
			}
			warningMessageByTutorialID.Clear();
			warningMessageByTutorialID = null;
			scheduleByWarningData.Clear();
			scheduleByWarningData = null;
		}

		private void InitializeTutorialWarningMessages()
		{
			foreach (GameplayTipsSchedule item in GlobalSaveController.CurrentVillageData.GameplayTipsSchedule)
			{
				if (!string.IsNullOrEmpty(item.TipId) && item.TipId != null)
				{
					if (warningMessageByTutorialID.ContainsKey(item.TipId))
					{
						Log.Warning("The same tutorial scheduled multiple times.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsMessagesController.cs");
						continue;
					}
					WarningMessageData warningMessageData = new WarningMessageData(WarningMessageCategory.Lesson, item.TipId, "almanac_more_details", "TutorialIcon", OnClickTutorial, null, OnClickClose);
					warningMessageByTutorialID.Add(item.TipId, warningMessageData);
					scheduleByWarningData.Add(warningMessageData, item);
				}
			}
		}

		private GameplayTipsSchedule GetSchedule(WarningMessageData message)
		{
			if (!scheduleByWarningData.ContainsKey(message))
			{
				return null;
			}
			return scheduleByWarningData[message];
		}

		private void OnClickTutorial(WarningMessageData message)
		{
			GameplayTipsSchedule schedule = GetSchedule(message);
			if (schedule == null)
			{
				return;
			}
			MonoSingleton<WarningMessageController>.Instance.HideMessage(message);
			AlmanacEntry byID = Repository<AlmanacEntriesRepository, AlmanacEntry>.Instance.GetByID(schedule.TipId);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsMessagesController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Couldn't find Almanac Entry with ID \"");
					messageBuilder.AppendFormatted(schedule.TipId);
					messageBuilder.AppendLiteral("\"");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				MonoSingleton<UIController>.Instance.ShowAlmanacEntry(byID.Name);
			}
		}

		private void OnClickClose(WarningMessageData message)
		{
			if (GetSchedule(message) != null)
			{
				MonoSingleton<WarningMessageController>.Instance.HideMessage(message);
			}
		}

		private void OnShowMessage(GameplayTipsSchedule schedule)
		{
			if (schedule != null && !string.IsNullOrEmpty(schedule.TipId) && warningMessageByTutorialID.TryGetValue(schedule.TipId, out var value))
			{
				MonoSingleton<WarningMessageController>.Instance.ShowMessage(value);
			}
		}
	}
}
