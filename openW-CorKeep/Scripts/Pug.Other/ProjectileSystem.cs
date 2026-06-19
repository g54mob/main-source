using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerCommand;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using PugTilemap.Quads;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateBefore(typeof(TileDamageSystem))]
[UpdateAfter(typeof(ProjectileMovementSystem))]
[UpdateBefore(typeof(ConditionEffectsUpdateSystemGroup))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
public struct ProjectileSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	[WithAll(new Type[]
	{
		typeof(Simulate),
		typeof(ProjectileCD)
	})]
	private struct UpdateProjectileJob : IJobEntity, IJobChunk
	{
		public struct Line
		{
			public float2 Point1;

			public float2 Point2;
		}

		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ProjectileAspect.TypeHandle __ProjectileAspect_RW_AspectTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ProjectileAspect_RW_AspectTypeHandle = new ProjectileAspect.TypeHandle(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ProjectileAspect_RW_AspectTypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProjectileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAspect<ProjectileAspect>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref UpdateProjectileJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateProjectileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateProjectileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateProjectileJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateProjectileJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateProjectileJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		public TileAccessor tileAccessor;

		public AttackSystem.Helper attackHelper;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public Entity tileDamageBufferEntity;

		public Entity effectEventBufferSingleton;

		public int deathAnim;

		public uint tickRate;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public bool isServer;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup;

		public ConditionsTableCD conditionsTable;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<PaintableObjectCD> paintableObjectLookup;

		[ReadOnly]
		public NativeArray<float2> normals;

		[ReadOnly]
		public ComponentLookup<TileColliderCD> tileCollLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionlLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ProjectileAspect projectileAspect, in BehaviourTagsCD attackTags, in GhostInstance ghostInstance, in ObjectPropertiesCD properties)
		{
			ref ProjectileCD valueRW = ref attackHelper.projectileLookup.GetRefRW(entity).ValueRW;
			RefRW<PiercingProjectileCD> refRW = attackHelper.piercingProjectileLookup.GetRefRW(entity);
			if (float.IsNaN(valueRW.directionRadians))
			{
				valueRW.directionRadians = projectileAspect.projectileSetup.ValueRO.directionRadians;
			}
			if (NetworkTimeUtilities.IsSpawnTickForBeginECBCreatedGhost(in ghostInstance, currentTick, isServer))
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			if (ownerLookup.TryGetComponent(entity, out var componentData))
			{
				flag = petLookup.HasComponent(componentData.owner);
				flag2 = attackHelper.playerGhostLookup.HasComponent(componentData.owner);
			}
			if (!isServer && !flag2)
			{
				return;
			}
			HealthCD healthCD = attackHelper.healthLookup[entity];
			if (healthCD.health <= 0)
			{
				return;
			}
			bool flag3 = projectileAspect.groundBouncableProjectileCD.IsValid && projectileAspect.groundBouncableProjectileCD.ValueRO.startFallTick.IsValid;
			bool flag4 = !flag3;
			if (projectileAspect.continouslyDamaging.IsValid)
			{
				ref ContinouslyDamagingProjectileCD valueRW2 = ref projectileAspect.continouslyDamaging.ValueRW;
				if (valueRW2.attackCooldown.isRunning && !valueRW2.attackCooldown.IsTimerElapsed(currentTick))
				{
					return;
				}
				valueRW2.attackCooldown.Start(currentTick, projectileAspect.continouslyDamaging.ValueRO.attackEveryXSecond, tickRate);
			}
			float2 xz = attackHelper.localTransformLookup[entity].Position.xz;
			float2 prevPos = valueRW.prevPos;
			bool flag5 = projectileAspect.bouncing.IsValid && projectileAspect.bouncing.ValueRO.bounceCount < projectileAspect.bouncing.ValueRO.maxBounceCount;
			NativeList<TileHitInfo> tilesToCheck = new NativeList<TileHitInfo>(2, Allocator.Temp);
			float2 minPos = prevPos;
			float2 maxPos = xz;
			EntityUtility.TileRayCastType type = (flag3 ? EntityUtility.TileRayCastType.Solid : (properties.Has(1509333117) ? EntityUtility.TileRayCastType.NonWalkable : EntityUtility.TileRayCastType.Walls));
			RaycastTiles(type, in valueRW, minPos, maxPos, tilesToCheck);
			bool damagesTiles = projectileAspect.DamagesTiles;
			DynamicBuffer<ProjectilePiercesWallTypesBuffer> piercesWallTypes = projectileAspect.piercesWallTypes;
			bool flag6 = false;
			bool flag7 = false;
			DynamicBuffer<TileDamageBuffer> tileDamageBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
			foreach (TileHitInfo item in tilesToCheck)
			{
				int2 tile = item.tile;
				TileCD top = tileAccessor.GetTop(tile);
				int tileset = top.tileset;
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(PugDatabase.GetObjectID(top.tileset, top.tileType, databaseBankCD.databaseBankBlob), databaseBankCD.databaseBankBlob);
				if (primaryPrefabEntity != Entity.Null && paintableObjectLookup.HasComponent(primaryPrefabEntity) && tileLookup.TryGetComponent(primaryPrefabEntity, out var componentData2))
				{
					tileset = componentData2.tileset;
				}
				for (int i = 0; i < piercesWallTypes.Length; i++)
				{
					if (piercesWallTypes[i].tileset == (Tileset)tileset && !tileAccessor.HasType(tile, TileType.immune))
					{
						ClientSystem.CreateTileDamage(entity, tileDamageBuffer, tile, 1000, in attackHelper.worldInfo, default(Entity), canDamageGround: false, pullAnyLootToPlayer: false, damagedByExplosion: false, dontPlayDamageTileEffect: false);
						flag6 = true;
						break;
					}
				}
				flag7 = flag7 || !flag6;
				if (flag7 && damagesTiles)
				{
					ClientSystem.CreateTileDamage(entity, tileDamageBuffer, tile, 1000, in attackHelper.worldInfo, default(Entity), canDamageGround: false, pullAnyLootToPlayer: false, damagedByExplosion: false, dontPlayDamageTileEffect: false);
				}
			}
			float2 float5 = valueRW.GetDirection();
			if (!flag7)
			{
				float damageRadiusClient = valueRW.damageRadiusClient;
				float2 x = xz - valueRW.prevPos;
				float2 v257 = math.normalizesafe(x, float5);
				NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(10, Allocator.Temp);
				CollisionWorld collisionWorld = attackHelper.physicsWorld.CollisionWorld;
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				};
				if (collisionWorld.SphereCastAll(prevPos.X0Y(), damageRadiusClient * 0.1f, v257.X0Y(), math.length(x), ref outHits, filter))
				{
					for (int j = 0; j < outHits.Length; j++)
					{
						Entity entity2 = outHits[j].Entity;
						if (attackHelper.entityPartLookup.TryGetComponent(entity2, out var componentData3))
						{
							entity2 = componentData3.mainEntity;
						}
						if (outHits[j].Entity != componentData.owner && entity2 != componentData.owner && !tileLookup.HasComponent(entity2) && !enemyLookup.HasComponent(entity2) && attackHelper.localTransformLookup.HasComponent(entity2))
						{
							flag7 = true;
							break;
						}
					}
				}
				outHits.Dispose();
			}
			float attackTime = 2f / (float)tickRate;
			float2 float6 = valueRW.prevPrevPos - xz;
			float2 float7 = xz - valueRW.prevPos;
			float2 float8 = -float6 + float7;
			float num = math.length(float8);
			if (flag7)
			{
				num = math.length(float8 - float7);
			}
			int damage = projectileAspect.projectileSetup.ValueRO.damage;
			bool isMagic = projectileAspect.projectileSetup.ValueRO.isMagic;
			bool flag8 = flag5 && (attackHelper.explodeStateLookup.HasComponent(entity) || properties.Has(1231997547));
			AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
			{
				effectEventBufferSingleton = effectEventBufferSingleton,
				attacker = entity,
				skipHitsOnEntity = (projectileAspect.continouslyDamaging.IsValid ? Entity.Null : valueRW.lastHitEnemy),
				isRanged = true,
				attackOffset = 0.5f * math.up() + float6.X0Y(),
				radius = valueRW.damageRadius,
				castDirection = math.normalizesafe(float8.X0Y()),
				castDistance = num,
				damage = damage,
				playerDamage = damage,
				triggerAnimationOnClientHit = ((!projectileAspect.CanPierceOneMoreEnemy(refRW) && (!flag5 || flag8)) ? deathAnim : 0),
				sameFactionHealingPercentage = (projectileAspect.healing.IsValid ? projectileAspect.healing.ValueRO.sameFactionHealingPercentage : 0f),
				canOnlyAttackType = (flag ? CanOnlyAttackType.EnemyAndPlayer : CanOnlyAttackType.All),
				behaviourTags = attackTags,
				isMagic = isMagic,
				treatDodgeAsHit = projectileAspect.TreatDodgeAsHit,
				isPredicted = flag2,
				attackTime = attackTime,
				useDefaultCastDistanceForRpcAttack = false
			};
			if (flag7 && !projectileAspect.SurviveCollision && !flag5)
			{
				p.ignoreLastPlayerHit = true;
				if (flag4)
				{
					attackHelper.Attack(ecb, in p);
				}
				attackHelper.healthLookup[entity] = new HealthCD
				{
					health = 0,
					maxHealth = healthCD.maxHealth
				};
				if (projectileAspect.ShatterOnCollision)
				{
					float3 float9 = attackHelper.localTransformLookup[entity].Position + (float5 * projectileAspect.Speed * (1f / 30f)).X0Y();
					ShatterOnCollisionProjectileCD valueRO = projectileAspect.shatterOnCollision.ValueRO;
					ObjectID shardObjectID = valueRO.shardObjectID;
					int shards = valueRO.shards;
					int damage2 = damage / shards;
					ownerLookup.TryGetComponent(entity, out var componentData4);
					bool setGhostOwner = attackHelper.ghostOwnerLookup.HasComponent(entity);
					for (int k = 0; k < shards; k++)
					{
						float x2 = MathF.PI / (float)shards * (1f + 2f * (float)k);
						float3 float10 = new float3(math.cos(x2), 0f, math.sin(x2));
						float3 position = float9 + float10 * 0.5f;
						RefRW<RandomCD> refRW2 = attackHelper.randomLookup.GetRefRW(entity);
						EntityUtility.SpawnProjectile(attackHelper.ghostOwnerLookup, behaviourTagsLookup, summarizedConditionBufferLookup, factionLookup, ecb, position, databaseBankCD.databaseBankBlob, shardObjectID, damage2, 0f, float10, componentData4.owner, conditionsTable, shotFromReinforcedWeapon: false, projectileAspect.projectileSourceSetup.ValueRO.weaponLevel, ref refRW2.ValueRW.Value, attackHelper.piercingProjectileLookup, setGhostOwner);
					}
				}
				return;
			}
			if (projectileAspect.DamagesTiles)
			{
				NativeList<int2> list = new NativeList<int2>(4, Allocator.Temp);
				float2 x3 = xz;
				float tileDamageRadius = valueRW.tileDamageRadius;
				int[] fourWay = AdjacentDir.fourWay;
				for (int l = 0; l < fourWay.Length; l++)
				{
					int2 value = (int2)math.round(x3.RoundToInt2() + (float2)AdjacentDir.GetInt2(fourWay[l]) * tileDamageRadius);
					if (!list.Contains(value))
					{
						list.Add(in value);
					}
				}
				for (int m = 0; m < list.Length; m++)
				{
					int2 int5 = list[m];
					int tileset2 = tileAccessor.GetTop(int5).tileset;
					bool flag9 = false;
					for (int n = 0; n < piercesWallTypes.Length; n++)
					{
						if (tileset2 == (int)piercesWallTypes[n].tileset)
						{
							flag9 = true;
							break;
						}
					}
					if (flag9)
					{
						tileDamageBuffer.Add(new TileDamageBuffer
						{
							damage = 1000,
							position = int5,
							skipWallAndRootsLootDropOnDestroy = false,
							canHitGround = false,
							dontHitBridges = true,
							causedByEntity = entity,
							canHitLowColliders = false
						});
					}
				}
				list.Dispose();
			}
			bool flag10 = false;
			if (flag4 && attackHelper.Attack(ecb, in p, out var hitPosition, out var hitEntity))
			{
				valueRW.lastHitEnemy = hitEntity;
				flag10 = true;
				if (!flag5 && refRW.IsValid)
				{
					refRW.ValueRW.currentPiercedEnemiesCount++;
				}
				if (!projectileAspect.PiercesEnemies(refRW) && !flag5)
				{
					attackHelper.localTransformLookup[entity] = LocalTransform.FromPosition(hitPosition);
					attackHelper.healthLookup[entity] = new HealthCD
					{
						health = 0,
						maxHealth = healthCD.maxHealth
					};
				}
				if (flag10 && flag8)
				{
					attackHelper.healthLookup[entity] = new HealthCD
					{
						health = 0,
						maxHealth = healthCD.maxHealth
					};
				}
			}
			if (flag5 && (flag7 || flag10))
			{
				bool flag11 = false;
				CollisionWorld collisionWorld2 = attackHelper.physicsWorld.CollisionWorld;
				float2 x4 = xz - prevPos;
				float2 v258 = math.normalizesafe(x4, float5);
				float damageRadiusClient2 = valueRW.damageRadiusClient;
				uint collidesWith = 29u;
				CollisionFilter filter2 = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = collidesWith
				};
				CollisionFilter filter3 = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				};
				float num2 = math.length(x4);
				if ((flag10 ? collisionWorld2.SphereCast(xz.X0Y() + new float3(0f, 0.5f, 0f), valueRW.damageRadius, math.normalizesafe(float8.X0Y()), num, out var hitInfo, filter2) : collisionWorld2.SphereCast(prevPos.X0Y() + new float3(0f, 0.5f, 0f), damageRadiusClient2 * 0.1f, v258.X0Y(), num2, out hitInfo, filter3)) && (!tileCollLookup.HasComponent(hitInfo.Entity) || !tileCollLookup.IsComponentEnabled(hitInfo.Entity)))
				{
					float3 x5 = math.normalizesafe(new float3(hitInfo.SurfaceNormal.x, 0f, hitInfo.SurfaceNormal.z));
					float num3 = -2f * math.dot(x5, v258.X0Y());
					float3 float11 = math.normalizesafe(new float3(num3 * x5.x + v258.x, 0f, num3 * x5.z + v258.y));
					if (projectileAspect.bouncing.IsValid)
					{
						projectileAspect.bouncing.ValueRW.bounceCount++;
						projectileAspect.bouncing.ValueRW.prevBounceTile = int2.zero;
					}
					float5 = float11.xz;
					valueRW.SetDirection(float11);
					if (!flag10)
					{
						LocalTransform value2 = attackHelper.localTransformLookup[entity];
						value2.Position = prevPos.X0Y() + v258.X0Y() * num2 * hitInfo.Fraction + float11 * num2 * (1f - hitInfo.Fraction);
						attackHelper.localTransformLookup[entity] = value2;
						valueRW.prevPos = prevPos;
						valueRW.prevPrevPos = prevPos;
					}
					flag11 = true;
				}
				if (!flag11 && tilesToCheck.Length > 0)
				{
					float2 normal = float2.zero;
					float closestTileDistance = float.MaxValue;
					TileHitInfo tileCollidedWith = default(TileHitInfo);
					float2 float12 = prevPos - float5 * valueRW.damageRadiusClient * 0.1f;
					float2 rayDirection = xz + float5 * valueRW.damageRadiusClient * 0.1f - float12;
					float2 rayOrigin = float12;
					bool isValid = projectileAspect.bouncing.IsValid;
					int2 prevBounceTile = projectileAspect.bouncing.ValueRO.prevBounceTile;
					EntityUtility.CheckIfIntersectedTile(tilesToCheck, normals, in prevPos, in rayOrigin, in rayDirection, ref closestTileDistance, ref normal, ref tileCollidedWith, isValid, prevBounceTile);
					if (!normal.Equals(float2.zero))
					{
						float2 float13 = math.normalizesafe(math.reflect(rayDirection, normal));
						float5 = float13;
						valueRW.SetDirection(float13);
						if (projectileAspect.bouncing.IsValid)
						{
							projectileAspect.bouncing.ValueRW.bounceCount++;
							projectileAspect.bouncing.ValueRW.prevBounceTile = tileCollidedWith.tile;
						}
						float2 point = tileCollidedWith.point;
						float num4 = math.length(prevPos - point);
						float num5 = math.length(xz - prevPos);
						float num6 = num4 / num5;
						LocalTransform value3 = attackHelper.localTransformLookup[entity];
						float2 float14 = point + normal * 0.01f;
						float2 float15 = point + float13 * num5 * (1f - num6);
						tilesToCheck.Clear();
						RaycastTiles(type, in valueRW, float14, float15, tilesToCheck);
						if (tilesToCheck.Length > 0)
						{
							value3.Position = float14.X0Y();
						}
						else
						{
							value3.Position = float15.X0Y();
						}
						attackHelper.localTransformLookup[entity] = value3;
						valueRW.prevPos = prevPos;
						valueRW.prevPrevPos = prevPos;
						flag11 = true;
					}
				}
				if (flag11 && !flag10)
				{
					valueRW.lastHitEnemy = Entity.Null;
				}
			}
			if (projectileAspect.ZigZag)
			{
				ref ZigZagProjectileCD valueRW3 = ref projectileAspect.zigZag.ValueRW;
				if (!valueRW3.timer.isRunning || valueRW3.timer.IsTimerElapsed(currentTick))
				{
					valueRW3.timer.Start(currentTick, 10f, tickRate);
				}
				float num7 = 25f;
				float num8 = 0.4f;
				float directionRadians = projectileAspect.projectileSetup.ValueRO.directionRadians;
				float2 float16 = new float2(math.cos(directionRadians), math.sin(directionRadians));
				float2 float17 = math.normalizesafe(new float2(0f - float16.y, float16.x));
				float elapsedSeconds = valueRW3.timer.GetElapsedSeconds(currentTick, tickRate);
				float num9 = ((elapsedSeconds == 0f) ? 0.01f : elapsedSeconds);
				float5 = float16 + float17 * (math.sin(num9 * num7) * num8);
				valueRW.SetDirection(float5);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RaycastTiles(EntityUtility.TileRayCastType type, in ProjectileCD projectile, float2 minPos, float2 maxPos, NativeList<TileHitInfo> tilesToCheck)
		{
			if (projectile.tileDamageRadius > 0f)
			{
				float2 float5 = math.normalizesafe(maxPos - minPos);
				minPos -= float5 * projectile.tileDamageRadius;
				maxPos += float5 * projectile.tileDamageRadius;
				float2 float6 = math.normalizesafe(math.cross(float5.ToFloat3(), math.up()).ToFloat2());
				minPos -= float6 * projectile.tileDamageRadius;
				maxPos -= float6 * projectile.tileDamageRadius;
				float2 x = maxPos - minPos;
				float distance = math.length(x);
				EntityUtility.DoRayCast(type, minPos, math.normalizesafe(x), distance, tileAccessor, tilesToCheck);
				minPos += float6 * projectile.tileDamageRadius * 2f;
				maxPos += float6 * projectile.tileDamageRadius * 2f;
			}
			float2 x2 = maxPos - minPos;
			float distance2 = math.length(x2);
			EntityUtility.DoRayCast(type, minPos, math.normalizesafe(x2), distance2, tileAccessor, tilesToCheck);
		}

		private bool FindIntersection(Line lineA, Line lineB, out float2 intersection, double tolerance = 0.001)
		{
			intersection = float2.zero;
			double num = lineA.Point1.x;
			double num2 = lineA.Point1.y;
			double num3 = lineA.Point2.x;
			double num4 = lineA.Point2.y;
			double num5 = lineB.Point1.x;
			double num6 = lineB.Point1.y;
			double num7 = lineB.Point2.x;
			double num8 = lineB.Point2.y;
			if (math.abs(num - num3) < tolerance && math.abs(num5 - num7) < tolerance && math.abs(num - num5) < tolerance)
			{
				return false;
			}
			if (math.abs(num2 - num4) < tolerance && math.abs(num6 - num8) < tolerance && math.abs(num2 - num6) < tolerance)
			{
				return false;
			}
			if (math.abs(num - num3) < tolerance && math.abs(num5 - num7) < tolerance)
			{
				return false;
			}
			if (math.abs(num2 - num4) < tolerance && math.abs(num6 - num8) < tolerance)
			{
				return false;
			}
			double num11;
			double num12;
			if (math.abs(num - num3) < tolerance)
			{
				double num9 = (num8 - num6) / (num7 - num5);
				double num10 = (0.0 - num9) * num5 + num6;
				num11 = num;
				num12 = num10 + num9 * num;
			}
			else if (math.abs(num5 - num7) < tolerance)
			{
				double num13 = (num4 - num2) / (num3 - num);
				double num14 = (0.0 - num13) * num + num2;
				num11 = num5;
				num12 = num14 + num13 * num5;
			}
			else
			{
				double num15 = (num4 - num2) / (num3 - num);
				double num16 = (0.0 - num15) * num + num2;
				double num17 = (num8 - num6) / (num7 - num5);
				double num18 = (0.0 - num17) * num5 + num6;
				num11 = (num16 - num18) / (num17 - num15);
				num12 = num18 + num17 * num11;
				if (!(math.abs((0.0 - num15) * num11 + num12 - num16) < tolerance) || !(math.abs((0.0 - num17) * num11 + num12 - num18) < tolerance))
				{
					return false;
				}
			}
			if (IsInsideLine(lineA, num11, num12) && IsInsideLine(lineB, num11, num12))
			{
				intersection = new float2((float)num11, (float)num12);
				return true;
			}
			return false;
		}

		private bool IsInsideLine(Line line, double x, double y)
		{
			if ((x >= (double)line.Point1.x && x <= (double)line.Point2.x) || (x >= (double)line.Point2.x && x <= (double)line.Point1.x))
			{
				if (!(y >= (double)line.Point1.y) || !(y <= (double)line.Point2.y))
				{
					if (y >= (double)line.Point2.y)
					{
						return y <= (double)line.Point1.y;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			ProjectileAspect.ResolvedChunk resolvedChunk = __TypeHandle.__ProjectileAspect_RW_AspectTypeHandle.Resolve(chunk);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ProjectileAspect projectileAspect = resolvedChunk[i];
					Execute(entity, projectileAspect, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						ProjectileAspect projectileAspect2 = resolvedChunk[nextRangeBegin];
						Execute(entity2, projectileAspect2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					ProjectileAspect projectileAspect3 = resolvedChunk[j];
					Execute(entity3, projectileAspect3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					ProjectileAspect projectileAspect4 = resolvedChunk[k];
					Execute(entity4, projectileAspect4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> __DestroyTimerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PaintableObjectCD> __PaintableObjectCD_RO_ComponentLookup;

		public BufferLookup<TileDamageBuffer> __TileDamageBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<TileColliderCD> __TileColliderCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		public UpdateProjectileJob.InternalCompilerQueryAndHandleData __ProjectileSystem_UpdateProjectileJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			__DestroyTimerCD_RO_ComponentLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__PaintableObjectCD_RO_ComponentLookup = state.GetComponentLookup<PaintableObjectCD>(isReadOnly: true);
			__TileDamageBuffer_RW_BufferLookup = state.GetBufferLookup<TileDamageBuffer>();
			__TileColliderCD_RO_ComponentLookup = state.GetComponentLookup<TileColliderCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__ProjectileSystem_UpdateProjectileJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00003010_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003010_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003010_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00003013_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00003013_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00003013_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private const float lookaheadTime = 1f / 30f;

	private TileAccessor _tileAccessor;

	private AttackSystem.Helper _attackHelper;

	private int _deathAnim;

	private uint _tickRate;

	private NativeArray<float2> _normals;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1963200453_0;

	private EntityQuery __query_1963200453_1;

	private EntityQuery __query_1963200453_2;

	private EntityQuery __query_1963200453_3;

	private EntityQuery __query_1963200453_4;

	private EntityQuery __query_1963200453_5;

	private EntityQuery __query_1963200453_6;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<WorldInfoCD>();
		state.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref state);
		_normals = new NativeArray<float2>(4, Allocator.Persistent);
		_normals[0] = new float2(-1f, 0f);
		_normals[1] = new float2(1f, 0f);
		_normals[2] = new float2(0f, 1f);
		_normals[3] = new float2(0f, -1f);
	}

	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
		if (!__query_1963200453_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
		_deathAnim = -414722770;
		_tickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	public void OnDestroy(ref SystemState state)
	{
		_normals.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		NetworkTime singleton = __query_1963200453_1.GetSingleton<NetworkTime>();
		if (!__query_1963200453_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_tileAccessor.Update(ref state);
		_attackHelper.Update(ref state, singleton.ServerTick, (uint)value.SimulationTickRate);
		_ = ref state.WorldUnmanaged.Time;
		EntityCommandBuffer ecb = __query_1963200453_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateProjectileJob
		{
			tileAccessor = _tileAccessor,
			attackHelper = _attackHelper,
			summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			petLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state),
			destroyTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestroyTimerCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			currentTick = singleton.ServerTick,
			tileDamageBufferEntity = __query_1963200453_3.GetSingletonEntity(),
			effectEventBufferSingleton = __query_1963200453_4.GetSingletonEntity(),
			deathAnim = _deathAnim,
			tickRate = _tickRate,
			isServer = state.WorldUnmanaged.IsServer(),
			databaseBankCD = __query_1963200453_5.GetSingleton<PugDatabase.DatabaseBankCD>(),
			behaviourTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			summarizedConditionBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			conditionsTable = __query_1963200453_6.GetSingleton<ConditionsTableCD>(),
			tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
			enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			paintableObjectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PaintableObjectCD_RO_ComponentLookup, ref state),
			tileDamageBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileDamageBuffer_RW_BufferLookup, ref state),
			tileCollLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileColliderCD_RO_ComponentLookup, ref state),
			directionlLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			normals = _normals
		}, __TypeHandle.__ProjectileSystem_UpdateProjectileJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(UpdateProjectileJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ProjectileSystem_UpdateProjectileJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ProjectileSystem_UpdateProjectileJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ProjectileSystem_UpdateProjectileJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ProjectileSystem_UpdateProjectileJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963200453_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963200453_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963200453_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963200453_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963200453_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963200453_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1963200453_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((ProjectileSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003010_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		((ProjectileSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((ProjectileSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00003013_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ProjectileSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ProjectileSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ProjectileSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
