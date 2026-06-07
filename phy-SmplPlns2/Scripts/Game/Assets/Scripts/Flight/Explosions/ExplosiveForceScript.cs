using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.WorldObjects;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class ExplosiveForceScript : MonoBehaviour
	{
		private struct DamageableCollider
		{
			public Collider Collider { get; private set; }

			public IDamageableObject DamageableObject { get; private set; }

			public DamageableCollider(IDamageableObject damageableObject, Collider collider)
			{
				this = default(DamageableCollider);
				DamageableObject = damageableObject;
				Collider = collider;
			}
		}

		private struct DamageableRigidBodyImpact
		{
			public float Distance { get; private set; }

			public Vector3 Normal { get; private set; }

			public Vector3 Point { get; private set; }

			public Vector3 Vector { get; private set; }

			public DamageableRigidBodyImpact(Vector3 vector, Vector3 point, Vector3 normal, float distance)
			{
				this = default(DamageableRigidBodyImpact);
				Vector = vector;
				Point = point;
				Normal = normal;
				Distance = distance;
			}
		}

		private struct DestructibleCollider
		{
			public Collider Collider { get; private set; }

			public DestructibleChunk DestructibleChunk { get; private set; }

			public DestructibleCollider(DestructibleChunk destructibleChunk, Collider collider)
			{
				this = default(DestructibleCollider);
				DestructibleChunk = destructibleChunk;
				Collider = collider;
			}
		}

		private struct MiscRigidBody
		{
			public Collider ClosestCollider { get; private set; }

			public Vector3 ClosestPointOnBounds { get; private set; }

			public Rigidbody RigidBody { get; private set; }

			public float SquaredDistanceFromBlastOrigin { get; private set; }

			public MiscRigidBody(Rigidbody body, Collider closestCollider, Vector3 closestPointOnBounds, float squaredDistanceFromBlastOrigin)
			{
				this = default(MiscRigidBody);
				RigidBody = body;
				ClosestCollider = closestCollider;
				ClosestPointOnBounds = closestPointOnBounds;
				SquaredDistanceFromBlastOrigin = squaredDistanceFromBlastOrigin;
			}
		}

		private struct PartCollider
		{
			public Collider Collider { get; private set; }

			public PartScript Part { get; private set; }

			public PartCollider(PartScript part, Collider collider)
			{
				this = default(PartCollider);
				Part = part;
				Collider = collider;
			}
		}

		public float BlastForce;

		public float BlastRadius;

		public float CriticalBlastRadius;

		public void Detonate(AircraftScript owner)
		{
			Detonate(owner, null, null);
		}

		public void Detonate(AircraftScript blastOwner, Rigidbody rigidBodyOwner, Vector3? impactDirection)
		{
			if (FlightSceneScript.IsPeacefulMode)
			{
				return;
			}
			List<PartCollider> value;
			using (CollectionPool<List<PartCollider>, PartCollider>.Get(out value))
			{
				List<NetworkCharacterScript> value2;
				using (CollectionPool<List<NetworkCharacterScript>, NetworkCharacterScript>.Get(out value2))
				{
					List<DamageableCollider> value3;
					using (CollectionPool<List<DamageableCollider>, DamageableCollider>.Get(out value3))
					{
						List<DestructibleCollider> value4;
						using (CollectionPool<List<DestructibleCollider>, DestructibleCollider>.Get(out value4))
						{
							List<Collider> value5;
							using (CollectionPool<List<Collider>, Collider>.Get(out value5))
							{
								Collider[] array = Physics.OverlapSphere(base.transform.position, BlastRadius, -67108865);
								foreach (Collider collider in array)
								{
									if (collider.isTrigger)
									{
										continue;
									}
									PartScript componentInParent;
									if ((componentInParent = collider.GetComponentInParent<PartScript>()) != null)
									{
										value.Add(new PartCollider(componentInParent, collider));
										continue;
									}
									Rigidbody attachedRigidbody = collider.attachedRigidbody;
									if ((object)attachedRigidbody != null && attachedRigidbody.TryGetComponent<NetworkCharacterScript>(out var component) && !value2.Contains(component))
									{
										value2.Add(component);
										continue;
									}
									if (collider.TryGetComponent<IDamageableObject>(out var component2))
									{
										value3.Add(new DamageableCollider(component2, collider));
										continue;
									}
									Rigidbody attachedRigidbody2 = collider.attachedRigidbody;
									ExplosionDebrisScript component3;
									if ((object)attachedRigidbody2 != null && attachedRigidbody2.TryGetComponent<IDamageableObject>(out component2))
									{
										value3.Add(new DamageableCollider(component2, collider));
									}
									else if (!(collider.attachedRigidbody == null) && (!(rigidBodyOwner != null) || !(rigidBodyOwner == collider.attachedRigidbody)) && !collider.attachedRigidbody.TryGetComponent<ExplosionDebrisScript>(out component3))
									{
										if (collider.TryGetComponent<DestructibleChunk>(out var component4))
										{
											value4.Add(new DestructibleCollider(component4, collider));
											value5.Add(collider);
										}
										else
										{
											value5.Add(collider);
										}
									}
								}
								DetonateAircraftParts(value, blastOwner);
								DetonateCharacters(value2, blastOwner);
								DetonateDestructibleChunks(value4);
								DetonateDamageableBodies(value3, impactDirection, blastOwner?.NetworkAircraft?.PlayerId);
								DetonateMiscellaneousRigidBodies(value5);
							}
						}
					}
				}
			}
		}

		private void DetonateAircraftParts(List<PartCollider> parts, AircraftScript blastOwner)
		{
			Dictionary<AircraftScript, List<PartScript>> value;
			using (CollectionPool<Dictionary<AircraftScript, List<PartScript>>, KeyValuePair<AircraftScript, List<PartScript>>>.Get(out value))
			{
				List<AircraftScript> value2;
				using (CollectionPool<List<AircraftScript>, AircraftScript>.Get(out value2))
				{
					for (int i = 0; i < parts.Count; i++)
					{
						PartCollider partCollider = parts[i];
						if (partCollider.Collider.TryGetComponent<RocketScript>(out var component) && component.IsLaunched)
						{
							continue;
						}
						PartScript part = partCollider.Part;
						AircraftScript aircraft = part.Aircraft;
						if (!aircraft.RemoteAircraft)
						{
							if (!value.TryGetValue(aircraft, out var value3))
							{
								value3 = (value[aircraft] = CollectionPool<List<PartScript>, PartScript>.Get());
								value2.Add(aircraft);
							}
							value3.Add(part);
						}
					}
					foreach (KeyValuePair<AircraftScript, List<PartScript>> item in value)
					{
						item.Key.HandleExplosiveBlast(item.Value, BlastForce, BlastRadius, CriticalBlastRadius, base.transform.position, blastOwner, value2);
						CollectionPool<List<PartScript>, PartScript>.Release(item.Value);
					}
				}
			}
		}

		private void DetonateCharacters(List<NetworkCharacterScript> characters, AircraftScript blastOwner)
		{
			foreach (NetworkCharacterScript character in characters)
			{
				character.HandleExplosiveBlast(BlastForce, BlastRadius, CriticalBlastRadius, base.transform.position, blastOwner);
			}
		}

		private void DetonateDamageableBodies(List<DamageableCollider> damageableBodies, Vector3? impactDirection, int? playerId)
		{
			Vector3 position = base.transform.position;
			float num = BlastRadius - CriticalBlastRadius;
			Dictionary<IDamageableObject, DamageableRigidBodyImpact> value;
			using (CollectionPool<Dictionary<IDamageableObject, DamageableRigidBodyImpact>, KeyValuePair<IDamageableObject, DamageableRigidBodyImpact>>.Get(out value))
			{
				List<DamageableRigidBodyImpact> value2;
				using (CollectionPool<List<DamageableRigidBodyImpact>, DamageableRigidBodyImpact>.Get(out value2))
				{
					for (int i = 0; i < damageableBodies.Count; i++)
					{
						IDamageableObject damageableObject = damageableBodies[i].DamageableObject;
						Collider collider = damageableBodies[i].Collider;
						value2.Clear();
						int layer = collider.gameObject.layer;
						int num2 = 8;
						collider.gameObject.layer = num2;
						if (impactDirection.HasValue && !Physics.Raycast(position, impactDirection.Value * -1f, out var hitInfo, 1000f, 1 << num2) && Physics.Raycast(position + impactDirection.Value * -1000f, impactDirection.Value, out hitInfo, 2000f, 1 << num2))
						{
							Vector3 vector = hitInfo.point - position;
							value2.Add(new DamageableRigidBodyImpact(vector, hitInfo.point, hitInfo.normal, vector.magnitude));
						}
						Vector3 vector2 = collider.ClosestPointOnBounds(position) - position;
						if (vector2.sqrMagnitude > 0.001f && Physics.Raycast(position, vector2.normalized, out hitInfo, 1000f, 1 << num2))
						{
							Vector3 vector3 = hitInfo.point - position;
							value2.Add(new DamageableRigidBodyImpact(vector3, hitInfo.point, hitInfo.normal, vector3.magnitude));
						}
						Vector3 normalized = (collider.transform.position - position).normalized;
						if (Physics.Raycast(position + normalized * -1000f, normalized, out hitInfo, 2000f, 1 << num2))
						{
							Vector3 vector4 = hitInfo.point - position;
							value2.Add(new DamageableRigidBodyImpact(vector4, hitInfo.point, hitInfo.normal, vector4.magnitude));
						}
						Vector3 vector5 = collider.transform.position - position;
						value2.Add(new DamageableRigidBodyImpact(vector5, collider.transform.position, Vector3.up, vector5.magnitude));
						if (value2.Count > 0)
						{
							DamageableRigidBodyImpact value3 = value2[0];
							for (int j = 1; j < value2.Count; j++)
							{
								DamageableRigidBodyImpact damageableRigidBodyImpact = value2[j];
								if (damageableRigidBodyImpact.Distance < value3.Distance)
								{
									value3 = damageableRigidBodyImpact;
								}
							}
							if (!value.TryGetValue(damageableObject, out var value4) || value3.Distance < value4.Distance)
							{
								value[damageableObject] = value3;
							}
						}
						collider.gameObject.layer = layer;
					}
					foreach (KeyValuePair<IDamageableObject, DamageableRigidBodyImpact> item in value)
					{
						DamageableRigidBodyImpact value5 = item.Value;
						float num3 = BlastForce;
						if (value5.Distance > CriticalBlastRadius)
						{
							num3 *= 1f - (value5.Distance - CriticalBlastRadius) / num;
						}
						item.Key.RigidBody?.AddForce(value5.Vector.normalized * num3, ForceMode.Impulse);
						item.Key.OnExplosiveForce(num3, playerId, value5.Point, value5.Normal);
					}
				}
			}
		}

		private void DetonateDestructibleChunks(List<DestructibleCollider> destructibleChunks)
		{
			for (int i = 0; i < destructibleChunks.Count; i++)
			{
				destructibleChunks[i].DestructibleChunk.AddDamage(BlastForce);
			}
		}

		private void DetonateMiscellaneousRigidBodies(List<Collider> colliders)
		{
			Vector3 position = base.transform.position;
			float num = BlastRadius - CriticalBlastRadius;
			Dictionary<Rigidbody, MiscRigidBody> dictionary = new Dictionary<Rigidbody, MiscRigidBody>();
			for (int i = 0; i < colliders.Count; i++)
			{
				Collider collider = colliders[i];
				Rigidbody attachedRigidbody = collider.attachedRigidbody;
				Vector3 vector = collider.ClosestPointOnBounds(position);
				float sqrMagnitude = (vector - position).sqrMagnitude;
				if (!dictionary.ContainsKey(attachedRigidbody))
				{
					dictionary.Add(attachedRigidbody, new MiscRigidBody(attachedRigidbody, collider, vector, sqrMagnitude));
				}
				else if (sqrMagnitude < dictionary[attachedRigidbody].SquaredDistanceFromBlastOrigin)
				{
					dictionary[attachedRigidbody] = new MiscRigidBody(attachedRigidbody, collider, vector, sqrMagnitude);
				}
			}
			foreach (MiscRigidBody value in dictionary.Values)
			{
				Vector3 vector2 = value.ClosestCollider.transform.position - position;
				float magnitude = vector2.magnitude;
				Vector3 normalized = vector2.normalized;
				float num2 = BlastForce;
				if (magnitude > CriticalBlastRadius)
				{
					num2 *= 1f - (magnitude - CriticalBlastRadius) / num;
				}
				value.RigidBody.AddForce(normalized * num2, ForceMode.Impulse);
			}
		}
	}
}
