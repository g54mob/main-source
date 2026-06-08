using System;
using System.Collections.Generic;
using Platforms;

namespace Controllers
{
	public interface IInputSource
	{
		InputLock GlobalLock { get; }

		event EventHandler<InputUpdateEvent> OnInputUpdate;

		event Action<int, string> OnBindingChange;

		void MakeRequest(int player, GameStateRequest request);

		InputLock.Lock SetInputLock(int player, PlayerLockState type);

		void ReleaseLock(int player, InputLock.Lock input_lock);

		void ReleaseLock(InputLock.Lock input_lock);

		InputLock.Lock SetLock(PlayerLockState type);

		bool IsValidLock(InputLock.Lock input_lock);

		int GetMenuRequester();

		void DisconnectedPlayers(List<int> players);

		bool IsPlayerDisconnected(int player);

		bool AnyPlayerPressingMenu();

		bool GetCurrentInputData(int player_id, out InputState input_state, InputLock.Lock input_lock = default(InputLock.Lock));

		ControllerType GetCurrentController(int player_id);

		ControllerType GetAllLocalControllers();

		bool CanPerformRebinding(int player);

		void RequestRebinding(int player, string action_name, Action<RebindResult> callback);

		string GetBindingName(int player, string action_name);

		string GetBindingString(int player);

		void SetBindingString(int player, string json);

		void ClearBindings(int player);

		void ResetInputs();
	}
}
