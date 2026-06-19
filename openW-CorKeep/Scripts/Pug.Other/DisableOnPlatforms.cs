using UnityEngine;

public class DisableOnPlatforms : MonoBehaviour
{
	public PlatformFlags disableOnPlatforms;

	public StorefrontFlags disableOnStorefronts;

	private void Start()
	{
		if (PlatformStorefrontUtility.MatchesCurrent(disableOnPlatforms, disableOnStorefronts))
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
