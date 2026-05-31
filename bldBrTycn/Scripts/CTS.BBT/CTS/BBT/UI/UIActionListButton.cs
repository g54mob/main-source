using CTS.BBT.AI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.BBT.UI
{
	internal sealed class UIActionListButton : MonoBehaviour
	{
		private Button _button;

		private TextMeshProUGUI _buttonText;

		private AgentAction _action;

		private void Awake()
		{
			_button = GetComponentInChildren<Button>();
			_buttonText = GetComponentInChildren<TextMeshProUGUI>();
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnClick);
		}

		public void SetActive(bool p_active, AgentAction p_action)
		{
			_action = p_action;
			if (p_action == null || !p_active)
			{
				if (base.gameObject.activeSelf)
				{
					base.gameObject.SetActive(value: false);
				}
				return;
			}
			_buttonText.text = p_action.GetType().Name;
			if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
		}

		private void OnClick()
		{
			if (_action.Status <= AgentAction.EStatus.Wait)
			{
				_action.CancelAction("Cancelled from action list");
			}
		}
	}
}
