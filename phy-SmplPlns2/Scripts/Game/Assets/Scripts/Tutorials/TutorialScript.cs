using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Levels;
using Assets.Scripts.Tutorials.Requirements;
using UnityEngine;

namespace Assets.Scripts.Tutorials
{
	public class TutorialScript : MonoBehaviour
	{
		public class TutorialScriptBuilder
		{
			public TutorialScript TutorialScript { get; }

			public TutorialScriptBuilder(TutorialScript tutorial)
			{
				TutorialScript = tutorial;
			}

			public TutorialScriptBuilder AddMessage(string message, string messageVR = null)
			{
				AddStep().AddRequirement(new MessageRequirement(message, messageVR ?? message));
				return this;
			}

			public TutorialStep.TutorialStepBuilder AddStep()
			{
				TutorialStep.TutorialStepBuilder tutorialStepBuilder = TutorialStep.Create(this);
				TutorialScript.AddStep(tutorialStepBuilder.Step);
				return tutorialStepBuilder;
			}

			public TutorialScriptBuilder AddTimedMessage(float durationInSeconds, string message)
			{
				AddStep().AddRequirement(new TimeRequirement(durationInSeconds, message));
				return this;
			}
		}

		private object _currentMessageSource;

		[SerializeField]
		private bool _initialized;

		[SerializeField]
		private List<TutorialStep> _steps;

		public static TutorialScript Current { get; private set; }

		[field: SerializeReference]
		public TutorialStep ActiveStep { get; private set; }

		public string CurrentMessage { get; set; }

		[field: SerializeReference]
		public TutorialRequirement FocusedRequirement { get; private set; }

		[field: SerializeField]
		public string Name { get; set; }

		public AircraftScript PlayerAircraft { get; set; }

		[field: SerializeField]
		public TutorialState State { get; private set; }

		public IReadOnlyList<TutorialStep> Steps => _steps;

		public TutorialScript()
		{
			_steps = new List<TutorialStep>();
			State = TutorialState.NotStarted;
		}

		public static TutorialScriptBuilder Create()
		{
			return new TutorialScriptBuilder(new GameObject("Tutorial").AddComponent<TutorialScript>());
		}

		public static TutorialScript LoadFromXml(XElement xml)
		{
			TutorialScript tutorialScript = new GameObject("Tutorial").AddComponent<TutorialScript>();
			tutorialScript.Name = (string)xml.Attribute("name");
			foreach (XElement item in xml.Elements("Step"))
			{
				try
				{
					tutorialScript.AddStep(TutorialStep.LoadFromXml(item));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError($"An error occurred trying to load a tutorial step from XML: {System.Environment.NewLine}{item}");
				}
			}
			return tutorialScript;
		}

		public void AddStep(TutorialStep step)
		{
			_steps.Add(step);
		}

		public XElement GenerateXml()
		{
			return new XElement("Tutorial", new XAttribute("name", Name), _steps.Select((TutorialStep x) => x.GenerateXml()));
		}

		public void StartTutorial(AircraftScript playerAircraft)
		{
			if (_initialized)
			{
				throw new InvalidOperationException("The tutorial cannot be restarted without created a new instance of the tutorial.");
			}
			TutorialScript[] array = UnityEngine.Object.FindObjectsByType<TutorialScript>(FindObjectsSortMode.None);
			foreach (TutorialScript tutorialScript in array)
			{
				if (tutorialScript.State != TutorialState.NotStarted)
				{
					if (tutorialScript.State == TutorialState.Active)
					{
						Debug.Log("Immediately ending active tutorial '" + tutorialScript.Name + "' in order to start tutorial '" + Name + "'");
					}
					UnityEngine.Object.Destroy(tutorialScript.gameObject);
				}
			}
			PlayerAircraft = playerAircraft;
			Initialize();
			State = TutorialState.Active;
			Current = this;
			MoveToNextStep();
			OnStarted();
		}

		protected virtual void OnDestroy()
		{
			if ((object)Current == this)
			{
				Current = null;
			}
		}

		protected void OnStarted()
		{
			Debug.Log("On Tutorial Started");
		}

		protected virtual void Update()
		{
			if (State != TutorialState.Active)
			{
				return;
			}
			if (ActiveStep == null)
			{
				State = TutorialState.Passed;
				OnTutorialPassed();
				return;
			}
			ActiveStep.Update();
			if (ActiveStep.State == TutorialStepState.Passed)
			{
				MoveToNextStep();
			}
			else if (ActiveStep.State == TutorialStepState.Failed)
			{
				State = TutorialState.Failed;
				OnTutorialFailed();
			}
			UpdateFocusedRequirement();
			UpdateCurrentMessage();
			UpdateHighlightedParts();
		}

		private void ClearHighlightedParts(TutorialRequirement requirement)
		{
			if (requirement == null)
			{
				return;
			}
			foreach (TutorialRequirement.HighlightedPart highlightedPart in requirement.HighlightedParts)
			{
				highlightedPart.Part.PartMaterialScript.TutorialHighlight = null;
			}
			foreach (TutorialRequirement.HighlightedUIElement highlightedUIElement in requirement.HighlightedUIElements)
			{
				if (highlightedUIElement.RadialMenuButton != null)
				{
					highlightedUIElement.RadialMenuButton.IsBlinking = false;
				}
			}
		}

		private TutorialRequirement FindFocusedRequirement(TutorialStep step)
		{
			if (step == null)
			{
				return null;
			}
			foreach (TutorialRequirement requirement in step.Requirements)
			{
				if (requirement.State == TutorialRequirementState.RequirementNotMet || requirement.State == TutorialRequirementState.RequirementImpossible)
				{
					return requirement;
				}
			}
			using (IEnumerator<TutorialStep> enumerator2 = step.Steps.GetEnumerator())
			{
				if (enumerator2.MoveNext())
				{
					TutorialStep current2 = enumerator2.Current;
					return FindFocusedRequirement(current2);
				}
			}
			return null;
		}

		private void Initialize()
		{
			_initialized = true;
			for (int i = 0; i < _steps.Count; i++)
			{
				_steps[i].Initialize(this, i + 1);
			}
		}

		private void MoveToNextStep()
		{
			if (ActiveStep == null)
			{
				ActiveStep = _steps.FirstOrDefault();
				return;
			}
			int num = _steps.IndexOf(ActiveStep) + 1;
			if (num > 0)
			{
				ActiveStep = ((num < _steps.Count) ? _steps[num] : null);
			}
			else
			{
				ActiveStep = null;
			}
		}

		private void OnTutorialFailed()
		{
			Debug.Log("Tutorial Failed");
		}

		private void OnTutorialPassed()
		{
			Debug.Log("Tutorial Passed");
		}

		private void UpdateCurrentMessage()
		{
			string text = null;
			object obj = null;
			bool showContinueButton = false;
			TutorialStep tutorialStep = FocusedRequirement?.Step;
			while (text == null && tutorialStep != null)
			{
				text = tutorialStep.Message;
				if (text != null)
				{
					obj = tutorialStep;
				}
				tutorialStep = tutorialStep.ParentStep;
			}
			if (text == null)
			{
				text = FocusedRequirement?.CurrentMessage;
				if (text != null)
				{
					obj = FocusedRequirement;
					showContinueButton = FocusedRequirement.ShowContinueButton;
				}
			}
			if (obj != _currentMessageSource)
			{
				_currentMessageSource = obj;
				LevelBase.CurrentLevel.MessageManager.FadeCurrentTutorialMessage();
			}
			if (CurrentMessage != text)
			{
				CurrentMessage = text;
				LevelBase.CurrentLevel.MessageManager.SetTutorialMessage(text, showContinueButton);
			}
		}

		private void UpdateFocusedRequirement()
		{
			TutorialRequirement focusedRequirement = FocusedRequirement;
			TutorialRequirement tutorialRequirement = FindFocusedRequirement(ActiveStep);
			if (tutorialRequirement != focusedRequirement)
			{
				FocusedRequirement = tutorialRequirement;
				ClearHighlightedParts(focusedRequirement);
			}
		}

		private void UpdateHighlightedParts()
		{
			if (FocusedRequirement == null)
			{
				return;
			}
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			foreach (TutorialRequirement.HighlightedPart highlightedPart in FocusedRequirement.HighlightedParts)
			{
				bool flag = highlightedPart.Enabled && FocusedRequirement.HighlightPartsEnabled;
				foreach (PartModifierScript modifier in highlightedPart.Part.Modifiers)
				{
					PosedGripScript posedGripScript = modifier as PosedGripScript;
					if (posedGripScript != null)
					{
						flag &= !posedGripScript.IsGripped;
					}
				}
				PartMaterialScript partMaterialScript = highlightedPart.Part.PartMaterialScript;
				if (flag)
				{
					highlightedPart.Pulse(realtimeSinceStartup);
					partMaterialScript.TutorialHighlight = highlightedPart.Highlight;
				}
				else
				{
					partMaterialScript.TutorialHighlight = null;
				}
			}
			foreach (TutorialRequirement.HighlightedUIElement highlightedUIElement in FocusedRequirement.HighlightedUIElements)
			{
				if (highlightedUIElement.RadialMenuButton != null)
				{
					highlightedUIElement.RadialMenuButton.IsBlinking = true;
				}
			}
		}
	}
}
