using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.EventSystems;

public class CutsceneUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private List<CutscenePart> cutscenePartsList;

	[SerializeField]
	private AudioSource ambient;

	private int cutsceneIndex;

	private void Start()
	{
		if (ambient != null)
		{
			ambient.volume = 0f;
		}
		ShowCutscene(cutsceneIndex);
		if (!AllServices.Container.Single<IPersistentProgressService>().Progress.ShowCurtain || AllServices.Container.Single<IPersistentProgressService>().Progress.IsFirstLaunch)
		{
			Hide();
		}
	}

	private void OnDestroy()
	{
	}

	private void InputManager_OnInteract(object sender, EventArgs e)
	{
		if (cutsceneIndex < cutscenePartsList.Count)
		{
			AdvanceCutscene();
		}
	}

	private void AdvanceCutscene()
	{
		HideCutscene(cutsceneIndex);
		cutsceneIndex++;
		if (cutsceneIndex < cutscenePartsList.Count)
		{
			ShowCutscene(cutsceneIndex);
			SoundManager.Instance.OnButtonClick();
			return;
		}
		AllServices.Container.Single<IPersistentProgressService>().Progress.ShowCurtain = false;
		DialogueManager.Instance.ShowStartingDialogue();
		MusicManager.Instance.PlayLevelMusic();
		Hide();
	}

	private void ShowCutscene(int index)
	{
		cutscenePartsList[index].Show();
	}

	private void HideCutscene(int index)
	{
		cutscenePartsList[index].Hide();
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		if (ambient != null)
		{
			ambient.volume = 0.2f;
		}
		base.gameObject.SetActive(value: false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		InputManager_OnInteract(null, null);
	}
}
