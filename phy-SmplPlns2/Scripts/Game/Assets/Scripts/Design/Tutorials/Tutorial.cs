using System.Collections.Generic;
using Assets.Scripts.Design.Tutorials.Steps;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials
{
	public abstract class Tutorial
	{
		private int _currentStepIndex;

		private Color32 _savedSkyColor;

		private string _savedSkyName;

		private List<TutorialStep> _steps;

		public TutorialStep CurrentStep
		{
			get
			{
				if (_currentStepIndex < 0 || _currentStepIndex >= _steps.Count)
				{
					return null;
				}
				return _steps[_currentStepIndex];
			}
		}

		public DesignerScript Designer { get; private set; }

		public TutorialDatabase.TutorialInfo Info { get; }

		public bool IsComplete { get; private set; }

		public TutorialStep PreviousStep
		{
			get
			{
				if (_currentStepIndex - 1 < 0 || _currentStepIndex - 1 >= _steps.Count)
				{
					return null;
				}
				return _steps[_currentStepIndex - 1];
			}
		}

		public IReadOnlyList<TutorialStep> Steps => _steps;

		public TutorialScript TutorialScript { get; private set; }

		public Tutorial(TutorialDatabase.TutorialInfo tutorialInfo)
		{
			Info = tutorialInfo;
			_steps = new List<TutorialStep>();
		}

		public void Complete()
		{
			IsComplete = true;
			TutorialUIScript uI = TutorialScript.UI;
			uI.ShowNextButton = false;
			uI.ShowPreviousButton = false;
			uI.ShowRestartButton = false;
			uI.ShowStepTextSecondary = false;
			uI.ShowOkayButton = true;
			uI.SetOkayButtonText("Okay");
			CurrentStep?.End();
			OnCompleteTutorial();
		}

		public void EndTutorial()
		{
			CurrentStep?.End();
			OnEndTutorial();
			_currentStepIndex = -1;
		}

		public void FixedUpdate()
		{
			CurrentStep?.FixedUpdate();
			OnFixedUpdate();
		}

		public void Initialize(TutorialScript tutorialScript)
		{
			TutorialScript = tutorialScript;
			Designer = tutorialScript.Designer;
			TutorialStepBuilderContext tutorialStepBuilderContext = new TutorialStepBuilderContext(this, tutorialScript.Designer);
			BuildSteps(tutorialStepBuilderContext);
			CollectionPool<List<ITutorialStepPartChange>, ITutorialStepPartChange>.Get(out var value);
			for (int num = tutorialStepBuilderContext.Steps.Count - 1; num >= 0; num--)
			{
				TutorialStep tutorialStep = tutorialStepBuilderContext.Steps[num];
				tutorialStep.PendingPartChanges.AddRange(value);
				value.AddRange(tutorialStep.AppliedPartChanges);
			}
			_steps.AddRange(tutorialStepBuilderContext.Steps);
		}

		public void LateUpdate()
		{
			CurrentStep?.LateUpdate();
			OnLateUpdate();
		}

		public void MoveToNextStep()
		{
			MoveToStep(_currentStepIndex + 1);
		}

		public void MoveToPreviousStep()
		{
			int num = _currentStepIndex - 1;
			while (num > 0 && _steps[num].SkipOnRewind)
			{
				num--;
			}
			MoveToStep(num);
		}

		public void MoveToStep(int stepIndex)
		{
			if (!IsComplete)
			{
				if (stepIndex < 0)
				{
					stepIndex = 0;
				}
				else if (stepIndex >= _steps.Count)
				{
					stepIndex = _steps.Count - 1;
				}
				CurrentStep?.End();
				_currentStepIndex = stepIndex;
				TutorialStep currentStep = CurrentStep;
				TutorialUIScript uI = TutorialScript.UI;
				uI.ShowNextButton = currentStep != null && stepIndex < _steps.Count - 1;
				uI.ShowPreviousButton = currentStep != null && stepIndex > 0;
				currentStep?.Start();
			}
		}

		public virtual void OnCompleteTutorial()
		{
		}

		public void RestartStep()
		{
			MoveToStep(_currentStepIndex);
		}

		public void StartTutorial()
		{
			_currentStepIndex = 0;
			TutorialUIScript uI = TutorialScript.UI;
			uI.ShowNextButton = true;
			uI.ShowPreviousButton = false;
			uI.ShowRestartButton = true;
			uI.ShowStepTextSecondary = true;
			uI.ShowOkayButton = false;
			OnStartTutorial();
			MoveToStep(_currentStepIndex);
		}

		public void Update()
		{
			CurrentStep?.Update();
			OnUpdate();
		}

		protected abstract void BuildSteps(TutorialStepBuilderContext context);

		protected virtual void OnEndTutorial()
		{
			DesignerEnvironmentScript environment = Designer.Designer.Environment;
			environment.SkyName = _savedSkyName;
			environment.SkyColor = _savedSkyColor;
		}

		protected virtual void OnFixedUpdate()
		{
		}

		protected virtual void OnLateUpdate()
		{
		}

		protected virtual void OnStartTutorial()
		{
			DesignerEnvironmentScript environment = Designer.Designer.Environment;
			_savedSkyName = environment.SkyName;
			_savedSkyColor = environment.SkyColor;
			environment.SuppressPersistence = true;
			environment.SkyName = "Solid Color";
			environment.SkyColor = new Color32(32, 32, 32, byte.MaxValue);
			environment.SuppressPersistence = false;
		}

		protected virtual void OnUpdate()
		{
		}
	}
}
