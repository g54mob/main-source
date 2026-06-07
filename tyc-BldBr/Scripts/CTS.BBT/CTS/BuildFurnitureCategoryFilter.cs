using System;
using CTS.BBT;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class BuildFurnitureCategoryFilter : MonoBehaviour
	{
		[Serializable]
		private struct FilterInfluenceCategoryButtonElement
		{
			public Sprite _icon;

			public E_OrderSort _tag;
		}

		private HorizontalLayoutGroup _horizonalLayout;

		private CanvasGroupController _canvasGroupController;

		private CanvasGroupMove _canvasGroupMove;

		private bool _onShow;

		private TMP_Text _toggleText;

		private ToggleGroup _toggleGroup;

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private float _hiddenYOffset;

		[SerializeField]
		private FilterButton _filterButtonPrefab;

		[SerializeField]
		private FilterInfluenceCategoryButtonElement[] _filterButtonsElemnts;

		[SerializeField]
		private Toggle _openPanelToggle;

		[SerializeField]
		private FurnitureShopPopulator _populator;

		private void Start()
		{
			_horizonalLayout = GetComponent<HorizontalLayoutGroup>();
			_toggleGroup = GetComponent<ToggleGroup>();
			for (int i = 0; i < _filterButtonsElemnts.Length; i++)
			{
				FilterButton filterButton = UnityEngine.Object.Instantiate(_filterButtonPrefab, base.transform);
				filterButton.SetButtoninfo(_filterButtonsElemnts[i]._icon, "", (int)_filterButtonsElemnts[i]._tag);
				filterButton.OnToggleChanged = SetFilter;
				filterButton.SetToggleGroup(_toggleGroup);
			}
		}

		private void SetFilter(bool p_value, int p_tag)
		{
			if (p_value)
			{
				_populator.ReorderBy((E_OrderSort)p_tag);
			}
		}
	}
}
