using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.UIFramework;
using DV.Util;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class LanguageSelectorController : AUIController
	{
		private ASettingsProvider provider;

		[NullCheck]
		public LanguageSelectorGridView gridView;

		[NullCheck]
		public ButtonDV translateButton;

		private bool reentrancyCheck_RefreshData;

		private bool reentrancyCheck_RefreshInterface;

		private bool IsIndexValid
		{
			get
			{
				if (gridView.SelectedModelIndex >= 0)
				{
					return gridView.SelectedModelIndex < gridView.Model.Count;
				}
				return false;
			}
		}

		public void SetProvider(ASettingsProvider provider)
		{
			if (this.provider != null)
			{
				Util.RunOnce(this, "SetProvider");
				return;
			}
			this.provider = provider;
			translateButton.onClick.AddListener(OpenTranslationForm);
			RefreshData();
		}

		private void OpenTranslationForm()
		{
			provider?.OpenTranslationForm();
		}

		private void OnEnable()
		{
			RefreshData();
			StartCoroutine(ScrollToSelected());
		}

		private void RefreshData()
		{
			if (reentrancyCheck_RefreshData)
			{
				Debug.LogError("Reentrancy check fail for RefreshData!", this);
			}
			reentrancyCheck_RefreshData = true;
			if (provider == null)
			{
				gridView.SetModel(null);
			}
			else
			{
				List<LanguageItem> list = provider.GetLanguages().Select(provider.ToLanguageItem).ToList();
				list.Sort(LanguageSortingComparison);
				ObservableCollectionExt<LanguageItem> model = new ObservableCollectionExt<LanguageItem>(list);
				gridView.SetModel(model);
				string currentLang = provider.GetCurrentLanguage();
				int num = list.FindIndex((LanguageItem l) => l.languageName == currentLang);
				if (num >= 0)
				{
					gridView.SetSelected(num);
				}
			}
			RefreshInterface();
			reentrancyCheck_RefreshData = false;
		}

		private void RefreshInterface()
		{
			if (reentrancyCheck_RefreshInterface)
			{
				Debug.LogError("Reentrancy check fail for RefreshInterface!", this);
			}
			reentrancyCheck_RefreshInterface = true;
			reentrancyCheck_RefreshInterface = false;
		}

		private IEnumerator ScrollToSelected()
		{
			yield return null;
			if (IsIndexValid)
			{
				int selectedModelIndex = gridView.SelectedModelIndex;
				if (gridView.transform.childCount <= selectedModelIndex)
				{
					Debug.LogError($"gridView doesn't have enough children! {gridView.transform.childCount} <= {selectedModelIndex}", gridView);
					yield break;
				}
				int constraintCount = gridView.GetComponent<GridLayoutGroup>().constraintCount;
				int num = selectedModelIndex / constraintCount;
				int num2 = Mathf.CeilToInt((float)gridView.Model.Count / (float)constraintCount);
				float num3 = (float)num / (float)(num2 - 1);
				num3 = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(1f - num3));
				gridView.GetComponentInParent<ScrollRect>().verticalScrollbar.value = num3;
			}
		}

		private int LanguageSortingComparison(LanguageItem a, LanguageItem b)
		{
			if (a.languageName == "English")
			{
				return -1;
			}
			if (b.languageName == "English")
			{
				return 1;
			}
			if (a.languageName == "Longtext")
			{
				return 1;
			}
			if (b.languageName == "Longtext")
			{
				return -1;
			}
			return a.languageName.CompareTo(b.languageName);
		}
	}
}
