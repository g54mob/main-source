using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	[RequireComponent(typeof(Button))]
	public class UIToggler : MonoBehaviour
	{
		[SerializeField]
		private UIObject _objectToToggle;

		private Button _button;

		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			_objectToToggle.ToggleState();
		}
	}
}
