#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class ImproveBlueprintAfterDuration : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public ImproveBlueprintAfterDuration _003C_003E4__this;

			public float discount;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity desk, ref CDeskTarget target, ref CTakesDuration duration)
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_desk;

					public LambdaParameterValueProvider_IComponentData<CDeskTarget>.Runtime runtime_target;

					public LambdaParameterValueProvider_IComponentData<CTakesDuration>.Runtime runtime_duration;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_desk;

				private LambdaParameterValueProvider_IComponentData<CDeskTarget> forParameter_target;

				private LambdaParameterValueProvider_IComponentData<CTakesDuration> forParameter_duration;

				public void ScheduleTimeInitialize(ImproveBlueprintAfterDuration componentSystem)
				{
					forParameter_desk.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_target.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_duration.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_desk = forParameter_desk.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_target = forParameter_target.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_duration = forParameter_duration.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public ImproveBlueprintAfterDuration _003C_003E4__this;

			public float discount;

			public EntityCommandBuffer ecb;

			[NoAlias]
			private ComponentDataFromEntity<CBlueprintStore> _ComponentDataFromEntity_CBlueprintStore_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity desk, ref CDeskTarget target, ref CTakesDuration duration)
			{
				if (!duration.Active || duration.Remaining > 0f || !_003C_003E4__this.Require<CBlueprintStore>(target.Target, out CBlueprintStore comp) || !comp.InUse || !_003C_003E4__this.Data.TryGet<Appliance>(comp.ApplianceID, out var output))
				{
					return;
				}
				if (_003C_003E4__this.Require<CModifyBlueprintStoreAfterDuration>(desk, out CModifyBlueprintStoreAfterDuration comp2))
				{
					if (comp2.PerformUpgrade && output.HasUpgrades && !comp.HasBeenUpgraded)
					{
						Appliance appliance = output.Upgrades.Random();
						comp.Price = Mathf.CeilToInt((float)appliance.PurchaseCost * discount);
						if (comp.HasBeenMadeFree)
						{
							comp.Price = Mathf.CeilToInt((float)comp.Price / 2f);
						}
						comp.ApplianceID = appliance.ID;
						comp.BlueprintID = AssetReference.Blueprint;
						comp.HasBeenUpgraded = true;
					}
					if (comp2.PerformCopy)
					{
						comp.HasBeenCopied = true;
					}
					if (comp2.MakeFree)
					{
						comp.Price = Mathf.CeilToInt((float)comp.Price / 2f);
						comp.HasBeenMadeFree = true;
					}
				}
				if (_003C_003E4__this.Has<CEnchantBlueprintAfterDuration>(desk) && output.HasEnchantments && !comp.HasBeenUpgraded)
				{
					Appliance appliance2 = output.Enchantments.Random();
					comp.Price = Mathf.CeilToInt((float)appliance2.PurchaseCost * discount);
					if (comp.HasBeenMadeFree)
					{
						comp.Price = Mathf.CeilToInt((float)comp.Price / 2f);
					}
					comp.ApplianceID = appliance2.ID;
					comp.BlueprintID = AssetReference.Blueprint;
					comp.HasBeenUpgraded = true;
				}
				if (_003C_003E4__this.Require<CCabinetModifier>(target.Target, out CCabinetModifier comp3) && comp3.DisablesDeskAfterImprovement)
				{
					ecb.AddComponent<CIsBroken>(desk);
				}
				_ComponentDataFromEntity_CBlueprintStore_0[target.Target] = comp;
				target.Target = default(Entity);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				discount = displayClass.discount;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.discount = discount;
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_desk.For(i), ref runtimes.runtime_target.For(i), ref runtimes.runtime_duration.For(i));
				}
			}

			public void ScheduleTimeInitialize(ImproveBlueprintAfterDuration componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CBlueprintStore_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CBlueprintStore>(false);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Discounts;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Discounts = GetEntityQuery(typeof(CGrantsShopDiscount));
			RequireForUpdate(GetEntityQuery(typeof(CDeskTarget)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End)
			};
			using NativeArray<CGrantsShopDiscount> nativeArray = Discounts.ToComponentDataArray<CGrantsShopDiscount>(Allocator.Temp);
			displayClass.discount = 1f;
			foreach (CGrantsShopDiscount item in nativeArray)
			{
				displayClass.discount *= 1f - item.Amount;
			}
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
				ComponentType.ReadWrite<CDeskTarget>(),
				ComponentType.ReadWrite<CTakesDuration>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CPreventUse>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
