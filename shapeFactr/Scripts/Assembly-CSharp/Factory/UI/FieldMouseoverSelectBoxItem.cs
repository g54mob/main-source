using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Factory.UI
{
	public class FieldMouseoverSelectBoxItem : MonoBehaviour
	{
		public Image luggageIcon;

		public Toggle toggle;

		private eLuggage luggageId;

		private UnityAction onValueChanged;

		public bool IsSelected => false;

		public eLuggage LuggageId => default(eLuggage);

		public void Init(eLuggage luggage, ToggleGroup toggleGroup, bool isOn, UnityAction valueChangedAction)
		{
		}

		public void OnValueChanged(bool value)
		{
		}

		public void SwitchToggle(bool isOn)
		{
		}
	}
}
