#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class PlayerSpreadsMess : GenericSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CPlayer>.StructuralChangeRuntime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CPlayerDirtyShoes>.StructuralChangeRuntime runtime_dirty;

					public LambdaParameterValueProvider_IComponentData<CPlayerCosmetics>.StructuralChangeRuntime runtime_shoes;

					public LambdaParameterValueProvider_IComponentData<CPosition>.StructuralChangeRuntime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				private LambdaParameterValueProvider_IComponentData<CPlayerDirtyShoes> forParameter_dirty;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPlayerCosmetics> forParameter_shoes;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(PlayerSpreadsMess componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_dirty.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_shoes.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_player = forParameter_player.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_dirty = forParameter_dirty.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_shoes = forParameter_shoes.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_pos = forParameter_pos.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public PlayerSpreadsMess hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			public void OriginalLambdaBody(Entity e, ref CPlayer player, ref CPlayerDirtyShoes dirty, [In] ref CPlayerCosmetics shoes, [In] ref CPosition pos)
			{
				hostInstance._003COnUpdate_003Eb__0_0(e, ref player, ref dirty, in shoes, in pos);
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CPlayer originalComponent;
				CPlayer player = reference.runtime_player.For(entity, out originalComponent);
				CPlayerDirtyShoes originalComponent2;
				CPlayerDirtyShoes dirty = reference.runtime_dirty.For(entity, out originalComponent2);
				CPlayerCosmetics originalComponent3;
				CPlayerCosmetics shoes = reference.runtime_shoes.For(entity, out originalComponent3);
				CPosition originalComponent4;
				CPosition pos = reference.runtime_pos.For(entity, out originalComponent4);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref player, ref dirty, ref shoes, ref pos);
				reference.runtime_player.WriteBack(entity, ref player, ref originalComponent);
				reference.runtime_dirty.WriteBack(entity, ref dirty, ref originalComponent2);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(PlayerSpreadsMess componentSystem)
			{
				hostInstance = componentSystem;
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.Execute(this, query);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity e, ref CPlayer player, ref CPlayerDirtyShoes dirty, in CPlayerCosmetics shoes, in CPosition pos)
		{
			if (dirty.MessID != 0 && shoes.Shoe != PlayerShoe.None && !(base.TileManager.GetOccupant(pos.Position) != default(Entity)) && base.TileManager.GetOccupant(pos.Position, OccupancyLayer.Floor) == default(Entity))
			{
				if (Random.value < 0.5f)
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
					base.EntityManager.AddComponentData(entity, new CCreateAppliance
					{
						ID = dirty.MessID,
						ForceLayer = OccupancyLayer.Floor
					});
					base.EntityManager.AddComponentData(entity, default(CMess));
					base.EntityManager.AddComponentData(entity, CPosition.Rounded(pos));
				}
				else
				{
					dirty.TimeUntil = -1f;
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
			{
				ComponentType.ReadWrite<CPlayer>(),
				ComponentType.ReadWrite<CPlayerDirtyShoes>(),
				ComponentType.ReadOnly<CPlayerCosmetics>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
