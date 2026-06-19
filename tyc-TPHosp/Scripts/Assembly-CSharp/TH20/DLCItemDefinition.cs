using UnityEngine;

namespace TH20
{
	public class DLCItemDefinition
	{
		public LocalisedString Name;

		public LocalisedString Description;

		public LocalisedString InstalledDescription;

		public Sprite PromotionImage;

		public Sprite Icon;

		public Sprite NotOwnedIcon;

		public uint AppID;

		public bool IsPurchasable;

		public string OverrideUrl;

		public LocalisedString OverrideButtonText;

		public bool IsHospitalPassSignup;

		public bool ShowInCarousel;

		public LocalisedString HowToFindText;
	}
}
