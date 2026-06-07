using Data.FactoryFloor.Resources;
using Events;
using Events.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class ResourceInfoPanelView : InfoPanelView
	{
		[SerializeField]
		private ResourceOriginsDatabase _resourceOriginsDatabase;

		[SerializeField]
		private ShowResourceInfoPanelEvent _showInfoPanelEvent;

		[SerializeField]
		private BaseEvent _hideInfoPanelEvent;

		[SerializeField]
		private TextMeshProUGUI _title;

		[SerializeField]
		private TextMeshProUGUI _sourceText;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private GameObject _content;

		[SerializeField]
		private GameObject _spacing;

		private ResourceInfoPanelDto _resourceInfoPanelDto;

		private bool _hasAmountInfo;

		private string _currentTitleText;

		protected override void Awake()
		{
			base.gameObject.SetActive(value: false);
			_showInfoPanelEvent.Register(base.Show);
			_hideInfoPanelEvent.Register(Hide);
		}

		protected override void OnDestroy()
		{
			_showInfoPanelEvent.UnRegister(base.Show);
			_hideInfoPanelEvent.UnRegister(Hide);
		}

		protected override void SetContent(InfoPanelDto dto)
		{
			_resourceInfoPanelDto = dto as ResourceInfoPanelDto;
			if (_resourceInfoPanelDto.IsShapeData)
			{
				_content.SetActive(value: false);
				_spacing.SetActive(value: false);
				_title.color = Color.white;
				_title.SetText("0");
			}
			else
			{
				_content.SetActive(value: true);
				_spacing.SetActive(value: true);
				ResourceOriginInfo resourceOriginInfo = _resourceOriginsDatabase.GetResourceOriginInfo(_resourceInfoPanelDto.ResourceData);
				if (resourceOriginInfo != null && !_resourceInfoPanelDto.HideOrigin)
				{
					_currentTitleText = LocalizationUtility.GetLocalizedText(resourceOriginInfo.Name);
					_title.color = resourceOriginInfo.Color;
					_image.sprite = resourceOriginInfo.Origins[0].ImageSprite;
					switch (resourceOriginInfo.Origins[0].Type)
					{
					case ResourceOriginType.Natural:
						_sourceText.SetText(" ");
						break;
					case ResourceOriginType.CreatedInBuilding:
						_sourceText.SetText(LocalizationUtility.GetLocalizedText("BuildingPanel.ResourceCraftedIn"));
						break;
					case ResourceOriginType.CreatedFromRecipe:
						_sourceText.SetText(LocalizationUtility.GetLocalizedText("BuildingPanel.ResourceCraftedIn"));
						break;
					}
					_text.SetText(LocalizationUtility.GetLocalizedText(resourceOriginInfo.Origins[0].OriginName));
				}
				else if (_resourceInfoPanelDto.HideOrigin)
				{
					_currentTitleText = string.Empty;
					_sourceText.SetText(string.Empty);
					_text.SetText(LocalizationUtility.GetLocalizedText(_resourceInfoPanelDto.ResourceData.NameLocaKey));
					_image.sprite = _resourceInfoPanelDto.ResourceData.Sprite;
				}
				else
				{
					_currentTitleText = LocalizationUtility.GetLocalizedText(_resourceInfoPanelDto.ResourceData.NameLocaKey);
					_sourceText.SetText(string.Empty);
					_text.SetText(LocalizationUtility.GetLocalizedText("BuildingPanel.ResourceNotCrafted"));
					_image.sprite = _resourceInfoPanelDto.ResourceData.Sprite;
				}
				_title.SetText(_currentTitleText);
			}
			_hasAmountInfo = _resourceInfoPanelDto.ResourceAmountInfo != null;
			if (_hasAmountInfo)
			{
				_resourceInfoPanelDto.ResourceAmountInfo.ValueChanged += UpdateAmountInfo;
				UpdateAmountInfo(_resourceInfoPanelDto.ResourceAmountInfo.Amount, _resourceInfoPanelDto.ResourceAmountInfo.TotalAmount);
			}
		}

		protected override void Hide()
		{
			if (_hasAmountInfo)
			{
				_resourceInfoPanelDto.ResourceAmountInfo.ValueChanged -= UpdateAmountInfo;
			}
			base.Hide();
		}

		private void UpdateAmountInfo(int amount, int totalAmount)
		{
			if (_resourceInfoPanelDto.IsShapeData)
			{
				_title.SetText($"<style=Size80><color=#ffffff>{amount}/{totalAmount}</color></style>");
			}
			else
			{
				_title.SetText($"{_currentTitleText} <style=Size80><color=#ffffff>({amount}/{totalAmount})</color></style>");
			}
		}
	}
}
