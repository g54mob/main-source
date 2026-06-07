using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class WorkerPowerPanel : AbsAgentPanel
	{
		[SerializeField]
		private Image _powerButton;

		[SerializeField]
		private TMP_Text _powerName;

		[SerializeField]
		private TMP_Text _powerDesc;

		[SerializeField]
		private ToolTipsShower _shower;

		[SerializeField]
		private bool _debug;

		private PowerFeatureElement? _currentPower;

		public override void ClearAgentInfo()
		{
			_powerButton.sprite = null;
			_currentPower = null;
		}

		public override void SetAgentInfo()
		{
			Debug.Log("SetAgentInfo: ");
			if (base._agent is Worker)
			{
				SetPowerFeatures();
			}
		}

		private void SetPowerFeatures()
		{
			WorkerPowerFeature.e_PowerFeatures power = ((Worker)base._agent).PowerFeatures.GetPower();
			ClearAgentInfo();
			if (power == WorkerPowerFeature.e_PowerFeatures.None)
			{
				Debug.LogError("WorkerPower Have No power!");
				return;
			}
			PowerFeatureElement? element = WorkerPowerFeature.PowerFeatureTable.GetElement(power);
			if (element.HasValue)
			{
				_currentPower = element;
				_powerButton.sprite = _currentPower.Value.featureIcon_1;
				LocalizationChanged();
			}
		}

		protected override void LocalizationChanged()
		{
			if (_currentPower.HasValue)
			{
				_powerName.text = _currentPower.Value.FeatureTitle.GetLocalizedStringSafe();
				_powerDesc.text = _currentPower.Value.FeatureDescription.GetLocalizedStringSafe();
				_shower.SetTootipsInfo(_currentPower.Value.FeatureTitle, _currentPower.Value.FeaturesToolsTipsDescription);
			}
		}
	}
}
