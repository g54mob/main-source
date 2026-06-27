using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public class LaunchedUltrasonicState : UltrasonicStateBase
	{
		public LaunchedUltrasonicState(UltrasonicStateContext stateContext, UltrasonicStateMachine stateMachine)
			: base(stateContext, stateMachine)
		{
		}

		public override void Enter()
		{
			if (!base.Timer.IsCountdown)
			{
				Debug.LogError("Timer is not launched in IdleUltrasonicState");
				base.StateSwitcher.EnterIdleState();
				return;
			}
			Subscribe();
			base.SonicBath.CleaningEffectsPlayer.Play();
			if (!(base.DisassembleState is DisabledDisassembleState) && base.IsPulled)
			{
				base.Cover.Close();
				base.SonicBath.FreezeInsertedElements();
			}
		}

		public override void Exit()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			base.SonicBath.OnUltrasonicToolReplacing += ResolveUltrasonicToolReplacing;
			base.TriggerController.OnBodyClick += ResolveBodyClick;
			base.ToggleButton.OnButtonClick += ResolveButtonClick;
			base.Timer.OnCountdownComplete += ResolveTimerCountdownComplete;
			base.DisassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		private void Unsubscribe()
		{
			base.SonicBath.OnUltrasonicToolReplacing -= ResolveUltrasonicToolReplacing;
			base.TriggerController.OnBodyClick -= ResolveBodyClick;
			base.ToggleButton.OnButtonClick -= ResolveButtonClick;
			base.Timer.OnCountdownComplete -= ResolveTimerCountdownComplete;
			base.DisassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
		}

		private void ResolveUltrasonicToolReplacing()
		{
			base.Timer.TryStopCountdown();
			base.SonicBath.CleaningEffectsPlayer.Stop();
			base.StateSwitcher.EnterDisabledState();
		}

		private void ResolveBodyClick()
		{
			if (!(base.DisassembleState is DisabledDisassembleState) && !base.SonicBath.TryPush())
			{
				base.SonicBath.TryPull();
			}
		}

		private void ResolveButtonClick()
		{
			if (!base.ToggleButton.IsOn)
			{
				base.Timer.TryStopCountdown();
				base.SonicBath.CleaningEffectsPlayer.Stop();
				base.StateSwitcher.EnterIdleState();
			}
		}

		private void ResolveTimerCountdownComplete()
		{
			base.ToggleButton.TurnOff();
			base.SonicBath.CleaningEffectsPlayer.Stop();
			base.SonicBath.MakeInsertedElementsClean();
			base.StateSwitcher.EnterIdleState();
		}

		private void ResolveDisassembleStateChanged()
		{
			SonicBath sonicBath = base.SonicBath;
			IExitableState disassembleState = base.DisassembleState;
			sonicBath.CanBeDetected = disassembleState is DetectionDisassembleState || disassembleState is EmptyDisassembleState;
			if (base.DisassembleState is DisabledDisassembleState)
			{
				base.SonicBath.TryPush();
			}
		}
	}
}
