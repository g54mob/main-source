using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Tutorial
{
	public class TutorialPanelScript : MonoBehaviour
	{
		public enum TutorialPanelType
		{
			None = 0,
			BackupCraft = 1,
			Instruction = 2,
			Okay = 3
		}

		private XmlElement _errorText;

		private Image _highlight;

		private Image _highlightOffscreen;

		private TextMeshProUGUI _instructionText;

		private XmlElement _panelBackup;

		private XmlElement _panelInstruction;

		private XmlElement _panelOkay;

		private XmlElement _progress;

		private XmlElement _skipButton;

		private TextMeshProUGUI _stepText;

		public string InstructionText
		{
			get
			{
				return _instructionText.text;
			}
			set
			{
				_instructionText.text = value;
				_instructionText.gameObject.SetActive(!string.IsNullOrEmpty(value));
			}
		}

		public bool IsHighlightOffscreen => _highlightOffscreen.gameObject.activeInHierarchy;

		public string StepText
		{
			get
			{
				return _stepText.text;
			}
			set
			{
				_stepText.text = value;
				_stepText.gameObject.SetActive(!string.IsNullOrEmpty(value));
			}
		}

		public TutorialScript TutorialScript { get; set; }

		public void DisableHighlight()
		{
			_highlight.gameObject.SetActive(value: false);
			_highlightOffscreen.gameObject.SetActive(value: false);
		}

		public void DisplayError(string message)
		{
			_errorText.SetActive(!string.IsNullOrEmpty(message));
			_errorText.SetText(message);
		}

		public void EnableHighlight(Vector3 position, int width, int height, Color color, ScrollRect scrollRect)
		{
			RectTransform component = _highlight.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(width, height);
			component.localPosition = position;
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
			if (component.position.x < vector.x || component.position.x > vector2.x || component.position.y < vector.y || component.position.y > vector2.y)
			{
				RectTransform component2 = _highlightOffscreen.GetComponent<RectTransform>();
				Vector3 position2 = component.position;
				float z = 0f;
				if (position2.y < vector.y)
				{
					z = 180f;
					position2.y = vector.y + component2.sizeDelta.y;
				}
				else if (position2.y > vector2.y)
				{
					z = 0f;
					position2.y = vector2.y - component2.sizeDelta.y;
				}
				if (position2.x < vector.x)
				{
					z = 90f;
					position2.x = vector.x + component2.sizeDelta.x;
				}
				else if (position2.x > vector2.x)
				{
					z = 270f;
					position2.x = vector2.x - component2.sizeDelta.x;
				}
				component2.localRotation = Quaternion.Euler(0f, 0f, z);
				component2.position = position2;
				_highlightOffscreen.color = color;
				_highlightOffscreen.gameObject.SetActive(value: true);
				_highlight.gameObject.SetActive(value: false);
			}
			else
			{
				_highlight.color = color;
				_highlight.gameObject.SetActive(value: true);
				_highlightOffscreen.gameObject.SetActive(value: false);
			}
		}

		public void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_instructionText = xmlLayout.GetElementById<TextMeshProUGUI>("tutorial-instruction-text");
			_stepText = xmlLayout.GetElementById<TextMeshProUGUI>("tutorial-step-text");
			_highlight = xmlLayout.GetElementById<Image>("tutorial-highlight");
			_highlightOffscreen = xmlLayout.GetElementById<Image>("tutorial-highlight-offscreen");
			_progress = xmlLayout.GetElementById("tutorial-progress");
			_panelBackup = xmlLayout.GetElementById("backup-craft-panel");
			_panelInstruction = xmlLayout.GetElementById("instruction-panel");
			_panelOkay = xmlLayout.GetElementById("okay-panel");
			_skipButton = xmlLayout.GetElementById("skip-button");
			_errorText = xmlLayout.GetElementById("error-text");
		}

		public void ShowPanel(TutorialPanelType panelType)
		{
			_panelOkay.SetActive(panelType == TutorialPanelType.Okay);
			_panelBackup.SetActive(panelType == TutorialPanelType.BackupCraft);
			_panelInstruction.SetActive(panelType == TutorialPanelType.Instruction);
			Canvas canvas = _highlight.gameObject.AddMissingComponent<Canvas>();
			canvas.sortingOrder = 100;
			canvas.overrideSorting = true;
			Canvas canvas2 = _highlightOffscreen.gameObject.AddMissingComponent<Canvas>();
			canvas2.sortingOrder = 100;
			canvas2.overrideSorting = true;
		}

		public void UpdateStepNumberText(int stepNumber, int numSteps, bool canSkip)
		{
			int num = (int)((float)(stepNumber - 1) / (float)(numSteps - 1) * 100f);
			if (stepNumber <= 3)
			{
				num = 0;
			}
			_progress.SetAndApplyAttribute("width", $"{num}%");
			_skipButton.SetActive(canSkip);
		}

		private void BackupEditorCraft()
		{
			CraftDesigns craftDesigns = Game.Instance.CraftDesigns;
			XElement craftDesign = craftDesigns.GetCraftDesign(CraftDesigns.EditorCraftId);
			if (craftDesign != null)
			{
				DateTime now = DateTime.Now;
				string text = $"Backup-{now.Year}.{now.Month}.{now.Day}-{now.Hour}.{now.Minute}.{now.Second}";
				craftDesigns.SaveCraft(text, craftDesign);
				craftDesigns.DeleteCraftFile(CraftDesigns.EditorCraftId);
				Debug.LogFormat("Tutorial detected existing editor craft. Backing up to '{0}'", text);
			}
		}

		private void OnBackupCraftClicked()
		{
			BackupEditorCraft();
			OnSkipStepClicked();
		}

		private void OnCloseButtonClicked()
		{
			TutorialScript.ExitTutorial();
		}

		private void OnRestartStepClicked()
		{
			TutorialScript.RestartStep();
		}

		private void OnSkipStepClicked()
		{
			TutorialScript.SkipStep();
		}

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
