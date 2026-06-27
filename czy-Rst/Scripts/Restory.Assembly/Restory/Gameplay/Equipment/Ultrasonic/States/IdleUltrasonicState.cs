using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public class IdleUltrasonicState : UltrasonicStateBase
	{
		private bool isSubscribedToDetectionStateChanged;

		public IdleUltrasonicState(UltrasonicStateContext stateContext, UltrasonicStateMachine stateMachine)
			: base(stateContext, stateMachine)
		{
		}

		public override void Enter()
		{
			Subscribe();
			if (base.Timer.IsCountdown)
			{
				Debug.LogError("Timer still launched in IdleUltrasonicState");
				base.Timer.TryStopCountdown();
			}
			if (base.SonicBath.IsCleaningDone && base.SonicBath.InsertedElements.Count > 0)
			{
				base.Timer.OutputDoneMessage();
			}
			if (!(base.DisassembleState is DisabledDisassembleState))
			{
				ResolveDisassembleStateChanged();
				if (base.IsPulled)
				{
					base.Cover.Open();
					base.SonicBath.ReleaseInsertedElements();
				}
			}
		}

		public override void Exit()
		{
			Unsubscribe();
			UnsubscribeToDetectionStateChanged();
		}

		private void Subscribe()
		{
			base.SonicBath.OnElementInserted += ResolveElementInserted;
			base.SonicBath.OnElementRetrieved += ResolveElementRetrieved;
			base.SonicBath.OnUltrasonicToolReplacing += ResolveUltrasonicToolReplacing;
			base.TriggerController.OnBodyClick += ResolveBodyClick;
			base.ToggleButton.OnButtonClick += ResolveButtonClick;
			base.Drawer.OnAnimationCompleted += ResolveDrawerAnimationCompleted;
			base.Cover.OnAnimationCompleted += ResolveCoverAnimationCompleted;
			base.DisassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		private void Unsubscribe()
		{
			base.SonicBath.OnElementInserted -= ResolveElementInserted;
			base.SonicBath.OnElementRetrieved -= ResolveElementRetrieved;
			base.SonicBath.OnUltrasonicToolReplacing -= ResolveUltrasonicToolReplacing;
			base.TriggerController.OnBodyClick -= ResolveBodyClick;
			base.ToggleButton.OnButtonClick -= ResolveButtonClick;
			base.Drawer.OnAnimationCompleted -= ResolveDrawerAnimationCompleted;
			base.Cover.OnAnimationCompleted -= ResolveCoverAnimationCompleted;
			base.DisassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
		}

		private void SubscribeToDetectionStateChanged()
		{
			if (!isSubscribedToDetectionStateChanged)
			{
				isSubscribedToDetectionStateChanged = true;
				base.CursorSelectionService.OnDetectionStateChanged += ResolveDetectionStateChanged;
			}
		}

		private void UnsubscribeToDetectionStateChanged()
		{
			if (isSubscribedToDetectionStateChanged)
			{
				isSubscribedToDetectionStateChanged = false;
				base.CursorSelectionService.OnDetectionStateChanged -= ResolveDetectionStateChanged;
			}
		}

		private void ResolveElementInserted(ElementBase insertedElement)
		{
			base.Timer.SkipTimer();
		}

		private void ResolveElementRetrieved(ElementBase retrievedElement)
		{
			if (!base.SonicBath.IsCleaningDone)
			{
				base.Timer.SkipTimer();
			}
		}

		private void ResolveUltrasonicToolReplacing()
		{
			base.StateSwitcher.EnterDisabledState();
		}

		private void ResolveBodyClick()
		{
			if (!(base.DisassembleState is DisabledDisassembleState))
			{
				if (base.SonicBath.TryPush())
				{
					base.Cover.Close();
				}
				else
				{
					base.SonicBath.TryPull();
				}
			}
		}

		private void ResolveButtonClick()
		{
			if (base.ToggleButton.IsOn)
			{
				if (base.Cover.IsOpen)
				{
					base.SonicBath.FreezeInsertedElements();
					base.Cover.Close();
				}
				if (base.Timer.TryStartCountdown(base.SonicBath.CleaningDuration))
				{
					base.StateSwitcher.EnterLaunchedState();
				}
			}
		}

		private void ResolveDrawerAnimationCompleted()
		{
			if (base.IsPulled)
			{
				base.Cover.Open();
				base.SonicBath.ReleaseInsertedElements();
			}
		}

		private void ResolveCoverAnimationCompleted()
		{
		}

		private void ResolveDisassembleStateChanged()
		{
			if (base.DisassembleState is DisabledDisassembleState && base.SonicBath.TryPush())
			{
				base.Cover.Close();
			}
			IExitableState disassembleState = base.DisassembleState;
			if (disassembleState is DetectionDisassembleState || disassembleState is EmptyDisassembleState)
			{
				base.SonicBath.CanBeDetected = true;
				SubscribeToDetectionStateChanged();
			}
			else
			{
				base.SonicBath.CanBeDetected = false;
				UnsubscribeToDetectionStateChanged();
			}
		}

		private void ResolveDetectionStateChanged()
		{
			if (base.DisassembleState is DetectionDisassembleState || base.DisassembleState is EmptyDisassembleState)
			{
				if (!base.CursorSelectionService.DetectedGameObject || (!base.CursorSelectionService.DetectedGameObject.transform.TryGetComponent<ElementBase>(out var component) && !base.CursorSelectionService.DetectedGameObject.transform.parent.TryGetComponent<ElementBase>(out component)))
				{
					base.SonicBath.CanBeDetected = true;
				}
				else
				{
					base.SonicBath.CanBeDetected = false;
				}
			}
		}
	}
}
