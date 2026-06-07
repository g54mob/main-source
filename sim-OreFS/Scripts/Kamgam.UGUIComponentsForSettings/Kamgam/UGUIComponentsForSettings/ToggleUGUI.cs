using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class ToggleUGUI : MonoBehaviour
	{
		public delegate void ValueChangedDelegate(bool value);

		public delegate void ValueChangedFromClickDelegate(bool value);

		public TextMeshProUGUI TextTf;

		public Toggle Toggle;

		public GameObject ToggleOnObject;

		public GameObject ToggleOffObject;

		[SerializeField]
		public Toggle.ToggleEvent OnValueChangedEvent;

		public ValueChangedDelegate OnValueChanged;

		[SerializeField]
		public Toggle.ToggleEvent onValueChangedFromClickEvent;

		public ValueChangedDelegate OnValueChangedFromClick;

		public bool Value
		{
			get
			{
				return Toggle.isOn;
			}
			set
			{
				if (Toggle.isOn != value)
				{
					Toggle.isOn = value;
					onValueChanged(value);
				}
			}
		}

		public string Text
		{
			get
			{
				return TextTf.text;
			}
			set
			{
				if (!(value == Text))
				{
					TextTf.text = value;
				}
			}
		}

		public void Start()
		{
			Toggle.onValueChanged.AddListener(onValueChanged);
			onValueChanged(Toggle.isOn);
		}

		private void onValueChanged(bool isOn)
		{
			OnValueChangedEvent?.Invoke(isOn);
			OnValueChanged?.Invoke(isOn);
			ToggleOnObject.SetActive(isOn);
			ToggleOffObject.SetActive(!isOn);
		}

		private void onValueChangedFromClick(bool isOn)
		{
			onValueChangedFromClickEvent?.Invoke(isOn);
			OnValueChangedFromClick?.Invoke(isOn);
		}
	}
}
