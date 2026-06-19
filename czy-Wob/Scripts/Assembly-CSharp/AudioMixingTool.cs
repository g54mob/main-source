using System.Collections.Generic;
using ClockStone;
using UnityEngine;
using UnityEngine.UI;

public class AudioMixingTool : MonoBehaviour
{
	public GameObject screenDimmer;

	public Transform categoryHolderHolder;

	public GameObject categoryHolderPrefab;

	public Transform audioLogHolder;

	public Transform activeAudioHolder;

	public GameObject audioLogEntryPrefab;

	public GameObject activeAudioWindowHolder;

	public GameObject audioLoggingWindowHolder;

	public GameObject spammedSoundsToggle;

	public GameObject worldspaceSoundsToggle;

	public GameObject worldSoundVisualizationPrefab;

	private bool audioLogPinned;

	private bool logSpammedSounds = true;

	private bool activeAudioLogPinned;

	private bool worldSpaceSoundVisualizationEnabled;

	private List<string> spammedSoundsCategories = new List<string> { "SFX_Petting" };

	private List<string> spammedSoundsIDs = new List<string> { "thud_mud", "thud_soft", "thud_hard" };

	private bool menuOpen;

	private List<AudioMixingCategory> instantiatedCategoryHolders = new List<AudioMixingCategory>();

	private List<string> activeAudioCategoryIDs = new List<string>();

	private List<AudioObject> framePlayingAudioObjects = new List<AudioObject>();

	private List<AudioObject> currentlyPlayingAudioObjects = new List<AudioObject>();

	private int maxLogItems = 200;

	private List<GameObject> instantiatedLogItems = new List<GameObject>();

	private List<AudioLogItem> activeAudioLogItems = new List<AudioLogItem>();

	private List<WorldspaceAudioVisualizer> activeWorldSoundVisualizers = new List<WorldspaceAudioVisualizer>();

	private GUIManagerPens guiRef;

	private void Awake()
	{
		guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		CloseMenu(force: true);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Minus) && !CheatEngine.cheatRef.publicBuild)
		{
			ToggleMenu();
		}
		UpdateLog();
	}

	public void OnAudioLogTogglePressed(Toggle value)
	{
		audioLogPinned = value.isOn;
		if (!audioLogPinned && !menuOpen)
		{
			audioLoggingWindowHolder.SetActive(value: false);
		}
	}

	public void OnActiveAudioLogTogglePressed(Toggle value)
	{
		activeAudioLogPinned = value.isOn;
		if (!activeAudioLogPinned && !menuOpen)
		{
			activeAudioWindowHolder.SetActive(value: false);
		}
	}

	public void OnWorldspaceSoundVisTogglePressed(Toggle value)
	{
		worldSpaceSoundVisualizationEnabled = value.isOn;
	}

	public void OnSpammedSoundsTogglePressed(Toggle value)
	{
		logSpammedSounds = value.isOn;
	}

	private void ToggleMenu()
	{
		if (menuOpen)
		{
			CloseMenu();
		}
		else
		{
			OpenMenu();
		}
	}

	private void OpenMenu()
	{
		if (!menuOpen)
		{
			menuOpen = true;
			screenDimmer.SetActive(value: true);
			spammedSoundsToggle.SetActive(value: true);
			worldspaceSoundsToggle.SetActive(value: true);
			activeAudioWindowHolder.SetActive(value: true);
			audioLoggingWindowHolder.SetActive(value: true);
			if (guiRef != null)
			{
				guiRef.DisableBG(LockReason.AUDIO_DEBUG);
			}
			CreateMenu();
		}
	}

	private void CloseMenu(bool force = false)
	{
		if (menuOpen || force)
		{
			RemoveButtons();
			menuOpen = false;
			screenDimmer.SetActive(value: false);
			spammedSoundsToggle.SetActive(value: false);
			worldspaceSoundsToggle.SetActive(value: false);
			if (!activeAudioLogPinned)
			{
				activeAudioWindowHolder.SetActive(value: false);
			}
			if (!audioLogPinned)
			{
				audioLoggingWindowHolder.SetActive(value: false);
			}
			if (guiRef != null)
			{
				guiRef.EnableBG(LockReason.AUDIO_DEBUG);
			}
		}
	}

	private void CreateMenu()
	{
		RemoveButtons();
		AudioController component = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<AudioController>();
		List<string> list = new List<string>();
		for (int i = 0; i < component.AudioCategories.Length; i++)
		{
			list.Add(component.AudioCategories[i].Name);
		}
		list.Sort();
		for (int j = 0; j < list.Count; j++)
		{
			AudioMixingCategory component2 = Object.Instantiate(categoryHolderPrefab, categoryHolderHolder).GetComponent<AudioMixingCategory>();
			component2.SetButtonInfo(list[j]);
			instantiatedCategoryHolders.Add(component2);
		}
	}

	private void RemoveButtons()
	{
		for (int num = instantiatedCategoryHolders.Count - 1; num >= 0; num--)
		{
			Object.Destroy(instantiatedCategoryHolders[num].gameObject);
		}
		instantiatedCategoryHolders.Clear();
	}

	private void UpdateLog()
	{
		framePlayingAudioObjects = AudioController.GetPlayingAudioObjects();
		if (!logSpammedSounds)
		{
			for (int num = framePlayingAudioObjects.Count - 1; num >= 0; num--)
			{
				if (spammedSoundsCategories.Contains(framePlayingAudioObjects[num].category.Name) || spammedSoundsIDs.Contains(framePlayingAudioObjects[num].audioID))
				{
					framePlayingAudioObjects.RemoveAt(num);
				}
			}
		}
		activeAudioCategoryIDs.Clear();
		for (int i = 0; i < framePlayingAudioObjects.Count; i++)
		{
			if (!activeAudioCategoryIDs.Contains(framePlayingAudioObjects[i].category.Name))
			{
				activeAudioCategoryIDs.Add(framePlayingAudioObjects[i].category.Name);
			}
			if (!currentlyPlayingAudioObjects.Contains(framePlayingAudioObjects[i]))
			{
				GameObject gameObject = Object.Instantiate(audioLogEntryPrefab, audioLogHolder);
				GameObject gameObject2 = Object.Instantiate(audioLogEntryPrefab, activeAudioHolder);
				gameObject.transform.SetSiblingIndex(0);
				gameObject.GetComponent<AudioLogItem>().SetAudioObject(framePlayingAudioObjects[i]);
				gameObject2.GetComponent<AudioLogItem>().SetAudioObject(framePlayingAudioObjects[i]);
				currentlyPlayingAudioObjects.Add(framePlayingAudioObjects[i]);
				instantiatedLogItems.Add(gameObject);
				if (instantiatedLogItems.Count > maxLogItems)
				{
					Object.Destroy(instantiatedLogItems[0]);
					instantiatedLogItems.RemoveAt(0);
				}
				activeAudioLogItems.Add(gameObject2.GetComponent<AudioLogItem>());
				if (worldSpaceSoundVisualizationEnabled && framePlayingAudioObjects[i].primaryAudioSource.spatialBlend > 0f)
				{
					WorldspaceAudioVisualizer component = Object.Instantiate(worldSoundVisualizationPrefab, framePlayingAudioObjects[i].transform.position, Quaternion.identity).GetComponent<WorldspaceAudioVisualizer>();
					component.SetAudioObject(framePlayingAudioObjects[i]);
					activeWorldSoundVisualizers.Add(component);
				}
			}
		}
		for (int num2 = currentlyPlayingAudioObjects.Count - 1; num2 >= 0; num2--)
		{
			if (!framePlayingAudioObjects.Contains(currentlyPlayingAudioObjects[num2]))
			{
				for (int j = 0; j < activeAudioLogItems.Count; j++)
				{
					if (activeAudioLogItems[j].associatedObject == currentlyPlayingAudioObjects[num2])
					{
						Object.Destroy(activeAudioLogItems[j].gameObject);
						activeAudioLogItems.RemoveAt(j);
						break;
					}
				}
				for (int k = 0; k < activeWorldSoundVisualizers.Count; k++)
				{
					if (activeWorldSoundVisualizers[k].associatedObject == currentlyPlayingAudioObjects[num2])
					{
						activeWorldSoundVisualizers[k].StartDestruction();
						activeWorldSoundVisualizers.RemoveAt(k);
						break;
					}
				}
				currentlyPlayingAudioObjects.RemoveAt(num2);
			}
		}
		for (int l = 0; l < instantiatedCategoryHolders.Count; l++)
		{
			instantiatedCategoryHolders[l].SetPlayingStatus(activeAudioCategoryIDs.Contains(instantiatedCategoryHolders[l].GetCategoryID()));
		}
	}
}
