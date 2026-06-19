using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class HospitalPin : UIMapPin
	{
		[SerializeField]
		private TMP_Text _foundationNameText;

		[SerializeField]
		private Image _foundationIconImage;

		private bool _isPlayerHospital;

		private AmbulanceDepartment _ambulanceDepartment;

		public bool IsPlayerHospital => _isPlayerHospital;

		public void Setup(EmergencyDispatchMenu emergencyDispatchMenu, EmergencyDispatchMap dispatchMap, AmbulanceDepartment ambulanceDepartment)
		{
			ResetPin();
			_ambulanceDepartment = ambulanceDepartment;
			_isPlayerHospital = _ambulanceDepartment is PlayerAmbulanceDepartment;
			_mapLayer = MapLayerParent.EMapLayer.StaticPins;
			FoundationStyleDefinition foundationStyle = _ambulanceDepartment.FoundationStyle;
			if (foundationStyle != null)
			{
				_foundationNameText.color = foundationStyle.GlobalStyleProperties.FoundationTextColour;
			}
			Setup(dispatchMap, ambulanceDepartment.BaseConfig.Location);
			SetHospitalInformation();
			LocalizationManager.OnLocalizeEvent += OnLocalize;
		}

		protected override void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			base.OnDestroy();
		}

		private void OnLocalize()
		{
			SetHospitalInformation();
		}

		private void SetHospitalInformation()
		{
			if (_ambulanceDepartment != null)
			{
				_foundationNameText.text = _ambulanceDepartment.FoundationName;
				_foundationIconImage.overrideSprite = _ambulanceDepartment.FoundationIcon;
				_foundationNameText.font = ResourceManager.pInstance.GetAsset<TMP_FontAsset>(ScriptLocalization.Menu_Dispatch.HospitalFont);
				_foundationNameText.fontSharedMaterial = ResourceManager.pInstance.GetAsset<Material>(ScriptLocalization.Menu_Dispatch.HospitalOutlineMaterial);
			}
		}
	}
}
