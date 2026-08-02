using JUTPS.ArmorSystem;
using JUTPS.CharacterBrain;
using JUTPS.FX;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace JUTPS.WeaponSystem
{
	[AddComponentMenu("JU TPS/Weapon System/Bullet")]
	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : NetworkBehaviour
	{
		public enum BulletMovementType
		{
			Physics = 0,
			Calculated = 1,
			Teleport = 2
		}

		public GameObject Owner;

		private Vector3 OldPosition;

		private Rigidbody rb;

		[Header("Bullet Settings")]
		public float BulletVelocity;

		public float BulletDamage = 20f;

		public float DestroyTime;

		public bool HightPrecisionCollisionDetection = true;

		public bool ImpactAddForce = true;

		[Header("Ricochet")]
		public bool Ricochet;

		public float RicochetAngle = 45f;

		public int MaxRicochets = 1;

		[HideInInspector]
		public int RicochetsCount;

		[Header("Physics: It is calculated by physics")]
		[Header("Calculated: Follow a path between two points")]
		[Header("Teleport: It is teleported to the hit point.")]
		public BulletMovementType MovementType;

		[HideInInspector]
		public Vector3 FinalPoint;

		[HideInInspector]
		public Vector3 FinalPointNormal;

		private string CollidedGameObjectTag;

		public SurfaceFX[] ImpactFX;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
			rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
			if (!IsDestinationAHead() && MovementType != BulletMovementType.Physics)
			{
				MovementType = BulletMovementType.Physics;
			}
			if (MovementType == BulletMovementType.Physics)
			{
				rb.velocity = base.transform.forward * BulletVelocity;
			}
			else
			{
				rb.useGravity = false;
			}
			OldPosition = base.transform.position;
			if (MovementType == BulletMovementType.Teleport && FinalPoint != Vector3.zero)
			{
				base.transform.position = FinalPoint;
			}
		}

		private void FixedUpdate()
		{
			if (MovementType != BulletMovementType.Teleport)
			{
				if (HightPrecisionCollisionDetection)
				{
					CheckCollisionDetection();
				}
				if (MovementType == BulletMovementType.Calculated && FinalPoint != Vector3.zero)
				{
					MoveToFinalPoint();
				}
				else if (MovementType == BulletMovementType.Calculated)
				{
					MovePhysically();
				}
				if (MovementType == BulletMovementType.Physics)
				{
					MovePhysically();
				}
				if (base.transform.position == FinalPoint && MovementType != BulletMovementType.Physics)
				{
					MovementType = BulletMovementType.Physics;
				}
			}
		}

		private void MovePhysically()
		{
			rb.velocity = base.transform.forward * BulletVelocity;
		}

		private void MoveForward()
		{
			base.transform.Translate(0f, 0f, BulletVelocity * Time.deltaTime);
		}

		private void MoveToFinalPoint()
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, FinalPoint, BulletVelocity * Time.deltaTime);
		}

		private void CheckCollisionDetection()
		{
			if (Physics.Linecast(base.transform.position, OldPosition, out var hitInfo))
			{
				FinalPoint = hitInfo.point;
				FinalPointNormal = hitInfo.normal;
				base.transform.position = hitInfo.point;
				MovementType = BulletMovementType.Calculated;
			}
			OldPosition = base.transform.position;
		}

		private void OnCollisionEnter(Collision col)
		{
			if (!(col.gameObject.tag != "Bullet"))
			{
				return;
			}
			float damage = BulletDamage;
			bool flag = false;
			JUHealth component2;
			if (col.gameObject.layer == 15 || col.gameObject.layer == 9 || col.gameObject.layer == 23)
			{
				if (col.gameObject.layer == 9 && col.gameObject.GetComponentInChildren<DamageableBodyPart>() != null)
				{
					Physics.IgnoreCollision(col.collider, GetComponent<Collider>());
					return;
				}
				if (col.gameObject.TryGetComponent<DamageableBodyPart>(out var component))
				{
					damage = component.DoDamage(BulletDamage);
				}
				else if ((bool)col.gameObject.GetComponentInParent<JUCharacterBrain>())
				{
					col.gameObject.GetComponentInParent<JUCharacterBrain>().TakeDamage(BulletDamage);
				}
			}
			else if (col.gameObject.TryGetComponent<JUHealth>(out component2))
			{
				component2.DoDamage(BulletDamage);
			}
			if (ImpactAddForce && col.gameObject.TryGetComponent<Rigidbody>(out var component3))
			{
				component3.AddForce(base.transform.forward * BulletVelocity * rb.mass, ForceMode.Impulse);
			}
			if (Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, 1f))
			{
				FinalPoint = hitInfo.point;
				FinalPointNormal = hitInfo.normal;
			}
			CollidedGameObjectTag = col.gameObject.tag;
			if (!flag)
			{
				SurfaceFX.InstantiateParticleFX(ImpactFX, col.gameObject.tag, FinalPoint, Quaternion.FromToRotation(base.transform.forward, FinalPointNormal) * base.transform.rotation, col.gameObject.transform);
			}
			if (GetOwner() != null)
			{
				if (col.gameObject.layer == 15 || col.gameObject.layer == 9 || col.gameObject.layer == 23)
				{
					if (col.gameObject.GetComponentInParent<JUHealth>() != null && !col.gameObject.GetComponentInParent<JUHealth>().IsDead)
					{
						HitMarkerEffect.HitCheck(CollidedGameObjectTag, GetOwner().tag, FinalPoint, damage);
					}
				}
				else
				{
					HitMarkerEffect.HitCheck(CollidedGameObjectTag, GetOwner().tag);
				}
			}
			if (Ricochet)
			{
				if (Vector3.Dot(base.transform.forward, FinalPointNormal) < 0f - RicochetAngle / 360f)
				{
					DestroyBullet(DestroyTime);
				}
				else
				{
					RicochetBullet(FinalPointNormal);
				}
			}
			else
			{
				DestroyBullet(DestroyTime);
			}
		}

		public void RicochetBullet(Vector3 WallNormal)
		{
			if (!Ricochet || RicochetsCount > MaxRicochets)
			{
				DestroyBullet(DestroyTime);
				return;
			}
			RicochetsCount++;
			MovementType = BulletMovementType.Physics;
			base.transform.rotation = Quaternion.FromToRotation(base.transform.forward, Vector3.Reflect(base.transform.forward, WallNormal)) * base.transform.rotation;
		}

		private bool IsDestinationAHead()
		{
			bool result = true;
			if (FinalPoint != Vector3.zero && MovementType != BulletMovementType.Physics)
			{
				result = Vector3.Dot(base.transform.forward, (FinalPoint - base.transform.position).normalized) > 0.3f;
			}
			return result;
		}

		public void Ignore(Collider[] collider)
		{
			foreach (Collider collider2 in collider)
			{
				Physics.IgnoreCollision(GetComponent<Collider>(), collider2);
			}
		}

		[Command(requiresAuthority = false)]
		public void SetOwner(GameObject owner)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteGameObject(owner);
			SendCommandInternal("System.Void JUTPS.WeaponSystem.Bullet::SetOwner(UnityEngine.GameObject)", -1049661367, writer, 0, requiresAuthority: false);
			NetworkWriterPool.Return(writer);
		}

		public void CMDSetProperties(Vector3 finalPoint, Vector3 finalPointNormal)
		{
			FinalPoint = finalPoint;
			FinalPointNormal = finalPointNormal;
		}

		public void RPCSetProperties(Vector3 startPos, Vector3 finalPoint, Vector3 finalPointNormal)
		{
			base.transform.position = startPos;
			FinalPoint = finalPoint;
			FinalPointNormal = finalPointNormal;
		}

		public GameObject GetOwner()
		{
			if (Owner != null)
			{
				return Owner;
			}
			return base.gameObject;
		}

		public void DestroyBullet(float destroyTime = 0f)
		{
			Object.Destroy(base.gameObject, destroyTime);
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_SetOwner__GameObject(GameObject owner)
		{
			Owner = owner;
		}

		protected static void InvokeUserCode_SetOwner__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command SetOwner called on client.");
			}
			else
			{
				((Bullet)obj).UserCode_SetOwner__GameObject(reader.ReadGameObject());
			}
		}

		static Bullet()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(Bullet), "System.Void JUTPS.WeaponSystem.Bullet::SetOwner(UnityEngine.GameObject)", InvokeUserCode_SetOwner__GameObject, requiresAuthority: false);
		}
	}
}
