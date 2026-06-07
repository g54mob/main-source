using System;
using System.Collections.Generic;
using Gh.Tk.UI;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class BuildMenuSearch3DUIView : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> _visuals;

		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private CheckBox3DUIView _searchNames;

		[SerializeField]
		private CheckBox3DUIView _searchAuthors;

		[SerializeField]
		private CheckBox3DUIView _searchDescriptions;

		[SerializeField]
		private Button3DUIView _optionsButton;

		[SerializeField]
		private ClearBuildMenuSearchButton _clearSearchButton;

		[SerializeField]
		private QuickSearchFilterButton _quickSearchFilterButton;

		private string _currentInput;

		private void Start()
		{
		}

		private void UIControllerOnQuickSearchFilterChanged(object sender, EventArgs e)
		{
		}

		private void ResetUI(object sender, EventArgs eventArgs)
		{
		}

		private void OnCheckboxToggled(object sender, EventArgs<bool> eventArgs)
		{
		}

		private void OnTextChanged(string input)
		{
		}

		private void UpdateClearSearchButton()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public IEnumerable<BuildableTemplate> GetMatches(IEnumerable<BuildableTemplate> templates)
		{
			return null;
		}

		public bool DoesMatchSearch(BuildableTemplate template)
		{
			return false;
		}

		private bool IsMatch(string matchingString)
		{
			return false;
		}

		public IEnumerable<BuildableTemplate> OrderResults(IEnumerable<BuildableTemplate> results)
		{
			return null;
		}

		public bool IsUsingSearch()
		{
			return false;
		}

		public bool IsSearchOpen()
		{
			return false;
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void ClearSearch()
		{
		}
	}
}
