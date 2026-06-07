using System;
using UnityEngine;
using UnityEngine.Events;

namespace Motorways.UI
{
	public abstract class OptionButton : MonoBehaviour
	{
		[Serializable]
		public class OptionEvent : UnityEvent<int>
		{
		}

		public OptionEvent onOptionChanged;

		public bool wrap;

		protected int _currentIndex = -1;

		public int SelectedOptionIndex => _currentIndex;

		public virtual int NumberOfOptions => 0;

		public virtual void SetOption(int index)
		{
			SetOption(index, invokeMethod: true);
		}

		public virtual void SetOption(int index, bool invokeMethod)
		{
			int currentIndex = Mathf.Clamp(index, 0, NumberOfOptions - 1);
			_currentIndex = currentIndex;
			if (Diagnostics.Verify(_currentIndex >= 0 && _currentIndex < NumberOfOptions, "Options index {0} isn't valid. Must be between 0 and {1}", _currentIndex, NumberOfOptions) && invokeMethod)
			{
				onOptionChanged.Invoke(_currentIndex);
			}
		}
	}
}
