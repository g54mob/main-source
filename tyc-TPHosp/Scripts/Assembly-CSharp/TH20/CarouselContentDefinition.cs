using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Definitions/Carousel Content Definition", order = 1114)]
	public class CarouselContentDefinition : ScriptableObjectWithID
	{
		[HideInInspector]
		public enum Platform
		{
			STEAM = 0,
			MSSTORE_ORIGIN = 1,
			AMAZON_PRIME = 2
		}

		[FormerlySerializedAs("OnlineFeatureType")]
		public PlatformFeatureSupport.FeatureType m_featureType;

		public List<Sprite> PromotionImages;

		public string TitleTerm;

		public string DescriptionTerm;

		public string ClickUrl;

		[FormerlySerializedAs("RequiresSteam")]
		public bool RequiresOnlineAccountLogin;

		public uint StartTime;

		public uint ExpiryTime;

		public List<Platform> OnlyShowOn;
	}
}
