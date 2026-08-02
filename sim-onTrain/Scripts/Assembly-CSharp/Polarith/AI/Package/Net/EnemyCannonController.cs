using Mirror;
using UnityEngine;

namespace Polarith.AI.Package.Net
{
	[AddComponentMenu("Polarith AI » Examples/Network/Enemy Cannon Controller")]
	public sealed class EnemyCannonController : NetworkBehaviour
	{
		[Tooltip("A template for the projectile that is being spawned when the cannon shoots.")]
		public GameObject BulletPrefab;

		[Tooltip("The tag of the player objects. All objects with this tag are potential targets.")]
		public string PlayerTag = "Player";

		[Tooltip("The range of the weapon, it is only fired if the target is closer than this distance.")]
		public float MaxDistance = 50f;

		[Tooltip("Determines how fast the weapon can reload.")]
		public float Interval = 0.5f;

		[Tooltip("Influences the frequency of when the weapon is fired. E.g. a value of 1 means that the enemy may wait up to 1 additional second before it fires again.")]
		public float Randomness;

		[Tooltip("A random angle offset is applied to the perfect shot direction between 0 and spread. 0 = perfect aim 180 = pure random. (Spread is in degrees)")]
		public float Spread;

		[Tooltip("The traveling speed of the spawned bullet.")]
		public float BulletSpeed = 10f;

		private GameObject[] players;

		private float currentTime;

		private float delay;

		private void Update()
		{
			if (base.isClient && !base.isServer)
			{
				return;
			}
			players = GameObject.FindGameObjectsWithTag(PlayerTag);
			if (players == null || players.Length == 0)
			{
				return;
			}
			int num = 0;
			float num2 = (players[num].transform.position - base.transform.position).sqrMagnitude;
			float num3 = 0f;
			for (int i = 1; i < players.Length; i++)
			{
				num3 = (players[i].transform.position - base.transform.position).sqrMagnitude;
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			if (currentTime >= Interval + delay)
			{
				Vector3 vector = players[num].transform.position - base.transform.position;
				if (vector.sqrMagnitude > MaxDistance * MaxDistance)
				{
					return;
				}
				vector = Quaternion.Euler(0f, 0f, Random.value * Spread * 2f - Spread) * vector;
				vector.Normalize();
				GameObject obj = Object.Instantiate(BulletPrefab, base.transform.position, Quaternion.identity);
				obj.GetComponent<Rigidbody2D>().velocity = vector * BulletSpeed;
				NetworkServer.Spawn(obj);
				Object.Destroy(obj, 4f);
				delay = Random.value * Randomness;
				currentTime = 0f;
			}
			currentTime += Time.deltaTime;
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
