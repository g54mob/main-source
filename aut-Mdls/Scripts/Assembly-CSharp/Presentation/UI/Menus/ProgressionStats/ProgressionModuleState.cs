using Data.Buildings;
using Data.Variables;
using Presentation.FactoryFloor.Toolbar;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus.ProgressionStats
{
	public class ProgressionModuleState : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _nameText;

		[SerializeField]
		private GameObject _disabled;

		[SerializeField]
		private Image _border;

		[SerializeField]
		private Image _background;

		[SerializeField]
		private ModuleButton _moduleButton;

		[SerializeField]
		private Button _moduleButtonButton;

		[SerializeField]
		private Image _moduleImage;

		[SerializeField]
		private Image _moduleBackground;

		[SerializeField]
		private GameObject _check;

		[SerializeField]
		private Color _borderColorSuccess;

		[SerializeField]
		private Color _borderColorFailed;

		[SerializeField]
		private Color _backgroundColorSuccess;

		[SerializeField]
		private Color _backgroundColorFailed;

		[SerializeField]
		private Color _moduleBgColorFailed;

		[SerializeField]
		private Color _moduleBgColorSuccess;

		[SerializeField]
		private Color _moduleImageColorFailed;

		[SerializeField]
		private Color _moduleImageColorSuccess;

		private string _nameLocaKey;

		private int _moduleNumber;

		private BoolVariableSO _showCondition;

		private bool _isDisabled;

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void OnEnable()
		{
			if (_showCondition != null)
			{
				_showCondition.ValueChanged += CheckIfShowConditionIsTrue;
				SetStateDisabled(!_showCondition.Value);
			}
		}

		private void OnDisable()
		{
			if (_showCondition != null)
			{
				_showCondition.ValueChanged -= CheckIfShowConditionIsTrue;
			}
		}

		private void OnLanguageUpdate()
		{
			SetText();
		}

		public void Build(BuildingObjectData buildingObjectData, int index, Texture2D iconTexture)
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_nameLocaKey = buildingObjectData.NameLocKey;
			_moduleNumber = index + 1;
			SetText();
			_moduleButton.SetModuleIcon(iconTexture, buildingObjectData.GetModuleViewerData, index);
			_showCondition = buildingObjectData.UIData.ShowCondition;
			if (_showCondition != null)
			{
				SetStateDisabled(!_showCondition.Value);
			}
			else
			{
				SetStateDisabled(disabled: false);
			}
		}

		private void CheckIfShowConditionIsTrue(bool value)
		{
			SetStateDisabled(!_showCondition.Value);
		}

		private void SetText()
		{
			_nameText.SetText($"{LocalizationUtility.GetLocalizedText(_nameLocaKey)} {_moduleNumber}");
		}

		public void SetStateDefault()
		{
			_isDisabled = false;
			SetStyle(completed: false);
		}

		public void SetStateCompleted()
		{
			SetStyle(completed: true);
		}

		private void SetStateDisabled(bool disabled)
		{
			_isDisabled = disabled;
			_disabled.SetActive(disabled);
			_moduleImage.gameObject.SetActive(!disabled);
			_nameText.gameObject.SetActive(!disabled);
			_moduleButtonButton.interactable = !disabled;
			_moduleButtonButton.enabled = !disabled;
		}

		private void SetStyle(bool completed)
		{
			_border.color = (completed ? _borderColorSuccess : _borderColorFailed);
			_background.color = (completed ? _backgroundColorSuccess : _backgroundColorFailed);
			_moduleBackground.color = (completed ? _moduleBgColorSuccess : _moduleBgColorFailed);
			_moduleImage.color = (completed ? _moduleImageColorSuccess : _moduleImageColorFailed);
			_check.SetActive(completed);
		}
	}
}
