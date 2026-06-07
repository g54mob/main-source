using System;
using System.Collections.Generic;
using Motorways.Audio;
using UnityEngine;
using UnityEngine.Events;

namespace Motorways.UI
{
	public class SymbolOptionButton : OptionButton
	{
		[Serializable]
		public class OptionTrigger : UnityEvent<bool>
		{
		}

		public int optionCount;

		[Tooltip("On what index should the method trigger?")]
		public int triggerOnOption;

		[Tooltip("The value to send when OnOptionTrigger is invoked")]
		public bool triggerValue;

		[SerializeField]
		private NumberBubble _bubble;

		public OptionTrigger onOptionTriggered = new OptionTrigger();

		[SerializeField]
		private List<int> _blockedOptions = new List<int>();

		public override int NumberOfOptions => optionCount;

		private void Awake()
		{
			_bubble?.Hide(instantly: true);
			SetOption(0, invokeMethod: true, invokeTriggerMethod: false);
		}

		public void NextOption()
		{
			int num = 0;
			do
			{
				_currentIndex++;
				num++;
				if (_currentIndex >= NumberOfOptions)
				{
					_currentIndex = ((!wrap) ? (NumberOfOptions - 1) : 0);
				}
			}
			while (_blockedOptions.Contains(_currentIndex) && num <= NumberOfOptions);
			SetOption(_currentIndex);
			AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateUIEvent((_currentIndex == 0) ? UIEventType.CheckboxUnchecked : UIEventType.CheckboxChecked));
		}

		public void SetToTriggerOption(bool invokeMethod)
		{
			SetOption(triggerOnOption, invokeMethod);
		}

		public void SkipOption(int optionIndex)
		{
			if (!_blockedOptions.Contains(optionIndex))
			{
				_blockedOptions.Add(optionIndex);
			}
		}

		public void UnskipOption(int optionIndex)
		{
			if (_blockedOptions.Contains(optionIndex))
			{
				_blockedOptions.Remove(optionIndex);
			}
		}

		public void SetOption(int index, bool invokeMethod, bool invokeTriggerMethod)
		{
			base.SetOption(index, invokeMethod);
			if (invokeTriggerMethod)
			{
				if (_currentIndex == triggerOnOption)
				{
					onOptionTriggered.Invoke(triggerValue);
				}
				else
				{
					onOptionTriggered.Invoke(!triggerValue);
				}
			}
			if (_bubble != null)
			{
				if (_currentIndex == 0)
				{
					_bubble.Hide();
				}
				else
				{
					_bubble.SetValue(GetVisibleIndex());
				}
			}
		}

		private int GetVisibleIndex()
		{
			int num = 0;
			for (int i = 0; i < _currentIndex; i++)
			{
				if (!_blockedOptions.Contains(i))
				{
					num++;
				}
			}
			return num;
		}

		public override void SetOption(int index, bool invokeMethod)
		{
			SetOption(index, invokeMethod, invokeMethod);
		}
	}
}
