using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class EnumChooser : MonoBehaviour
	{
		public UILabel Label;

		public List<int> IgnoreValues;

		internal Enum SelectedOption;

		internal List<Enum> Options;

		private bool _unknownValue;

		public event Action<Enum> SelectionChanged;

		public void Init<T>(Enum selectedOption, bool unknownValue)
		{
			Options = new List<Enum>();
			foreach (object value in Enum.GetValues(typeof(T)))
			{
				Options.Add((Enum)value);
			}
			SelectedOption = selectedOption;
			_unknownValue = unknownValue;
		}

		public void Init<T>(Enum selectedOption)
		{
			Options = new List<Enum>();
			foreach (object value in Enum.GetValues(typeof(T)))
			{
				Options.Add((Enum)value);
			}
			SelectedOption = selectedOption;
		}

		public void Init<T>(List<T> values, Enum selectedOption) where T : Enum
		{
			Options = new List<Enum>();
			foreach (T value in values)
			{
				Options.Add(value);
			}
			SelectedOption = selectedOption;
			_unknownValue = false;
		}

		public void Init(Array values, Enum selectedOption, bool unknownValue)
		{
			Options = new List<Enum>();
			foreach (object value in values)
			{
				Options.Add((Enum)value);
			}
			SelectedOption = selectedOption;
			_unknownValue = unknownValue;
		}

		public void Update()
		{
			if (_unknownValue)
			{
				Label.text = "?";
			}
			else if (SelectedOption != null)
			{
				string translation = LocalizationManager.GetTranslation(SelectedOption.GetType().Name + "/" + SelectedOption);
				if (string.IsNullOrEmpty(translation))
				{
					Label.text = SelectedOption.ToString();
				}
				else
				{
					Label.text = translation;
				}
			}
		}

		public void ToggleNextOption(bool right)
		{
			int num = Options.Count - 1;
			int num2 = Options.IndexOf(SelectedOption);
			num2 = ((!right) ? (num2 - 1) : (num2 + 1));
			if (num2 < 0)
			{
				num2 = num;
			}
			if (num2 > num)
			{
				num2 = 0;
			}
			num2 = Check(num2, right);
			SelectedOption = Options[num2];
			Action<Enum> action = this.SelectionChanged;
			if (action != null)
			{
				action(SelectedOption);
			}
			_unknownValue = false;
		}

		private int Check(int current, bool right)
		{
			if (IgnoreValues == null || IgnoreValues.Count <= 0)
			{
				return current;
			}
			int num = 0;
			int count = Options.Count;
			int num2 = Options.Count - 1;
			while (IgnoreValues.Contains(current) && num < count)
			{
				num++;
				current = ((!right) ? (current - 1) : (current + 1));
				if (current < 0)
				{
					current = num2;
				}
				if (current > num2)
				{
					current = 0;
				}
			}
			return current;
		}
	}
}
