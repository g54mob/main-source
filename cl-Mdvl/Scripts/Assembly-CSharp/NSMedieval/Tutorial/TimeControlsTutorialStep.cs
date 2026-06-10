using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class TimeControlsTutorialStep : TutorialStep
	{
		public TimeControlsTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_normal_speed"),
				new TutorialStepTask("tut_fast_speed"),
				new TutorialStepTask("tut_fastest_speed"),
				new TutorialStepTask("tut_pause_game")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<UIShowManager>.Instance.ShowTimeControls();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowTimeControls(allow: true);
			Pause();
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIShowManager>.Instance.TimeControls.gameObject.GetComponent<RectTransform>());
			MonoSingleton<GameSpeedManager>.Instance.UpdateTimeScaleUIEvent += OnTimeScaleUpdate;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}

		private void OnTimeScaleUpdate(float timeScale, int speed)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(37, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TimeControlsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Time scale updated - scale: ");
				messageBuilder.AppendFormatted(timeScale);
				messageBuilder.AppendLiteral(", speed: ");
				messageBuilder.AppendFormatted(speed);
			}
			Log.Debug(messageBuilder);
			if (Tasks[2].IsComplete && speed == 0)
			{
				CompleteTask(3);
			}
			else if (Tasks[1].IsComplete && speed == 3)
			{
				CompleteTask(2);
				Tasks[3].SetActive(active: true);
			}
			else if (Tasks[0].IsComplete && speed == 2)
			{
				CompleteTask(1);
				Tasks[2].SetActive(active: true);
			}
			else if (speed == 1)
			{
				CompleteTask(0);
				Tasks[1].SetActive(active: true);
			}
		}
	}
}
