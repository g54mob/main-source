using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design.UI;
using Assets.Scripts.UI;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class TutorialScript : MonoBehaviour
	{
		private class HighlightTarget
		{
			public Vector2 Offset { get; set; }

			public Vector2 Size { get; set; }

			public Transform Target { get; set; }
		}

		private XElement _currentStepAircraftXml;

		private bool _firstFrame;

		private Color _highlightColor;

		private HighlightTarget _highlightTarget;

		private float _highlightTime;

		private string _lastAccomplishment;

		private int _step;

		private List<TutorialStep> _steps;

		private TutorialPanelScript _tutorialPanel;

		public DesignerScript DesignerScript { get; set; }

		public DesignerUIScript UIScript => DesignerScript.DesignerUI;

		public Material TargetPartMaterial { get; set; }

		private TutorialStep CurrentStep => _steps[_step];

		public void Accomplishment(string name)
		{
			if (_lastAccomplishment != name)
			{
				_lastAccomplishment = name;
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStep);
			}
		}

		public void CloseTutorial()
		{
			Game.Instance.SceneManager.LoadMenu();
		}

		public void DisableUiHighlight()
		{
			_highlightTarget = null;
		}

		public void DisplayMessage(string message)
		{
			_tutorialPanel.Message = message;
		}

		public DesignerPart GetDesignerPart(string name)
		{
			foreach (DesignerPart part in DesignerScript.Designer.PartList.Parts)
			{
				if (part.Name == name)
				{
					return part;
				}
			}
			return null;
		}

		public void HidePanelButtons()
		{
			_tutorialPanel.HidePanelButtons();
		}

		public bool HighlightUiElement(string name, Vector2 offset, Vector2 size, bool highlightEvenIfInactive = false)
		{
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(name, base.gameObject);
			return HighlightUiElement(gameObject, offset, size, highlightEvenIfInactive);
		}

		public bool HighlightUiElement(GameObject gameObject, Vector2 offset, Vector2 size, bool highlightEvenIfInactive)
		{
			if (gameObject != null && (gameObject.activeInHierarchy || highlightEvenIfInactive))
			{
				_highlightTarget = new HighlightTarget
				{
					Target = gameObject.transform,
					Offset = offset,
					Size = size
				};
				return true;
			}
			_highlightTarget = null;
			return false;
		}

		public void NextStep()
		{
			if (_step < _steps.Count)
			{
				CurrentStep.End();
				DisableUiHighlight();
				_step++;
				LoadStep(_step);
				_lastAccomplishment = null;
			}
		}

		public void RestartStep()
		{
			LoadStep(_step);
		}

		public void ShowPanel(bool show)
		{
			_tutorialPanel.gameObject.SetActive(show);
		}

		public void SkipStep()
		{
			if (_step < _steps.Count)
			{
				_steps[_step].Skip();
			}
			NextStep();
		}

		protected virtual void Start()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Designer/TutorialPanel")) as GameObject;
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			_tutorialPanel = gameObject.GetComponent<TutorialPanelScript>();
			_tutorialPanel.TutorialScript = this;
			TargetPartMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerTutorialTargetPart");
			int[] collection = new int[3] { 1, 2, 3 };
			List<int> list = new List<int>();
			list.AddRange(collection);
			_step = 0;
			_steps = new List<TutorialStep>();
			_currentStepAircraftXml = Game.Instance.CraftDatabase.LoadBuiltinCraftXml("__designerTutorial1__", showErrorDialogs: true);
			QueueStep(null, new InfoStep("This is the airplane designer and this is where you will build your masterpiece.\n\nClick 'Start' and let's build an airplane together!", this));
			QueueStep(list, new CameraStep(this));
			QueueAddPartStep(5, list, "Block", "Great, now let's build the plane's body (also called the fuselage). ");
			QueueAddPartStep(6, list, "Block", "Let's keep building the fuselage. ");
			QueueAddPartStep(7, list, "Block", "Continue building. The fuselage is long. ");
			QueueAddPartStep(9, list, "Block", "Keep it going. ");
			QueueAddPartStep(10, list, "Block", "Doing great. Keep adding more blocks. ");
			QueueAddPartStep(63, list, "Block", "5 more blocks. ");
			QueueAddPartStep(118, list, "Block", "4 more blocks. ");
			QueueAddPartStep(64, list, "Block", "3 more blocks. ");
			QueueAddPartStep(11, list, "Block", "2 more blocks. ");
			QueueAddPartStep(15, list, "Block", "Last one here at the end. ");
			QueueAddPartStep(4, list, "Block", "Now let's add some on the front. ");
			QueueAddPartStep(109, list, "Block", "One more block at the front. ");
			QueueAddPartStep(23, list, "Nose Cone", "Let's put a nose cone on the front to help reduce the plane's drag. ");
			QueueAddPartStep(65, list, "Angled Block", "An angled block behind the cockpit would make the plane look nicer. ");
			QueueAddWingPartStep(82, list, "Structural Wing", 0.75f, 0.25f, 0.75f, 0.25f, new Vector3(0f, 1.5f, 0f), "Let's add a small wing section here. ").CenterOnPart = true;
			QueueAddPartStep(25, list, "Block", "Now let's build a section on this wing where we can attach landing gear and an engine. ");
			QueueAddPartStep(26, list, "Block", "Let's keep building this section. ");
			QueueAddPartStep(73, list, "Block", "One more block. ");
			QueueAddPartStep(46, list, "Large Retractable Gear", "Now let's attach some landing gear. ").CenterOnPart = true;
			QueueAddPartStep(55, list, "Blade T1000", "Great, now let's give this plane some power. ");
			QueueStep(list, new PropEngineStep(this));
			_currentStepAircraftXml = Game.Instance.CraftDatabase.LoadBuiltinCraftXml("__designerTutorial2__", showErrorDialogs: true);
			QueueAddWingPartStep(91, list, "Primary Wing", 0.75f, 0.25f, 0.25f, 0.25f, new Vector3(0f, 3.5f, 0f), "Now we can attach the primary wings. They provide the main lift and allow the plane to roll left and right. ");
			QueueAddWingPartStep(17, list, "Horizontal Stabilizer", 0.75f, 0.25f, 0.25f, 0.25f, new Vector3(0f, 1.5f, 0f), "Now let's put the horizontal stabilizers in the back. They provide stability and allow the plane to pitch up and down. ");
			QueueAddWingPartStep(16, list, "Vertical Stabilizer", 0.75f, 0.25f, 0.25f, 0.25f, new Vector3(0f, 1.5f, 0f), "The last wing section is the vertical stabilizer. It provides additional stability and helps to keep the plane flying straight. ");
			QueueAddPartStep(100, list, "Retractable Gear", "Let's not forget the rear landing gear. ");
			TodoException<TutorialScript>.LogOnce("Part mirroring has changed. This tutorial needs updated.");
			QueueStep(null, new EndStep("Excellent! You have built your first plane! You can now click the play button on the right side of the screen to try it out.", this));
			LoadStep(_step);
		}

		protected virtual void Update()
		{
			if (!_firstFrame)
			{
				_firstFrame = true;
				UIScript.ShowMessage(string.Empty);
			}
			CurrentStep.Update();
			AnimateHighlightColors();
			if (_highlightTarget != null)
			{
				_tutorialPanel.Highlight.gameObject.SetActive(value: true);
				_tutorialPanel.Highlight.transform.position = _highlightTarget.Target.TransformPoint(new Vector3(_highlightTarget.Offset.x, _highlightTarget.Offset.y, 0f));
				_tutorialPanel.Highlight.Width = (int)_highlightTarget.Size.x;
				_tutorialPanel.Highlight.Height = (int)_highlightTarget.Size.y;
				_tutorialPanel.Highlight.Color.Base = _highlightColor;
			}
			else
			{
				_tutorialPanel.Highlight.gameObject.SetActive(value: false);
			}
		}

		private void AnimateHighlightColors()
		{
			_highlightTime += Time.deltaTime;
			float t = (Mathf.Sin(_highlightTime * 10f) + 1f) / 2f;
			Color color = Color.Lerp(new Color32(0, byte.MaxValue, 0, 30), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 5), t);
			TargetPartMaterial.color = color;
			float num = (Mathf.Sin(_highlightTime * 5f) + 1f) / 2f;
			float num2 = 0.25f;
			float a = num2 + (1f - num2) * num;
			_highlightColor = new Color(0f, 1f, 0f, a);
		}

		private void LoadStep(int stepIndex)
		{
			_steps[stepIndex].LoadStep();
		}

		private TutorialStep QueueAddPartStep(int partId, List<int> loadedPartIds, string designerPartName, string preMessage = "")
		{
			AddPartStep addPartStep = new AddPartStep(partId, this, designerPartName);
			addPartStep.PreMessage = preMessage;
			QueueStep(loadedPartIds, addPartStep);
			loadedPartIds.Add(partId);
			return addPartStep;
		}

		private TutorialStep QueueAddWingPartStep(int partId, List<int> loadedPartIds, string designerPartName, float rootLeadingOffset, float rootTrailingOffset, float tipLeadingOffset, float tipTrailingOffset, Vector3 tipPosition, string preMessage = "")
		{
			AddWingPartStep addWingPartStep = new AddWingPartStep(partId, this, designerPartName, rootLeadingOffset, rootTrailingOffset, tipLeadingOffset, tipTrailingOffset, tipPosition);
			addWingPartStep.PreMessage = preMessage;
			QueueStep(loadedPartIds, addWingPartStep);
			loadedPartIds.Add(partId);
			return addWingPartStep;
		}

		private void QueueStep(List<int> loadedPartIds, TutorialStep step)
		{
			if (loadedPartIds != null)
			{
				step.LoadedPartIds.AddRange(loadedPartIds);
			}
			else
			{
				step.LoadAllParts = true;
			}
			step.AircraftXml = _currentStepAircraftXml;
			_steps.Add(step);
		}
	}
}
