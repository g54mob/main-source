using System.Collections;
using PugMod;
using UnityEngine;

public class TitleMenuModLoadedInfo : MonoBehaviour
{
	private const string MOD_MENU_BUTTON_NO_MODS_LOADED_KEY = "Menu/Mods";

	private const string MOD_MENU_BUTTON_MODS_LOADED_KEY = "Menu/ModMenuButtonModsLoaded";

	private const string MOD_MENU_BUTTON_MODS_LOADED_PENDING_CHANGES_KEY = "Menu/ModMenuButtonModsLoadedPendingChanges";

	public PugText text;

	public GameObject pendingChangesText;

	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSecondsRealtime(0.5f);
			if (!text.gameObject.activeInHierarchy)
			{
				pendingChangesText.SetActive(value: false);
				continue;
			}
			int num = 0;
			foreach (LoadedMod loadedMod in Loader.Instance.LoadedMods)
			{
				_ = loadedMod;
				num++;
			}
			if (Manager.mod.CheckForModChanges(restartIfNeeded: false, forceRestart: false))
			{
				text.localizePlaceholders = false;
				text.formatFields = new string[1] { num.ToString() };
				text.Render("Menu/ModMenuButtonModsLoadedPendingChanges");
				pendingChangesText.SetActive(value: true);
			}
			else if (num > 0)
			{
				text.localizePlaceholders = false;
				text.formatFields = new string[1] { num.ToString() };
				text.Render("Menu/ModMenuButtonModsLoaded");
				pendingChangesText.SetActive(value: false);
			}
			else
			{
				text.formatFields = null;
				text.Render("Menu/Mods");
				pendingChangesText.SetActive(value: false);
			}
		}
	}
}
