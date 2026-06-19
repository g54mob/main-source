using TH20;
using UnityEngine;

[CreateAssetMenu(menuName = "TH20/Configs/Online Feature Support Config", order = 1115)]
public class PlatformFeatureSupport : ScriptableObject
{
	public enum FeatureType
	{
		None = 0,
		Superbug = 1,
		CollaborativeProject = 2,
		UserGeneratedContent = 3,
		Workshop = 4,
		OnlineChallenges = 5,
		HospitalPass = 6,
		OnlineChallengeScreenshots = 7,
		CampusPreorderPromoItems = 8,
		CampusPreorderPromoNoItems = 9,
		AmazonPrimeItems = 10,
		RoomTemplates = 11,
		DLCPurchase = 12
	}

	[SerializeField]
	private FeatureType[] _steamSupportedFeaturesType;

	[SerializeField]
	private FeatureType[] _msStoreSupportedFeaturesType;

	[SerializeField]
	private FeatureType[] _eaOriginSupportedFeaturesType;

	[SerializeField]
	private FeatureType[] _amazonPrimeSupportedFeaturesType;

	private static FeatureType[] s_steamSupportedFeaturesType;

	private static FeatureType[] s_msStoreSupportedFeaturesType;

	private static FeatureType[] s_eaOriginSupportedFeaturesType;

	private static FeatureType[] s_amazonPrimeSupportedFeaturesType;

	private static bool s_initialised;

	private void Awake()
	{
		Initialise();
	}

	private void Initialise()
	{
		if (!s_initialised)
		{
			s_steamSupportedFeaturesType = _steamSupportedFeaturesType;
			s_msStoreSupportedFeaturesType = _msStoreSupportedFeaturesType;
			s_eaOriginSupportedFeaturesType = _eaOriginSupportedFeaturesType;
			s_amazonPrimeSupportedFeaturesType = _amazonPrimeSupportedFeaturesType;
			s_initialised = true;
		}
	}

	public static bool IsFeatureSupported(FeatureType feature, CloudDataManager cloudDataManager = null)
	{
		switch (feature)
		{
		case FeatureType.None:
			return true;
		case FeatureType.AmazonPrimeItems:
			if (cloudDataManager?.DownloadedCloudData != null)
			{
				return cloudDataManager.DownloadedCloudData.PrimePromotionAvailableForSignUp;
			}
			return false;
		default:
			return InternalIsFeatureSupported(feature, s_steamSupportedFeaturesType);
		}
	}

	private static bool InternalIsFeatureSupported(FeatureType feature, FeatureType[] supportedFeaturesType)
	{
		for (int i = 0; i < supportedFeaturesType.Length; i++)
		{
			if (supportedFeaturesType[i] == feature)
			{
				return true;
			}
		}
		return false;
	}
}
