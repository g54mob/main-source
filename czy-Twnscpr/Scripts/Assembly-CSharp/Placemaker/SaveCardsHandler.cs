using System;
using System.Collections;
using System.Collections.Generic;
using Placemaker.Ui;
using UnityEngine;

namespace Placemaker
{
	public class SaveCardsHandler : MonoBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private enum LoadingAllSaveCardsState : byte
		{
			Begin = 0,
			GetPath = 1,
			LoadSave = 2,
			LastStep = 3,
			Done = 4
		}

		[SerializeField]
		private enum LoadSingleSaveDataState : byte
		{
			Begin = 0,
			Work = 1,
			Done = 2
		}

		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private SaveCard srcSaveCard;

		[SerializeField]
		private Transform cardsRoot;

		[SerializeField]
		private List<SaveCard> cardPool;

		[SerializeField]
		private List<SaveCard> activeCards;

		[SerializeField]
		private LoadingAllSaveCardsState loadingAllSaveCardsState;

		[SerializeField]
		private LoadSingleSaveDataState loadSingleSaveDataState;

		[SerializeField]
		private IEnumerator loadingDataEnumerator;

		[SerializeField]
		private int storageFilesIndex;

		[SerializeField]
		private int currentCardIndex;

		[SerializeField]
		private string currentFilePath;

		public SaveCard lastSaveCard;

		public StorageUtils storage;

		public void OnSetup(UiMaster master)
		{
		}

		public void OnStart(UiMaster master)
		{
		}

		private void Update()
		{
		}

		public void FillList()
		{
		}

		public SaveCard InstantiateNewCard()
		{
			return null;
		}

		public void ResetCardPool()
		{
		}

		public void ResetActiveCards()
		{
		}

		public void AddCardToActiveCardsList(SaveCard card)
		{
		}

		public bool SetLastSaveCard()
		{
			return false;
		}

		public void SortActiveCards()
		{
		}

		public void SetCardImages()
		{
		}

		public void SetCurrentCardImage()
		{
		}

		public void BeginLoadingAllSaveCards()
		{
		}

		public bool IsLoadingAllSaveCardsDone()
		{
			return false;
		}

		private void LoadingAllSaveCards()
		{
		}

		public void BeginLoadingDataIntoCard()
		{
		}

		private void CardDataLoadingFailed()
		{
		}

		private void LoadDataIntoCard()
		{
		}

		public void SetNewCard(SaveData saveData, string fileName, string filePath)
		{
		}

		public void UpdateCardLastWriteTime(string fileName, long time)
		{
		}

		public IEnumerator DuplicateCard(SaveCard templateCard, Action callback = null)
		{
			return null;
		}

		public IEnumerator DeleteCard(SaveCard card, Action callback = null)
		{
			return null;
		}
	}
}
