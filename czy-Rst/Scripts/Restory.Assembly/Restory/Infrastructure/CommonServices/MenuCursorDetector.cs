using System.Collections.Generic;
using Helpers.Extensions;
using Restory.Gameplay.PlayerInput;
using Restory.UserInterface;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Restory.Infrastructure.CommonServices
{
	public class MenuCursorDetector : MonoBehaviour, ICursorDetector, IInitializable
	{
		private readonly List<RaycastResult> pointerRaycastResults = new List<RaycastResult>();

		private GUI_CursorStateOnPointEnterSetter cursorStateSwitcher;

		private Selectable selectable;

		private GUI_Selectable guiSelectable;

		private GameObject detectedGameObject;

		private EventSystem eventSystem;

		private IPlayerInput playerInput;

		public Vector3 ScreenPosition => playerInput.GetMousePosition();

		public GUI_CursorStateOnPointEnterSetter CursorStateSwitcher => cursorStateSwitcher;

		public Selectable Selectable => selectable;

		public GUI_Selectable GUISelectable => guiSelectable;

		public bool IsActive { get; set; }

		public bool IsMouseOverRaycastedUI
		{
			get
			{
				UIBehaviour component;
				return pointerRaycastResults.TryGetComponent<UIBehaviour>(out component);
			}
		}

		public GUI_DialogueBubbleButton ConversationBubble { get; }

		public GameObject DetectedGameObject
		{
			get
			{
				return detectedGameObject;
			}
			private set
			{
				if (!(detectedGameObject == value))
				{
					detectedGameObject = value;
					OnObjectChanged?.Invoke();
				}
			}
		}

		public UnityEvent OnObjectChanged { get; } = new UnityEvent();

		[Inject]
		private void Construct(IPlayerInput playerInput, EventSystem eventSystem)
		{
			this.playerInput = playerInput;
			this.eventSystem = eventSystem;
		}

		public void Initialize()
		{
			eventSystem.enabled = true;
		}

		private void Update()
		{
			if (playerInput != null)
			{
				eventSystem.MouseRaycast(playerInput.GetMousePosition(), pointerRaycastResults);
				if (pointerRaycastResults.TryGetComponentInFirstParent<Selectable>(out selectable))
				{
					DetectedGameObject = selectable.gameObject;
				}
				else if (pointerRaycastResults.TryGetComponentInFirstParent<GUI_Selectable>(out guiSelectable))
				{
					DetectedGameObject = guiSelectable.gameObject;
				}
				else if (pointerRaycastResults.TryGetComponentInFirstParent<GUI_CursorStateOnPointEnterSetter>(out cursorStateSwitcher))
				{
					DetectedGameObject = cursorStateSwitcher.gameObject;
				}
				else
				{
					DetectedGameObject = null;
				}
			}
		}
	}
}
