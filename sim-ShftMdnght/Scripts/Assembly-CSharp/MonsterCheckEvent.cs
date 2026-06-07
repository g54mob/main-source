using UnityEngine;

public class MonsterCheckEvent : MonoBehaviour
{
	public Transform monsterCheckPosition;

	public float distanceToAttract;

	public void CauseDistraction()
	{
		if (!HuntManager.Instance || !StoreManager.Instance.inHunt)
		{
			return;
		}
		foreach (Enemy allEnemy in HuntManager.Instance.allEnemies)
		{
			if (GetXZDistance(allEnemy.transform, monsterCheckPosition) < distanceToAttract)
			{
				allEnemy.ChaseNonPlayerTarget(monsterCheckPosition.position);
			}
		}
	}

	private float GetXZDistance(Transform a, Transform b)
	{
		Vector3 position = a.position;
		Vector3 position2 = b.position;
		position.y = 0f;
		position2.y = 0f;
		return Vector3.Distance(position, position2);
	}
}
