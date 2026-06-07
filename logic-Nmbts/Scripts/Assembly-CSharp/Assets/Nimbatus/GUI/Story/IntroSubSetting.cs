using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Story
{
	[Serializable]
	public class IntroSubSetting
	{
		public ETypeOfIntroSetting Type;

		[ShowIf("Type", ETypeOfIntroSetting.ActivateObjects, true)]
		public List<GameObject> ActivateObjects = new List<GameObject>();

		[ShowIf("Type", ETypeOfIntroSetting.DeactivateObjects, true)]
		public List<GameObject> DeactivateObjects = new List<GameObject>();

		[ShowIf("Type", ETypeOfIntroSetting.FadeObjects, true)]
		public List<FadeObject> FadeObjects = new List<FadeObject>();

		[ShowIf("Type", ETypeOfIntroSetting.PlaySounds, true)]
		public List<string> PlaySounds = new List<string>();

		[ShowIf("Type", ETypeOfIntroSetting.StopSounds, true)]
		public List<string> StopSounds = new List<string>();

		[ShowIf("Type", ETypeOfIntroSetting.TextLines, true)]
		public List<TextLine> Texts = new List<TextLine>();
	}
}
