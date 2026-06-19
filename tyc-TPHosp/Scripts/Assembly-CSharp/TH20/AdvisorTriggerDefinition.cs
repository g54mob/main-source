using UnityEngine;

namespace TH20
{
	public abstract class AdvisorTriggerDefinition
	{
		[Header("Cooldown")]
		public float CooldownSeconds;

		[Tooltip("The Required Supported Online Feature for this trigger to fire")]
		public PlatformFeatureSupport.FeatureType FeatureRequired;

		[Header("Message")]
		public LocalisedString MessageLocalised;

		public Sprite MessageIcon;

		public float MessageLifetime;

		public AdvisorDisplayType DisplayType;

		public abstract AdvisorTrigger CreateAdvisorTrigger();
	}
}
