using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class LicenseTemplatePaperData : TemplatePaperData
	{
		public string licenseName;

		public string licenseDescription;

		public Color licenseColor;

		public string cost;

		public string insuranceParticipation;

		public string timeBonusDecrease;

		public Sprite iconSprite;

		public Sprite requiredLicenseIconSprite;

		public LicenseTemplatePaperData(string licenseName, string licenseDescription, Color licenseColor, string cost, string insuranceParticipation, string timeBonusDecrease, Sprite iconSprite, Sprite requiredLicenseIconSprite)
		{
			this.licenseName = licenseName;
			this.licenseDescription = licenseDescription;
			this.licenseColor = licenseColor;
			this.cost = cost;
			this.insuranceParticipation = insuranceParticipation;
			this.timeBonusDecrease = timeBonusDecrease;
			this.iconSprite = iconSprite;
			this.requiredLicenseIconSprite = requiredLicenseIconSprite;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.LicensePage;
		}
	}
}
