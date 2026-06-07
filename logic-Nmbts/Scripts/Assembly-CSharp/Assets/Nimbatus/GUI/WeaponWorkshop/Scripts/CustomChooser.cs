using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class CustomChooser : MonoBehaviour
	{
		public UILabel Label;

		internal object SelectedOption;

		internal List<object> Options;

		public void Init<T>(IEnumerable<T> options, T selectedOption)
		{
			Options = new List<object>();
			foreach (T option in options)
			{
				Options.Add(option);
			}
			SelectedOption = selectedOption;
		}

		public void Update()
		{
			if (SelectedOption != null)
			{
				Label.text = SelectedOption.ToString();
			}
			else
			{
				Label.text = "None";
			}
		}

		public void ToggleNextOption(bool right)
		{
			int num = 0;
			int num2 = Options.Count - 1;
			int num3 = Options.IndexOf(SelectedOption);
			num3 = ((!right) ? (num3 - 1) : (num3 + 1));
			if (num3 < num)
			{
				num3 = num2;
			}
			if (num3 > num2)
			{
				num3 = num;
			}
			SelectedOption = Options[num3];
		}
	}
}
