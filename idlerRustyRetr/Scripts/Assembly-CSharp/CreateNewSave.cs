using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateNewSave : MonoBehaviour
{
	[SerializeField]
	private int farmType;

	[SerializeField]
	private bool vertical;

	[Space]
	[SerializeField]
	private RectTransform panelObject;

	[SerializeField]
	private RectTransform farmSelected;

	[SerializeField]
	private RectTransform layoutSelected;

	[SerializeField]
	private RectTransform[] farmTransforms;

	[SerializeField]
	private RectTransform[] layoutTransforms;

	[SerializeField]
	private Button[] farmButtons;

	[Space]
	[SerializeField]
	private Button createButton;

	[Space]
	[Header("Crossover override")]
	[SerializeField]
	private bool crossoverPanel;

	[SerializeField]
	private int crossoverFarm;

	private void OnEnable()
	{
		panelObject.DOComplete();
		panelObject.transform.localScale = new Vector3(1f, 0f, 1f);
		panelObject.DOScaleY(1f, 0.3f).SetEase(Ease.OutBack);
		if (crossoverPanel)
		{
			SelectCrossover(1);
			return;
		}
		for (int i = 0; i < farmButtons.Length; i++)
		{
			if (i > SaveData.ins.mapsUnlocked)
			{
				farmButtons[i].interactable = false;
			}
			else
			{
				farmButtons[i].interactable = true;
			}
		}
		if (SaveData.ins.mapsUnlocked > 2)
		{
			for (int j = 0; j < farmButtons.Length; j++)
			{
				farmButtons[j].interactable = true;
			}
		}
		SelectFarm(farmType);
	}

	public void SelectFarm(int value)
	{
		farmType = value;
		crossoverFarm = 0;
		farmSelected.transform.localPosition = farmTransforms[value].transform.localPosition;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void SelectCrossover(int value)
	{
		crossoverFarm = value;
		farmSelected.transform.localPosition = farmTransforms[value - 1].transform.localPosition;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void SelectLayoutVertical(int value)
	{
		if (value == 0)
		{
			vertical = false;
		}
		if (value == 1)
		{
			vertical = true;
		}
		layoutSelected.anchoredPosition = layoutTransforms[value].anchoredPosition;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void CreateANewSaveFile()
	{
		if (!GameManager.ins.isLoadingNewGame)
		{
			createButton.interactable = false;
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			StartCoroutine(LoadSave());
		}
	}

	private IEnumerator LoadSave()
	{
		GameManager.ins.isLoadingNewGame = true;
		SaveData.ins.SaveGameData();
		yield return new WaitForSeconds(0.5f);
		GridSystem.ins.loadingScreen.SetActive(value: true);
		yield return new WaitForSeconds(0.5f);
		PersistentFilePath.ins.SetCurrentFilePathToNowUTC(vertical, farmType, crossoverFarm);
		PersistentFilePath.ins.closeMainMenuOnReload = true;
		GameManager.ins.isLoadingNewGame = false;
		SceneManager.LoadScene(0);
	}
}
