#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateInGroup(typeof(ItemTransferPropose))]
	public class TakeFromAreaSource : TransferProposalSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public TakeFromAreaSource _003C_003E4__this;

			public NativeArray<Entity> sources;

			public NativeArray<CItemAreaSource> source_components;

			public NativeArray<CItemProvider> source_provider;

			public NativeArray<CPosition> source_positions;

			public EntityContext ctx;

			public TransferFlags flags;

			internal void _003COnUpdate_003Eb__0(Entity item, in CItem item_data, in CHeldBy holder)
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

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_item;

					public LambdaParameterValueProvider_IComponentData<CItem>.StructuralChangeRuntime runtime_item_data;

					public LambdaParameterValueProvider_IComponentData<CHeldBy>.StructuralChangeRuntime runtime_holder;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_item;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItem> forParameter_item_data;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CHeldBy> forParameter_holder;

				public void ScheduleTimeInitialize(TakeFromAreaSource componentSystem)
				{
					forParameter_item.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_item_data.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_item = forParameter_item.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_item_data = forParameter_item_data.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_holder = forParameter_holder.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public TakeFromAreaSource _003C_003E4__this;

			public NativeArray<Entity> sources;

			public NativeArray<CItemAreaSource> source_components;

			public NativeArray<CItemProvider> source_provider;

			public NativeArray<CPosition> source_positions;

			public EntityContext ctx;

			public TransferFlags flags;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity item, in CItem item_data, in CHeldBy holder)
			{
				if (!_003C_003E4__this.Require<CPosition>((Entity)holder, out CPosition comp))
				{
					return;
				}
				for (int i = 0; i < source_components.Length; i++)
				{
					Entity source = sources[i];
					CItemAreaSource cItemAreaSource = source_components[i];
					CItemProvider cItemProvider = source_provider[i];
					if ((source_positions[i].Position - comp.Position).sqrMagnitude < cItemAreaSource.Range * cItemAreaSource.Range)
					{
						TransferProposalSystem.CreateProposal(ctx, _003C_003E4__this, ctx.CreateItemGroup(cItemProvider.ProvidedItem, cItemProvider.ProvidedComponents), source, holder, flags);
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				sources = displayClass.sources;
				source_components = displayClass.source_components;
				source_provider = displayClass.source_provider;
				source_positions = displayClass.source_positions;
				ctx = displayClass.ctx;
				flags = displayClass.flags;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.sources = sources;
				displayClass.source_components = source_components;
				displayClass.source_provider = source_provider;
				displayClass.source_positions = source_positions;
				displayClass.ctx = ctx;
				displayClass.flags = flags;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity item = reference.runtime_item.For(entity);
				CItem originalComponent;
				CItem item_data = reference.runtime_item_data.For(entity, out originalComponent);
				CHeldBy originalComponent2;
				CHeldBy holder = reference.runtime_holder.For(entity, out originalComponent2);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(item, in item_data, in holder);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(TakeFromAreaSource componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private EntityQuery Sources;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			Sources = GetEntityQuery(typeof(CItemProvider), typeof(CItemAreaSource), typeof(CPosition));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this,
				sources = Sources.ToEntityArray(Allocator.Temp)
			};
			try
			{
				displayClass.source_components = Sources.ToComponentDataArray<CItemAreaSource>(Allocator.Temp);
				try
				{
					displayClass.source_provider = Sources.ToComponentDataArray<CItemProvider>(Allocator.Temp);
					try
					{
						displayClass.source_positions = Sources.ToComponentDataArray<CPosition>(Allocator.Temp);
						try
						{
							displayClass.ctx = new EntityContext(base.EntityManager);
							displayClass.flags = TransferFlags.RequireMerge | TransferFlags.NoReturns | TransferFlags.Provider;
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
						finally
						{
							((IDisposable)displayClass.source_positions/*cast due to .constrained prefix*/).Dispose();
						}
					}
					finally
					{
						((IDisposable)displayClass.source_provider/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)displayClass.source_components/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)displayClass.sources/*cast due to .constrained prefix*/).Dispose();
			}
		}

		public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx)
		{
			if (Require<CItemTransferProposal>(transfer, out CItemTransferProposal comp) && Require<CItemProvider>(comp.Source, out CItemProvider comp2) && comp2.Maximum > 0)
			{
				comp2.Available--;
				SetComponent(comp.Source, comp2);
			}
		}

		public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx)
		{
		}

		public override void Tidy(EntityContext ctx, CItemTransferProposal proposal)
		{
			if (proposal.Status != ItemTransferStatus.Resolved)
			{
				ctx.Destroy(proposal.Item);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CItem>(),
				ComponentType.ReadOnly<CHeldBy>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
