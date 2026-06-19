using UnityEngine;

public class PlatformObjectDisabler : MonoBehaviour
{
	[SerializeField]
	private PlatformFlags _enabledPlatforms;

	[SerializeField]
	private StorefrontFlags _enabledStorefronts;

	private void Awake()
	{
		base.gameObject.SetActive(_enabledPlatforms.MatchesCurrentPlatform() && _enabledStorefronts.MatchesCurrentStorefront());
	}
}
