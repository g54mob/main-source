using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class ZombieDamageDealer : NetworkBehaviour
{
	public Transform hitCollider;

	public float damageAmount = 10f;

	public float hitRadius = 2f;

	public LayerMask targetLayers;

	public LayerMask propLayers;

	[Header("Hit Window")]
	[Tooltip("Darbe tek kare yerine bu süre boyunca aranır - oyuncu az geri kaçsa bile yakalanır")]
	public float hitWindowDuration = 0.2f;

	[Tooltip("Pencere boyunca kaç saniyede bir isabet kontrol edilir")]
	public float hitCheckInterval = 0.03f;

	[Tooltip("Oyuncu kapsül yarıçapı - yatay mesafeden düşülür (kapsül yüzeyine ClosestPoint yaklaşımı)")]
	public float playerBodyRadius = 0.4f;

	[Tooltip("Dikey isabet toleransı - hitCollider ile oyuncu arasındaki Y farkı bundan fazlaysa vurmaz")]
	public float verticalHitTolerance = 2.5f;

	private ZombieController zombieController;

	private Coroutine hitWindowRoutine;

	private void OnDrawGizmosSelected()
	{
		if (hitCollider != null)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(hitCollider.position, hitRadius);
			Gizmos.color = new Color(1f, 0.5f, 0f, 1f);
			Gizmos.DrawWireSphere(hitCollider.position, hitRadius + playerBodyRadius);
		}
	}

	private void Start()
	{
		zombieController = GetComponent<ZombieController>();
	}

	public void CheckHit()
	{
		if (!base.isServer)
		{
			Debug.LogWarning("[ZombieDamageDealer] CheckHit SERVER DEĞİL, return!");
		}
		else if (hitCollider == null)
		{
			Debug.LogError("[ZombieDamageDealer] Hit Collider is not assigned!");
		}
		else if (hitWindowRoutine == null)
		{
			hitWindowRoutine = StartCoroutine(HitWindowRoutine());
		}
	}

	private IEnumerator HitWindowRoutine()
	{
		float elapsed = 0f;
		WaitForSeconds wait = new WaitForSeconds(hitCheckInterval);
		for (; elapsed <= hitWindowDuration; elapsed += hitCheckInterval)
		{
			if (TryApplyHit())
			{
				break;
			}
			yield return wait;
		}
		hitWindowRoutine = null;
	}

	private bool TryApplyHit()
	{
		if (!base.isServer)
		{
			return false;
		}
		if (zombieController == null || zombieController.CurrentTarget == null)
		{
			return false;
		}
		TSPlayerController component = zombieController.CurrentTarget.GetComponent<TSPlayerController>();
		if (component == null)
		{
			return false;
		}
		Vector3 position = hitCollider.position;
		Vector3 position2 = component.transform.position;
		if (Mathf.Abs(position.y - position2.y) > verticalHitTolerance)
		{
			return false;
		}
		float num = position.x - position2.x;
		float num2 = position.z - position2.z;
		if (Mathf.Sqrt(num * num + num2 * num2) - playerBodyRadius > hitRadius)
		{
			return false;
		}
		Vector3 vector = base.transform.position + Vector3.up * 1f;
		Vector3 vector2 = component.transform.position + Vector3.up * 1f - vector;
		if (Physics.Raycast(vector, vector2.normalized, vector2.magnitude, propLayers))
		{
			return false;
		}
		NetworkIdentity component2 = component.GetComponent<NetworkIdentity>();
		if (component2 != null && component2.connectionToClient != null)
		{
			TargetApplyDamage(component2.connectionToClient, component.gameObject, damageAmount);
			return true;
		}
		return false;
	}

	[TargetRpc]
	private void TargetApplyDamage(NetworkConnection target, GameObject hitPlayer, float damage)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(hitPlayer);
		writer.WriteFloat(damage);
		SendTargetRPCInternal(target, "System.Void ZombieDamageDealer::TargetApplyDamage(Mirror.NetworkConnection,UnityEngine.GameObject,System.Single)", 1578308389, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void CheckPropHit()
	{
		if (!base.isServer)
		{
			Debug.LogWarning($"[ZombieDamageDealer] CheckPropHit SERVER DEĞİL, return ediliyor! isServer: {base.isServer}");
		}
		else if (hitCollider == null)
		{
			Debug.LogError("[ZombieDamageDealer] Hit Collider is not assigned!");
		}
		else
		{
			if (zombieController == null || zombieController.CurrentPropTarget == null)
			{
				return;
			}
			PropBase currentPropTarget = zombieController.CurrentPropTarget;
			Collider component = currentPropTarget.GetComponent<Collider>();
			if (component == null || Vector3.Distance(hitCollider.position, component.ClosestPoint(hitCollider.position)) > hitRadius)
			{
				return;
			}
			Vector3 vector = component.ClosestPoint(hitCollider.position);
			Vector3 forward = (vector - hitCollider.position).normalized;
			if (forward.sqrMagnitude < 0.001f)
			{
				forward = -base.transform.forward;
			}
			Quaternion quaternion = Quaternion.LookRotation(forward);
			float health = currentPropTarget.health;
			currentPropTarget.TakeDamage(damageAmount, vector, quaternion);
			SpawnPropHitParticle(currentPropTarget.propType, vector, quaternion);
			if (health > 0f && currentPropTarget.health <= 0f)
			{
				SpawnPropDestroyParticle(currentPropTarget.propType, vector, quaternion);
				if (zombieController != null)
				{
					zombieController.OnPropDestroyed();
				}
			}
		}
	}

	private void SpawnPropHitParticle(PropType propType, Vector3 position, Quaternion rotation)
	{
		if (NetworkSceneObjectSpawner.Instance == null)
		{
			Debug.LogWarning("[ZombieDamageDealer] NetworkSceneObjectSpawner.Instance NULL!");
			return;
		}
		switch (propType)
		{
		case PropType.Wall:
			NetworkSceneObjectSpawner.Instance.SpawnZombieWallHitParticle(position, rotation);
			break;
		case PropType.Prop:
			NetworkSceneObjectSpawner.Instance.SpawnZombiePropHitParticle(position, rotation);
			break;
		case PropType.TrainObject:
			NetworkSceneObjectSpawner.Instance.SpawnZombiePropHitParticle(position, rotation);
			break;
		}
	}

	private void SpawnPropDestroyParticle(PropType propType, Vector3 position, Quaternion rotation)
	{
		if (NetworkSceneObjectSpawner.Instance == null)
		{
			Debug.LogWarning("[ZombieDamageDealer] NetworkSceneObjectSpawner.Instance NULL!");
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnTrainObjectDestroyingParticle(position, rotation);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TargetApplyDamage__NetworkConnection__GameObject__Single(NetworkConnection target, GameObject hitPlayer, float damage)
	{
		TSPlayerStatusHolder component = hitPlayer.GetComponent<TSPlayerStatusHolder>();
		if (component != null)
		{
			component.GetDamage(damage, isZombieHit: true);
		}
	}

	protected static void InvokeUserCode_TargetApplyDamage__NetworkConnection__GameObject__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetApplyDamage called on server.");
		}
		else
		{
			((ZombieDamageDealer)obj).UserCode_TargetApplyDamage__NetworkConnection__GameObject__Single(null, reader.ReadGameObject(), reader.ReadFloat());
		}
	}

	static ZombieDamageDealer()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(ZombieDamageDealer), "System.Void ZombieDamageDealer::TargetApplyDamage(Mirror.NetworkConnection,UnityEngine.GameObject,System.Single)", InvokeUserCode_TargetApplyDamage__NetworkConnection__GameObject__Single);
	}
}
