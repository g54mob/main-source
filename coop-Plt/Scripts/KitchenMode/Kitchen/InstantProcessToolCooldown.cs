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
	public class InstantProcessToolCooldown : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public float dt;

			public InstantProcessToolCooldown _003C_003E4__this;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CInstantProcessToolOnCooldown cooldown, in CInstantProcessTool tool)
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

					public LambdaParameterValueProvider_IComponentData<CInstantProcessToolOnCooldown>.StructuralChangeRuntime runtime_cooldown;

					public LambdaParameterValueProvider_IComponentData<CInstantProcessTool>.StructuralChangeRuntime runtime_tool;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CInstantProcessToolOnCooldown> forParameter_cooldown;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CInstantProcessTool> forParameter_tool;

				public void ScheduleTimeInitialize(InstantProcessToolCooldown componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_cooldown.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_tool.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_cooldown = forParameter_cooldown.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_tool = forParameter_tool.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public float dt;

			public InstantProcessToolCooldown _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, ref CInstantProcessToolOnCooldown cooldown, in CInstantProcessTool tool)
			{
				cooldown.ProgressSeconds += dt;
				if (cooldown.ProgressSeconds >= tool.CooldownSeconds)
				{
					_003C_003E4__this.EntityManager.RemoveComponent<CInstantProcessToolOnCooldown>(e);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				dt = displayClass.dt;
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.dt = dt;
				displayClass._003C_003E4__this = _003C_003E4__this;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CInstantProcessToolOnCooldown originalComponent;
				CInstantProcessToolOnCooldown cooldown = reference.runtime_cooldown.For(entity, out originalComponent);
				CInstantProcessTool originalComponent2;
				CInstantProcessTool tool = reference.runtime_tool.For(entity, out originalComponent2);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref cooldown, in tool);
				reference.runtime_cooldown.WriteBack(entity, ref cooldown, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(InstantProcessToolCooldown componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
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
				dt = base.Time.DeltaTime
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CInstantProcessToolOnCooldown>(),
				ComponentType.ReadOnly<CInstantProcessTool>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
