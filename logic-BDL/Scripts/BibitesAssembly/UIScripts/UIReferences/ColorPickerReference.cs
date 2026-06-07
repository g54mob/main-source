using HSVPicker;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class ColorPickerReference : MonoBehaviour
	{
		[SerializeField]
		public TextMeshProUGUI settingName;

		[SerializeField]
		public TextMeshProUGUI colorValue;

		[SerializeField]
		public TooltipTrigger tooltip;

		[SerializeField]
		public Button colorButton;

		[SerializeField]
		public Button resetButton;

		[SerializeField]
		public Image colorDisplay;

		[SerializeField]
		public ColorPicker colorPicker;

		public UnityEvent onEnterPressed = new UnityEvent();

		private void Update()
		{
			if (colorPicker.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
			{
				onEnterPressed.Invoke();
			}
		}
	}
}
