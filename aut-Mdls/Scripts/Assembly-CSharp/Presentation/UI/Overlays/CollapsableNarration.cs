using System;
using Events.UI.Overlays;
using Presentation.UI.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Overlays
{
	public class CollapsableNarration : MonoBehaviour
	{
		[SerializeField]
		private NarrationDialog _narrationDialog;

		[SerializeField]
		private RectTransform _narratorImage;

		[SerializeField]
		private float _narratorCollapsedHeight;

		[SerializeField]
		private float _narratorExtendedHeight;

		[SerializeField]
		private GameObject _expandedContent;

		[SerializeField]
		private GameObject _collapsedContent;

		[SerializeField]
		private IconFlipper _collapseButton;

		[SerializeField]
		private TextMeshProUGUI _collapsedTitleField;

		[SerializeField]
		private TextMeshProUGUI _collapsedTextField;

		[SerializeField]
		private TextMeshProUGUI _contentButtonText;

		[SerializeField]
		private Button _collapsedContentButton;

		[SerializeField]
		private TextMeshProUGUI _collapsedContentButtonText;

		private NarrationDto _dto;

		public event Action<bool> OnCollapseStateChanged;

		private void Awake()
		{
			_narrationDialog.OnCurrentNarrationDtoUpdate += OnCurrentNarrationDtoUpdate;
		}

		private void OnDestroy()
		{
			_narrationDialog.OnCurrentNarrationDtoUpdate -= OnCurrentNarrationDtoUpdate;
		}

		private void OnEnable()
		{
			_collapsedContent.SetActive(value: false);
			_narrationDialog.OnNarrationStartShow += OnNarrationStart;
			_narrationDialog.OnNarrationHide += OnNarrationHide;
			_collapseButton.FlippedStateChanged += SetCollapsedState;
			_collapsedContentButton.onClick.AddListener(_narrationDialog.OnContentButtonClick);
		}

		private void OnDisable()
		{
			_narrationDialog.OnNarrationStartShow -= OnNarrationStart;
			_narrationDialog.OnNarrationHide -= OnNarrationHide;
			_collapseButton.FlippedStateChanged -= SetCollapsedState;
			_collapsedContentButton.onClick.RemoveListener(_narrationDialog.OnContentButtonClick);
		}

		private void OnNarrationStart(NarrationDto dto)
		{
			_dto = dto;
			_collapseButton.IsFlipped = false;
			_collapsedContentButton.gameObject.SetActive(_dto.HasButton);
			SetCollapsedState(activated: false);
			UpdateCollapsedText();
		}

		private void OnCurrentNarrationDtoUpdate()
		{
			if (_dto != null)
			{
				UpdateCollapsedText();
			}
		}

		private void UpdateCollapsedText()
		{
			_collapsedTitleField.SetText(LocalizationUtility.GetLocalizedText(_dto.Title));
			_collapsedTextField.SetText(LocalizationUtility.GetLocalizedText(_dto.Text));
			if (_dto.HasButton)
			{
				_collapsedContentButtonText.SetText(LocalizationUtility.GetLocalizedText(_dto.ButtonText));
			}
			float num = _collapsedTitleField.preferredWidth + 10f;
			float num2 = (_dto.HasButton ? (_collapsedContentButtonText.preferredWidth + 56f) : 0f);
			_collapsedTextField.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, _collapsedTitleField.rectTransform.anchoredPosition.x + num, 1200f - num - num2);
		}

		private void OnNarrationHide()
		{
			_dto = null;
		}

		private void SetCollapsedState(bool activated)
		{
			_expandedContent.SetActive(!activated);
			_collapsedContent.SetActive(activated);
			_narratorImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, activated ? _narratorCollapsedHeight : _narratorExtendedHeight);
			this.OnCollapseStateChanged?.Invoke(activated);
		}
	}
}
