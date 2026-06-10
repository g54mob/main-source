using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Tools.BugReporting;
using UnityEngine;

namespace NSMedieval.Tools.Debug
{
	public class BugReporterManager : MonoSingleton<BugReporterManager>, IObserver
	{
		[SerializeField]
		private BugReporter bugReporter;

		private bool exceptionCaught;

		private bool isDevConsoleOpened;

		public bool IsDevConsoleOpened
		{
			get
			{
				return isDevConsoleOpened;
			}
			set
			{
				isDevConsoleOpened = value;
			}
		}

		public void ShowReporter()
		{
			bugReporter.Show();
		}

		protected override void Awake()
		{
			if (MonoSingleton<BugReporterManager>.IsInstantiated())
			{
				base.Awake();
				return;
			}
			base.Awake();
			Log.Info("Bug reporting Active.", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\BugReporterManager.cs");
			Application.logMessageReceived += LogCallback;
		}

		protected override void OnDestroy()
		{
			Application.logMessageReceived -= LogCallback;
			base.OnDestroy();
		}

		private void OnDisable()
		{
			Log.Info("Deactivating bug reporting.", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\BugReporterManager.cs");
			Application.logMessageReceived -= LogCallback;
		}

		public void ReportException(string preText, string stackTrace)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\BugReporterManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Trying to report exception \"");
				messageBuilder.AppendFormatted(preText);
				messageBuilder.AppendLiteral("\"\nStack Trace:\n");
				messageBuilder.AppendFormatted(stackTrace);
			}
			Log.Info(messageBuilder);
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SendAutoReports || exceptionCaught)
			{
				return;
			}
			BugReporter.WindowType initialState = (IntegrityChecker.IsGameModified ? BugReporter.WindowType.QuittingNoReport : BugReporter.WindowType.Quitting);
			bugReporter.Show(initialState);
			MonoSingleton<BugReporterJiraAPI>.Instance.SubmitReport(BugReporterJiraAPI.ReportPriority.High, BugReporterJiraAPI.ReportType.Exception, TextFormatting.GetErrorFilename(stackTrace), preText + "\n" + stackTrace, delegate(BugReporterJiraAPI.ReportStatus status)
			{
				if (status == BugReporterJiraAPI.ReportStatus.Error)
				{
					bugReporter.Show(BugReporter.WindowType.ErrorOccured);
				}
				else
				{
					MonoSingleton<TaskController>.Instance.WaitForUnscaled(3f).Then(delegate
					{
						bugReporter.Close();
					});
				}
			});
			exceptionCaught = true;
		}

		private void LogCallback(string condition, string stackTrace, LogType type)
		{
			if (type == LogType.Exception && !exceptionCaught)
			{
				ReportException(FilePathUtils.RemoveUserFromPath(condition), stackTrace);
			}
		}
	}
}
