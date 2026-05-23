using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Data.Quests.Validators.ButtonReference
{
	public class ButtonClickedValidatorWidget : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private BaseEvent _buttonClickedEvent;

		private void OnEnable()
		{
			if (!(_buttonClickedEvent == null))
			{
				_button.onClick.AddListener(HandleButtonClicked);
			}
		}

		private void OnDisable()
		{
			if (!(_buttonClickedEvent == null))
			{
				_button.onClick.RemoveListener(HandleButtonClicked);
			}
		}

		private void HandleButtonClicked()
		{
			if (!(_buttonClickedEvent == null))
			{
				_buttonClickedEvent.Fire();
			}
		}
	}
}
