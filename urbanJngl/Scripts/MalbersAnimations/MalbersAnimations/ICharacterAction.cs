using System;
using UnityEngine;

namespace MalbersAnimations
{
	public interface ICharacterAction
	{
		GameObject gameObject { get; }

		bool IsPlayingAction { get; }

		bool MovementDetected { get; }

		Action<int> OnState { get; set; }

		Action<int, int> ModeStart { get; set; }

		Action<int, int> ModeEnd { get; set; }

		Action<int> OnStance { get; set; }

		bool PlayAction(int Set, int Index);

		bool ForceAction(int Set, int Index);
	}
}
