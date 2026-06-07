using System;
using System.Collections.Generic;

namespace Kamgam.SettingsGenerator
{
	public class GetSetConnectionWithOptions<T> : ConnectionWithOptions<T>
	{
		protected int _selectedIndex;

		protected List<T> _optionLabels;

		public event Func<int> Getter;

		public event Action<int> Setter;

		public event Func<List<T>> OptionLabelGetter;

		public event Action<List<T>> OptionLabelSetter;

		public GetSetConnectionWithOptions(Func<int> getter, Action<int> setter, Func<List<T>> optionLabelGetter = null, Action<List<T>> optionLabelSetter = null)
		{
			Getter += getter;
			Setter += setter;
			if (optionLabelGetter != null)
			{
				OptionLabelGetter += optionLabelGetter;
			}
			if (optionLabelSetter != null)
			{
				OptionLabelSetter += optionLabelSetter;
			}
		}

		public override int Get()
		{
			_selectedIndex = this.Getter();
			return _selectedIndex;
		}

		public override void Set(int selectedIndex)
		{
			_selectedIndex = selectedIndex;
			this.Setter(selectedIndex);
		}

		public int GetLastKnownValue()
		{
			return _selectedIndex;
		}

		public override List<T> GetOptionLabels()
		{
			if (this.OptionLabelGetter != null)
			{
				_optionLabels = this.OptionLabelGetter();
			}
			return _optionLabels;
		}

		public override void SetOptionLabels(List<T> optionLabels)
		{
			_optionLabels = optionLabels;
			if (this.OptionLabelSetter != null)
			{
				this.OptionLabelSetter(optionLabels);
			}
		}

		public override void RefreshOptionLabels()
		{
			_optionLabels = null;
			GetOptionLabels();
		}

		public int GetLastSelectedIndex()
		{
			return _selectedIndex;
		}

		public void SetLastSelectedIndex(int index)
		{
			_selectedIndex = index;
		}
	}
}
