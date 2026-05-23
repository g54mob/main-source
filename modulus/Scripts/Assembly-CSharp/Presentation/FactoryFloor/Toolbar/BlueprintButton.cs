using System;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Logic.Factory.Blueprint;
using Presentation.UI;
using TMPro;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BlueprintButton : BaseOperatorBarButton
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private GameObject _plus;

		[SerializeField]
		private BlueprintBarInfoContent _barInfoContent;

		[SerializeField]
		private TextInfoPanelContent _nameInfoPanelContent;

		[SerializeField]
		private float _alphaUnused = 0.1f;

		[SerializeField]
		private float _alphaUsed = 1f;

		[SerializeField]
		private Color _backgroundUnusedColor;

		[SerializeField]
		private StringVariableSO _currentFactoryBlueprintWorkingPath;

		[SerializeField]
		private BaseEvent _selectNewBlueprintToolEvent;

		[SerializeField]
		private BlueprintDtoEvent _placeBlueprintToolEvent;

		[SerializeField]
		private IntVariableSO _lastSelectedBlueprintSlot;

		public Action<BlueprintButton> OnSelected = delegate
		{
		};

		private string _slotChar;

		private int _index;

		private bool _isUsed;

		private (BlueprintDto, string) _blueprint;

		public bool IsUsed => _isUsed;

		public BlueprintDto Blueprint => _blueprint.Item1;

		protected override void Initialized()
		{
			_button.onClick.AddListener(ButtonPressed);
		}

		protected override void Show()
		{
			if (!_isSelected)
			{
				base.Show();
			}
			_isSelected = true;
			OnSelected(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_button.onClick.RemoveListener(ButtonPressed);
		}

		public void Setup(int index, string slotChar)
		{
			_index = index;
			_slotChar = slotChar;
			_text.text = slotChar;
			_barInfoContent.enabled = false;
			_nameInfoPanelContent.enabled = false;
		}

		public void UseForBlueprint((BlueprintDto, string) blueprint)
		{
			_blueprint = blueprint;
			BlueprintUIData barInfo = new BlueprintUIData
			{
				BlueprintName = blueprint.Item1.BlueprintName,
				FileName = blueprint.Item2,
				SlotChar = _slotChar,
				Color = blueprint.Item1.Color,
				Index = blueprint.Item1.Index
			};
			_barInfoContent.SetBarInfo(barInfo);
			_nameInfoPanelContent.UpdateContent(barInfo.BlueprintName);
			SetUsedState(isUsed: true);
		}

		public void SetUsedState(bool isUsed)
		{
			_isUsed = isUsed;
			_plus.SetActive(!isUsed);
			_canvasGroup.alpha = (isUsed ? _alphaUsed : _alphaUnused);
			_coloredPanel.color = (_isUsed ? _blueprint.Item1.Color : _backgroundUnusedColor);
			_barInfoContent.enabled = isUsed;
			_nameInfoPanelContent.enabled = isUsed;
		}

		private void ButtonPressed()
		{
			if (_isUsed)
			{
				_placeBlueprintToolEvent.Fire(_blueprint.Item1);
				return;
			}
			_lastSelectedBlueprintSlot.SetValue(_index);
			_selectNewBlueprintToolEvent?.Fire();
		}
	}
}
