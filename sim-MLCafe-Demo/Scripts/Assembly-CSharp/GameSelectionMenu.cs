using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSelectionMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject buttonContinue;

	[SerializeField]
	private GameObject content;

	[SerializeField]
	private GameObject labelNoSaveDataFound;

	[SerializeField]
	private GameObject slotScrollView;

	[SerializeField]
	private GameObject slotPrefab;

	[SerializeField]
	private RectTransform slotContainer;

	private List<GameSaveSlot> slots = new List<GameSaveSlot>();

	private SaveFileMeta gameMeta;

	private void Start()
	{
		gameMeta = DataPersistenceManager.LoadSaveFileMeta();
		if (gameMeta == null || gameMeta.files.Count == 0)
		{
			slotScrollView.SetActive(value: false);
			buttonContinue.SetActive(value: false);
			labelNoSaveDataFound.SetActive(value: true);
			return;
		}
		slotScrollView.SetActive(value: true);
		labelNoSaveDataFound.SetActive(value: false);
		if (DataPersistenceManager.IsGameVersionCompatible(gameMeta.files.Find((GameDataPreview x) => x.fileName == gameMeta.lastPlayedFile).version))
		{
			buttonContinue.SetActive(value: true);
		}
	}

	public void ShowGameSelection()
	{
		content.SetActive(value: true);
		if (gameMeta == null)
		{
			return;
		}
		foreach (GameSaveSlot slot in slots)
		{
			if (!(slot == null) && slot.gameObject != null)
			{
				UnityEngine.Object.Destroy(slot.gameObject);
			}
		}
		slots.Clear();
		for (int i = 0; i < gameMeta.files.Count; i++)
		{
			CreateSaveSlot(i, gameMeta);
		}
		slots = slots.OrderByDescending((GameSaveSlot x) => DateTime.Parse(x.GetData().lastPlayed)).ToList();
		for (int num = 0; num < slots.Count; num++)
		{
			slots[num].transform.SetSiblingIndex(num);
		}
	}

	private void CreateSaveSlot(int index, SaveFileMeta meta)
	{
		GameSaveSlot component = UnityEngine.Object.Instantiate(slotPrefab, slotContainer).GetComponent<GameSaveSlot>();
		component.InitSlot(index, meta);
		slots.Add(component);
	}
}
