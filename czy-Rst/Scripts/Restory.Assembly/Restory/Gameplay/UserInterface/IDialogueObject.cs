using UnityEngine;

namespace Restory.Gameplay.UserInterface
{
	public interface IDialogueObject
	{
		GameObject GameObject { get; }

		CanvasGroup CanvasGroup { get; }
	}
}
