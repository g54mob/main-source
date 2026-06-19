using System;
using I2.Loc;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ExtraContentMenuItem : MonoBehaviour
	{
		[SerializeField]
		private Image _promotionalImage;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Localize _dlcName;

		[SerializeField]
		private Localize _dlcDescription;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private Localize _buttonText;

		[SerializeField]
		private LocalisedString _defaultButtonString;

		[SerializeField]
		private GameObject _installedPanel;

		[SerializeField]
		private GameObject _notInstalledPanel;

		[SerializeField]
		private GameObject _storeButtonPanel;

		public Action<DLCItemDefinition> OnPurchasePressed;

		private DLCItemDefinition _dlcItemDefinition;

		public void Setup(DLCItemDefinition dlcItemDefinition)
		{
			_dlcItemDefinition = dlcItemDefinition;
			_dlcName.SetTerm(dlcItemDefinition.Name.Term);
			_icon.overrideSprite = dlcItemDefinition.Icon;
			_promotionalImage.overrideSprite = dlcItemDefinition.PromotionImage;
			Refresh();
		}

		private void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		private void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnButtonPressed);
		}

		public void Refresh()
		{
			bool flag = DLCUtils.IsDLCOwned(_dlcItemDefinition);
			bool flag2 = DLCUtils.IsDLCInstalled(_dlcItemDefinition);
			GameObjectUtils.SetActive(_storeButtonPanel, !flag);
			GameObjectUtils.SetActive(_notInstalledPanel, flag && !flag2);
			GameObjectUtils.SetActive(_installedPanel, flag && flag2);
			GameObjectUtils.SetActive(_icon.gameObject, _dlcItemDefinition.Icon);
			_dlcDescription.SetTerm(flag2 ? _dlcItemDefinition.InstalledDescription.Term : _dlcItemDefinition.Description.Term);
			_buttonText.SetTerm((!_dlcItemDefinition.OverrideButtonText.IsNull()) ? _dlcItemDefinition.OverrideButtonText.Term : _defaultButtonString.Term);
		}

		private void OnButtonPressed()
		{
			OnPurchasePressed.InvokeSafe(_dlcItemDefinition);
		}
	}
}
