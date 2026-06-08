#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class SpawnMenuAtStand : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public SpawnMenuAtStand _003C_003E4__this;

			public int menu_id;

			internal void _003COnUpdate_003Eb__0(Entity e, ref COccupiedByGroup occupied, in CItemHolder holding, in CApplianceHostStand stand, in CPosition pos)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_e;

					public LambdaParameterValueProvider_IComponentData<COccupiedByGroup>.StructuralChangeRuntime runtime_occupied;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.StructuralChangeRuntime runtime_holding;

					public LambdaParameterValueProvider_IComponentData<CApplianceHostStand>.StructuralChangeRuntime runtime_stand;

					public LambdaParameterValueProvider_IComponentData<CPosition>.StructuralChangeRuntime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<COccupiedByGroup> forParameter_occupied;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holding;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CApplianceHostStand> forParameter_stand;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(SpawnMenuAtStand componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_occupied.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_holding.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_stand.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_occupied = forParameter_occupied.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_holding = forParameter_holding.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_stand = forParameter_stand.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_pos = forParameter_pos.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public SpawnMenuAtStand _003C_003E4__this;

			public int menu_id;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CCustomerGroup> _ComponentDataFromEntity_CCustomerGroup_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CAssignedMenu> _ComponentDataFromEntity_CAssignedMenu_1;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, ref COccupiedByGroup occupied, in CItemHolder holding, in CApplianceHostStand stand, in CPosition pos)
			{
				if (!stand.Automatic && !(holding.HeldItem != default(Entity)) && _ComponentDataFromEntity_CCustomerGroup_0.HasComponent(occupied.Group) && !_ComponentDataFromEntity_CAssignedMenu_1.HasComponent(occupied.Group))
				{
					Entity entity = _003C_003E4__this.EntityManager.CreateEntity();
					_003C_003E4__this.EntityManager.AddComponentData(entity, new CCreateItem
					{
						ID = menu_id,
						Holder = e
					});
					_003C_003E4__this.EntityManager.AddComponentData(entity, new CMenu
					{
						Group = occupied.Group
					});
					_003C_003E4__this.EntityManager.AddComponentData(occupied.Group, new CAssignedMenu
					{
						Menu = entity
					});
					_003C_003E4__this.EntityManager.SetComponentData(e, new CItemHolder
					{
						HeldItem = entity
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				menu_id = displayClass.menu_id;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.menu_id = menu_id;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				COccupiedByGroup originalComponent;
				COccupiedByGroup occupied = reference.runtime_occupied.For(entity, out originalComponent);
				CItemHolder originalComponent2;
				CItemHolder holding = reference.runtime_holding.For(entity, out originalComponent2);
				CApplianceHostStand originalComponent3;
				CApplianceHostStand stand = reference.runtime_stand.For(entity, out originalComponent3);
				CPosition originalComponent4;
				CPosition pos = reference.runtime_pos.For(entity, out originalComponent4);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref occupied, in holding, in stand, in pos);
				reference.runtime_occupied.WriteBack(entity, ref occupied, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(SpawnMenuAtStand componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CCustomerGroup_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CCustomerGroup>(true);
				_ComponentDataFromEntity_CAssignedMenu_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAssignedMenu>(true);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				menu_id = base.Data.ReferableObjects.Menu
			};
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this, ref displayClass);
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
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.WriteToDisplayClass(ref displayClass);
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
				ComponentType.ReadWrite<COccupiedByGroup>(),
				ComponentType.ReadOnly<CItemHolder>(),
				ComponentType.ReadOnly<CApplianceHostStand>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
