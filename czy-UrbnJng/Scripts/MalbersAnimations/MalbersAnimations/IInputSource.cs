using System;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	public interface IInputSource
	{
		bool MoveCharacter { get; set; }

		Action<Vector3> OnMoveAxis { get; set; }

		Vector3 MoveAxis { get; set; }

		Transform transform { get; }

		void Enable(bool val);

		IInputAction GetInput(string input);

		void EnableInput(string input);

		void DisableInput(string input);

		void SetInput(string input, bool value);

		void ConnectInput(string name, UnityAction<bool> action);

		void DisconnectInput(string name, UnityAction<bool> action);

		void ResetInput(string name);

		void PlayerInput(IInputSource player);
	}
}
