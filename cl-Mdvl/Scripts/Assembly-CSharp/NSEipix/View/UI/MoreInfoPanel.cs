using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSEipix.View.UI
{
	public class MoreInfoPanel : MonoBehaviour
	{
		[SerializeField]
		private CustomToggleWithText customToggleWithText;

		[SerializeField]
		private TMP_Text infoText;

		[SerializeField]
		private string locKey = "more_info_scenario";

		private void Awake()
		{
			customToggleWithText.onValueChanged.AddListener(delegate
			{
				MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.ToggleTutorialGuidedStepsShow();
				Show();
			});
		}

		public void Show()
		{
			customToggleWithText.SetIsOnSilently(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TutorialGuidedStepsShow);
			infoText.gameObject.SetActive(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TutorialGuidedStepsShow);
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TutorialGuidedStepsShow)
			{
				infoText.text = locKey.ToLocalized();
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\View\\UI\\MoreInfoPanel.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("should show: ");
					messageBuilder.AppendFormatted(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TutorialGuidedStepsShow);
				}
				Log.Debug(messageBuilder);
			}
		}
	}
}
