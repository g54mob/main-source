using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ResolutionChooser : MonoBehaviour
	{
		public UILabel Label;

		internal Resolution SelectedOption;

		internal List<Resolution> Options;

		public void Start()
		{
			Options = new List<Resolution>();
			foreach (Resolution resolution in Screen.resolutions.ToList())
			{
				if (!Options.Any((Resolution r) => r.width == resolution.width && r.height == resolution.height))
				{
					Options.Add(resolution);
				}
			}
			SelectedOption = Screen.currentResolution;
		}

		public void Update()
		{
			Label.text = SelectedOption.width + "x" + SelectedOption.height;
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
			RuntimeGlobals.Settings.ScreenHeight = SelectedOption.height;
			RuntimeGlobals.Settings.ScreenWidth = SelectedOption.width;
		}
	}
}
