using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pug.Properties;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;

public readonly struct ProjectileAspect : IAspect, IQueryTypeParameter, IAspectCreate<ProjectileAspect>
{
	public struct Lookup : InternalCompilerInterface.IAspectLookup<ProjectileAspect>
	{
		private ComponentLookup<BouncingProjectileCD> ProjectileAspect_bouncingCAc;

		private ComponentLookup<ContinouslyDamagingProjectileCD> ProjectileAspect_continouslyDamagingCAc;

		[ReadOnly]
		private ComponentLookup<DestroyTimerCD> ProjectileAspect_destroyTimerCAc;

		[ReadOnly]
		private ComponentLookup<GroundBouncableProjectileCD> ProjectileAspect_groundBouncableProjectileCDCAc;

		[ReadOnly]
		private ComponentLookup<HealingProjectileCD> ProjectileAspect_healingCAc;

		[ReadOnly]
		private ComponentLookup<HomingProjectileCD> ProjectileAspect_homingCAc;

		private ComponentLookup<MovementSpeedCD> ProjectileAspect_speedCAc;

		[ReadOnly]
		private ComponentLookup<MovementSpeedModifierCD> ProjectileAspect_speedModifierCAc;

		[ReadOnly]
		private ComponentLookup<PingPongProjectileCD> ProjectileAspect_pingPongCAc;

		private BufferLookup<ProjectilePiercesWallTypesBuffer> ProjectileAspect_piercesWallTypesBAc;

		[ReadOnly]
		private ComponentLookup<ProjectileSetupCD> ProjectileAspect_projectileSetupCAc;

		[ReadOnly]
		private ComponentLookup<ProjectileSourceCD> ProjectileAspect_projectileSourceSetupCAc;

		[ReadOnly]
		private ComponentLookup<ProjectileSpeedCurveBlendValueCD> ProjectileAspect_speedCurveBlendValueCAc;

		private ComponentLookup<ProjectileSpeedCurveCD> ProjectileAspect_speedCurveCAc;

		[ReadOnly]
		private ComponentLookup<ObjectPropertiesCD> ProjectileAspect_propertiesCAc;

		[ReadOnly]
		private ComponentLookup<ShatterOnCollisionProjectileCD> ProjectileAspect_shatterOnCollisionCAc;

		private ComponentLookup<ZigZagProjectileCD> ProjectileAspect_zigZagCAc;

		public ProjectileAspect this[Entity entity] => new ProjectileAspect(ProjectileAspect_bouncingCAc.GetRefRWOptional(entity), ProjectileAspect_continouslyDamagingCAc.GetRefRWOptional(entity), ProjectileAspect_destroyTimerCAc.GetRefROOptional(entity), ProjectileAspect_groundBouncableProjectileCDCAc.GetRefROOptional(entity), ProjectileAspect_healingCAc.GetRefROOptional(entity), ProjectileAspect_homingCAc.GetRefROOptional(entity), ProjectileAspect_speedCAc.GetRefRW(entity), ProjectileAspect_speedModifierCAc.GetRefRO(entity), ProjectileAspect_pingPongCAc.GetRefROOptional(entity), ProjectileAspect_piercesWallTypesBAc[entity], ProjectileAspect_projectileSetupCAc.GetRefROOptional(entity), ProjectileAspect_projectileSourceSetupCAc.GetRefROOptional(entity), ProjectileAspect_speedCurveBlendValueCAc.GetRefROOptional(entity), ProjectileAspect_speedCurveCAc.GetRefRWOptional(entity), ProjectileAspect_propertiesCAc.GetRefRO(entity), ProjectileAspect_shatterOnCollisionCAc.GetRefROOptional(entity), ProjectileAspect_zigZagCAc.GetRefRWOptional(entity));

		public Lookup(ref SystemState state)
		{
			ProjectileAspect_bouncingCAc = state.GetComponentLookup<BouncingProjectileCD>();
			ProjectileAspect_continouslyDamagingCAc = state.GetComponentLookup<ContinouslyDamagingProjectileCD>();
			ProjectileAspect_destroyTimerCAc = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
			ProjectileAspect_groundBouncableProjectileCDCAc = state.GetComponentLookup<GroundBouncableProjectileCD>(isReadOnly: true);
			ProjectileAspect_healingCAc = state.GetComponentLookup<HealingProjectileCD>(isReadOnly: true);
			ProjectileAspect_homingCAc = state.GetComponentLookup<HomingProjectileCD>(isReadOnly: true);
			ProjectileAspect_speedCAc = state.GetComponentLookup<MovementSpeedCD>();
			ProjectileAspect_speedModifierCAc = state.GetComponentLookup<MovementSpeedModifierCD>(isReadOnly: true);
			ProjectileAspect_pingPongCAc = state.GetComponentLookup<PingPongProjectileCD>(isReadOnly: true);
			ProjectileAspect_piercesWallTypesBAc = state.GetBufferLookup<ProjectilePiercesWallTypesBuffer>();
			ProjectileAspect_projectileSetupCAc = state.GetComponentLookup<ProjectileSetupCD>(isReadOnly: true);
			ProjectileAspect_projectileSourceSetupCAc = state.GetComponentLookup<ProjectileSourceCD>(isReadOnly: true);
			ProjectileAspect_speedCurveBlendValueCAc = state.GetComponentLookup<ProjectileSpeedCurveBlendValueCD>(isReadOnly: true);
			ProjectileAspect_speedCurveCAc = state.GetComponentLookup<ProjectileSpeedCurveCD>();
			ProjectileAspect_propertiesCAc = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			ProjectileAspect_shatterOnCollisionCAc = state.GetComponentLookup<ShatterOnCollisionProjectileCD>(isReadOnly: true);
			ProjectileAspect_zigZagCAc = state.GetComponentLookup<ZigZagProjectileCD>();
		}

		public void Update(ref SystemState state)
		{
			ProjectileAspect_bouncingCAc.Update(ref state);
			ProjectileAspect_continouslyDamagingCAc.Update(ref state);
			ProjectileAspect_destroyTimerCAc.Update(ref state);
			ProjectileAspect_groundBouncableProjectileCDCAc.Update(ref state);
			ProjectileAspect_healingCAc.Update(ref state);
			ProjectileAspect_homingCAc.Update(ref state);
			ProjectileAspect_speedCAc.Update(ref state);
			ProjectileAspect_speedModifierCAc.Update(ref state);
			ProjectileAspect_pingPongCAc.Update(ref state);
			ProjectileAspect_piercesWallTypesBAc.Update(ref state);
			ProjectileAspect_projectileSetupCAc.Update(ref state);
			ProjectileAspect_projectileSourceSetupCAc.Update(ref state);
			ProjectileAspect_speedCurveBlendValueCAc.Update(ref state);
			ProjectileAspect_speedCurveCAc.Update(ref state);
			ProjectileAspect_propertiesCAc.Update(ref state);
			ProjectileAspect_shatterOnCollisionCAc.Update(ref state);
			ProjectileAspect_zigZagCAc.Update(ref state);
		}
	}

	public struct ResolvedChunk
	{
		public NativeArray<BouncingProjectileCD> ProjectileAspect_bouncingNaC;

		public NativeArray<ContinouslyDamagingProjectileCD> ProjectileAspect_continouslyDamagingNaC;

		public NativeArray<DestroyTimerCD> ProjectileAspect_destroyTimerNaC;

		public NativeArray<GroundBouncableProjectileCD> ProjectileAspect_groundBouncableProjectileCDNaC;

		public NativeArray<HealingProjectileCD> ProjectileAspect_healingNaC;

		public NativeArray<HomingProjectileCD> ProjectileAspect_homingNaC;

		public NativeArray<MovementSpeedCD> ProjectileAspect_speedNaC;

		public NativeArray<MovementSpeedModifierCD> ProjectileAspect_speedModifierNaC;

		public NativeArray<PingPongProjectileCD> ProjectileAspect_pingPongNaC;

		public BufferAccessor<ProjectilePiercesWallTypesBuffer> ProjectileAspect_piercesWallTypesBa;

		public NativeArray<ProjectileSetupCD> ProjectileAspect_projectileSetupNaC;

		public NativeArray<ProjectileSourceCD> ProjectileAspect_projectileSourceSetupNaC;

		public NativeArray<ProjectileSpeedCurveBlendValueCD> ProjectileAspect_speedCurveBlendValueNaC;

		public NativeArray<ProjectileSpeedCurveCD> ProjectileAspect_speedCurveNaC;

		public NativeArray<ObjectPropertiesCD> ProjectileAspect_propertiesNaC;

		public NativeArray<ShatterOnCollisionProjectileCD> ProjectileAspect_shatterOnCollisionNaC;

		public NativeArray<ZigZagProjectileCD> ProjectileAspect_zigZagNaC;

		public int Length;

		public ProjectileAspect this[int index] => new ProjectileAspect(RefRW<BouncingProjectileCD>.Optional(ProjectileAspect_bouncingNaC, index), RefRW<ContinouslyDamagingProjectileCD>.Optional(ProjectileAspect_continouslyDamagingNaC, index), RefRO<DestroyTimerCD>.Optional(ProjectileAspect_destroyTimerNaC, index), RefRO<GroundBouncableProjectileCD>.Optional(ProjectileAspect_groundBouncableProjectileCDNaC, index), RefRO<HealingProjectileCD>.Optional(ProjectileAspect_healingNaC, index), RefRO<HomingProjectileCD>.Optional(ProjectileAspect_homingNaC, index), new RefRW<MovementSpeedCD>(ProjectileAspect_speedNaC, index), new RefRO<MovementSpeedModifierCD>(ProjectileAspect_speedModifierNaC, index), RefRO<PingPongProjectileCD>.Optional(ProjectileAspect_pingPongNaC, index), ProjectileAspect_piercesWallTypesBa[index], RefRO<ProjectileSetupCD>.Optional(ProjectileAspect_projectileSetupNaC, index), RefRO<ProjectileSourceCD>.Optional(ProjectileAspect_projectileSourceSetupNaC, index), RefRO<ProjectileSpeedCurveBlendValueCD>.Optional(ProjectileAspect_speedCurveBlendValueNaC, index), RefRW<ProjectileSpeedCurveCD>.Optional(ProjectileAspect_speedCurveNaC, index), new RefRO<ObjectPropertiesCD>(ProjectileAspect_propertiesNaC, index), RefRO<ShatterOnCollisionProjectileCD>.Optional(ProjectileAspect_shatterOnCollisionNaC, index), RefRW<ZigZagProjectileCD>.Optional(ProjectileAspect_zigZagNaC, index));
	}

	public struct TypeHandle
	{
		private ComponentTypeHandle<BouncingProjectileCD> ProjectileAspect_bouncingCAc;

		private ComponentTypeHandle<ContinouslyDamagingProjectileCD> ProjectileAspect_continouslyDamagingCAc;

		[ReadOnly]
		private ComponentTypeHandle<DestroyTimerCD> ProjectileAspect_destroyTimerCAc;

		[ReadOnly]
		private ComponentTypeHandle<GroundBouncableProjectileCD> ProjectileAspect_groundBouncableProjectileCDCAc;

		[ReadOnly]
		private ComponentTypeHandle<HealingProjectileCD> ProjectileAspect_healingCAc;

		[ReadOnly]
		private ComponentTypeHandle<HomingProjectileCD> ProjectileAspect_homingCAc;

		private ComponentTypeHandle<MovementSpeedCD> ProjectileAspect_speedCAc;

		[ReadOnly]
		private ComponentTypeHandle<MovementSpeedModifierCD> ProjectileAspect_speedModifierCAc;

		[ReadOnly]
		private ComponentTypeHandle<PingPongProjectileCD> ProjectileAspect_pingPongCAc;

		private BufferTypeHandle<ProjectilePiercesWallTypesBuffer> ProjectileAspect_piercesWallTypesBAc;

		[ReadOnly]
		private ComponentTypeHandle<ProjectileSetupCD> ProjectileAspect_projectileSetupCAc;

		[ReadOnly]
		private ComponentTypeHandle<ProjectileSourceCD> ProjectileAspect_projectileSourceSetupCAc;

		[ReadOnly]
		private ComponentTypeHandle<ProjectileSpeedCurveBlendValueCD> ProjectileAspect_speedCurveBlendValueCAc;

		private ComponentTypeHandle<ProjectileSpeedCurveCD> ProjectileAspect_speedCurveCAc;

		[ReadOnly]
		private ComponentTypeHandle<ObjectPropertiesCD> ProjectileAspect_propertiesCAc;

		[ReadOnly]
		private ComponentTypeHandle<ShatterOnCollisionProjectileCD> ProjectileAspect_shatterOnCollisionCAc;

		private ComponentTypeHandle<ZigZagProjectileCD> ProjectileAspect_zigZagCAc;

		public TypeHandle(ref SystemState state)
		{
			ProjectileAspect_bouncingCAc = state.GetComponentTypeHandle<BouncingProjectileCD>();
			ProjectileAspect_continouslyDamagingCAc = state.GetComponentTypeHandle<ContinouslyDamagingProjectileCD>();
			ProjectileAspect_destroyTimerCAc = state.GetComponentTypeHandle<DestroyTimerCD>(isReadOnly: true);
			ProjectileAspect_groundBouncableProjectileCDCAc = state.GetComponentTypeHandle<GroundBouncableProjectileCD>(isReadOnly: true);
			ProjectileAspect_healingCAc = state.GetComponentTypeHandle<HealingProjectileCD>(isReadOnly: true);
			ProjectileAspect_homingCAc = state.GetComponentTypeHandle<HomingProjectileCD>(isReadOnly: true);
			ProjectileAspect_speedCAc = state.GetComponentTypeHandle<MovementSpeedCD>();
			ProjectileAspect_speedModifierCAc = state.GetComponentTypeHandle<MovementSpeedModifierCD>(isReadOnly: true);
			ProjectileAspect_pingPongCAc = state.GetComponentTypeHandle<PingPongProjectileCD>(isReadOnly: true);
			ProjectileAspect_piercesWallTypesBAc = state.GetBufferTypeHandle<ProjectilePiercesWallTypesBuffer>();
			ProjectileAspect_projectileSetupCAc = state.GetComponentTypeHandle<ProjectileSetupCD>(isReadOnly: true);
			ProjectileAspect_projectileSourceSetupCAc = state.GetComponentTypeHandle<ProjectileSourceCD>(isReadOnly: true);
			ProjectileAspect_speedCurveBlendValueCAc = state.GetComponentTypeHandle<ProjectileSpeedCurveBlendValueCD>(isReadOnly: true);
			ProjectileAspect_speedCurveCAc = state.GetComponentTypeHandle<ProjectileSpeedCurveCD>();
			ProjectileAspect_propertiesCAc = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
			ProjectileAspect_shatterOnCollisionCAc = state.GetComponentTypeHandle<ShatterOnCollisionProjectileCD>(isReadOnly: true);
			ProjectileAspect_zigZagCAc = state.GetComponentTypeHandle<ZigZagProjectileCD>();
		}

		public void Update(ref SystemState state)
		{
			ProjectileAspect_bouncingCAc.Update(ref state);
			ProjectileAspect_continouslyDamagingCAc.Update(ref state);
			ProjectileAspect_destroyTimerCAc.Update(ref state);
			ProjectileAspect_groundBouncableProjectileCDCAc.Update(ref state);
			ProjectileAspect_healingCAc.Update(ref state);
			ProjectileAspect_homingCAc.Update(ref state);
			ProjectileAspect_speedCAc.Update(ref state);
			ProjectileAspect_speedModifierCAc.Update(ref state);
			ProjectileAspect_pingPongCAc.Update(ref state);
			ProjectileAspect_piercesWallTypesBAc.Update(ref state);
			ProjectileAspect_projectileSetupCAc.Update(ref state);
			ProjectileAspect_projectileSourceSetupCAc.Update(ref state);
			ProjectileAspect_speedCurveBlendValueCAc.Update(ref state);
			ProjectileAspect_speedCurveCAc.Update(ref state);
			ProjectileAspect_propertiesCAc.Update(ref state);
			ProjectileAspect_shatterOnCollisionCAc.Update(ref state);
			ProjectileAspect_zigZagCAc.Update(ref state);
		}

		public ResolvedChunk Resolve(ArchetypeChunk chunk)
		{
			ResolvedChunk result = default(ResolvedChunk);
			result.ProjectileAspect_bouncingNaC = chunk.GetNativeArray(ref ProjectileAspect_bouncingCAc);
			result.ProjectileAspect_continouslyDamagingNaC = chunk.GetNativeArray(ref ProjectileAspect_continouslyDamagingCAc);
			result.ProjectileAspect_destroyTimerNaC = chunk.GetNativeArray(ref ProjectileAspect_destroyTimerCAc);
			result.ProjectileAspect_groundBouncableProjectileCDNaC = chunk.GetNativeArray(ref ProjectileAspect_groundBouncableProjectileCDCAc);
			result.ProjectileAspect_healingNaC = chunk.GetNativeArray(ref ProjectileAspect_healingCAc);
			result.ProjectileAspect_homingNaC = chunk.GetNativeArray(ref ProjectileAspect_homingCAc);
			result.ProjectileAspect_speedNaC = chunk.GetNativeArray(ref ProjectileAspect_speedCAc);
			result.ProjectileAspect_speedModifierNaC = chunk.GetNativeArray(ref ProjectileAspect_speedModifierCAc);
			result.ProjectileAspect_pingPongNaC = chunk.GetNativeArray(ref ProjectileAspect_pingPongCAc);
			result.ProjectileAspect_piercesWallTypesBa = chunk.GetBufferAccessor(ref ProjectileAspect_piercesWallTypesBAc);
			result.ProjectileAspect_projectileSetupNaC = chunk.GetNativeArray(ref ProjectileAspect_projectileSetupCAc);
			result.ProjectileAspect_projectileSourceSetupNaC = chunk.GetNativeArray(ref ProjectileAspect_projectileSourceSetupCAc);
			result.ProjectileAspect_speedCurveBlendValueNaC = chunk.GetNativeArray(ref ProjectileAspect_speedCurveBlendValueCAc);
			result.ProjectileAspect_speedCurveNaC = chunk.GetNativeArray(ref ProjectileAspect_speedCurveCAc);
			result.ProjectileAspect_propertiesNaC = chunk.GetNativeArray(ref ProjectileAspect_propertiesCAc);
			result.ProjectileAspect_shatterOnCollisionNaC = chunk.GetNativeArray(ref ProjectileAspect_shatterOnCollisionCAc);
			result.ProjectileAspect_zigZagNaC = chunk.GetNativeArray(ref ProjectileAspect_zigZagCAc);
			result.Length = chunk.Count;
			return result;
		}
	}

	public struct Enumerator : IEnumerator<ProjectileAspect>, IEnumerator, IDisposable, IEnumerable<ProjectileAspect>, IEnumerable
	{
		private ResolvedChunk _Resolved;

		private InternalEntityQueryEnumerator _QueryEnumerator;

		private TypeHandle _Handle;

		public ProjectileAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

		object IEnumerator.Current
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		internal Enumerator(EntityQuery query, TypeHandle typeHandle)
		{
			_QueryEnumerator = new InternalEntityQueryEnumerator(query);
			_Handle = typeHandle;
			_Resolved = default(ResolvedChunk);
		}

		public void Dispose()
		{
			_QueryEnumerator.Dispose();
		}

		public bool MoveNext()
		{
			if (_QueryEnumerator.MoveNextHotLoop())
			{
				return true;
			}
			return MoveNextCold();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNextCold()
		{
			ArchetypeChunk chunk;
			bool num = _QueryEnumerator.MoveNextColdLoop(out chunk);
			if (num)
			{
				_Resolved = _Handle.Resolve(chunk);
			}
			return num;
		}

		public Enumerator GetEnumerator()
		{
			return this;
		}

		void IEnumerator.Reset()
		{
			throw new NotImplementedException();
		}

		IEnumerator<ProjectileAspect> IEnumerable<ProjectileAspect>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}

	public readonly RefRO<ObjectPropertiesCD> properties;

	public readonly RefRW<MovementSpeedCD> speed;

	public readonly RefRO<MovementSpeedModifierCD> speedModifier;

	[Optional]
	public readonly RefRO<ProjectileSetupCD> projectileSetup;

	[Optional]
	public readonly RefRO<ProjectileSourceCD> projectileSourceSetup;

	[Optional]
	public readonly RefRO<DestroyTimerCD> destroyTimer;

	[Optional]
	public readonly RefRW<ProjectileSpeedCurveCD> speedCurve;

	[Optional]
	public readonly RefRO<ProjectileSpeedCurveBlendValueCD> speedCurveBlendValue;

	[Optional]
	public readonly RefRW<BouncingProjectileCD> bouncing;

	[Optional]
	public readonly RefRO<HomingProjectileCD> homing;

	[Optional]
	public readonly RefRO<HealingProjectileCD> healing;

	[Optional]
	public readonly RefRO<ShatterOnCollisionProjectileCD> shatterOnCollision;

	[Optional]
	public readonly RefRO<PingPongProjectileCD> pingPong;

	[Optional]
	public readonly RefRW<ContinouslyDamagingProjectileCD> continouslyDamaging;

	[Optional]
	public readonly RefRW<ZigZagProjectileCD> zigZag;

	[Optional]
	public readonly DynamicBuffer<ProjectilePiercesWallTypesBuffer> piercesWallTypes;

	[Optional]
	public readonly RefRO<GroundBouncableProjectileCD> groundBouncableProjectileCD;

	public float Speed => speed.ValueRO.speed * speedModifier.ValueRO.Value;

	public bool UseSpeedCurve => speedCurve.IsValid;

	public bool DamagesTiles => properties.ValueRO.Has(-1797642098);

	public bool IsDamageable => properties.ValueRO.Has(-1005412627);

	public bool MayExplodeWithWindup => properties.ValueRO.Has(885676563);

	public bool TreatDodgeAsHit => properties.ValueRO.Has(-1390535385);

	public bool ZigZag => zigZag.IsValid;

	public bool SurviveCollision => properties.ValueRO.Has(995941150);

	public bool ShatterOnCollision => shatterOnCollision.IsValid;

	public bool ShotFromReinforcedWeapon => projectileSourceSetup.ValueRO.shotFromReinforcedWeapon;

	public bool PiercesEnemies(RefRW<PiercingProjectileCD> piercing)
	{
		if (piercing.IsValid)
		{
			return piercing.ValueRO.currentPiercedEnemiesCount <= piercing.ValueRO.piercesEnemiesAmount;
		}
		return false;
	}

	public bool CanPierceOneMoreEnemy(RefRW<PiercingProjectileCD> piercing)
	{
		if (piercing.IsValid)
		{
			return piercing.ValueRO.currentPiercedEnemiesCount < piercing.ValueRO.piercesEnemiesAmount;
		}
		return false;
	}

	public unsafe float GetSpeed(NetworkTick currentTick, uint tickRate)
	{
		float num = (pingPong.IsValid ? pingPong.ValueRO.pingPongDuration : 0f);
		float num2 = Speed;
		if (num > 0f)
		{
			float elapsedSeconds = destroyTimer.ValueRO.timer.GetElapsedSeconds(currentTick, tickRate);
			num2 *= ((elapsedSeconds % (num * 2f) < num - 0.005f) ? 1f : (-1f));
		}
		if (!speedCurve.IsValid)
		{
			return num2;
		}
		float percentageFinished = destroyTimer.ValueRO.timer.GetPercentageFinished(currentTick);
		float num3 = speedCurve.ValueRO.speedCurvePoints1[math.clamp((int)math.round(percentageFinished * 15f), 0, 15)];
		float num4 = speedCurve.ValueRO.speedCurvePoints2[math.clamp((int)math.round(percentageFinished * 15f), 0, 15)];
		return num2 * (num3 * (1f - speedCurveBlendValue.ValueRO.speedCurveBlendValue) + num4 * speedCurveBlendValue.ValueRO.speedCurveBlendValue);
	}

	public ProjectileAspect(RefRW<BouncingProjectileCD> projectileaspect_bouncingRef, RefRW<ContinouslyDamagingProjectileCD> projectileaspect_continouslydamagingRef, RefRO<DestroyTimerCD> projectileaspect_destroytimerRef, RefRO<GroundBouncableProjectileCD> projectileaspect_groundbouncableprojectilecdRef, RefRO<HealingProjectileCD> projectileaspect_healingRef, RefRO<HomingProjectileCD> projectileaspect_homingRef, RefRW<MovementSpeedCD> projectileaspect_speedRef, RefRO<MovementSpeedModifierCD> projectileaspect_speedmodifierRef, RefRO<PingPongProjectileCD> projectileaspect_pingpongRef, DynamicBuffer<ProjectilePiercesWallTypesBuffer> projectileaspect_pierceswalltypesDb, RefRO<ProjectileSetupCD> projectileaspect_projectilesetupRef, RefRO<ProjectileSourceCD> projectileaspect_projectilesourcesetupRef, RefRO<ProjectileSpeedCurveBlendValueCD> projectileaspect_speedcurveblendvalueRef, RefRW<ProjectileSpeedCurveCD> projectileaspect_speedcurveRef, RefRO<ObjectPropertiesCD> projectileaspect_propertiesRef, RefRO<ShatterOnCollisionProjectileCD> projectileaspect_shatteroncollisionRef, RefRW<ZigZagProjectileCD> projectileaspect_zigzagRef)
	{
		bouncing = projectileaspect_bouncingRef;
		continouslyDamaging = projectileaspect_continouslydamagingRef;
		destroyTimer = projectileaspect_destroytimerRef;
		groundBouncableProjectileCD = projectileaspect_groundbouncableprojectilecdRef;
		healing = projectileaspect_healingRef;
		homing = projectileaspect_homingRef;
		speed = projectileaspect_speedRef;
		speedModifier = projectileaspect_speedmodifierRef;
		pingPong = projectileaspect_pingpongRef;
		piercesWallTypes = projectileaspect_pierceswalltypesDb;
		projectileSetup = projectileaspect_projectilesetupRef;
		projectileSourceSetup = projectileaspect_projectilesourcesetupRef;
		speedCurveBlendValue = projectileaspect_speedcurveblendvalueRef;
		speedCurve = projectileaspect_speedcurveRef;
		properties = projectileaspect_propertiesRef;
		shatterOnCollision = projectileaspect_shatteroncollisionRef;
		zigZag = projectileaspect_zigzagRef;
	}

	public ProjectileAspect CreateAspect(Entity entity, ref SystemState systemState)
	{
		return new Lookup(ref systemState)[entity];
	}

	public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
	{
		UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
		unsafeList.Add(ComponentType.ReadWrite<MovementSpeedCD>());
		unsafeList.Add(ComponentType.ReadOnly<MovementSpeedModifierCD>());
		unsafeList.Add(ComponentType.ReadOnly<ObjectPropertiesCD>());
		UnsafeList<ComponentType> withThese = unsafeList;
		InternalCompilerInterface.MergeWith(ref all, ref withThese);
		withThese.Dispose();
	}

	public static int GetRequiredComponentTypeCount()
	{
		return 3;
	}

	public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
	{
		componentTypes[0] = ComponentType.ReadWrite<MovementSpeedCD>();
		componentTypes[1] = ComponentType.ReadOnly<MovementSpeedModifierCD>();
		componentTypes[2] = ComponentType.ReadOnly<ObjectPropertiesCD>();
	}

	public static Enumerator Query(EntityQuery query, TypeHandle typeHandle)
	{
		return new Enumerator(query, typeHandle);
	}

	public void CompleteDependencyBeforeRO(ref SystemState state)
	{
		state.EntityManager.CompleteDependencyBeforeRO<MovementSpeedCD>();
		state.EntityManager.CompleteDependencyBeforeRO<MovementSpeedModifierCD>();
		state.EntityManager.CompleteDependencyBeforeRO<ObjectPropertiesCD>();
	}

	public void CompleteDependencyBeforeRW(ref SystemState state)
	{
		state.EntityManager.CompleteDependencyBeforeRW<MovementSpeedCD>();
		state.EntityManager.CompleteDependencyBeforeRO<MovementSpeedModifierCD>();
		state.EntityManager.CompleteDependencyBeforeRO<ObjectPropertiesCD>();
	}
}
