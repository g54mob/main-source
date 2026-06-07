using System.Collections.Generic;
using UnityEngine;

public class BlockProjectiles : MonoBehaviour
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float blockInterval = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float range = 30f;

	[SerializeField]
	private GameObject fxBlockProjectile;

	private float cooldown;

	private TagManager tagManager;

	public List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	private void Start()
	{
		tagManager = TagManager.instance;
		cooldown = Random.value * blockInterval;
	}

	private void Update()
	{
		cooldown -= Time.deltaTime;
		while (cooldown <= 0f)
		{
			BlockAnArrow();
			cooldown += blockInterval;
		}
	}

	private void BlockAnArrow()
	{
		TaggedObject taggedObject = tagManager.FindClosestTaggedObjectWithTags(base.transform.position, mustHaveTags, mayNotHaveTags);
		if (!(taggedObject == null) && (taggedObject.transform.position - base.transform.position).magnitude < range)
		{
			if ((bool)fxBlockProjectile)
			{
				Object.Instantiate(fxBlockProjectile, taggedObject.transform.position, Quaternion.identity);
			}
			Object.Destroy(taggedObject.gameObject);
		}
	}
}
