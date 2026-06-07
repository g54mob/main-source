using System.Collections.Generic;
using System.Linq;
using Gh.Tk.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk
{
	public class SaveGameCardList3DUIView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _saveGameCardPrefab;

		[SerializeField]
		private Container3DUIView _cardContainer;

		[SerializeField]
		private ScrollRect _cardScrollRect;

		private List<SaveGameCard3DUIView> _cards;

		[SerializeField]
		private Container3DUIView _olderSaveCardContainer;

		[SerializeField]
		private ScrollRect _oldCardScrollRect;

		private List<SaveGameCard3DUIView> _olderSaveCards;

		[SerializeField]
		private Button3DUIView _loadMoreButton;

		private int _currentSaveFolderIndex;

		private ILookup<string, SaveLoadManager.SaveGameHeader> _saveGameCache;

		private int _currentOlderSaveGameIndex;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		public void ResetLayout()
		{
		}

		private void ResetOlderSaves()
		{
		}

		private void ResetSaveCardList()
		{
		}

		public void ShowSaveGames(string levelId)
		{
		}

		public void PopulateSaveGames(string levelId)
		{
		}

		private void PopulateCardList(ILookup<string, SaveLoadManager.SaveGameHeader> saveGameLookUp)
		{
		}

		public void RefreshSaveFolderList()
		{
		}

		private void LoadMoreSaveFolders()
		{
		}

		private SaveGameCard3DUIView AddSaveGameToList(int atIndex, IEnumerable<SaveLoadManager.SaveGameHeader> saveFolder)
		{
			return null;
		}

		private void CheckOldSavesButtonStates(string tavernId)
		{
		}

		private void PopulateOlderSavesCardList(IEnumerable<SaveLoadManager.SaveGameHeader> saveGames)
		{
		}

		private SaveGameCard3DUIView AddOlderSaveGameToList(int atIndex, SaveLoadManager.SaveGameHeader save)
		{
			return null;
		}

		private SaveGameCard3DUIView CreateNewCard(Transform container)
		{
			return null;
		}

		private void CleanUpSaveCardList(int totalNeeded, List<SaveGameCard3DUIView> cards)
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}
	}
}
