using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Simulator.GameWorld
{
	public interface IPlayerInputReceiver
	{
		private static IPlayerInputReceiver _current;

		private static Stack<IPlayerInputReceiver> _stack;

		void OnPlayerInput_Look(Vector2 delta);

		void OnPlayerInput_Move(Vector3 moveInput);

		void OnPlayerInput_SprintStarted();

		void OnPlayerInput_SprintEnded();

		void OnPlayerInput_MainInteractTap(ISensable sensable);

		void OnPlayerInput_MainHoldProcessing(HoldInteraction holdInteraction, ISensable sensable);

		void OnPlayerInput_MainHoldInteractStart(ISensable sensable);

		void OnPlayerInput_MainHoldInteractStop(ISensable sensable);

		void OnPlayerInput_MainHoldInteractCancel(ISensable sensable);

		void OnPlayerInput_SecondInteractTap(ISensable sensable);

		void OnPlayerInput_SecondHoldProcessing(HoldInteraction holdInteraction, ISensable sensable);

		void OnPlayerInput_SecondHoldInteractStart(ISensable sensable);

		void OnPlayerInput_SecondHoldInteractStop(ISensable sensable);

		void OnPlayerInput_SecondHoldInteractCancel(ISensable sensable);

		void OnPlayerInput_ThirdInteractTap(ISensable sensable);

		void OnPlayerInput_Jump();

		void OnPlayerInput_Crouch();

		void OnPlayerInput_NextDayHoldProcessing(HoldInteraction holdInteraction);

		void OnPlayerInput_NextDayHoldStart();

		void OnPlayerInput_NextDayHoldStop();

		void OnPlayerInput_NextDayHoldCancel();

		void OnPlayerInput_Rotate(float rotateInput);

		void OnPlayerInput_Pause();

		void OnLoseReceiver();

		static void SetCurrent(IPlayerInputReceiver receiver)
		{
			_current?.OnLoseReceiver();
			_stack.Clear();
			_current = receiver;
		}

		static void Stack(IPlayerInputReceiver receiver)
		{
			_current?.OnLoseReceiver();
			_stack.Push(_current);
			_current = receiver;
		}

		static void PopCurrent()
		{
			_stack.TryPop(out _current);
		}

		static bool HasCurrent(out IPlayerInputReceiver receiver)
		{
			receiver = _current;
			return receiver != null;
		}

		static IPlayerInputReceiver()
		{
			_stack = new Stack<IPlayerInputReceiver>();
		}
	}
}
