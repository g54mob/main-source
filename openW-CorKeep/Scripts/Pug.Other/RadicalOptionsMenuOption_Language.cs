using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using UnityEngine;

public class RadicalOptionsMenuOption_Language : RadicalPauseMenuOption
{
	public override void OnActivated()
	{
		base.OnActivated();
		NextLanguage();
	}

	public override bool OnSkimLeft()
	{
		return NextLanguage(-1);
	}

	public override bool OnSkimRight()
	{
		return NextLanguage();
	}

	public bool NextLanguage(int offset = 1)
	{
		List<string> allLanguagesCode = LocalizationManager.GetAllLanguagesCode();
		string language = Manager.prefs.language;
		int index = MathUtilities.Negmod(allLanguagesCode.IndexOf(language) + offset, allLanguagesCode.Count);
		string language2 = allLanguagesCode[index];
		Manager.prefs.language = language2;
		PugText[] array = Object.FindObjectsOfType<PugText>();
		foreach (PugText pugText in array)
		{
			if (pugText.localize)
			{
				pugText.Render(rewindEffectAnims: false);
			}
		}
		return true;
	}
}
