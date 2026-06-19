using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using ModIO;
using PugMod;
using UnityEngine;

public class TitleMenuIncompatibleModWarning : MonoBehaviour
{
	private const string TERM_INCOMPATIBLE_MOD_MESSAGE = "Menu/ModIncompatibleWarning";

	private const string TERM_FAILED_MOD_MESSAGE = "Menu/ModFailedToLoadWarning";

	private const string TERM_LOAD_ANYWAY = "Menu/LoadAnyway";

	private const string TERM_DISABLE = "Menu/Disable";

	private const string TERM_OK = "ok";

	[ClearOnReload]
	private static bool _hasChecked;

	private IEnumerator Start()
	{
		if (_hasChecked)
		{
			yield break;
		}
		_hasChecked = true;
		bool isShowingPopUp = false;
		bool restartNeeded = false;
		Queue<NotLoadedMod> failedMods = new Queue<NotLoadedMod>(Loader.Instance.FailedToLoadMods);
		Dictionary<long, NotLoadedMod> modsToDisableOrLoadAnyway = new Dictionary<long, NotLoadedMod>();
		HashSet<long> modsToLoadAnyway = new HashSet<long>();
		while (failedMods.Count > 0)
		{
			while (isShowingPopUp)
			{
				yield return null;
			}
			isShowingPopUp = true;
			NotLoadedMod mod = failedMods.Dequeue();
			if (mod.CanForceLoad)
			{
				Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ModIncompatibleWarning", new string[1] { mod.Metadata.name }, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
				{
					modsToDisableOrLoadAnyway.Add(mod.ModId, mod);
					if (response.IsConfirm)
					{
						modsToLoadAnyway.Add(mod.ModId);
					}
					isShowingPopUp = false;
				}, new List<string> { "Menu/Disable", "Menu/LoadAnyway" }, 10f, 0.8f, 0, 20f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false);
				continue;
			}
			string translation = LocalizationManager.GetTranslation("Error/" + mod.Reason);
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ModFailedToLoadWarning", new string[2]
			{
				mod.Metadata.name,
				translation
			}, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
			{
				if (response.IsConfirm && mod.ModId > 0)
				{
					ModIOUnity.DisableMod(new ModId(mod.ModId));
					restartNeeded = true;
				}
				isShowingPopUp = false;
			}, (mod.ModId > 0) ? new List<string> { "ok", "Menu/Disable" } : new List<string> { "ok" }, 10f, 0.8f, 0, 20f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false);
		}
		while (isShowingPopUp)
		{
			yield return null;
		}
		foreach (KeyValuePair<long, NotLoadedMod> item in modsToDisableOrLoadAnyway)
		{
			if (modsToLoadAnyway.Contains(item.Key))
			{
				Loader.Instance.LoadUnsupportedMod(item.Value.Metadata.guid);
				restartNeeded = true;
			}
			else
			{
				ModIOUnity.DisableMod(new ModId(item.Key));
			}
		}
		if (restartNeeded)
		{
			Manager.mod.CheckForModChanges(restartIfNeeded: true, forceRestart: false);
		}
	}
}
