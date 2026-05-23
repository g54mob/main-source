using System.Collections.Generic;
using UnityEngine;

public class BarricadeDamage : MonoBehaviour
{
	public float preSelectRadius = 4f;

	public float slowTime = 3f;

	public List<DamageModifyer> damage;

	public LayerMask lmTakeDamage;

	private Collider[] overlapColliders = new Collider[50];

	private float timeSinceLastCollisionCheck;

	public float DamageMultiplyer = 1f;

	private BoxCollider myCollider;

	private BlacksmithUpgrades blacksmithUpgrades;

	private void Start()
	{
		myCollider = GetComponent<BoxCollider>();
		timeSinceLastCollisionCheck = Random.value;
	}

	private void Update()
	{
		timeSinceLastCollisionCheck += Time.deltaTime;
		if (timeSinceLastCollisionCheck < 0.2f)
		{
			return;
		}
		timeSinceLastCollisionCheck = 0f;
		foreach (TaggedObject enemyUnit in TagManager.instance.EnemyUnits)
		{
			if (!(Vector3.Distance(base.transform.position, enemyUnit.transform.position) <= preSelectRadius) || enemyUnit.Hp.PathfindMovement.IsSlowed)
			{
				continue;
			}
			overlapColliders = Physics.OverlapBox(base.transform.position, myCollider.size, base.transform.rotation, lmTakeDamage);
			Collider[] array = overlapColliders;
			for (int i = 0; i < array.Length; i++)
			{
				TaggedObject componentInParent = array[i].GetComponentInParent<TaggedObject>();
				if (!componentInParent || !componentInParent.Tags.Contains(TagManager.ETag.EnemyOwned) || !componentInParent.Tags.Contains(TagManager.ETag.FastMoving))
				{
					continue;
				}
				Hp hp = componentInParent.Hp;
				if (!hp)
				{
					continue;
				}
				PathfindMovement pathfindMovement = hp.PathfindMovement;
				if ((bool)pathfindMovement && !pathfindMovement.IsSlowed)
				{
					if (!blacksmithUpgrades)
					{
						blacksmithUpgrades = BlacksmithUpgrades.instance;
					}
					float meleeDamage = blacksmithUpgrades.meleeDamage;
					pathfindMovement.Slow(slowTime);
					hp.TakeDamage(DamageModifyer.CalculateDamageOnTarget(componentInParent, damage, DamageMultiplyer * meleeDamage));
				}
			}
			break;
		}
	}
}
