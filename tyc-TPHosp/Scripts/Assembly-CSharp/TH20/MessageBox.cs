using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class MessageBox : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _bodyText;

		[SerializeField]
		private TextMeshProUGUI _acknowledgeButtonText;

		[SerializeField]
		private TextMeshProUGUI _acknowledgeButtonText2;

		[SerializeField]
		private TextMeshProUGUI _cancelButtonText;

		[SerializeField]
		private Button _acknowledgeButton;

		[SerializeField]
		private Button _acknowledgeButton2;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private Image _bgPanelImage;

		[SerializeField]
		private Material _bgPanelMaterialFrosted;

		[SerializeField]
		private Material _bgPanelMaterialSolid;

		[SerializeField]
		private Color _bgPanelColourFrosted;

		[SerializeField]
		private Color _bgPanelColourSolid;

		private Action _acknowledgeAction;

		private Action _acknowledgeAction2;

		private Action _cancelAction;

		private int _lastCloseFrame;

		private bool _useNonFrostedPanelData;

		private bool _option1ButtonsAutoHide;

		private bool _option2ButtonsAutoHide;

		private const int cNumClosingFrames = 1;

		public bool IsVisibleOrClosing
		{
			get
			{
				if (!IsVisible)
				{
					return Time.frameCount - _lastCloseFrame <= 1;
				}
				return true;
			}
		}

		public bool IsVisible => base.gameObject.activeInHierarchy;

		public string TitleText => _titleText.text;

		public string BodyText => _bodyText.text;

		public void Show(string titleText, string bodyText, string acknowledgeButtonText, Action acknowledgeAction = null)
		{
			if (!base.gameObject.activeSelf)
			{
				SetupPanelData();
				_titleText.text = titleText;
				_bodyText.text = bodyText;
				_acknowledgeButtonText.text = acknowledgeButtonText;
				_option1ButtonsAutoHide = true;
				_acknowledgeAction = acknowledgeAction;
				GameObjectUtils.SetActive(_acknowledgeButton2.gameObject, isActive: false);
				GameObjectUtils.SetActive(_cancelButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(base.gameObject, isActive: true);
				_acknowledgeButton.onClick.AddListener(AcknowledgeButtonPressed);
				_cancelButton.onClick.AddListener(CancelButtonPressed);
			}
		}

		public void ShowAsYesNo(string titleText, string bodyText, string acknowledgeButtonText, string cancelButtonText, Action acknowledgeAction = null, Action cancelAction = null, bool option1ButtonsAutoHide = true)
		{
			if (!base.gameObject.activeSelf)
			{
				SetupPanelData();
				_titleText.text = titleText;
				_bodyText.text = bodyText;
				_acknowledgeButtonText.text = acknowledgeButtonText;
				_cancelButtonText.text = cancelButtonText;
				_option1ButtonsAutoHide = option1ButtonsAutoHide;
				_acknowledgeAction = acknowledgeAction;
				_cancelAction = cancelAction;
				GameObjectUtils.SetActive(_acknowledgeButton2.gameObject, isActive: false);
				GameObjectUtils.SetActive(_cancelButton.gameObject, isActive: true);
				GameObjectUtils.SetActive(base.gameObject, isActive: true);
				_acknowledgeButton.onClick.AddListener(AcknowledgeButtonPressed);
				_cancelButton.onClick.AddListener(CancelButtonPressed);
			}
		}

		public void ShowAs2ChoiceAndCancel(string titleText, string bodyText, string button1Text, string button2Text, string cancelButtonText, Action button1Action = null, Action button2Action = null, Action cancelAction = null, bool option1ButtonsAutoHide = true, bool option2ButtonsAutoHide = true)
		{
			if (!base.gameObject.activeSelf)
			{
				SetupPanelData();
				_titleText.text = titleText;
				_bodyText.text = bodyText;
				_acknowledgeButtonText.text = button1Text;
				_acknowledgeButtonText2.text = button2Text;
				_cancelButtonText.text = cancelButtonText;
				_option1ButtonsAutoHide = option1ButtonsAutoHide;
				_option2ButtonsAutoHide = option2ButtonsAutoHide;
				_acknowledgeAction = button1Action;
				_acknowledgeAction2 = button2Action;
				_cancelAction = cancelAction;
				GameObjectUtils.SetActive(_acknowledgeButton2.gameObject, isActive: true);
				GameObjectUtils.SetActive(_cancelButton.gameObject, isActive: true);
				GameObjectUtils.SetActive(base.gameObject, isActive: true);
				_acknowledgeButton.onClick.AddListener(AcknowledgeButtonPressed);
				_acknowledgeButton2.onClick.AddListener(AcknowledgeButton2Pressed);
				_cancelButton.onClick.AddListener(CancelButtonPressed);
			}
		}

		public void Cancel()
		{
			if (IsVisible)
			{
				CancelButtonPressed();
			}
		}

		public void SetUseNonFrostedPanelData(bool bUseNonFrostedPanelData)
		{
			_useNonFrostedPanelData = bUseNonFrostedPanelData;
		}

		private void SetupPanelData()
		{
			if (_bgPanelImage != null)
			{
				if (_useNonFrostedPanelData)
				{
					_bgPanelImage.material = _bgPanelMaterialSolid;
					_bgPanelImage.color = _bgPanelColourSolid;
				}
				else
				{
					_bgPanelImage.material = _bgPanelMaterialFrosted;
					_bgPanelImage.color = _bgPanelColourFrosted;
				}
			}
		}

		private void AcknowledgeButtonPressed()
		{
			Action acknowledgeAction = _acknowledgeAction;
			if (_option1ButtonsAutoHide)
			{
				Hide();
			}
			acknowledgeAction?.Invoke();
		}

		private void AcknowledgeButton2Pressed()
		{
			Action acknowledgeAction = _acknowledgeAction2;
			if (_option2ButtonsAutoHide)
			{
				Hide();
			}
			acknowledgeAction?.Invoke();
		}

		private void CancelButtonPressed()
		{
			Action cancelAction = _cancelAction;
			Hide();
			cancelAction?.Invoke();
		}

		public void Hide()
		{
			SetUseNonFrostedPanelData(bUseNonFrostedPanelData: false);
			if (base.gameObject.activeSelf)
			{
				_acknowledgeAction = null;
				_acknowledgeAction2 = null;
				_cancelAction = null;
				_acknowledgeButton.onClick.RemoveListener(AcknowledgeButtonPressed);
				_acknowledgeButton2.onClick.RemoveListener(AcknowledgeButton2Pressed);
				_cancelButton.onClick.RemoveListener(CancelButtonPressed);
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				_lastCloseFrame = Time.frameCount;
			}
		}
	}
}
