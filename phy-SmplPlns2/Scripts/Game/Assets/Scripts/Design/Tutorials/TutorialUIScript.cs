using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Design.UI.Input;
using Assets.Scripts.Input;
using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Tutorials
{
	public class TutorialUIScript : WidgetScript
	{
		private ButtonWidget _closeButton;

		private Widget _emptySpaceWidget;

		private ImageWidget _highlightImage;

		private ImageWidget _highlightOffscreenImage;

		private ButtonWidget _nextButton;

		private ButtonWidget _okayButton;

		private ButtonWidget _previousButton;

		private string _primaryText;

		private ButtonWidget _restartButton;

		private GameObject _screenInputGameObject;

		private string _secondaryText;

		private TextWidget _stepTextPrimary;

		private TextWidget _stepTextSecondary;

		private List<Widget> _toolPanelWidgets;

		private TutorialScript _tutorialScript;

		public string PrimaryText
		{
			get
			{
				return _primaryText;
			}
			set
			{
				_primaryText = value;
				_stepTextPrimary.Text = ProcessStepText(value);
			}
		}

		public string PrimaryTextRaw
		{
			get
			{
				return _stepTextPrimary.Text;
			}
			set
			{
				_primaryText = value;
				_stepTextPrimary.Text = value;
			}
		}

		public string SecondaryText
		{
			get
			{
				return _secondaryText;
			}
			set
			{
				_secondaryText = value;
				_stepTextSecondary.Text = ProcessStepText(value);
			}
		}

		public string SecondaryTextRaw
		{
			get
			{
				return _stepTextSecondary.Text;
			}
			set
			{
				_secondaryText = value;
				_stepTextSecondary.Text = value;
			}
		}

		public bool ShowCloseButton
		{
			get
			{
				return _closeButton.Visible;
			}
			set
			{
				_closeButton.Visible = value;
			}
		}

		public bool ShowNextButton
		{
			get
			{
				return _nextButton.Visible;
			}
			set
			{
				_nextButton.Visible = value;
			}
		}

		public bool ShowOkayButton
		{
			get
			{
				return _okayButton.Visible;
			}
			set
			{
				_okayButton.Visible = value;
			}
		}

		public bool ShowPreviousButton
		{
			get
			{
				return _previousButton.Visible;
			}
			set
			{
				_previousButton.Visible = value;
			}
		}

		public bool ShowRestartButton
		{
			get
			{
				return _restartButton.Visible;
			}
			set
			{
				_restartButton.Visible = value;
			}
		}

		public bool ShowStepTextPrimary
		{
			get
			{
				return _stepTextPrimary.Visible;
			}
			set
			{
				_stepTextPrimary.Visible = value;
			}
		}

		public bool ShowStepTextSecondary
		{
			get
			{
				return _stepTextSecondary.Visible;
			}
			set
			{
				_stepTextSecondary.Visible = value;
			}
		}

		public void DisableHighlight()
		{
			_highlightImage.Visible = false;
			_highlightOffscreenImage.Visible = false;
		}

		public void EnableEmptySpaceWidget(bool enable)
		{
			if (enable)
			{
				Vector2? vector = FindEmptyScreenPosition();
				if (vector.HasValue)
				{
					RectTransformUtility.ScreenPointToLocalPointInRectangle(_emptySpaceWidget.Rect.parent as RectTransform, vector.Value, null, out var localPoint);
					_emptySpaceWidget.Rect.localPosition = localPoint;
				}
			}
			_emptySpaceWidget.Visible = enable;
		}

		public void EnableHighlight(Vector3 position, int width, int height, Color color, ScrollRect scrollRect)
		{
			RectTransform rect = _highlightImage.Rect;
			rect.sizeDelta = new Vector2(width, height);
			rect.localPosition = position;
			Vector2 vector = new Vector2(0f, 0f);
			Vector2 vector2 = new Vector2(Screen.width, Screen.height);
			if (scrollRect != null)
			{
				Vector3[] array = new Vector3[4];
				scrollRect.GetComponent<RectTransform>().GetWorldCorners(array);
				Vector2 vector3 = RectTransformUtility.WorldToScreenPoint(null, array[0]);
				Vector2 vector4 = RectTransformUtility.WorldToScreenPoint(null, array[2]);
				vector.x = Mathf.Max(vector.x, vector3.x);
				vector.y = Mathf.Max(vector.y, vector3.y);
				vector2.x = Mathf.Min(vector2.x, vector4.x);
				vector2.y = Mathf.Min(vector2.y, vector4.y);
			}
			if (rect.position.x < vector.x || rect.position.x > vector2.x || rect.position.y < vector.y || rect.position.y > vector2.y)
			{
				RectTransform rect2 = _highlightOffscreenImage.Rect;
				Vector3 position2 = rect.position;
				float num = 0f;
				if (position2.y < vector.y)
				{
					num = 180f;
					position2.y = vector.y + rect2.sizeDelta.y;
				}
				else if (position2.y > vector2.y)
				{
					num = 0f;
					position2.y = vector2.y - rect2.sizeDelta.y;
				}
				if (position2.x < vector.x)
				{
					num = 90f;
					position2.x = vector.x + rect2.sizeDelta.x;
				}
				else if (position2.x > vector2.x)
				{
					num = 270f;
					position2.x = vector2.x - rect2.sizeDelta.x;
				}
				rect2.localRotation = Quaternion.Euler(0f, 0f, num + 180f);
				rect2.position = position2;
				_highlightOffscreenImage.Image.color = color;
				_highlightOffscreenImage.gameObject.SetActive(value: true);
				_highlightImage.gameObject.SetActive(value: false);
			}
			else
			{
				_highlightImage.Image.color = color;
				_highlightImage.gameObject.SetActive(value: true);
				_highlightOffscreenImage.gameObject.SetActive(value: false);
			}
		}

		public void Initialize(TutorialScript tutorialScript)
		{
			_tutorialScript = tutorialScript;
			_screenInputGameObject = _tutorialScript.Designer.DesignerUI.GetComponentInChildren<DesignerScreenInputScript>()?.gameObject;
			Widget rootWidget = _tutorialScript.Designer.DesignerUI.RootWidget;
			string[] obj = new string[4] { "tool-panel-translate", "tool-panel-rotate", "tool-panel-trapezoid", "mass-text" };
			_toolPanelWidgets = new List<Widget>();
			string[] array = obj;
			foreach (string text in array)
			{
				Widget widget = rootWidget.FindWidget(text);
				if (widget != null)
				{
					_toolPanelWidgets.Add(widget);
				}
				else
				{
					Debug.LogError("TutorialUIScript: Tool panel widget not found: " + text);
				}
			}
		}

		public void OnTutorialEnding(Tutorial tutorial)
		{
			foreach (Widget toolPanelWidget in _toolPanelWidgets)
			{
				toolPanelWidget.EnableClass("tool-panel-tutorial", enabled: false);
				toolPanelWidget.UpdateWidget(null);
			}
			SetVisibility(visible: false);
		}

		public void OnTutorialStarting(Tutorial tutorial)
		{
			foreach (Widget toolPanelWidget in _toolPanelWidgets)
			{
				toolPanelWidget.EnableClass("tool-panel-tutorial", enabled: true);
				toolPanelWidget.UpdateWidget(null);
			}
			SetVisibility(visible: true);
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_closeButton = widget.FindWidget<ButtonWidget>("tutorial-button-quit");
			_nextButton = widget.FindWidget<ButtonWidget>("tutorial-button-next");
			_previousButton = widget.FindWidget<ButtonWidget>("tutorial-button-prev");
			_restartButton = widget.FindWidget<ButtonWidget>("tutorial-button-restart-step");
			_okayButton = widget.FindWidget<ButtonWidget>("tutorial-button-complete");
			_stepTextPrimary = widget.FindWidget<TextWidget>("tutorial-text-1");
			_stepTextSecondary = widget.FindWidget<TextWidget>("tutorial-text-2");
			_highlightImage = widget.FindWidget<ImageWidget>("tutorial-highlight");
			_highlightOffscreenImage = widget.FindWidget<ImageWidget>("tutorial-highlight-offscreen");
			_emptySpaceWidget = widget.FindWidget("tutorial-empty-space");
			_closeButton.Clicked += CloseButtonClicked;
			_restartButton.Clicked += RestartStepButtonClicked;
			_nextButton.Clicked += NextButtonClicked;
			_previousButton.Clicked += PreviousButtonClicked;
			_okayButton.Clicked += OkayButtonClicked;
			DisableHighlight();
		}

		public void SetOkayButtonText(string text)
		{
			_okayButton.FindWidget<TextWidget>("tutorial-button-text").Text = text;
		}

		private void CloseButtonClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Are you sure you want to quit the tutorial?", "Quit Tutorial", delegate(MessageDialogScript d)
			{
				_tutorialScript.EndTutorial();
				UndoStep currentUndoStep = _tutorialScript.Designer.Designer.UndoHistory.CurrentUndoStep;
				if (currentUndoStep != null)
				{
					_tutorialScript.Designer.Designer.RestoreFromUndoStep(currentUndoStep);
				}
				d.Close();
			});
		}

		private Vector2? FindEmptyScreenPosition()
		{
			Camera camera = _tutorialScript.Designer.Designer.CameraController.Camera;
			float num = (float)Screen.width * 0.2f;
			float num2 = (float)Screen.height * 0.15f;
			float num3 = (float)Screen.width - num * 2f;
			float num4 = (float)Screen.height - num2 * 2f;
			List<Vector2> value;
			using (CollectionPool<List<Vector2>, Vector2>.Get(out value))
			{
				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < 14; j++)
					{
						float x = num + num3 * ((float)j / 13f);
						float y = num2 + num4 * ((float)i / 9f);
						value.Add(new Vector2(x, y));
					}
				}
				Vector2 topRight = new Vector2(Screen.width, Screen.height);
				value.Sort((Vector2 a, Vector2 b) => Vector2.SqrMagnitude(a - topRight).CompareTo(Vector2.SqrMagnitude(b - topRight)));
				List<RaycastResult> list = new List<RaycastResult>();
				PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
				foreach (Vector2 item in value)
				{
					list.Clear();
					pointerEventData.position = item;
					EventSystem.current.RaycastAll(pointerEventData, list);
					if (list.Any((RaycastResult r) => r.gameObject != _screenInputGameObject))
					{
						continue;
					}
					bool flag = false;
					Span<Vector2> span = stackalloc Vector2[5]
					{
						Vector2.zero,
						new Vector2(-50f, -50f),
						new Vector2(50f, -50f),
						new Vector2(-50f, 50f),
						new Vector2(50f, 50f)
					};
					for (int num5 = 0; num5 < span.Length; num5++)
					{
						Vector2 vector = span[num5];
						if (Physics.Raycast(camera.ScreenPointToRay(item + vector), 10000f, 2129921))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return item;
					}
				}
				return null;
			}
		}

		private void GetStepTextSegments(string text, List<(int StartIndex, int Length)> segments)
		{
			int num = 0;
			while (num < text.Length)
			{
				int num2 = text.IndexOf('[', num);
				if (num2 == -1)
				{
					break;
				}
				int num3 = 1;
				int num4 = -1;
				for (int i = num2 + 1; i < text.Length; i++)
				{
					switch (text[i])
					{
					case '[':
						num3++;
						continue;
					case ']':
						num3--;
						if (num3 != 0)
						{
							continue;
						}
						break;
					default:
						continue;
					}
					num4 = i;
					break;
				}
				if (num4 != -1)
				{
					segments.Add((num2, num4 - num2 + 1));
					num = num4 + 1;
					continue;
				}
				break;
			}
		}

		private void NextButtonClicked(Widget widget)
		{
			_tutorialScript.MoveToNextStep();
		}

		private void OkayButtonClicked(Widget widget)
		{
			Tutorial currentTutorial = _tutorialScript.CurrentTutorial;
			if (currentTutorial != null && currentTutorial.IsComplete)
			{
				_tutorialScript.EndTutorial();
			}
			else
			{
				_tutorialScript.MoveToNextStep();
			}
		}

		private void PreviousButtonClicked(Widget widget)
		{
			_tutorialScript.MoveToPreviousStep();
		}

		private string ProcessStepText(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			List<(int, int)> value;
			using (CollectionPool<List<(int, int)>, (int, int)>.Get(out value))
			{
				GetStepTextSegments(text, value);
				for (int num = value.Count - 1; num >= 0; num--)
				{
					(int, int) tuple = value[num];
					string segment = text.Substring(tuple.Item1, tuple.Item2);
					string value2 = ProcessStepTextSegment(segment);
					text = text.Remove(tuple.Item1, tuple.Item2).Insert(tuple.Item1, value2);
				}
				return text;
			}
		}

		private string ProcessStepTextSegment(string segment)
		{
			StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
			if (segment.Equals("[click:]", comparisonType))
			{
				bool flag = segment[1] == 'C';
				if (!Device.IsMobileBuild)
				{
					if (!flag)
					{
						return "click";
					}
					return "Click";
				}
				if (!flag)
				{
					return "tap";
				}
				return "Tap";
			}
			if (segment.Equals("[clicking:]", comparisonType))
			{
				bool flag2 = segment[1] == 'C';
				if (!Device.IsMobileBuild)
				{
					if (!flag2)
					{
						return "clicking";
					}
					return "Clicking";
				}
				if (!flag2)
				{
					return "taping";
				}
				return "Taping";
			}
			if (segment.StartsWith("[keybind:", comparisonType))
			{
				string text = segment.Substring(9, segment.Length - 10);
				GameInputs inputs = Game.Inputs;
				if (!(inputs.GetType().GetProperty(text, BindingFlags.Instance | BindingFlags.Public)?.GetValue(inputs) is IGameInput gameInput))
				{
					Debug.LogError("Input not found: " + text);
					return "INPUT_NOT_FOUND: " + text;
				}
				return gameInput.GetKeyboardPrimaryBindingText();
			}
			string text2 = string.Empty;
			string[] array = segment.Substring(1, segment.Length - 2).Split('|');
			foreach (string text3 in array)
			{
				if (text3.StartsWith("mobile:", comparisonType))
				{
					if (Device.IsMobileBuild)
					{
						text2 = text3.Substring(7);
						break;
					}
				}
				else if (text3.StartsWith("steamdeck:", comparisonType))
				{
					if (Device.IsWindowsBuild && SocialExt.IsSteamDeckOrBigPicture)
					{
						text2 = text3.Substring(10);
						break;
					}
				}
				else if (text3.StartsWith("keyboard:", comparisonType))
				{
					if (!Device.IsMobileBuild && !SocialExt.IsSteamDeckOrBigPicture)
					{
						text2 = text3.Substring(9);
						break;
					}
				}
				else
				{
					text2 = text3;
				}
			}
			return ProcessStepText(text2);
		}

		private void RestartStepButtonClicked(Widget widget)
		{
			_tutorialScript.RestartStep();
		}

		private void SetVisibility(bool visible)
		{
			Widget widget = base.Widget;
			if (visible)
			{
				widget.Show();
			}
			else
			{
				widget.Hide();
			}
		}
	}
}
