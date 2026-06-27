using System;
using System.Linq;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.CrashReportHandler;
using Zenject;

namespace Restory.Infrastructure.ProjectServices
{
	public class GlobalGameCrashReportMetaDataCollector : IInitializable, IDisposable
	{
		public class Factory : PlaceholderFactory<GlobalGameCrashReportMetaDataCollector>
		{
		}

		private const string UNDEFINED_NAME = "null";

		private readonly GlobalStateObserver globalStateObserver;

		private readonly LoadPresetListHistory presetListHistory;

		private IExitableState activeState;

		private IExitableState previousState;

		public GlobalGameCrashReportMetaDataCollector(GlobalStateObserver globalStateObserver, LoadPresetListHistory presetListHistory)
		{
			this.globalStateObserver = globalStateObserver;
			this.presetListHistory = presetListHistory;
		}

		public void Initialize()
		{
			CrashReportHandler.SetUserMetadata("AnalyticsSessionInfo.UserID", AnalyticsSessionInfo.userId);
			CrashReportHandler.SetUserMetadata("AnalyticsSessionInfo.SessionID", AnalyticsSessionInfo.sessionId.ToString());
			Application.logMessageReceivedThreaded += Application_logMessageReceivedThreaded;
			globalStateObserver.AddSubscriber(this, LogGlobalMachineState);
			LogGlobalMachineState();
			presetListHistory.OnEnqueued += OnPresetListHistoryOnOnEnqueued;
			OnPresetListHistoryOnOnEnqueued();
		}

		private void OnPresetListHistoryOnOnEnqueued()
		{
			PresetHistoryRecord presetHistoryRecord = presetListHistory.Records.LastOrDefault();
			string value = ((presetHistoryRecord != null) ? presetHistoryRecord.PresetName : "null");
			CrashReportHandler.SetUserMetadata("LoadPresetListHistory.Last", value);
		}

		public void Dispose()
		{
			globalStateObserver.RemoveSubscriber(this);
			Application.logMessageReceivedThreaded -= Application_logMessageReceivedThreaded;
		}

		private void LogGlobalMachineState()
		{
			previousState = activeState;
			activeState = globalStateObserver.ActiveState;
			string value = ((previousState != null) ? previousState.GetType().Name : "null");
			CrashReportHandler.SetUserMetadata("GlobalGameState.Previous", value);
			string value2 = ((activeState != null) ? activeState.GetType().Name : "null");
			CrashReportHandler.SetUserMetadata("GlobalGameState.Active", value2);
		}

		private void Application_logMessageReceivedThreaded(string condition, string stacktrace, LogType type)
		{
			if (type != LogType.Error)
			{
				_ = 4;
			}
		}
	}
}
