using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Story
{
	[Serializable]
	public class IntroSetting
	{
		public EShowIntroMode IntroMode;

		public float Delay;

		public bool Skippable;

		public List<IntroSubSetting> SubSettings = new List<IntroSubSetting>();

		[HideInInspector]
		public List<TextLine> TextLines;

		public IntroSubSetting Execute(int index)
		{
			if (index >= SubSettings.Count)
			{
				throw new IndexOutOfRangeException();
			}
			IntroSubSetting introSubSetting = SubSettings[index];
			switch (introSubSetting.Type)
			{
			case ETypeOfIntroSetting.TextLines:
				TextLines = introSubSetting.Texts;
				break;
			case ETypeOfIntroSetting.ActivateObjects:
				introSubSetting.ActivateObjects.ForEach(delegate(GameObject o)
				{
					o.SetActive(true);
				});
				break;
			case ETypeOfIntroSetting.DeactivateObjects:
				introSubSetting.DeactivateObjects.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
				break;
			case ETypeOfIntroSetting.FadeObjects:
				introSubSetting.FadeObjects.ForEach(delegate(FadeObject o)
				{
					o.Tween.Play(o.In);
				});
				break;
			case ETypeOfIntroSetting.PlaySounds:
				introSubSetting.PlaySounds.ForEach(delegate(string s)
				{
					AudioController.Play(s);
				});
				break;
			case ETypeOfIntroSetting.StopSounds:
				introSubSetting.StopSounds.ForEach(delegate(string s)
				{
					AudioController.Stop(s, 0.15f);
				});
				break;
			}
			return introSubSetting;
		}
	}
}
