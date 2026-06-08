using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Dorfromantik
{
	public class PointerClickDebugger : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference clickAction;

		[SerializeField]
		private List<GameObject> currentSelectedGameObjects;

		private void Awake()
		{
			clickAction.action.started += DebugPointers;
		}

		private void DebugPointers(InputAction.CallbackContext obj)
		{
			currentSelectedGameObjects = new List<GameObject>();
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = Pointer.current.position.ReadValue();
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			foreach (RaycastResult item in list)
			{
				currentSelectedGameObjects.Add(item.gameObject);
			}
		}
	}
}
