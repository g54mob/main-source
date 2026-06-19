using System.Collections.Generic;
using UnityEngine;

public class ShowPopUpWhenEnabled : MonoBehaviour
{
	private const string HAS_SHOWN_POP_UP_PREFS_KEY = "pug/showpopupwhenenabled/hasshown";

	public string text;

	public bool localized = true;

	public bool hasDontShowAgainOption;

	private void OnEnable()
	{
		string prefsKey = "pug/showpopupwhenenabled/hasshown/" + text;
		if (hasDontShowAgainOption && PlayerPrefs.HasKey(prefsKey))
		{
			return;
		}
		Manager.menu.centerPopUpText.StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, options: hasDontShowAgainOption ? new List<string> { "ok", "dontShowAgain" } : new List<string> { "ok" }, localize: localized, fontFace: TextManager.FontFace.boldMedium, optionsCallback: delegate(PopupResponse response)
		{
			Debug.Log($"ok={response.IsConfirm}");
			if (response.IsConfirm)
			{
				PlayerPrefs.SetInt(prefsKey, 1);
			}
		}, minWidth: 10f, backgroundAlpha: 0.8f, priority: 0, textMaxWidth: 20f);
	}
}
