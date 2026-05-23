using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Factory.UI
{
	public class SelectCategoryPaletteCtrl : MonoBehaviour
	{
		private const int paletteCategoryWidth = 80;

		[SerializeField]
		private PaletteCategoryCtrl paletteCategoryPrefab;

		[SerializeField]
		private ToggleGroup toggleGroup;

		private List<ArtifactPaletteCtrl.PaletteCategoryData> categoryDataList;

		private List<ArtifactPaletteCtrl.PaletteData> paletteDataList;

		private List<PaletteCategoryCtrl> paletteCategoryList;

		private int selectedCategoryNumber;

		private UnityAction<int> onChangeCategoryAction;

		public void Init(List<ArtifactPaletteCtrl.PaletteData> paletteDataList, UnityAction<int> action, int selectedCategoryNumber = -1)
		{
		}

		public void SetCategories(List<ArtifactPaletteCtrl.PaletteCategoryData> categoryDataList, int selectedCategoryNumber = -1)
		{
		}

		public void UpdatePaletteItems(int selectedCategoryNumber, bool showShortcut = true)
		{
		}

		public void UpdateVisibleShortcutIcon(bool showShortcut)
		{
		}

		private void Update()
		{
		}

		private void OnClickCategoryButton(int categoryNumber)
		{
		}

		private void ReadPaletteItem(int categoryNumber)
		{
		}

		public void SetToggleOn(int categoryNumber)
		{
		}

		public bool GetToggleEnable(int categoryNumber)
		{
			return false;
		}

		private void SetCategoryTabVisible()
		{
		}

		public PaletteCategoryCtrl GetCategoryCtrl(int categoryNumber)
		{
			return null;
		}
	}
}
