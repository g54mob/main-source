#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class CreateStorageToolAfterDuration : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public CreateStorageToolAfterDuration _003C_003E4__this;

			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CItemHolder holder, in CTakesDuration duration, in CCreateStorageToolAfterDuration create_tool)
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

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.StructuralChangeRuntime runtime_holder;

					public LambdaParameterValueProvider_IComponentData<CTakesDuration>.StructuralChangeRuntime runtime_duration;

					public LambdaParameterValueProvider_IComponentData<CCreateStorageToolAfterDuration>.StructuralChangeRuntime runtime_create_tool;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holder;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CTakesDuration> forParameter_duration;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCreateStorageToolAfterDuration> forParameter_create_tool;

				public void ScheduleTimeInitialize(CreateStorageToolAfterDuration componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_duration.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_create_tool.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_holder = forParameter_holder.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_duration = forParameter_duration.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_create_tool = forParameter_create_tool.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public CreateStorageToolAfterDuration _003C_003E4__this;

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, ref CItemHolder holder, in CTakesDuration duration, in CCreateStorageToolAfterDuration create_tool)
			{
				if (!duration.Active || !(duration.Remaining <= 0f))
				{
					return;
				}
				if (_003C_003E4__this.Require<CItemStorage>((Entity)holder, out CItemStorage comp))
				{
					if (comp.Capacity == 1 && _003C_003E4__this.RequireBuffer((Entity)holder, out DynamicBuffer<CItemStored> comp2) && comp2.Length >= 1)
					{
						CItemStored cItemStored = comp2[0];
						if (_003C_003E4__this.Has<CItem>(cItemStored))
						{
							ctx.Remove<CStoredBy>(cItemStored);
							ctx.Set(cItemStored, new CHeldBy
							{
								Holder = e
							});
							ctx.Destroy(holder);
							holder.HeldItem = cItemStored;
						}
					}
				}
				else if (_003C_003E4__this.Has<CItem>(holder.HeldItem))
				{
					Entity entity = ctx.CreateItem(create_tool.ToolID);
					if (_003C_003E4__this.Require<CToolStorage>(entity, out CToolStorage comp3))
					{
						ctx.Set(entity, new CItemStorage
						{
							Capacity = comp3.Capacity
						});
						ctx.AddBuffer<CItemStored>(entity).Add(holder.HeldItem);
						ctx.Set(holder.HeldItem, new CStoredBy
						{
							Storage = entity
						});
						ctx.Set(holder.HeldItem, new CHeldBy
						{
							Holder = default(Entity)
						});
						ctx.Set(entity, new CHeldBy
						{
							Holder = e
						});
						holder.HeldItem = entity;
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ctx = ctx;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CItemHolder originalComponent;
				CItemHolder holder = reference.runtime_holder.For(entity, out originalComponent);
				CTakesDuration originalComponent2;
				CTakesDuration duration = reference.runtime_duration.For(entity, out originalComponent2);
				CCreateStorageToolAfterDuration originalComponent3;
				CCreateStorageToolAfterDuration create_tool = reference.runtime_create_tool.For(entity, out originalComponent3);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref holder, in duration, in create_tool);
				reference.runtime_holder.WriteBack(entity, ref holder, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(CreateStorageToolAfterDuration componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				ctx = new EntityContext(base.EntityManager)
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadWrite<CItemHolder>(),
				ComponentType.ReadOnly<CTakesDuration>(),
				ComponentType.ReadOnly<CCreateStorageToolAfterDuration>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
