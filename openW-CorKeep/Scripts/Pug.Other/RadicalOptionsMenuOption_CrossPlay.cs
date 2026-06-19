using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class RadicalOptionsMenuOption_CrossPlay : RadicalPauseMenuOption
{
	[Serializable]
	public struct LocalizedText
	{
		public Platform platform;

		public string textWhenOn;

		public string textWhenOff;
	}

	[ArrayElementTitle("platform")]
	public List<LocalizedText> localizedTexts;

	private LocalizedText _localizedText;

	private bool currentValue;

	private void Start()
	{
		Platform platform = Manager.platform.Platform;
		if (!TryGetLocalizedText(platform, out _localizedText))
		{
			Debug.LogWarning(string.Format("{0}: No localized text found for platform: {1}.", "RadicalOptionsMenuOption_CrossPlay", platform));
			_localizedText = new LocalizedText
			{
				platform = platform,
				textWhenOn = "on",
				textWhenOff = "off"
			};
		}
		bool flag = Manager.platform.parentalControlManager.IParentalControl.CrossPlayAllowed(showUI: false);
		Debug.Log("ALLOW CROSSPLAY: " + flag);
		currentValue = Manager.prefs.crossPlay && flag;
		UpdateText(currentValue);
	}

	private bool TryGetLocalizedText(Platform platform, out LocalizedText localizedText)
	{
		foreach (LocalizedText localizedText2 in localizedTexts)
		{
			if (localizedText2.platform == platform)
			{
				localizedText = localizedText2;
				return true;
			}
		}
		localizedText = default(LocalizedText);
		return false;
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (Manager.platform.parentalControlManager.IParentalControl.CrossPlayAllowed(showUI: true))
		{
			currentValue = !currentValue;
			Manager.prefs.crossPlay = currentValue;
			UpdateText(currentValue);
		}
	}

	public override bool OnSkimRight()
	{
		return OnSkimLeft();
	}

	public override bool OnSkimLeft()
	{
		OnActivated();
		return true;
	}

	private void UpdateText(bool crossPlayEnabled)
	{
		valueText.Render(crossPlayEnabled ? _localizedText.textWhenOn : _localizedText.textWhenOff);
	}

	public override bool IsOn()
	{
		return Manager.prefs.crossPlay;
	}
}
