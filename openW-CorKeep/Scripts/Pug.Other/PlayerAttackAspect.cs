using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PlayerEquipment;
using PlayerState;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

public readonly struct PlayerAttackAspect : IAspect, IQueryTypeParameter, IAspectCreate<PlayerAttackAspect>
{
	public struct Lookup : InternalCompilerInterface.IAspectLookup<PlayerAttackAspect>
	{
		[ReadOnly]
		private ComponentLookup<ClientInput> PlayerAttackAspect_clientInputCAc;

		[ReadOnly]
		private ComponentLookup<CollectedAndEnabledSoulsMask> PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc;

		private ComponentLookup<CornerSmoothingCD> PlayerAttackAspect_cornerSmoothingCDCAc;

		[ReadOnly]
		private ComponentLookup<EquippedObjectCD> PlayerAttackAspect_equippedObjectCDCAc;

		private ComponentLookup<HungerCD> PlayerAttackAspect_hungerCDCAc;

		[ReadOnly]
		private ComponentLookup<PetOwnerCD> PlayerAttackAspect_petOwnerCDCAc;

		[ReadOnly]
		private ComponentLookup<PlayerAimPositionCD> PlayerAttackAspect_playerAimPositionCAc;

		private ComponentLookup<PlayerEmoteEffectsCD> PlayerAttackAspect_emoteEffectsCDCAc;

		[ReadOnly]
		private ComponentLookup<EquipmentSlotCD> PlayerAttackAspect_equipmentSlotCDCAc;

		private ComponentLookup<PlayerAttackCD> PlayerAttackAspect_playerAttackCDCAc;

		private BufferLookup<PlayerPreviouslyHitEnemiesBuffer> PlayerAttackAspect_previouslyHitEnemiesBufferBAc;

		[ReadOnly]
		private ComponentLookup<PlayerGhost> PlayerAttackAspect_playerGhostCAc;

		[ReadOnly]
		private ComponentLookup<PlayerMovementCD> PlayerAttackAspect_playerMovementCDCAc;

		[ReadOnly]
		private ComponentLookup<PlayerStateCD> PlayerAttackAspect_playerStateCDCAc;

		[ReadOnly]
		private ComponentLookup<CommandDataInterpolationDelay> PlayerAttackAspect_interpolationDelayCAc;

		public PlayerAttackAspect this[Entity entity] => new PlayerAttackAspect(PlayerAttackAspect_clientInputCAc.GetRefRO(entity), PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc.GetRefRO(entity), PlayerAttackAspect_cornerSmoothingCDCAc.GetRefRW(entity), PlayerAttackAspect_equippedObjectCDCAc.GetRefRO(entity), PlayerAttackAspect_hungerCDCAc.GetRefRW(entity), PlayerAttackAspect_petOwnerCDCAc.GetRefRO(entity), PlayerAttackAspect_playerAimPositionCAc.GetRefRO(entity), PlayerAttackAspect_emoteEffectsCDCAc.GetRefRW(entity), PlayerAttackAspect_equipmentSlotCDCAc.GetRefRO(entity), PlayerAttackAspect_playerAttackCDCAc.GetRefRW(entity), PlayerAttackAspect_previouslyHitEnemiesBufferBAc[entity], PlayerAttackAspect_playerGhostCAc.GetRefRO(entity), PlayerAttackAspect_playerMovementCDCAc.GetRefRO(entity), PlayerAttackAspect_playerStateCDCAc.GetRefRO(entity), entity, PlayerAttackAspect_interpolationDelayCAc.GetRefRO(entity));

		public Lookup(ref SystemState state)
		{
			PlayerAttackAspect_clientInputCAc = state.GetComponentLookup<ClientInput>(isReadOnly: true);
			PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc = state.GetComponentLookup<CollectedAndEnabledSoulsMask>(isReadOnly: true);
			PlayerAttackAspect_cornerSmoothingCDCAc = state.GetComponentLookup<CornerSmoothingCD>();
			PlayerAttackAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
			PlayerAttackAspect_hungerCDCAc = state.GetComponentLookup<HungerCD>();
			PlayerAttackAspect_petOwnerCDCAc = state.GetComponentLookup<PetOwnerCD>(isReadOnly: true);
			PlayerAttackAspect_playerAimPositionCAc = state.GetComponentLookup<PlayerAimPositionCD>(isReadOnly: true);
			PlayerAttackAspect_emoteEffectsCDCAc = state.GetComponentLookup<PlayerEmoteEffectsCD>();
			PlayerAttackAspect_equipmentSlotCDCAc = state.GetComponentLookup<EquipmentSlotCD>(isReadOnly: true);
			PlayerAttackAspect_playerAttackCDCAc = state.GetComponentLookup<PlayerAttackCD>();
			PlayerAttackAspect_previouslyHitEnemiesBufferBAc = state.GetBufferLookup<PlayerPreviouslyHitEnemiesBuffer>();
			PlayerAttackAspect_playerGhostCAc = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			PlayerAttackAspect_playerMovementCDCAc = state.GetComponentLookup<PlayerMovementCD>(isReadOnly: true);
			PlayerAttackAspect_playerStateCDCAc = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			PlayerAttackAspect_interpolationDelayCAc = state.GetComponentLookup<CommandDataInterpolationDelay>(isReadOnly: true);
		}

		public void Update(ref SystemState state)
		{
			PlayerAttackAspect_clientInputCAc.Update(ref state);
			PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc.Update(ref state);
			PlayerAttackAspect_cornerSmoothingCDCAc.Update(ref state);
			PlayerAttackAspect_equippedObjectCDCAc.Update(ref state);
			PlayerAttackAspect_hungerCDCAc.Update(ref state);
			PlayerAttackAspect_petOwnerCDCAc.Update(ref state);
			PlayerAttackAspect_playerAimPositionCAc.Update(ref state);
			PlayerAttackAspect_emoteEffectsCDCAc.Update(ref state);
			PlayerAttackAspect_equipmentSlotCDCAc.Update(ref state);
			PlayerAttackAspect_playerAttackCDCAc.Update(ref state);
			PlayerAttackAspect_previouslyHitEnemiesBufferBAc.Update(ref state);
			PlayerAttackAspect_playerGhostCAc.Update(ref state);
			PlayerAttackAspect_playerMovementCDCAc.Update(ref state);
			PlayerAttackAspect_playerStateCDCAc.Update(ref state);
			PlayerAttackAspect_interpolationDelayCAc.Update(ref state);
		}
	}

	public struct ResolvedChunk
	{
		public NativeArray<ClientInput> PlayerAttackAspect_clientInputNaC;

		public NativeArray<CollectedAndEnabledSoulsMask> PlayerAttackAspect_CollectedAndEnabledSoulsMaskNaC;

		public NativeArray<CornerSmoothingCD> PlayerAttackAspect_cornerSmoothingCDNaC;

		public NativeArray<EquippedObjectCD> PlayerAttackAspect_equippedObjectCDNaC;

		public NativeArray<HungerCD> PlayerAttackAspect_hungerCDNaC;

		public NativeArray<PetOwnerCD> PlayerAttackAspect_petOwnerCDNaC;

		public NativeArray<PlayerAimPositionCD> PlayerAttackAspect_playerAimPositionNaC;

		public NativeArray<PlayerEmoteEffectsCD> PlayerAttackAspect_emoteEffectsCDNaC;

		public NativeArray<EquipmentSlotCD> PlayerAttackAspect_equipmentSlotCDNaC;

		public NativeArray<PlayerAttackCD> PlayerAttackAspect_playerAttackCDNaC;

		public BufferAccessor<PlayerPreviouslyHitEnemiesBuffer> PlayerAttackAspect_previouslyHitEnemiesBufferBa;

		public NativeArray<PlayerGhost> PlayerAttackAspect_playerGhostNaC;

		public NativeArray<PlayerMovementCD> PlayerAttackAspect_playerMovementCDNaC;

		public NativeArray<PlayerStateCD> PlayerAttackAspect_playerStateCDNaC;

		public NativeArray<Entity> PlayerAttackAspect_entityNaE;

		public NativeArray<CommandDataInterpolationDelay> PlayerAttackAspect_interpolationDelayNaC;

		public int Length;

		public PlayerAttackAspect this[int index] => new PlayerAttackAspect(new RefRO<ClientInput>(PlayerAttackAspect_clientInputNaC, index), new RefRO<CollectedAndEnabledSoulsMask>(PlayerAttackAspect_CollectedAndEnabledSoulsMaskNaC, index), new RefRW<CornerSmoothingCD>(PlayerAttackAspect_cornerSmoothingCDNaC, index), new RefRO<EquippedObjectCD>(PlayerAttackAspect_equippedObjectCDNaC, index), new RefRW<HungerCD>(PlayerAttackAspect_hungerCDNaC, index), new RefRO<PetOwnerCD>(PlayerAttackAspect_petOwnerCDNaC, index), new RefRO<PlayerAimPositionCD>(PlayerAttackAspect_playerAimPositionNaC, index), new RefRW<PlayerEmoteEffectsCD>(PlayerAttackAspect_emoteEffectsCDNaC, index), new RefRO<EquipmentSlotCD>(PlayerAttackAspect_equipmentSlotCDNaC, index), new RefRW<PlayerAttackCD>(PlayerAttackAspect_playerAttackCDNaC, index), PlayerAttackAspect_previouslyHitEnemiesBufferBa[index], new RefRO<PlayerGhost>(PlayerAttackAspect_playerGhostNaC, index), new RefRO<PlayerMovementCD>(PlayerAttackAspect_playerMovementCDNaC, index), new RefRO<PlayerStateCD>(PlayerAttackAspect_playerStateCDNaC, index), PlayerAttackAspect_entityNaE[index], new RefRO<CommandDataInterpolationDelay>(PlayerAttackAspect_interpolationDelayNaC, index));
	}

	public struct TypeHandle
	{
		[ReadOnly]
		private ComponentTypeHandle<ClientInput> PlayerAttackAspect_clientInputCAc;

		[ReadOnly]
		private ComponentTypeHandle<CollectedAndEnabledSoulsMask> PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc;

		private ComponentTypeHandle<CornerSmoothingCD> PlayerAttackAspect_cornerSmoothingCDCAc;

		[ReadOnly]
		private ComponentTypeHandle<EquippedObjectCD> PlayerAttackAspect_equippedObjectCDCAc;

		private ComponentTypeHandle<HungerCD> PlayerAttackAspect_hungerCDCAc;

		[ReadOnly]
		private ComponentTypeHandle<PetOwnerCD> PlayerAttackAspect_petOwnerCDCAc;

		[ReadOnly]
		private ComponentTypeHandle<PlayerAimPositionCD> PlayerAttackAspect_playerAimPositionCAc;

		private ComponentTypeHandle<PlayerEmoteEffectsCD> PlayerAttackAspect_emoteEffectsCDCAc;

		[ReadOnly]
		private ComponentTypeHandle<EquipmentSlotCD> PlayerAttackAspect_equipmentSlotCDCAc;

		private ComponentTypeHandle<PlayerAttackCD> PlayerAttackAspect_playerAttackCDCAc;

		private BufferTypeHandle<PlayerPreviouslyHitEnemiesBuffer> PlayerAttackAspect_previouslyHitEnemiesBufferBAc;

		[ReadOnly]
		private ComponentTypeHandle<PlayerGhost> PlayerAttackAspect_playerGhostCAc;

		[ReadOnly]
		private ComponentTypeHandle<PlayerMovementCD> PlayerAttackAspect_playerMovementCDCAc;

		[ReadOnly]
		private ComponentTypeHandle<PlayerStateCD> PlayerAttackAspect_playerStateCDCAc;

		private EntityTypeHandle PlayerAttackAspect_entityEAc;

		[ReadOnly]
		private ComponentTypeHandle<CommandDataInterpolationDelay> PlayerAttackAspect_interpolationDelayCAc;

		public TypeHandle(ref SystemState state)
		{
			PlayerAttackAspect_clientInputCAc = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
			PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc = state.GetComponentTypeHandle<CollectedAndEnabledSoulsMask>(isReadOnly: true);
			PlayerAttackAspect_cornerSmoothingCDCAc = state.GetComponentTypeHandle<CornerSmoothingCD>();
			PlayerAttackAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
			PlayerAttackAspect_hungerCDCAc = state.GetComponentTypeHandle<HungerCD>();
			PlayerAttackAspect_petOwnerCDCAc = state.GetComponentTypeHandle<PetOwnerCD>(isReadOnly: true);
			PlayerAttackAspect_playerAimPositionCAc = state.GetComponentTypeHandle<PlayerAimPositionCD>(isReadOnly: true);
			PlayerAttackAspect_emoteEffectsCDCAc = state.GetComponentTypeHandle<PlayerEmoteEffectsCD>();
			PlayerAttackAspect_equipmentSlotCDCAc = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
			PlayerAttackAspect_playerAttackCDCAc = state.GetComponentTypeHandle<PlayerAttackCD>();
			PlayerAttackAspect_previouslyHitEnemiesBufferBAc = state.GetBufferTypeHandle<PlayerPreviouslyHitEnemiesBuffer>();
			PlayerAttackAspect_playerGhostCAc = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
			PlayerAttackAspect_playerMovementCDCAc = state.GetComponentTypeHandle<PlayerMovementCD>(isReadOnly: true);
			PlayerAttackAspect_playerStateCDCAc = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
			PlayerAttackAspect_entityEAc = state.GetEntityTypeHandle();
			PlayerAttackAspect_interpolationDelayCAc = state.GetComponentTypeHandle<CommandDataInterpolationDelay>(isReadOnly: true);
		}

		public void Update(ref SystemState state)
		{
			PlayerAttackAspect_clientInputCAc.Update(ref state);
			PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc.Update(ref state);
			PlayerAttackAspect_cornerSmoothingCDCAc.Update(ref state);
			PlayerAttackAspect_equippedObjectCDCAc.Update(ref state);
			PlayerAttackAspect_hungerCDCAc.Update(ref state);
			PlayerAttackAspect_petOwnerCDCAc.Update(ref state);
			PlayerAttackAspect_playerAimPositionCAc.Update(ref state);
			PlayerAttackAspect_emoteEffectsCDCAc.Update(ref state);
			PlayerAttackAspect_equipmentSlotCDCAc.Update(ref state);
			PlayerAttackAspect_playerAttackCDCAc.Update(ref state);
			PlayerAttackAspect_previouslyHitEnemiesBufferBAc.Update(ref state);
			PlayerAttackAspect_playerGhostCAc.Update(ref state);
			PlayerAttackAspect_playerMovementCDCAc.Update(ref state);
			PlayerAttackAspect_playerStateCDCAc.Update(ref state);
			PlayerAttackAspect_entityEAc.Update(ref state);
			PlayerAttackAspect_interpolationDelayCAc.Update(ref state);
		}

		public ResolvedChunk Resolve(ArchetypeChunk chunk)
		{
			ResolvedChunk result = default(ResolvedChunk);
			result.PlayerAttackAspect_clientInputNaC = chunk.GetNativeArray(ref PlayerAttackAspect_clientInputCAc);
			result.PlayerAttackAspect_CollectedAndEnabledSoulsMaskNaC = chunk.GetNativeArray(ref PlayerAttackAspect_CollectedAndEnabledSoulsMaskCAc);
			result.PlayerAttackAspect_cornerSmoothingCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_cornerSmoothingCDCAc);
			result.PlayerAttackAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_equippedObjectCDCAc);
			result.PlayerAttackAspect_hungerCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_hungerCDCAc);
			result.PlayerAttackAspect_petOwnerCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_petOwnerCDCAc);
			result.PlayerAttackAspect_playerAimPositionNaC = chunk.GetNativeArray(ref PlayerAttackAspect_playerAimPositionCAc);
			result.PlayerAttackAspect_emoteEffectsCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_emoteEffectsCDCAc);
			result.PlayerAttackAspect_equipmentSlotCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_equipmentSlotCDCAc);
			result.PlayerAttackAspect_playerAttackCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_playerAttackCDCAc);
			result.PlayerAttackAspect_previouslyHitEnemiesBufferBa = chunk.GetBufferAccessor(ref PlayerAttackAspect_previouslyHitEnemiesBufferBAc);
			result.PlayerAttackAspect_playerGhostNaC = chunk.GetNativeArray(ref PlayerAttackAspect_playerGhostCAc);
			result.PlayerAttackAspect_playerMovementCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_playerMovementCDCAc);
			result.PlayerAttackAspect_playerStateCDNaC = chunk.GetNativeArray(ref PlayerAttackAspect_playerStateCDCAc);
			result.PlayerAttackAspect_entityNaE = chunk.GetNativeArray(PlayerAttackAspect_entityEAc);
			result.PlayerAttackAspect_interpolationDelayNaC = chunk.GetNativeArray(ref PlayerAttackAspect_interpolationDelayCAc);
			result.Length = chunk.Count;
			return result;
		}
	}

	public struct Enumerator : IEnumerator<PlayerAttackAspect>, IEnumerator, IDisposable, IEnumerable<PlayerAttackAspect>, IEnumerable
	{
		private ResolvedChunk _Resolved;

		private InternalEntityQueryEnumerator _QueryEnumerator;

		private TypeHandle _Handle;

		public PlayerAttackAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

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

		IEnumerator<PlayerAttackAspect> IEnumerable<PlayerAttackAspect>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}

	public readonly Entity entity;

	public readonly RefRO<EquipmentSlotCD> equipmentSlotCD;

	public readonly RefRO<EquippedObjectCD> equippedObjectCD;

	public readonly RefRW<PlayerAttackCD> playerAttackCD;

	public readonly RefRO<ClientInput> clientInput;

	public readonly RefRW<CornerSmoothingCD> cornerSmoothingCD;

	public readonly RefRO<CollectedAndEnabledSoulsMask> CollectedAndEnabledSoulsMask;

	public readonly DynamicBuffer<PlayerPreviouslyHitEnemiesBuffer> previouslyHitEnemiesBuffer;

	public readonly RefRO<PlayerAimPositionCD> playerAimPosition;

	public readonly RefRW<PlayerEmoteEffectsCD> emoteEffectsCD;

	public readonly RefRO<PlayerMovementCD> playerMovementCD;

	public readonly RefRO<PlayerGhost> playerGhost;

	public readonly RefRO<CommandDataInterpolationDelay> interpolationDelay;

	public readonly RefRW<HungerCD> hungerCD;

	public readonly RefRO<PlayerStateCD> playerStateCD;

	public readonly RefRO<PetOwnerCD> petOwnerCD;

	public PlayerAttackAspect(RefRO<ClientInput> playerattackaspect_clientinputRef, RefRO<CollectedAndEnabledSoulsMask> playerattackaspect_collectedandenabledsoulsmaskRef, RefRW<CornerSmoothingCD> playerattackaspect_cornersmoothingcdRef, RefRO<EquippedObjectCD> playerattackaspect_equippedobjectcdRef, RefRW<HungerCD> playerattackaspect_hungercdRef, RefRO<PetOwnerCD> playerattackaspect_petownercdRef, RefRO<PlayerAimPositionCD> playerattackaspect_playeraimpositionRef, RefRW<PlayerEmoteEffectsCD> playerattackaspect_emoteeffectscdRef, RefRO<EquipmentSlotCD> playerattackaspect_equipmentslotcdRef, RefRW<PlayerAttackCD> playerattackaspect_playerattackcdRef, DynamicBuffer<PlayerPreviouslyHitEnemiesBuffer> playerattackaspect_previouslyhitenemiesbufferDb, RefRO<PlayerGhost> playerattackaspect_playerghostRef, RefRO<PlayerMovementCD> playerattackaspect_playermovementcdRef, RefRO<PlayerStateCD> playerattackaspect_playerstatecdRef, Entity playerattackaspect_entityE, RefRO<CommandDataInterpolationDelay> playerattackaspect_interpolationdelayRef)
	{
		clientInput = playerattackaspect_clientinputRef;
		CollectedAndEnabledSoulsMask = playerattackaspect_collectedandenabledsoulsmaskRef;
		cornerSmoothingCD = playerattackaspect_cornersmoothingcdRef;
		equippedObjectCD = playerattackaspect_equippedobjectcdRef;
		hungerCD = playerattackaspect_hungercdRef;
		petOwnerCD = playerattackaspect_petownercdRef;
		playerAimPosition = playerattackaspect_playeraimpositionRef;
		emoteEffectsCD = playerattackaspect_emoteeffectscdRef;
		equipmentSlotCD = playerattackaspect_equipmentslotcdRef;
		playerAttackCD = playerattackaspect_playerattackcdRef;
		previouslyHitEnemiesBuffer = playerattackaspect_previouslyhitenemiesbufferDb;
		playerGhost = playerattackaspect_playerghostRef;
		playerMovementCD = playerattackaspect_playermovementcdRef;
		playerStateCD = playerattackaspect_playerstatecdRef;
		entity = playerattackaspect_entityE;
		interpolationDelay = playerattackaspect_interpolationdelayRef;
	}

	public PlayerAttackAspect CreateAspect(Entity entity, ref SystemState systemState)
	{
		return new Lookup(ref systemState)[entity];
	}

	public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
	{
		UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
		unsafeList.Add(ComponentType.ReadOnly<ClientInput>());
		unsafeList.Add(ComponentType.ReadOnly<CollectedAndEnabledSoulsMask>());
		unsafeList.Add(ComponentType.ReadWrite<CornerSmoothingCD>());
		unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
		unsafeList.Add(ComponentType.ReadWrite<HungerCD>());
		unsafeList.Add(ComponentType.ReadOnly<PetOwnerCD>());
		unsafeList.Add(ComponentType.ReadOnly<PlayerAimPositionCD>());
		unsafeList.Add(ComponentType.ReadWrite<PlayerEmoteEffectsCD>());
		unsafeList.Add(ComponentType.ReadOnly<EquipmentSlotCD>());
		unsafeList.Add(ComponentType.ReadWrite<PlayerAttackCD>());
		unsafeList.Add(ComponentType.ReadWrite<PlayerPreviouslyHitEnemiesBuffer>());
		unsafeList.Add(ComponentType.ReadOnly<PlayerGhost>());
		unsafeList.Add(ComponentType.ReadOnly<PlayerMovementCD>());
		unsafeList.Add(ComponentType.ReadOnly<PlayerStateCD>());
		unsafeList.Add(ComponentType.ReadOnly<CommandDataInterpolationDelay>());
		UnsafeList<ComponentType> withThese = unsafeList;
		InternalCompilerInterface.MergeWith(ref all, ref withThese);
		withThese.Dispose();
	}

	public static int GetRequiredComponentTypeCount()
	{
		return 15;
	}

	public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
	{
		componentTypes[0] = ComponentType.ReadOnly<ClientInput>();
		componentTypes[1] = ComponentType.ReadOnly<CollectedAndEnabledSoulsMask>();
		componentTypes[2] = ComponentType.ReadWrite<CornerSmoothingCD>();
		componentTypes[3] = ComponentType.ReadOnly<EquippedObjectCD>();
		componentTypes[4] = ComponentType.ReadWrite<HungerCD>();
		componentTypes[5] = ComponentType.ReadOnly<PetOwnerCD>();
		componentTypes[6] = ComponentType.ReadOnly<PlayerAimPositionCD>();
		componentTypes[7] = ComponentType.ReadWrite<PlayerEmoteEffectsCD>();
		componentTypes[8] = ComponentType.ReadOnly<EquipmentSlotCD>();
		componentTypes[9] = ComponentType.ReadWrite<PlayerAttackCD>();
		componentTypes[10] = ComponentType.ReadWrite<PlayerPreviouslyHitEnemiesBuffer>();
		componentTypes[11] = ComponentType.ReadOnly<PlayerGhost>();
		componentTypes[12] = ComponentType.ReadOnly<PlayerMovementCD>();
		componentTypes[13] = ComponentType.ReadOnly<PlayerStateCD>();
		componentTypes[14] = ComponentType.ReadOnly<CommandDataInterpolationDelay>();
	}

	public static Enumerator Query(EntityQuery query, TypeHandle typeHandle)
	{
		return new Enumerator(query, typeHandle);
	}

	public void CompleteDependencyBeforeRO(ref SystemState state)
	{
		state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
		state.EntityManager.CompleteDependencyBeforeRO<CollectedAndEnabledSoulsMask>();
		state.EntityManager.CompleteDependencyBeforeRO<CornerSmoothingCD>();
		state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
		state.EntityManager.CompleteDependencyBeforeRO<HungerCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PetOwnerCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerAimPositionCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerEmoteEffectsCD>();
		state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerAttackCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerPreviouslyHitEnemiesBuffer>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerMovementCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
		state.EntityManager.CompleteDependencyBeforeRO<CommandDataInterpolationDelay>();
	}

	public void CompleteDependencyBeforeRW(ref SystemState state)
	{
		state.EntityManager.CompleteDependencyBeforeRO<ClientInput>();
		state.EntityManager.CompleteDependencyBeforeRO<CollectedAndEnabledSoulsMask>();
		state.EntityManager.CompleteDependencyBeforeRW<CornerSmoothingCD>();
		state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
		state.EntityManager.CompleteDependencyBeforeRW<HungerCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PetOwnerCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerAimPositionCD>();
		state.EntityManager.CompleteDependencyBeforeRW<PlayerEmoteEffectsCD>();
		state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
		state.EntityManager.CompleteDependencyBeforeRW<PlayerAttackCD>();
		state.EntityManager.CompleteDependencyBeforeRW<PlayerPreviouslyHitEnemiesBuffer>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerGhost>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerMovementCD>();
		state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
		state.EntityManager.CompleteDependencyBeforeRO<CommandDataInterpolationDelay>();
	}
}
