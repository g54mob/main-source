using TH20;
using UnityEngine;

public class OnlineFeatureObjectEnabler : MonoBehaviour
{
	[SerializeField]
	private PlatformFeatureSupport.FeatureType _enableWithSupportedFeature;

	[SerializeField]
	private GameObject _objectToControl;

	private void OnEnable()
	{
		bool flag = PlatformFeatureSupport.IsFeatureSupported(_enableWithSupportedFeature);
		PlatformFeatureSupport.FeatureType enableWithSupportedFeature = _enableWithSupportedFeature;
		if ((uint)(enableWithSupportedFeature - 1) <= 1u || enableWithSupportedFeature == PlatformFeatureSupport.FeatureType.OnlineChallenges)
		{
			flag &= !OnlineManager.MultiplayerBlocked;
		}
		GameObjectUtils.SetActive(_objectToControl, flag);
	}
}
