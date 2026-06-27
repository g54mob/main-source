using UnityEngine;
using UnityEngine.Events;

namespace Restory.UserInterface
{
	public interface ICursorDetector
	{
		Vector3 ScreenPosition { get; }

		bool IsActive { get; set; }

		GameObject DetectedGameObject { get; }

		UnityEvent OnObjectChanged { get; }

		bool IsMouseOverRaycastedUI { get; }

		GUI_DialogueBubbleButton ConversationBubble { get; }
	}
}
