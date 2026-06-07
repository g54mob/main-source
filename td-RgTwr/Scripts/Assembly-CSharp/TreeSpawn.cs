using UnityEngine;

public class TreeSpawn : SpawnableObject
{
	public override void SpawnUI()
	{
		if (UIObject != null)
		{
			Object.Instantiate(UIObject, base.transform.position, Quaternion.identity).GetComponent<TreeUI>().SetStats(base.gameObject);
		}
	}
}
