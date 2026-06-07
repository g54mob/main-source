using System.Collections.Generic;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;
using UnityEngine.UI;

public class RadioMessagePanel : Panel
{
	[SerializeField]
	private RadioMessageProperties _messages;

	[SerializeField]
	private RadioMessagePanelOption[] _options;

	[SerializeField]
	private Button _buttonLeft;

	[SerializeField]
	private Button _buttonRight;

	private RadioMessage _selectedOption;

	private int _selectedOptionIndex = -1;

	private int _firstOptionIndex;

	private void OnEnable()
	{
		_buttonLeft.onClick.AddListener(OnButtonLeftClick);
		_buttonRight.onClick.AddListener(OnButtonRightClick);
	}

	private void OnDisable()
	{
		_buttonLeft.onClick.RemoveListener(OnButtonLeftClick);
		_buttonRight.onClick.RemoveListener(OnButtonRightClick);
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (base.Open(id, context))
		{
			List<RadioMessage> list = GameManager.RadioMessagesManager.ReturnPendingRadioMessages();
			for (int i = 0; i < list.Count; i++)
			{
				RadioMessage radioMessage = list[i];
				if (radioMessage.IsDialogueOption)
				{
					_selectedOption = radioMessage;
					_firstOptionIndex = i;
					break;
				}
			}
			if ((FlotsamInputManager.ActiveInput & InputFlags.Joystick) != InputFlags.None)
			{
				_selectedOptionIndex = list.IndexOf(_selectedOption);
				if (_selectedOptionIndex < 0)
				{
					_selectedOptionIndex = 0;
				}
				SelectOption(list, _selectedOptionIndex);
			}
			else
			{
				SetFirstOptionIndex(list, _firstOptionIndex);
			}
			return true;
		}
		return false;
	}

	public override void Close()
	{
		base.Close();
		foreach (RadioMessage item in GameManager.RadioMessagesManager.ReturnPendingRadioMessages())
		{
			item.OnPanelClosed();
		}
	}

	private void SetFirstOptionIndex(List<RadioMessage> options, int index)
	{
		_firstOptionIndex = Mathf.Clamp(index, 0, Mathf.Max(0, options.Count - _options.Length));
		InitializeOptions(options, _firstOptionIndex);
		UpdateButtons(options);
	}

	private void InitializeOptions(List<RadioMessage> messages, int index)
	{
		int i = 0;
		int num = index;
		while (i < _options.Length && num < messages.Count)
		{
			_options[i].Initialize(messages[num]);
			i++;
			num++;
		}
		for (; i < _options.Length; i++)
		{
			_options[i].gameObject.SetActive(value: false);
		}
	}

	private void UpdateButtons(List<RadioMessage> messages)
	{
		_buttonLeft.gameObject.SetActive(0 < _firstOptionIndex);
		_buttonRight.gameObject.SetActive(_options.Length < messages.Count && _firstOptionIndex < messages.Count - _options.Length);
	}

	private void OnButtonLeftClick()
	{
		if (0 < _firstOptionIndex)
		{
			SetFirstOptionIndex(GameManager.RadioMessagesManager.ReturnPendingRadioMessages(), --_firstOptionIndex);
		}
	}

	private void OnButtonRightClick()
	{
		List<RadioMessage> list = GameManager.RadioMessagesManager.ReturnPendingRadioMessages();
		if (list.Count - _options.Length > _firstOptionIndex)
		{
			SetFirstOptionIndex(list, ++_firstOptionIndex);
		}
	}

	public void SelectPreviousOption()
	{
		List<RadioMessage> list = GameManager.RadioMessagesManager.ReturnPendingRadioMessages();
		SelectOption(list, list.GetPreviousIndex(_selectedOptionIndex));
	}

	public void SelectNextOption()
	{
		List<RadioMessage> list = GameManager.RadioMessagesManager.ReturnPendingRadioMessages();
		SelectOption(list, list.GetNextIndex(_selectedOptionIndex));
	}

	private void SelectOption(List<RadioMessage> options, int selectedIndex)
	{
		_selectedOptionIndex = selectedIndex;
		_selectedOption = options[_selectedOptionIndex];
		if (_selectedOptionIndex < _firstOptionIndex)
		{
			SetFirstOptionIndex(options, _selectedOptionIndex);
		}
		else if (_selectedOptionIndex >= _firstOptionIndex + _options.Length)
		{
			SetFirstOptionIndex(options, _selectedOptionIndex - _options.Length + 1);
		}
		else
		{
			SetFirstOptionIndex(options, _firstOptionIndex);
		}
		RadioMessagePanelOption[] options2 = _options;
		foreach (RadioMessagePanelOption radioMessagePanelOption in options2)
		{
			if (radioMessagePanelOption.gameObject.activeSelf && radioMessagePanelOption.RadioMessage == _selectedOption)
			{
				radioMessagePanelOption.Select();
			}
		}
	}
}
