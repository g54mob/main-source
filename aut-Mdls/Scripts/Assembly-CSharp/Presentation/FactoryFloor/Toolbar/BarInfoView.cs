using Data.Buildings;
using Data.Operator;
using Events;
using Events.FactoryFloor;
using Events.UI;
using Events.UI.BarInfo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BarInfoView : BaseBarInfoView
	{
		[SerializeField]
		private bool _isVerticallyOriented;

		[SerializeField]
		private TextMeshProUGUI _title;

		[SerializeField]
		private Image _img;

		[SerializeField]
		private GameObject _speedInfoPanel;

		[SerializeField]
		private SpeedInfo _speedInfo;

		[Space]
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private ShowBarInfoEvent _showBarInfoEvent;

		[Space]
		[SerializeField]
		private BluePrintEvent _initPreviewEvent;

		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		private BarInfoDto? _previewDto;

		private BarInfoDto _barInfoDto;

		protected override void Awake()
		{
			base.Awake();
			_showBarInfoEvent.Register(Show);
			if (!_isVerticallyOriented)
			{
				_initPreviewEvent.Register(OnStartPreview);
				_startPreviewEvent.Register(OnStartPreview);
				_stopPreviewEvent.Register(OnStopPreview);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_showBarInfoEvent.UnRegister(Show);
			if (!_isVerticallyOriented)
			{
				_initPreviewEvent.UnRegister(OnStartPreview);
				_startPreviewEvent.UnRegister(OnStartPreview);
				_stopPreviewEvent.UnRegister(OnStopPreview);
			}
		}

		private void OnStartPreview(BlueprintViewEventDto dto)
		{
			if (dto.Blueprint.BlueprintViewElementDtos.Count <= 1 && _factoryObjectDatabase.TryGetObjectDataWithId(dto.Blueprint.BlueprintViewElementDtos[0].ObjectId, out var factoryObjectData) && !(factoryObjectData.UIData == null) && !(factoryObjectData is BuildingObjectData))
			{
				_previewDto = new BarInfoDto(false, factoryObjectData.UIData, null);
				if (!base.gameObject.activeSelf)
				{
					PopulateWithUIData(_previewDto.Value);
				}
			}
		}

		private void OnStopPreview()
		{
			_previewDto = null;
			Hide();
		}

		public void Show(BarInfoDto barinfoDto)
		{
			if (_isVerticallyOriented == barinfoDto.Vertical)
			{
				if (_isVerticallyOriented && barinfoDto.ReferenceButton != null)
				{
					RectTransform obj = base.transform as RectTransform;
					obj.anchoredPosition = new Vector2(obj.anchoredPosition.x, barinfoDto.ReferenceButton.anchoredPosition.y - barinfoDto.ReferenceButton.sizeDelta.y / 2f);
				}
				PopulateWithUIData(barinfoDto);
			}
		}

		private void PopulateWithUIData(BarInfoDto barInfo)
		{
			_barInfoDto = barInfo;
			if (_img != null)
			{
				_img.sprite = ((barInfo.ToolImage != null) ? barInfo.ToolImage : null);
			}
			PopulateSpeedInfo();
			UpdateLocalization();
			base.gameObject.SetActive(value: true);
		}

		private void PopulateSpeedInfo()
		{
			if (!(_speedInfo == null) && !(_barInfoDto.FactoryObjectUIData == null))
			{
				FactoryObjectUIData factoryObjectUIData = _barInfoDto.FactoryObjectUIData;
				if (factoryObjectUIData.HideInput && factoryObjectUIData.HideOutput)
				{
					_speedInfoPanel.SetActive(value: false);
					return;
				}
				bool active = factoryObjectUIData.FactoryObject != null && (factoryObjectUIData.FactoryObject.InputPositionsData.Count > 0 || factoryObjectUIData.FactoryObject.OutputPositions.Count > 0);
				_speedInfoPanel.SetActive(active);
				_speedInfo.SetSpeedsFromUIData(factoryObjectUIData);
			}
		}

		protected override void UpdateLocalization()
		{
			string text = "";
			string text2 = "";
			if (!string.IsNullOrEmpty(_barInfoDto.TitleLocKey))
			{
				text2 = LocalizationUtility.GetLocalizedText(_barInfoDto.TitleLocKey);
			}
			if (!string.IsNullOrEmpty(_barInfoDto.TextLocKey))
			{
				string text3 = LocalizationUtility.GetLocalizedText(_barInfoDto.TextLocKey);
				if (!_barInfoDto.TextArgs.IsNullOrEmpty())
				{
					string format = text3;
					object[] textArgs = _barInfoDto.TextArgs;
					text3 = string.Format(format, textArgs);
				}
				text = text3;
			}
			_title.SetText(text2);
			_text.SetText(text);
		}

		public override void Hide()
		{
			if (_previewDto.HasValue)
			{
				PopulateWithUIData(_previewDto.Value);
			}
			else
			{
				base.Hide();
			}
		}
	}
}
