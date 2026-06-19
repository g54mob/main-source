using Aggro.Core;
using UnityEngine;

public class TutorialSpawn : EntityBehaviourBase
{
	public enum SpawnType
	{
		BombsEarly = 0,
		BombsLate = 1
	}

	public SpawnType type;

	public GameObject prefab;

	public void CheckSpawn(SpawnType type)
	{
		if (type == this.type)
		{
			EntityUtil.Instantiate(prefab, base.transform.position);
		}
	}
}
