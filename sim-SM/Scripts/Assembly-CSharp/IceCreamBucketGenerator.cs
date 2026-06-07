using UnityEngine;

public class IceCreamBucketGenerator : NoktaSingleton<IceCreamBucketGenerator>
{
	[SerializeField]
	private IceCreamBucket m_BucketPrefab;

	public IceCreamBucket SpawnBucket(IceCreamFlavourData iceCreamFlavourData, Vector3 position)
	{
		return null;
	}
}
