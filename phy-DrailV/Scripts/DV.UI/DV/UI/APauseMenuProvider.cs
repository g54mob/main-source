using DV.Common;
using UnityEngine;

namespace DV.UI
{
	public abstract class APauseMenuProvider : MonoBehaviour
	{
		public abstract ASettingsProvider SettingsProvider { get; }

		public abstract AUserProfileProvider UserProfileProvider { get; }

		public abstract ABugReportDataProvider BugReportDataProvider { get; }

		public abstract ATutorialsMenuProvider TutorialsMenuProvider { get; }

		public abstract IGameSession Session { get; }

		public virtual bool HasUnsavedProgress { get; set; }

		public abstract bool IsVR { get; }
	}
}
