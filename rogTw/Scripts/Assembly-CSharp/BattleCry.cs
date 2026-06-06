using UnityEngine;

public class BattleCry : MonoBehaviour
{
	public enum BattleCryTrigger
	{
		Death = 0,
		Spawn = 1,
		NearEnd = 2,
		ArmorBreak = 3,
		ShieldBreak = 4,
		Periodic = 5
	}

	[SerializeField]
	private LayerMask enemyLayerMask;

	[SerializeField]
	private string battleCryText = "Battle Cry!";

	[SerializeField]
	private float cryRadius;

	private float periodicTimer = 5f;

	[SerializeField]
	private BattleCryTrigger myTrigger;

	[SerializeField]
	private float fortifyTime;

	[SerializeField]
	private float hastePercentage;

	[SerializeField]
	private GameObject[] enemiesToSpawn;

	[SerializeField]
	private Vector3 heal;

	[SerializeField]
	private int teleport;

	[SerializeField]
	private GameObject teleportObject;

	private bool triggered;

	public void CheckBattleCry(BattleCryTrigger source)
	{
		if (source == myTrigger && !triggered)
		{
			Cry();
		}
	}

	private void FixedUpdate()
	{
		if (myTrigger == BattleCryTrigger.Periodic)
		{
			if (periodicTimer <= 0f)
			{
				Cry();
				periodicTimer = Random.Range(1f, 6f) + Random.Range(1f, 6f);
			}
			else
			{
				periodicTimer -= Time.fixedDeltaTime;
			}
		}
	}

	private void Cry()
	{
		if (teleport > 0)
		{
			if (teleportObject != null)
			{
				Object.Instantiate(teleportObject, base.transform.position, Quaternion.identity);
			}
			GetComponent<Pathfinder>().Teleport(teleport);
			if (teleportObject != null)
			{
				Object.Instantiate(teleportObject, base.transform.position, Quaternion.identity);
			}
		}
		if (enemiesToSpawn.Length != 0)
		{
			Waypoint currentWaypoint = GetComponent<Pathfinder>().currentWaypoint;
			GameObject[] array = enemiesToSpawn;
			for (int i = 0; i < array.Length; i++)
			{
				Enemy component = Object.Instantiate(array[i], base.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f)), Quaternion.identity).GetComponent<Enemy>();
				component.SetStats();
				component.SetFirstSpawnPoint(currentWaypoint);
				SpawnManager.instance.currentEnemies.Add(component);
			}
		}
		DamageNumber component2 = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
		component2.SetText(battleCryText, "Grey", 1f);
		component2.SetHoldTime(2f);
		if (myTrigger != BattleCryTrigger.Death)
		{
			component2.transform.parent = base.transform;
		}
		Collider[] array2 = ((cryRadius > 0f) ? Physics.OverlapSphere(base.transform.position, cryRadius, enemyLayerMask, QueryTriggerInteraction.Collide) : new Collider[1] { GetComponent<Collider>() });
		Collider[] array3 = array2;
		for (int i = 0; i < array3.Length; i++)
		{
			Enemy component3 = array3[i].GetComponent<Enemy>();
			if (component3 != null)
			{
				if (fortifyTime > 0f)
				{
					component3.Fortify(fortifyTime);
				}
				if (hastePercentage > 0f)
				{
					component3.AddHaste(hastePercentage);
				}
				if (heal.x > 0f)
				{
					component3.ClenseBleed((int)heal.x);
					component3.HealHealth((int)heal.x);
				}
				if (heal.y > 0f)
				{
					component3.ClenseBurn((int)heal.y);
					component3.HealArmor((int)heal.x);
				}
				if (heal.z > 0f)
				{
					component3.ClensePoison((int)heal.z);
					component3.HealShield((int)heal.x);
				}
			}
		}
		triggered = true;
	}
}
