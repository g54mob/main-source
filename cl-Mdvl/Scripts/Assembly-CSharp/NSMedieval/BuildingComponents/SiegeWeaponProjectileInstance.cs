using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CombatAi;
using NSMedieval.Enums;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Scripts.Pooler;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class SiegeWeaponProjectileInstance : IDamageDealAgent, IDamageCommonAgent, IGoapTargetable, IGameDisposable, IDisposable
	{
		private readonly VillageMap map;

		[SerializeField]
		private string blueprintID;

		[SerializeField]
		private SiegeWeaponProjectileBlueprint blueprint;

		[SerializeField]
		private SiegeWeaponComponentInstance siegeWeaponComponentInstance;

		private BezierProjectileTrajectory bezierProjectileTrajectory;

		[SerializeField]
		private float projectileHp;

		[SerializeField]
		private float projectileMaxHp;

		public SiegeWeaponProjectileBlueprint Blueprint => blueprint;

		public bool HasDisposed { get; protected set; }

		public StatsInstance Stats => null;

		public bool HasDied => HasDisposed;

		public bool HasActivePath => false;

		public VillageMap Map => map;

		public bool ForbidWeapon { get; set; }

		public CombatAiAgent CombatAi => null;

		public int CurrentAttackStream { get; set; }

		public bool FlammableProjectilesAllowed => false;

		public bool IsOnFire => false;

		public event Action<IGameDisposable> OnDisposedEvent;

		public SiegeWeaponProjectileInstance(SiegeWeaponProjectileBlueprint blueprint, SiegeWeaponComponentInstance siegeWeaponComponentInstance, BezierProjectileTrajectory bezierProjectileTrajectory)
		{
			blueprintID = blueprint.GetID();
			this.blueprint = Repository<SiegeWeaponProjectileRepository, SiegeWeaponProjectileBlueprint>.Instance.GetByID(blueprintID);
			this.siegeWeaponComponentInstance = siegeWeaponComponentInstance;
			this.bezierProjectileTrajectory = bezierProjectileTrajectory;
			projectileHp = this.siegeWeaponComponentInstance.ProjectileHp;
			projectileMaxHp = this.siegeWeaponComponentInstance.ProjectileMaxHp;
			map = VillageManager.ActiveVillage.Map;
			this.bezierProjectileTrajectory.ProjectileHitEvent += OnProjectileHit;
			this.bezierProjectileTrajectory.CreatureHitEvent += OnCreatureHit;
			this.bezierProjectileTrajectory.DestinationReachedEvent += OnDestinationReached;
		}

		public void Dispose()
		{
			if (!HasDisposed)
			{
				if (bezierProjectileTrajectory != null)
				{
					bezierProjectileTrajectory.ProjectileHitEvent -= OnProjectileHit;
					bezierProjectileTrajectory.CreatureHitEvent -= OnCreatureHit;
					bezierProjectileTrajectory.DestinationReachedEvent -= OnDestinationReached;
				}
				HasDisposed = true;
				this.OnDisposedEvent?.Invoke(this);
				this.OnDisposedEvent = null;
				blueprint = null;
				siegeWeaponComponentInstance = null;
			}
		}

		public Vector3 GetPosition()
		{
			return Vector3.zero;
		}

		public Vec3Int GetGridPosition()
		{
			return Vec3Int.zero;
		}

		public List<EquipmentInstance> GetEquipment()
		{
			return null;
		}

		public Transform GetTransform()
		{
			throw new NotImplementedException();
		}

		public MapNode GetNode()
		{
			return null;
		}

		public float GetBaseDamageOverride(DamageTakingAgentType targetType)
		{
			switch (targetType)
			{
			case DamageTakingAgentType.Building:
			case DamageTakingAgentType.Trebuchet:
				return blueprint.BuildingDamage;
			case DamageTakingAgentType.ResourcePile:
				return blueprint.PileDamage;
			case DamageTakingAgentType.None:
				return 0.1f;
			default:
				return blueprint.CreatureDamage;
			}
		}

		public DamageTakingAgentType CanAttackTypes()
		{
			return DamageTakingAgentType.None;
		}

		public IDamageTakingAgent GetTarget()
		{
			return null;
		}

		public void SetTarget(IDamageTakingAgent target)
		{
		}

		public void FaceTarget()
		{
		}

		public void FaceObject(Vector3 position)
		{
		}

		public void SetWeaponVisibility(bool isVisible)
		{
		}

		public Transform GetWeaponTransform(int slot)
		{
			return null;
		}

		public bool IsNextRoundFlammable()
		{
			return false;
		}

		public void SetNextRoundFlammable(bool isNextFlammable, bool ignoreAllowed = false)
		{
		}

		public bool ConsumeFlammableRound()
		{
			return false;
		}

		private void OnCreatureHit(CreatureBase creatureHit, float damageMultiplier)
		{
			float falloff = blueprint.DamageFalloff;
			CombatHitInfo info = CombatHitManager.DealDamage(this, creatureHit, DamageType.Ranged, (float damage) => (damage - damage * falloff) * damageMultiplier);
			DamagePopup.Create(info, creatureHit.GetPosition());
			Transform transform = creatureHit.GetTransform();
			if (!info.HasBlocked && transform != null)
			{
				transform.GetComponent<HitEffect>()?.OnHit();
			}
		}

		private void OnProjectileHit(Vector3 target, float damageMultiplier, bool spawnPile)
		{
			MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(blueprint.HitParticle, target);
			MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition(blueprint.ImpactAudioEvent, target);
			switch (siegeWeaponComponentInstance.Blueprint.SiegeWeaponType)
			{
			case SiegeWeaponType.Trebuchet:
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(target, CameraShakeStrength.Strong);
				break;
			case SiegeWeaponType.Ballista:
			case SiegeWeaponType.Onager:
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(target, CameraShakeStrength.Mild);
				break;
			}
			float radius = blueprint.ProjectileHitRadius;
			float falloff = blueprint.DamageFalloff;
			MonoSingleton<GroundManager>.Instance.DamageVoxel(target, (short)(blueprint.GroundDamage * damageMultiplier), radius, falloff);
			float radiusPow2 = radius * radius;
			List<IDamageTakingAgent> targetsInRange = CombatUtils.GetTargetsInRangeForSiegeWeapon(target, radius * 3f, (IDamageTakingAgent agent2) => SelectObjectsInRadius(agent2, target, radiusPow2));
			AddRoofs(ref targetsInRange, target, radius);
			foreach (IDamageTakingAgent agent in targetsInRange)
			{
				CombatHitInfo info = CombatHitManager.DealDamage(this, agent, DamageType.Ranged, delegate(float damage)
				{
					Vector3 position = agent.GetPosition();
					float num = 1f;
					if (agent is BaseBuildingInstance { BuildingType: BuildingType.Roof } baseBuildingInstance)
					{
						RoofComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<RoofComponentInstance>();
						if (componentInstance != null)
						{
							num = (((componentInstance.End - componentInstance.Start).x != 0) ? Mathf.Clamp01(target.DistanceYZ(position) / radius) : Mathf.Clamp01(target.DistanceXY(position) / radius));
						}
					}
					else
					{
						num = Mathf.Clamp01(Vector3.Distance(target, position + Vector3.up * 0.5f) / radius);
					}
					return (damage - damage * num * falloff) * damageMultiplier;
				});
				DamagePopup.Create(info, agent.GetPosition());
				Transform transform = agent.GetTransform();
				if (!info.HasBlocked && transform != null)
				{
					transform.GetComponent<HitEffect>()?.OnHit();
				}
			}
			OnDestinationReached(target);
		}

		private void OnDestinationReached(Vector3 hitPoint)
		{
			if (map.IsBlockInRange(hitPoint.ToGridVec3Int()))
			{
				Vector3 vector = bezierProjectileTrajectory.StartPos.ToVector3World();
				Vector3 normalized = (hitPoint - vector).normalized;
				Vec3Int vec3Int = hitPoint.ToGridVec3Int() + Vec3Int.down;
				if (MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int) || map.BuildingsManagerMain.FinishedBuildingVerticalStabilityCarrierExits(vec3Int))
				{
					using PooledList<Vec3Int> positions = GetHorizontalImpactPositions(hitPoint, normalized);
					map.SiegeWeaponComponentManager?.ProjectileImpactSpawnerHorizontal(positions, blueprint);
					Vector3 vector2 = new Vector3(normalized.x, 0f, normalized.z);
					Vec3Int vec3Int2 = (hitPoint - vector2).ToGridVec3Int() + Vec3Int.down;
					if (!MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int2) && !map.BuildingsManagerMain.FinishedBuildingVerticalStabilityCarrierExits(vec3Int2))
					{
						using PooledList<Vec3Int> orderedSpawnPoints = GetDownwardSpreadPositions(hitPoint, normalized);
						map?.SiegeWeaponComponentManager?.ProjectileImpactSpawnerVertical(orderedSpawnPoints, blueprint);
					}
				}
				else
				{
					using PooledList<Vec3Int> orderedSpawnPoints2 = GetDownwardSpreadPositions(hitPoint, normalized);
					map?.SiegeWeaponComponentManager?.ProjectileImpactSpawnerVertical(orderedSpawnPoints2, blueprint);
				}
				TrySpawnProjectilePile(hitPoint);
			}
			Dispose();
		}

		private static bool SelectObjectsInRadius(IDamageTakingAgent agent, Vector3 searchAroundPoint, float radiusPow2)
		{
			if (agent is BaseBuildingInstance { HasDisposed: false } baseBuildingInstance && !string.IsNullOrEmpty(baseBuildingInstance.Blueprint.SiegeWeaponComponentID))
			{
				Vec3Int item = searchAroundPoint.ToGridVec3Int();
				if (baseBuildingInstance.Positions.Contains(item))
				{
					return true;
				}
			}
			float num = Mathf.Floor(Mathf.Abs(searchAroundPoint.x - agent.GetPosition().x));
			float num2 = Mathf.Floor(Mathf.Abs(searchAroundPoint.y - agent.GetPosition().y - (float)World.MapBlockHeight / 2f));
			float num3 = Mathf.Floor(Mathf.Abs(searchAroundPoint.z - agent.GetPosition().z));
			return num * num + num2 * num2 + num3 * num3 <= radiusPow2;
		}

		private void AddRoofs(ref List<IDamageTakingAgent> targetsInRange, Vector3 target, float radius)
		{
			int num = Mathf.CeilToInt(radius);
			Vector3 worldPosition = default(Vector3);
			for (int i = -num; i <= num; i++)
			{
				worldPosition.x = target.x + (float)i;
				for (int j = -num; j <= num; j++)
				{
					worldPosition.z = target.z + (float)j;
					for (int k = -num; k <= num; k += World.MapBlockHeight)
					{
						worldPosition.y = target.y + (float)k;
						RoofComponentInstance roofComponentInstance = Map?.RoofComponentManager?.GetComponentInstance(GridUtils.GetGridPosition(worldPosition));
						if (roofComponentInstance != null)
						{
							BaseBuildingInstance ownerBuilding = roofComponentInstance.OwnerBuilding;
							if (!targetsInRange.Contains(ownerBuilding))
							{
								targetsInRange.Add(ownerBuilding);
							}
						}
					}
				}
			}
		}

		private void TrySpawnProjectilePile(Vector3 hitPoint)
		{
			if (!blueprint.SpawnPileOnImpact)
			{
				return;
			}
			float num = projectileMaxHp * blueprint.ProjectileDamageOnImpact;
			float num2 = projectileHp - num;
			if (!(num2 < 1f))
			{
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintID);
				ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(byID, 1), hitPoint, forbidOnInit: true);
				if (resourcePileView != null)
				{
					resourcePileView.ResourcePileInstance.GetStat(StatType.Health)?.SetCurrent(num2);
				}
			}
		}

		[MustDisposeResource]
		public PooledList<Vec3Int> GetHorizontalImpactPositions(Vector3 hitPoint, Vector3 originalDirection)
		{
			if (HasDisposed || map?.BuildingsManagerMain == null)
			{
				return ListPool<Vec3Int>.GetJanitor();
			}
			Vector3 vector = new Vector3(originalDirection.x, 0f, originalDirection.z);
			Vector3 vector2 = hitPoint - vector;
			float groundHitMinRaycastLength = blueprint.GroundHitMinRaycastLength;
			float groundHitMaxRaycastLength = blueprint.GroundHitMaxRaycastLength;
			float groundHitSpreadAngle = blueprint.GroundHitSpreadAngle;
			int num = (int)(groundHitSpreadAngle / 10f);
			float num2 = groundHitSpreadAngle / (float)num;
			LayerMask layerMask = (1 << LayerMask.NameToLayer("CombatCover")) | (1 << LayerMask.NameToLayer("VoxelMap"));
			HashSet<Vec3Int> hashSet = new HashSet<Vec3Int>();
			Vec3Int vec3Int = hitPoint.ToGridVec3Int();
			if (map.BuildingsManagerMain.BuildingExists(vec3Int))
			{
				hashSet.Add(vec3Int);
			}
			for (int i = 0; i <= num; i++)
			{
				float num3 = (float)i / (float)num;
				float num4 = ((num3 <= 0.5f) ? (num3 * 2f) : ((1f - num3) * 2f));
				float num5 = groundHitMinRaycastLength + (groundHitMaxRaycastLength - groundHitMinRaycastLength) * num4;
				Vector3 vector3 = Quaternion.AngleAxis((0f - groundHitSpreadAngle) / 2f + (float)i * num2, Vector3.up) * vector;
				if (Physics.Raycast(vector2 + new Vector3(0f, 0.2f, 0f), vector3, out var hitInfo, num5, layerMask))
				{
					for (float num6 = 0f; num6 <= 1f; num6 += 0.1f)
					{
						Vec3Int vec3Int2 = Vector3.Lerp(vector2, hitInfo.point, num6).ToGridVec3Int();
						if (!CheckPosition(vec3Int2))
						{
							break;
						}
						hashSet.Add(vec3Int2);
					}
					continue;
				}
				for (float num7 = 0f; num7 <= 1f; num7 += 0.1f)
				{
					Vec3Int vec3Int3 = Vector3.Lerp(vector2, vector2 + vector3 * (num5 - 1f), num7).ToGridVec3Int();
					if (!CheckPosition(vec3Int3))
					{
						break;
					}
					hashSet.Add(vec3Int3);
				}
			}
			Vec3Int gridHitPos = vector2.ToGridVec3Int();
			return (from pos in ListPool<Vec3Int>.GetJanitor(hashSet)
				orderby Vec3Int.Distance(in gridHitPos, in pos)
				select pos).ToPooledListJanitor();
			bool CheckPosition(Vec3Int gridPos)
			{
				MapNode node = map.GetNode(gridPos);
				if (node == null)
				{
					return false;
				}
				if (node.IsVoxelAir() && node.BuildingType == (BuildingType)0 && !node.IsWalkable)
				{
					return false;
				}
				if (!map.IsBlockInRange(gridPos))
				{
					return false;
				}
				return true;
			}
		}

		[MustDisposeResource]
		private PooledList<Vec3Int> GetDownwardSpreadPositions(Vector3 hitPosition, Vector3 incomingDirection)
		{
			Direction cardinalDirection = GetCardinalDirection(incomingDirection);
			Vec3Int position = hitPosition.ToGridVec3Int();
			int num = blueprint.WallHitGroundHorizontalRange;
			PooledList<Vec3Int> spawnPositions = ListPool<Vec3Int>.GetJanitor();
			try
			{
				TryAddBuildingToSpawnPositions(position);
				int wallHitHorizontalRange = blueprint.WallHitHorizontalRange;
				switch (cardinalDirection)
				{
				case Direction.North:
				{
					for (int m = position.x - wallHitHorizontalRange; m <= position.x + wallHitHorizontalRange; m++)
					{
						Vec3Int position4 = new Vec3Int(m, position.y, position.z);
						TryAddBuildingToSpawnPositions(position4);
					}
					int num6 = 1;
					while (num >= 0)
					{
						for (int n = position.x - num; n <= position.x + num; n++)
						{
							int z2 = position.z - num6;
							for (int num7 = position.y; num7 >= 0; num7--)
							{
								Vec3Int vec3Int3 = new Vec3Int(n, num7, z2);
								if (map.IsBlockInRange(vec3Int3))
								{
									MapNode node3 = map.GetNode(vec3Int3);
									if (node3 != null && node3.IsWalkable)
									{
										spawnPositions.Add(vec3Int3);
										break;
									}
									if (node3.DataType.HasFlag(GridDataType.Roof))
									{
										spawnPositions.Add(vec3Int3);
										break;
									}
								}
							}
						}
						num6++;
						num--;
					}
					break;
				}
				case Direction.East:
				{
					for (int num8 = position.z - wallHitHorizontalRange; num8 <= position.z + wallHitHorizontalRange; num8++)
					{
						Vec3Int position5 = new Vec3Int(position.x, position.y, num8);
						TryAddBuildingToSpawnPositions(position5);
					}
					int num9 = 0;
					while (num >= 0)
					{
						for (int num10 = position.z - num; num10 <= position.z + num; num10++)
						{
							int x2 = position.x - num9;
							for (int num11 = position.y; num11 >= 0; num11--)
							{
								Vec3Int vec3Int4 = new Vec3Int(x2, num11, num10);
								if (map.IsBlockInRange(vec3Int4))
								{
									MapNode node4 = map.GetNode(vec3Int4);
									if (node4 != null && node4.IsWalkable)
									{
										spawnPositions.Add(vec3Int4);
										break;
									}
									if (node4.DataType.HasFlag(GridDataType.Roof))
									{
										spawnPositions.Add(vec3Int4);
										break;
									}
								}
							}
						}
						num9++;
						num--;
					}
					break;
				}
				case Direction.South:
				{
					for (int k = position.x - wallHitHorizontalRange; k <= position.x + wallHitHorizontalRange; k++)
					{
						Vec3Int position3 = new Vec3Int(k, position.y, position.z);
						TryAddBuildingToSpawnPositions(position3);
					}
					int num4 = 0;
					while (num >= 0)
					{
						for (int l = position.x - num; l <= position.x + num; l++)
						{
							int z = position.z + num4;
							for (int num5 = position.y; num5 >= 0; num5--)
							{
								Vec3Int vec3Int2 = new Vec3Int(l, num5, z);
								if (map.IsBlockInRange(vec3Int2))
								{
									MapNode node2 = map.GetNode(vec3Int2);
									if (node2 != null && node2.IsWalkable)
									{
										spawnPositions.Add(vec3Int2);
										break;
									}
									if (node2.DataType.HasFlag(GridDataType.Roof))
									{
										spawnPositions.Add(vec3Int2);
										break;
									}
								}
							}
						}
						num4++;
						num--;
					}
					break;
				}
				case Direction.West:
				{
					for (int i = position.z - wallHitHorizontalRange; i <= position.z + wallHitHorizontalRange; i++)
					{
						Vec3Int position2 = new Vec3Int(position.x, position.y, i);
						TryAddBuildingToSpawnPositions(position2);
					}
					int num2 = 0;
					while (num >= 0)
					{
						for (int j = position.z - num; j <= position.z + num; j++)
						{
							int x = position.x + num2;
							for (int num3 = position.y; num3 >= 0; num3--)
							{
								Vec3Int vec3Int = new Vec3Int(x, num3, j);
								if (map.IsBlockInRange(vec3Int))
								{
									MapNode node = map.GetNode(vec3Int);
									if (node != null && node.IsWalkable)
									{
										spawnPositions.Add(vec3Int);
										break;
									}
									if (node.DataType.HasFlag(GridDataType.Roof))
									{
										spawnPositions.Add(vec3Int);
										break;
									}
								}
							}
						}
						num2++;
						num--;
					}
					break;
				}
				}
				return spawnPositions.OrderByDescending((Vec3Int pos) => pos.y).ToPooledListJanitor();
			}
			finally
			{
				((IDisposable)spawnPositions/*cast due to .constrained prefix*/).Dispose();
			}
			void TryAddBuildingToSpawnPositions(Vec3Int vec3Int5)
			{
				if (map.BuildingsManagerMain.BuildingExists(vec3Int5))
				{
					spawnPositions.Add(vec3Int5);
				}
			}
		}

		private static Direction GetCardinalDirection(Vector3 direction)
		{
			direction = direction.normalized;
			float num = Mathf.Atan2(direction.x, direction.z) * 57.29578f;
			num = (num + 360f) % 360f;
			if (num >= 45f && num < 135f)
			{
				return Direction.East;
			}
			if (num >= 135f && num < 225f)
			{
				return Direction.South;
			}
			if (num >= 225f && num < 315f)
			{
				return Direction.West;
			}
			return Direction.North;
		}
	}
}
