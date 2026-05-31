using System;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Serializable]
	public struct PowerFeatureElement
	{
		[field: SerializeField]
		public WorkerPowerFeature.e_PowerFeatures PowerFeatureID { get; private set; }

		[field: SerializeField]
		public Sprite featureIcon_1 { get; private set; }

		[field: SerializeField]
		public LocalizedString FeatureTitle { get; private set; }

		[field: SerializeField]
		public LocalizedString FeatureDescription { get; private set; }

		[field: SerializeField]
		public LocalizedString FeaturesToolsTipsDescription { get; private set; }
	}
}
