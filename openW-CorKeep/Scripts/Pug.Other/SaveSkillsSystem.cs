using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct SaveSkillsSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1641582815_0
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<SkillBuffer> item1_BufferAccessor;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public DynamicBuffer<SkillBuffer> Get(int index)
			{
				return item1_BufferAccessor[index];
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<SkillBuffer> item1_BufferTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SkillBuffer>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<DynamicBuffer<SkillBuffer>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public DynamicBuffer<SkillBuffer> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<SkillBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1641582815_0.TypeHandle __IFE_1641582815_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1641582815_0_TypeHandle = new IFE_1641582815_0.TypeHandle(ref state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1641582815_0;

	public void OnUpdate(ref SystemState state)
	{
		foreach (DynamicBuffer<SkillBuffer> item in IFE_1641582815_0.Query(__query_1641582815_0, __TypeHandle.__IFE_1641582815_0_TypeHandle, ref state))
		{
			for (int i = 0; i < item.Length; i++)
			{
				SkillID skillID = (SkillID)i;
				int value = item[i].Value;
				int skillValue = Manager.saves.GetSkillValue(skillID);
				if (skillValue == item[i].Value)
				{
					continue;
				}
				int levelFromSkill = SkillExtensions.GetLevelFromSkill(skillID, skillValue);
				int maxSkillLevel = SkillExtensions.GetMaxSkillLevel(skillID);
				if (value > skillValue && levelFromSkill >= maxSkillLevel)
				{
					continue;
				}
				Manager.saves.SetSkillValue(skillID, value);
				ConditionData conditionDataForSkill = SkillExtensions.GetConditionDataForSkill(skillID, skillValue);
				ConditionData conditionDataForSkill2 = SkillExtensions.GetConditionDataForSkill(skillID, value);
				if (conditionDataForSkill.value != conditionDataForSkill2.value && !(Manager.main.player == null) && conditionDataForSkill2.value - conditionDataForSkill.value > 0)
				{
					int levelFromSkill2 = SkillExtensions.GetLevelFromSkill(skillID, item[i].Value);
					bool flag = levelFromSkill2 % 5 == 0;
					if (levelFromSkill != 0 || levelFromSkill2 != 3)
					{
						Manager.main.player.SpawnSkillIncreasePopup(skillID, !flag);
					}
					if (flag)
					{
						Manager.main.player.SpawnNewSkillPopup(skillID);
					}
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SkillBuffer>();
		__query_1641582815_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		__query_1641582815_0.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(SkillBuffer))
		});
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((SaveSkillsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SaveSkillsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
