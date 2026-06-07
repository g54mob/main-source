using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class TabToNextInput : MonoBehaviour, IUpdateSelectedHandler, IEventSystemHandler
	{
		private TMP_InputField _inputField;

		public void OnUpdateSelected(BaseEventData eventData)
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				Selectable selectable = null;
				((!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)) ? (_inputField.FindSelectableOnRight() ?? _inputField.FindSelectableOnDown()) : (_inputField.FindSelectableOnLeft() ?? _inputField.FindSelectableOnUp()))?.Select();
			}
		}

		protected virtual void Awake()
		{
			_inputField = GetComponent<TMP_InputField>();
		}
	}
}
