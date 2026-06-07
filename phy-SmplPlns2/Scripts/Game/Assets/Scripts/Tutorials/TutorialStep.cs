using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Tutorials.Requirements;
using UnityEngine;

namespace Assets.Scripts.Tutorials
{
	[Serializable]
	public class TutorialStep
	{
		public class TutorialStepBuilder
		{
			public TutorialStepBuilder ParentStep { get; }

			public TutorialStep Step { get; }

			public TutorialScript.TutorialScriptBuilder Tutorial { get; }

			public TutorialStepBuilder(TutorialScript.TutorialScriptBuilder tutorialBuilder, TutorialStepBuilder parentStepBuilder, TutorialStep step)
			{
				Tutorial = tutorialBuilder;
				ParentStep = parentStepBuilder;
				Step = step;
			}

			public TutorialRequirement.TutorialRequirementBuilder<T> AddRequirement<T>() where T : TutorialRequirement
			{
				TutorialRequirement.TutorialRequirementBuilder<T> tutorialRequirementBuilder = TutorialRequirement.Create<T>(this);
				Step.AddRequirement(tutorialRequirementBuilder.Requirement);
				return tutorialRequirementBuilder;
			}

			public TutorialRequirement.TutorialRequirementBuilder<T> AddRequirement<T>(T instance) where T : TutorialRequirement
			{
				Step.AddRequirement(instance);
				return new TutorialRequirement.TutorialRequirementBuilder<T>(this, instance);
			}

			public TutorialStepBuilder AddSubStep()
			{
				TutorialStepBuilder tutorialStepBuilder = Create(Tutorial, this);
				Step.AddStep(tutorialStepBuilder.Step);
				return tutorialStepBuilder;
			}
		}

		[SerializeField]
		private string __name;

		[SerializeReference]
		private List<TutorialRequirement> _requirements;

		[SerializeReference]
		private List<TutorialStep> _steps;

		[field: SerializeReference]
		public TutorialStep ActiveStep { get; private set; }

		[field: SerializeReference]
		public string Message { get; set; }

		public string Name
		{
			get
			{
				return __name;
			}
			private set
			{
				__name = value;
			}
		}

		public TutorialStep ParentStep { get; private set; }

		public IReadOnlyList<TutorialRequirement> Requirements => _requirements;

		[field: SerializeField]
		public TutorialStepState State { get; private set; }

		[field: SerializeReference]
		public string StepMessage { get; set; }

		public IReadOnlyList<TutorialStep> Steps => _steps;

		public TutorialScript Tutorial { get; private set; }

		public TutorialStep()
		{
			_requirements = new List<TutorialRequirement>();
			_steps = new List<TutorialStep>();
		}

		public static TutorialStepBuilder Create(TutorialScript.TutorialScriptBuilder tutorialBuilder, TutorialStepBuilder parentStepBuilder = null)
		{
			TutorialStep step = new TutorialStep();
			return new TutorialStepBuilder(tutorialBuilder, parentStepBuilder, step);
		}

		public static TutorialStep LoadFromXml(XElement xml)
		{
			TutorialStep tutorialStep = new TutorialStep();
			tutorialStep.Message = (string)xml.Attribute("message");
			foreach (XElement item in xml.Elements())
			{
				if (item.Name.LocalName == "Step")
				{
					try
					{
						tutorialStep.AddStep(LoadFromXml(item));
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Debug.LogError($"An error occurred trying to load a tutorial step from XML: {System.Environment.NewLine}{item}");
					}
				}
				else
				{
					try
					{
						tutorialStep.AddRequirement(TutorialRequirement.LoadFromXml(item));
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						Debug.LogError($"An error occurred trying to load a tutorial requirement from XML: {System.Environment.NewLine}{item}");
					}
				}
			}
			return tutorialStep;
		}

		public void AddRequirement(TutorialRequirement requirement)
		{
			_requirements.Add(requirement);
		}

		public void AddStep(TutorialStep step)
		{
			_steps.Add(step);
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Step");
			xElement.SetAttributeValue("message", Message);
			if (_requirements.Count > 0)
			{
				foreach (TutorialRequirement requirement in _requirements)
				{
					xElement.Add(requirement.GenerateXml());
				}
			}
			if (_steps.Count > 0)
			{
				foreach (TutorialStep step in _steps)
				{
					xElement.Add(step.GenerateXml());
				}
			}
			return xElement;
		}

		public void Initialize(TutorialScript tutorial, int stepNumber, TutorialStep parentStep = null)
		{
			Tutorial = tutorial;
			ParentStep = parentStep;
			Name = ((parentStep == null) ? $"Step #{stepNumber}" : $"{parentStep.Name}.{stepNumber}");
			for (int i = 0; i < _steps.Count; i++)
			{
				_steps[i].Initialize(tutorial, i + 1, this);
			}
			foreach (TutorialRequirement requirement in _requirements)
			{
				requirement.Initialize(this);
			}
		}

		public virtual void Update()
		{
			if (State == TutorialStepState.NotStarted)
			{
				State = TutorialStepState.Active;
				MoveToNextStep();
				OnStarted();
			}
			foreach (TutorialRequirement requirement in _requirements)
			{
				requirement.Update();
			}
			if (ActiveStep != null)
			{
				ActiveStep.Update();
				if (ActiveStep.State == TutorialStepState.Passed)
				{
					MoveToNextStep();
				}
			}
			bool flag = true;
			TutorialStep activeStep = ActiveStep;
			bool flag2 = activeStep != null && activeStep.State == TutorialStepState.Failed;
			foreach (TutorialRequirement requirement2 in _requirements)
			{
				if (requirement2.State != TutorialRequirementState.RequirementMet)
				{
					flag = false;
					if (requirement2.State == TutorialRequirementState.RequirementImpossible)
					{
						flag2 = true;
					}
				}
			}
			if (ParentStep != null)
			{
				foreach (TutorialRequirement requirement3 in ParentStep.Requirements)
				{
					if (requirement3.Inherited && requirement3.State != TutorialRequirementState.RequirementMet)
					{
						flag = false;
						if (requirement3.State == TutorialRequirementState.RequirementImpossible)
						{
							flag2 = true;
						}
					}
				}
			}
			if (flag2)
			{
				State = TutorialStepState.Failed;
			}
			else if (ActiveStep == null && flag)
			{
				State = TutorialStepState.Passed;
			}
			if (State == TutorialStepState.Passed)
			{
				OnPassed();
				OnStepCompleted(State);
			}
			else if (State == TutorialStepState.Failed)
			{
				OnFailed();
				OnStepCompleted(State);
			}
		}

		protected void OnFailed()
		{
			Debug.Log("On Step Failed: " + Name);
			foreach (TutorialRequirement requirement in Requirements)
			{
				requirement.OnStepFailed();
			}
		}

		protected void OnPassed()
		{
			Debug.Log("On Step Passed: " + Name);
			foreach (TutorialRequirement requirement in Requirements)
			{
				requirement.OnStepPassed();
			}
		}

		protected void OnStarted()
		{
			Debug.Log("On Step Started: " + Name);
			foreach (TutorialRequirement requirement in Requirements)
			{
				requirement.OnStepStarted();
			}
		}

		protected void OnStepCompleted(TutorialStepState state)
		{
			foreach (TutorialRequirement requirement in Requirements)
			{
				requirement.OnStepCompleted(state);
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
	}
}
