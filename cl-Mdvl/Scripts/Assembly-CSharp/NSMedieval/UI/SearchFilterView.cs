using System.Collections.Generic;
using NSEipix.View.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SearchFilterView : MonoBehaviour
	{
		public delegate void SearchKeywords(string[] keywords);

		public delegate void CancelSearch();

		public delegate void FilterChanged(int index);

		[SerializeField]
		private TMP_InputField searchInputField;

		[SerializeField]
		private SoundButton cancelSearchButton;

		[SerializeField]
		private TMP_Dropdown filterDropdown;

		public event SearchKeywords OnSearchKeywords;

		public event FilterChanged OnFilterChanged;

		public event CancelSearch OnCancelSearch;

		public void SetupFilters(List<string> filters)
		{
			filterDropdown.gameObject.SetActive(value: true);
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (string filter in filters)
			{
				list.Add(new TMP_Dropdown.OptionData(filter));
			}
			filterDropdown.onValueChanged.RemoveAllListeners();
			filterDropdown.ClearOptions();
			filterDropdown.AddOptions(list);
			filterDropdown.onValueChanged.AddListener(OnFilterDropdownChanged);
			filterDropdown.SetValueWithoutNotify(0);
		}

		public void ResetFilter()
		{
			filterDropdown.SetValueWithoutNotify(0);
		}

		public void DisableSearchField()
		{
			searchInputField.gameObject.SetActive(value: false);
		}

		private void Start()
		{
			cancelSearchButton.onClick.AddListener(ClearSearch);
		}

		private void Update()
		{
			if (base.gameObject.activeInHierarchy)
			{
				if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && searchInputField.text != string.Empty)
				{
					SearchButtons(searchInputField.text.ToLower());
					searchInputField.Select();
					searchInputField.ActivateInputField();
				}
				else if (Input.GetKeyDown(KeyCode.Escape) && searchInputField.text != string.Empty)
				{
					ClearSearch();
				}
			}
		}

		private void OnFilterDropdownChanged(int selectedIndex)
		{
			if (selectedIndex != -1)
			{
				this.OnFilterChanged?.Invoke(selectedIndex);
			}
		}

		private void SearchButtons(string searchContext)
		{
			string[] array = searchContext.Split(' ');
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].ToLower();
			}
			this.OnSearchKeywords?.Invoke(array);
		}

		private void ClearSearch()
		{
			ClearSearchInputField();
			this.OnCancelSearch?.Invoke();
		}

		private void ClearSearchInputField()
		{
			SearchButtons(string.Empty);
			searchInputField.Select();
			searchInputField.ActivateInputField();
			searchInputField.text = string.Empty;
		}
	}
}
