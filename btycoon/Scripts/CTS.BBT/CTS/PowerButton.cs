using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class PowerButton : MonoBehaviour
	{
		private Button _button;

		private FeatureIcon icon;

		private void Awake()
		{
			_button = GetComponent<Button>();
			icon = GetComponentInChildren<FeatureIcon>();
			_button.interactable = false;
		}

		public void SetIcon(PowerFeatureElement p_linkedPower)
		{
			base.gameObject.SetActive(value: true);
			icon.SetImageAndDescription(p_linkedPower.featureIcon_1, p_linkedPower.FeatureDescription, p_linkedPower.FeatureTitle);
		}
	}
}
