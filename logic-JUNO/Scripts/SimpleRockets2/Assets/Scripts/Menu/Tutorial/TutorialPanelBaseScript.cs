using System;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.Tutorial
{
	public class TutorialPanelBaseScript : MonoBehaviour
	{
		private class HighlightTarget
		{
			public Vector2 Padding { get; set; }

			public RectTransform Target { get; set; }
		}

		private Action _buttonAction;

		private XmlElement _buttonPanel;

		private XmlElement _closeButton;

		private Image _highlight;

		private Color _highlightColor;

		private HighlightTarget _highlightTarget;

		private float _highlightTime;

		private TextMeshProUGUI _instructionText;

		private TextMeshProUGUI _stepText;

		public bool CanClose
		{
			get
			{
				return _closeButton.Visible;
			}
			set
			{
				_closeButton.SetActive(value);
			}
		}

		public string InstructionText
		{
			get
			{
				return _instructionText.text;
			}
			set
			{
				_instructionText.text = value;
			}
		}

		public Action OnClosed { get; set; }

		public string StepText
		{
			get
			{
				return _stepText.text;
			}
			set
			{
				_stepText.text = value;
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		protected XmlElement Panel { get; private set; }

		public static GameObject FindFlightUiGameObject(string name, bool includeInactive = false)
		{
			Transform transform = Game.Instance.UserInterface.Transform;
			return Utilities.FindFirstGameObjectMyselfOrChildren(name, transform.gameObject, includeInactive);
		}

		public virtual void CloseTutorial()
		{
			OnClosed?.Invoke();
			OnClosed = null;
			base.gameObject.SetActive(value: false);
		}

		public void DisableButton()
		{
			_buttonPanel.gameObject.SetActive(value: false);
			_buttonAction = null;
		}

		public void DisableHighlight()
		{
			_highlightTarget = null;
		}

		public void EnableButton(Action action, bool highlight = true)
		{
			_buttonPanel.gameObject.SetActive(value: true);
			if (highlight)
			{
				HighlightUiElement("Tutorial.OkayButton", new Vector2(12f, 12f), highlightEvenIfInactive: true);
			}
			_buttonAction = action;
		}

		public bool HighlightUiElement(string name, Vector2 padding, bool highlightEvenIfInactive = false)
		{
			GameObject gameObject = FindFlightUiGameObject(name);
			return HighlightUiElement(gameObject, padding, highlightEvenIfInactive);
		}

		public bool HighlightUiElement(GameObject gameObject, Vector2 padding, bool highlightEvenIfInactive)
		{
			if (gameObject != null && (gameObject.activeInHierarchy || highlightEvenIfInactive))
			{
				_highlightTarget = new HighlightTarget
				{
					Target = gameObject.GetComponent<RectTransform>(),
					Padding = padding
				};
				return true;
			}
			_highlightTarget = null;
			return false;
		}

		public void OnButtonClicked()
		{
			_buttonAction?.Invoke();
		}

		public void OnCloseButtonClicked()
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Would you like to close this tutorial?";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				CloseTutorial();
			};
		}

		public virtual void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			Panel = xmlLayout.GetElementById("tutorial-panel");
			_instructionText = xmlLayout.GetElementById<TextMeshProUGUI>("tutorial-instruction-text");
			_stepText = xmlLayout.GetElementById<TextMeshProUGUI>("tutorial-step-text");
			_highlight = xmlLayout.GetElementById<Image>("tutorial-highlight");
			_buttonPanel = xmlLayout.GetElementById("tutorial-button-panel");
			_closeButton = xmlLayout.GetElementById("close-button");
		}

		protected virtual void LateUpdate()
		{
			AnimateHighlightColors();
			if (_highlightTarget != null)
			{
				if (_highlightTarget.Target != null)
				{
					RectTransform component = GetComponent<RectTransform>();
					Vector2[] array = new Vector2[4];
					UiUtilities.GetRectCornersInLocalSpace(_highlightTarget.Target, component, array, null);
					Vector2 vector = (array[0] + array[2]) / 2f;
					Vector2 vector2 = array[2] - array[0];
					if (vector2.x > 2f && vector2.y > 2f)
					{
						vector2 *= 1f + 0.025f * Mathf.Sin(Time.time * 8f);
						EnableHighlight(vector, Mathf.Abs(vector2.x + _highlightTarget.Padding.x), Mathf.Abs(vector2.y + _highlightTarget.Padding.y), _highlightColor);
					}
					else
					{
						_highlight.gameObject.SetActive(value: false);
					}
				}
				else
				{
					_highlightTarget = null;
				}
			}
			else
			{
				_highlight.gameObject.SetActive(value: false);
			}
		}

		protected virtual void Start()
		{
			Panel.Show();
		}

		private void AnimateHighlightColors()
		{
			_highlightTime += Time.unscaledDeltaTime;
			float num = (Mathf.Sin(_highlightTime * 5f) + 1f) / 2f;
			float num2 = 0.25f;
			float a = num2 + (1f - num2) * num;
			_highlightColor = new Color(0f, 1f, 0f, a);
		}

		private void EnableHighlight(Vector3 position, float width, float height, Color color)
		{
			RectTransform component = _highlight.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(width, height);
			component.localPosition = position;
			_highlight.color = color;
			_highlight.gameObject.SetActive(value: true);
		}
	}
}
