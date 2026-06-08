#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine.AI;

namespace Kitchen
{
	[UpdateInGroup(typeof(TableUpdatesGroup))]
	[UpdateBefore(typeof(AssembleTableSets))]
	public class MarkPathableHostStands : RestaurantTableUpdateSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public MarkPathableHostStands _003C_003E4__this;

			public SPerformTableUpdate spec;

			internal void _003COnUpdate_003Eb__0(Entity e, in CPosition pos)
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

					public LambdaParameterValueProvider_IComponentData<CPosition>.StructuralChangeRuntime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(MarkPathableHostStands componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_pos = forParameter_pos.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public MarkPathableHostStands _003C_003E4__this;

			public SPerformTableUpdate spec;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, in CPosition pos)
			{
				bool flag = false;
				Entity occupant = _003C_003E4__this.TileManager.GetOccupant(pos.ForwardPosition);
				if (!((occupant != default(Entity)) & _003C_003E4__this.Has<CAppliance>(occupant) & !_003C_003E4__this.Has<CApplianceChair>(occupant) & !_003C_003E4__this.Has<CApplianceGhostChair>(occupant) & !_003C_003E4__this.Has<CLetter>(occupant) & !_003C_003E4__this.Has<CApplianceBlueprint>(occupant) & !_003C_003E4__this.Has<CDestroyApplianceAtDay>(occupant)) && _003C_003E4__this.TileManager.CanReach(pos, pos.ForwardPosition))
				{
					_003C_003E4__this.Set<CEmptyAhead>(e);
					NavMesh.CalculatePath(spec.PathingSource, pos.ForwardPosition, -1, _003C_003E4__this.Path);
					flag = _003C_003E4__this.Path.status == NavMeshPathStatus.PathComplete;
				}
				else
				{
					_003C_003E4__this.EntityManager.RemoveComponent(e, typeof(CEmptyAhead));
				}
				if (flag)
				{
					_003C_003E4__this.Set<CPathable>(e);
				}
				else
				{
					_003C_003E4__this.EntityManager.RemoveComponent(e, typeof(CPathable));
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				spec = displayClass.spec;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.spec = spec;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CPosition originalComponent;
				CPosition pos = reference.runtime_pos.For(entity, out originalComponent);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, in pos);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(MarkPathableHostStands componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private NavMeshPath Path = new NavMeshPath();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPerformTableUpdate_62;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				spec = _SingletonEntityQuery_SPerformTableUpdate_62.GetSingleton<SPerformTableUpdate>()
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
			_SingletonEntityQuery_SPerformTableUpdate_62 = GetEntityQuery(ComponentType.ReadOnly<SPerformTableUpdate>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<CPosition>() };
			entityQueryDesc.Any = new ComponentType[2]
			{
				ComponentType.ReadWrite<CApplianceHostStand>(),
				ComponentType.ReadWrite<CApplianceRequiresPathable>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
