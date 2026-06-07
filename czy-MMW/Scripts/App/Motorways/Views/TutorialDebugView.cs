using Client;
using Factory;
using Factory.Pools;
using Motorways.Models;
using Motorways.Processes;
using UnityEngine;

namespace Motorways.Views
{
	public class TutorialDebugView : MonoBehaviour, IView, IReusable
	{
		[Dependency]
		private TutorialProgressionProcess _tutorialProgressionProcess;

		[Dependency]
		private ClockModel _clockModel;

		[Dependency]
		private City _city;

		private GUIStyle _style = new GUIStyle();

		public const string ShouldShowTutorialDebugView = "ShouldShowTutorialDebugView";

		private const int Padding = 10;

		private const int Margins = 10;

		private bool _isCollapsed = true;

		private const int PreviousStageCount = 2;

		private const int NextStageCount = 2;

		private bool ShouldShowView
		{
			get
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.TutorialView))
				{
					return true;
				}
				return false;
			}
		}

		private void OnEnable()
		{
			_style.fontSize = 18;
			_style.alignment = TextAnchor.MiddleLeft;
			_style.richText = true;
			_style.normal.textColor = Color.white;
			_style.normal.background = DebugViewUtils.DebugWindowBackground;
			_style.padding = new RectOffset(10, 10, 10, 10);
		}

		private void AppendStageList(ref string text)
		{
			int num = _tutorialProgressionProcess.CurrentStepIndex - 2;
			int num2 = _tutorialProgressionProcess.CurrentStepIndex + 2;
			for (int i = num; i <= num2; i++)
			{
				if (i >= 0 && i < _tutorialProgressionProcess.StageCount)
				{
					TutorialProgressionProcess.TutorialStep tutorialStep = _tutorialProgressionProcess.StageAt(i);
					string text2 = ((i == _tutorialProgressionProcess.CurrentStepIndex) ? "yellow" : "silver");
					text += $"<color={text2}>{i}: ({tutorialStep.StageShortName}) {tutorialStep.Id}</color>";
				}
				else
				{
					text += $"<color=silver>{i}: _______________</color>";
				}
				text += "\n";
			}
		}

		private void AppendTutorialInfo(ref string text, TutorialProgressionProcess.TutorialStep currentStep)
		{
			text += "\n<size=20>Info</size><size=18>\n";
			string text2 = ((currentStep == null) ? "No more steps" : currentStep.DebugText?.Invoke());
			text += text2 ?? "Not debug text set for current step.";
			text += $"\nClock Ticking: {ColorBoolean(currentStep?.DoesClockTick() ?? true)} | h:{_clockModel.Hour}, d:{_clockModel.Day}, w:{_clockModel.Week}, t:({(float)_clockModel.Time:F1})";
			text = text + "\nGameplay Input Blocked: " + ColorBoolean(_tutorialProgressionProcess.IsInputBlocked) + " | Has Mothballed Road: " + ColorBoolean(_tutorialProgressionProcess.HasPlayerMothballedARoad) + "</size>";
		}

		private string ColorBoolean(bool value)
		{
			string arg = (value ? "lime" : "red");
			return $"<color={arg}>{value}</color>";
		}

		private Rect CalculateRectSize(string text)
		{
			GUIContent content = new GUIContent(text);
			Vector2 vector = _style.CalcSize(content);
			return new Rect(10f, (float)Screen.height - vector.y - 10f, vector.x, vector.y);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Reset()
		{
			_style = new GUIStyle();
		}
	}
}
