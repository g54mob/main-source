using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public SettingsManager settingsManager;

	private SoundManager soundManager;

	public Transform twitterText;

	public Transform blackScreen;

	public Transform menuItemParent;

	public List<MenuItemLayer> menuItemLayers = new List<MenuItemLayer>();

	public MenuItemLayer currentVisibleLayer;

	private bool isTransitioningToLayer;

	public ParticleSystem completionParticle1;

	public ParticleSystem completionParticle2;

	public void Awake()
	{
		blackScreen.gameObject.SetActive(value: true);
		twitterText.gameObject.SetActive(value: false);
		SpeedrunTimer.doCountTime = false;
		StartCoroutine(Intro());
		GetAllMenuItemLayers();
	}

	public void Start()
	{
		PlayerSaveData playerSaveData = SaveSystem.LoadPlayerSaveData();
		if (playerSaveData == null)
		{
			SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		}
		else
		{
			SaveSystem.currentPlayerSaveData = playerSaveData;
		}
		SteamAchievements.CheckForFinalAchievement();
		AsyncStart();
	}

	private async void AsyncStart()
	{
		CheatPrevention.hasCheatedPreviously = await CheatPrevention.CheckIfPreviouslyCheated();
		SteamLeaderboards.AutoUpdateScoreToLeaderboard();
	}

	public void GetAllMenuItemLayers()
	{
		List<MenuItem> list = Object.FindObjectsOfType<MenuItem>().ToList();
		foreach (MenuItem item in list)
		{
			if (item.GetType() == typeof(OptionsMenuItem))
			{
				List<MenuItem> list2 = item.GetComponentsInChildren<MenuItem>().ToList();
				list2.Remove(item);
				if (list2.Count > 0)
				{
					CreateMenuItemLayer(item, list2);
				}
			}
		}
		List<MenuItem> list3 = new List<MenuItem>();
		foreach (MenuItem item2 in list)
		{
			if (GetLayerByChild(item2) == null)
			{
				list3.Add(item2);
			}
			item2.transform.localScale = new Vector3(item2.transform.localScale.x, 0f, item2.transform.localScale.z);
		}
		if (list3.Count > 0)
		{
			MenuItemLayer newLayer = CreateMenuItemLayer(null, list3);
			StartCoroutine(TransitionToNewLayer(newLayer));
		}
	}

	public MenuItemLayer CreateMenuItemLayer(MenuItem parent, List<MenuItem> children)
	{
		foreach (MenuItem child in children)
		{
			child.transform.SetParent(menuItemParent);
		}
		MenuItemLayer menuItemLayer = new MenuItemLayer(parent, children);
		menuItemLayers.Add(menuItemLayer);
		return menuItemLayer;
	}

	public MenuItemLayer GetLayerByChild(MenuItem child)
	{
		foreach (MenuItemLayer menuItemLayer in menuItemLayers)
		{
			if (menuItemLayer.menuItems.Contains(child))
			{
				return menuItemLayer;
			}
		}
		return null;
	}

	public MenuItemLayer GetLayerByParent(MenuItem parent)
	{
		foreach (MenuItemLayer menuItemLayer in menuItemLayers)
		{
			if (menuItemLayer.parentMenuItem == parent)
			{
				return menuItemLayer;
			}
		}
		return null;
	}

	public void OnItemDescendLayer(MenuItem menuItem)
	{
		if (!isTransitioningToLayer)
		{
			MenuItemLayer layerByParent = GetLayerByParent(menuItem);
			StartCoroutine(TransitionToNewLayer(layerByParent));
		}
	}

	public void OnItemAscendLayer(MenuItem menuItem)
	{
		if (!isTransitioningToLayer)
		{
			settingsManager.ApplySettings();
			MenuItemLayer layerByChild = GetLayerByChild(menuItem);
			MenuItemLayer layerByChild2 = GetLayerByChild(layerByChild.parentMenuItem);
			StartCoroutine(TransitionToNewLayer(layerByChild2));
		}
	}

	public IEnumerator TransitionToNewLayer(MenuItemLayer newLayer)
	{
		isTransitioningToLayer = true;
		if (currentVisibleLayer != null)
		{
			foreach (MenuItem menuItem in currentVisibleLayer.menuItems)
			{
				menuItem.gameObject.GetComponent<MenuItemSound>().enabled = false;
				GuessButtonBar component = menuItem.gameObject.GetComponent<GuessButtonBar>();
				component.StartCoroutine(component.GrowDecreaseBar());
			}
		}
		yield return new WaitForSeconds(0.25f);
		currentVisibleLayer = newLayer;
		foreach (MenuItem menuItem2 in currentVisibleLayer.menuItems)
		{
			if (menuItem2.GetType() == typeof(SettingMenuItem))
			{
				((SettingMenuItem)menuItem2).UpdateDisplayText();
			}
			menuItem2.gameObject.GetComponent<MenuItemSound>().enabled = true;
			GuessButtonBar component2 = menuItem2.gameObject.GetComponent<GuessButtonBar>();
			component2.StartCoroutine(component2.GrowIncreaseBar());
		}
		isTransitioningToLayer = false;
	}

	public IEnumerator Intro()
	{
		yield return new WaitForSeconds(1f);
		blackScreen.gameObject.SetActive(value: false);
		twitterText.gameObject.SetActive(value: true);
		soundManager = Object.FindObjectOfType<SoundManager>();
		SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
		SoundManager.LoadSoundEffect(soundManager.ambientSource.transform, soundManager.overworld_bridge_ambience);
		if (SteamAchievements.IsThisAchievementUnlocked("UNLOCK_ALL_ACHIEVEMENTS"))
		{
			completionParticle1.Play();
			completionParticle2.Play();
		}
	}

	public IEnumerator Outro(string sceneName, float time)
	{
		if (sceneName == "Overworld" && SpeedrunTimer.doSpeedrunTimer)
		{
			SaveSystem.currentPlayerSaveData.totalGameTime = 0f;
			SaveSystem.ResetPlayerSaveData();
			SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		}
		SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
		blackScreen.gameObject.SetActive(value: true);
		twitterText.gameObject.SetActive(value: false);
		soundManager.ambientSource.Pause();
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(sceneName);
	}

	public void OnWipeSaveFile()
	{
		SaveSystem.ResetPlayerSaveData();
	}

	public void OnItemPlay()
	{
		StartCoroutine(Outro("Overworld", 2f));
	}

	public void OnItemCredits()
	{
		StartCoroutine(Outro("Credits", 2f));
	}

	public void OnItemAchievements()
	{
		StartCoroutine(Outro("Achievements", 2f));
	}

	public void OnItemLeaderboard()
	{
		StartCoroutine(Outro("Leaderboard", 2f));
	}

	public void OnItemQuit()
	{
		Debug.Log("OnQuit");
		Application.Quit();
	}
}
