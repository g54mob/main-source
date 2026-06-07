using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class LicenseTemplatePaper : TemplatePaper
	{
		public LicenseTemplatePaperData data;

		public TextMeshProUGUI licenseName;

		public TextMeshProUGUI description;

		public Image backgroundColor;

		public TextMeshProUGUI cost;

		public TextMeshProUGUI insuranceParticipation;

		public TextMeshProUGUI timeBonusDecrease;

		public Image licenseIcon;

		public Image requiredLicenseIcon;

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for LicenseTemplatePaper, but data was not set!", this);
				return;
			}
			licenseName.text = data.licenseName;
			description.text = data.licenseDescription;
			backgroundColor.color = data.licenseColor;
			cost.text = data.cost;
			insuranceParticipation.text = data.insuranceParticipation;
			timeBonusDecrease.text = data.timeBonusDecrease;
			licenseIcon.sprite = data.iconSprite;
			if (data.requiredLicenseIconSprite == null)
			{
				requiredLicenseIcon.gameObject.SetActive(value: false);
				return;
			}
			requiredLicenseIcon.gameObject.SetActive(value: true);
			requiredLicenseIcon.sprite = data.requiredLicenseIconSprite;
		}

		public override void CleanUp()
		{
		}
	}
}
