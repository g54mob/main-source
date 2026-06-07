using UnityEngine;
using UnityEngine.EventSystems;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[AddComponentMenu("Character Controller Pro/Implementation/UI/Input Button")]
	public class InputButton : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler, IUIBoolAction, IUIAction
	{
		[SerializeField]
		private string actionName = "";

		private bool boolValue;

		public string ActionName => actionName;

		public bool BoolValue => boolValue;

		public void OnPointerDown(PointerEventData eventData)
		{
			boolValue = true;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			boolValue = false;
		}
	}
}
