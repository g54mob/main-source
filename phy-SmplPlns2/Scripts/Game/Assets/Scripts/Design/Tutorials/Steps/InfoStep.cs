using System.Collections.Generic;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class InfoStep : TutorialStep
	{
		private struct BackupHighlightEntry
		{
			public string ActionText;

			public string WidgetId;
		}

		private List<BackupHighlightEntry> _backupHighlights;

		private TooltipWidget _tooltip;

		private Widget _highlightedWidget;

		public bool CloseFlyouts { get; set; } = true;

		public bool AdvanceAfterPartSelected { get; set; }

		public bool AdvanceAfterWidgetClicked { get; set; }

		public Vector2 HighlightPadding { get; set; } = new Vector2(5f, 5f);

		public string HighlightWidgetPath { get; set; }

		public string SelectPartText { get; set; } = "Select the indicated part to continue.";

		public bool ShowWidgetTooltip { get; set; }

		public InfoStep(TutorialStepBuilderContext context, string stepText, string widgetPath = null, bool showTooltip = false)
			: base(context, stepText)
		{
			HighlightWidgetPath = widgetPath;
			ShowWidgetTooltip = showTooltip;
		}

		public InfoStep(TutorialStepBuilderContext context, string targetPartName, string stepText, string widgetPath = null, bool showTooltip = false)
			: base(context, context.GetPartIdByName(targetPartName), stepText)
		{
			HighlightWidgetPath = widgetPath;
			ShowWidgetTooltip = showTooltip;
		}

		public InfoStep AddBackupWigdetHighlight(string widgetId, string actionText)
		{
			if (_backupHighlights == null)
			{
				_backupHighlights = new List<BackupHighlightEntry>();
			}
			_backupHighlights.Add(new BackupHighlightEntry
			{
				WidgetId = widgetId,
				ActionText = actionText
			});
			return this;
		}

		protected override void OnEnd()
		{
			base.OnEnd();
			if (CloseFlyouts)
			{
				base.Designer.DesignerUI.Flyouts.Selected = null;
			}
			if (_highlightedWidget != null)
			{
				_highlightedWidget.Clicked -= OnTooltipWidgetClicked;
				_highlightedWidget.Context.HideTooltip(_highlightedWidget);
				_highlightedWidget = null;
			}
			if (_tooltip != null)
			{
				_tooltip.Destroy();
				_tooltip = null;
			}
			TutorialUIScript uI = base.Tutorial.TutorialScript.UI;
			if (!base.Tutorial.IsComplete)
			{
				uI.ShowOkayButton = false;
				uI.ShowRestartButton = true;
				uI.ShowStepTextSecondary = true;
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			if (HighlightWidgetPath != null)
			{
				_highlightedWidget = FindUIWidget(HighlightWidgetPath);
				if (_highlightedWidget != null)
				{
					_highlightedWidget.Clicked += OnTooltipWidgetClicked;
				}
				else
				{
					Debug.LogError("InfoStep cannot find widget: " + HighlightWidgetPath);
				}
			}
			bool flag = base.TargetPart != null;
			bool flag2 = flag && base.Designer.Designer.SelectedPart?.Part == base.TargetPart;
			TutorialUIScript uI = base.Tutorial.TutorialScript.UI;
			uI.ShowOkayButton = !flag || flag2;
			uI.ShowNextButton = false;
			uI.ShowPreviousButton = false;
			uI.ShowRestartButton = false;
			uI.SetOkayButtonText("Next");
			uI.ShowStepTextSecondary = flag && !flag2;
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (base.TargetPart != null)
			{
				TutorialUIScript uI = base.Tutorial.TutorialScript.UI;
				if (base.Designer.Designer.SelectedPart?.Part != base.TargetPart)
				{
					uI.ShowOkayButton = false;
					uI.ShowStepTextSecondary = true;
					base.InstructionText = SelectPartText;
					DisableUIHighlight();
					HighlightPart(base.TargetPart);
					return;
				}
				if (AdvanceAfterPartSelected)
				{
					CompleteStep();
				}
				uI.ShowOkayButton = true;
				uI.ShowStepTextSecondary = false;
				base.InstructionText = string.Empty;
				ClearHighlightedPart(base.TargetPart);
			}
			bool flag = HighlightWidgetPath != null && HighlightUIElement(HighlightWidgetPath, HighlightPadding);
			if (!flag && _backupHighlights != null)
			{
				TutorialUIScript uI2 = base.Tutorial.TutorialScript.UI;
				foreach (BackupHighlightEntry backupHighlight in _backupHighlights)
				{
					if (HighlightUIElement(backupHighlight.WidgetId, HighlightPadding))
					{
						uI2.ShowOkayButton = false;
						uI2.ShowStepTextSecondary = true;
						base.InstructionText = backupHighlight.ActionText;
						break;
					}
				}
			}
			else if (flag && _backupHighlights != null)
			{
				TutorialUIScript uI3 = base.Tutorial.TutorialScript.UI;
				uI3.ShowOkayButton = true;
				uI3.ShowStepTextSecondary = false;
				base.InstructionText = string.Empty;
			}
			if (_highlightedWidget != null && _tooltip == null && ShowWidgetTooltip && !string.IsNullOrWhiteSpace(_highlightedWidget.Tooltip))
			{
				_tooltip = _highlightedWidget.Context.CreateWidgetFromTemplate("tooltip", _highlightedWidget.Context.Root, null, _highlightedWidget.Context.Root.Stylesheet) as TooltipWidget;
				_tooltip.ConfigureForWidget(_highlightedWidget);
				_tooltip.Animation.ShowAnimation = null;
				_tooltip.TooltipDuration = 120f;
				_tooltip.Visible = false;
				_tooltip.Show();
			}
		}

		private void OnTooltipWidgetClicked(Widget widget)
		{
			if (AdvanceAfterWidgetClicked)
			{
				CompleteStep();
			}
		}
	}
}
