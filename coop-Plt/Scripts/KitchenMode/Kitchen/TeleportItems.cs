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
	[UpdateAfter(typeof(ApplyItemProcesses))]
	[UpdateBefore(typeof(PushItems))]
	public class TeleportItems : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public float dt;

			public TeleportItems _003C_003E4__this;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CItemHolder holder, ref CConveyTeleport teleport)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_holder;

					public LambdaParameterValueProvider_IComponentData<CConveyTeleport>.Runtime runtime_teleport;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holder;

				private LambdaParameterValueProvider_IComponentData<CConveyTeleport> forParameter_teleport;

				public void ScheduleTimeInitialize(TeleportItems componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_teleport.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holder = forParameter_holder.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_teleport = forParameter_teleport.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public float dt;

			public TeleportItems _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CItemHolder holder, ref CConveyTeleport teleport)
			{
				teleport.CurrentCooldown -= dt;
				if (_003C_003E4__this.Has<CHeldBy>(e))
				{
					teleport.HasReceivedTeleport = false;
					teleport.CurrentCooldown = 0f;
					return;
				}
				bool flag = _003C_003E4__this.Has<CHeldBy>(holder);
				if (teleport.HasReceivedTeleport)
				{
					if (flag)
					{
						return;
					}
					teleport.HasReceivedTeleport = false;
				}
				if (teleport.CurrentCooldown > 0f || !flag || _003C_003E4__this.Has<CItemUndergoingProcess>(holder.HeldItem))
				{
					return;
				}
				Entity heldItem = holder.HeldItem;
				if (_003C_003E4__this.Require<CItemHolder>(teleport.Target, out CItemHolder comp) && !_003C_003E4__this.Has<CHeldBy>(comp.HeldItem))
				{
					_003C_003E4__this.Set(heldItem, (CHeldBy)teleport.Target);
					holder.HeldItem = default(Entity);
					teleport.CurrentCooldown = teleport.SendCooldown;
					_003C_003E4__this.Set(teleport.Target, (CItemHolder)heldItem);
					if (_003C_003E4__this.Require<CConveyTeleport>(teleport.Target, out CConveyTeleport comp2))
					{
						comp2.HasReceivedTeleport = true;
						_003C_003E4__this.Set(teleport.Target, comp2);
					}
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

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			public void IterateEntities(ref ArchetypeChunk chunk, ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_holder.For(i), ref runtimes.runtime_teleport.For(i));
				}
			}

			public void ScheduleTimeInitialize(TeleportItems componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
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
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CItemHolder>(),
				ComponentType.ReadWrite<CConveyTeleport>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CDisableAutomation>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
