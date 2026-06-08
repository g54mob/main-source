#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class RebuildKitchen : FranchiseSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CNonKitchen : IComponentData
		{
		}

		public struct SCurrentKitchen : IComponentData
		{
			public int Dish;
		}

		public struct CRebuildKitchen : IComponentData
		{
			public int Dish;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CFranchiseKitchenSlot : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CFranchiseKitchenAppliance : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CFranchiseKitchenMenuItem : IComponentData
		{
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_DynamicBuffer<CDirtItem>.Runtime runtime_dirt;
				}

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				private LambdaParameterValueProvider_DynamicBuffer<CDirtItem> forParameter_dirt;

				public void ScheduleTimeInitialize(RebuildKitchen componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_dirt.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_dirt = forParameter_dirt.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000104_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000104_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000104_0024PostfixBurstDelegate).TypeHandle);
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					IntPtr result = (IntPtr)0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public static void Constructor()
				{
					DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
				}

				public static void Initialize()
				{
				}

				static RunWithoutJobSystem_00000104_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static void Invoke(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((UIntPtr/*delegate* unmanaged[Cdecl]<ArchetypeChunkIterator*, void*, void>*/)(void*)(long)functionPointer)(archetypeChunkIterator, jobData);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(archetypeChunkIterator, jobData);
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CDirtItem> dirt)
			{
				dirt.Clear();
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CDirtItem> dirt = runtimes.runtime_dirt.For(i);
					OriginalLambdaBody(e, ref dirt);
				}
			}

			public void ScheduleTimeInitialize(RebuildKitchen componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000104_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery RebuildRequests;

		private EntityQuery OldMenuItems;

		private EntityQuery Slots;

		private EntityQuery OldAppliances;

		private EntityQuery KitchenItems;

		private EntityQuery Customers;

		private EntityQuery Mess;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCurrentKitchen_1;

		private EntityQuery _SingletonEntityQuery_SCurrentKitchen_2;

		protected override void Initialise()
		{
			base.Initialise();
			RebuildRequests = GetEntityQuery(typeof(CRebuildKitchen));
			OldMenuItems = GetEntityQuery(typeof(CFranchiseKitchenMenuItem));
			Slots = GetEntityQuery(typeof(CFranchiseKitchenSlot), typeof(CPosition));
			OldAppliances = GetEntityQuery(typeof(CFranchiseKitchenAppliance));
			KitchenItems = GetEntityQuery(new QueryHelper().All(typeof(CItem)).None(typeof(CFranchiseNonKitchenItem), typeof(CPersistentItem), typeof(CDishChoice), typeof(CContractChoice), typeof(CItemLayoutMap), typeof(CNonKitchen)));
			Customers = GetEntityQuery(typeof(CCustomerGroup));
			Mess = GetEntityQuery(typeof(CMess));
			RequireForUpdate(RebuildRequests);
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<SCurrentKitchen>())
			{
				base.EntityManager.CreateEntity(typeof(SCurrentKitchen));
			}
			int current_dish = _SingletonEntityQuery_SCurrentKitchen_1.GetSingleton<SCurrentKitchen>().Dish;
			CRebuildKitchen cRebuildKitchen = RebuildRequests.FirstMatching((CRebuildKitchen m) => m.Dish != current_dish);
			base.EntityManager.DestroyEntity(RebuildRequests);
			base.EntityManager.DestroyEntity(Mess);
			if (cRebuildKitchen.Dish != 0 && base.Data.TryGet<Dish>(cRebuildKitchen.Dish, out var output, warn_if_fail: true))
			{
				base.EntityManager.DestroyEntity(OldMenuItems);
				base.EntityManager.DestroyEntity(KitchenItems);
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
				jobData.ScheduleTimeInitialize(this);
				CompleteDependency();
				EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
				}
				finally
				{
					_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
				}
				base.EntityManager.AddComponent<CGroupStartLeaving>(Customers);
				RecreateAppliances(output);
				RecreateMenu(output);
				_SingletonEntityQuery_SCurrentKitchen_2.SetSingleton(new SCurrentKitchen
				{
					Dish = cRebuildKitchen.Dish
				});
			}
		}

		protected void RecreateAppliances(Dish dish)
		{
			base.EntityManager.DestroyEntity(OldAppliances);
			int num = 0;
			using NativeArray<Entity> nativeArray = Slots.ToEntityArray(Allocator.Temp);
			HashSet<Process> hashSet = new HashSet<Process>(dish.RequiredProcesses);
			foreach (Appliance.ApplianceProcesses process in GameData.Main.Get<Appliance>(AssetReference.Counter).Processes)
			{
				hashSet.Remove(process.Process);
			}
			foreach (GameDataObject item in new HashSet<GameDataObject>(hashSet.Select((Process e) => e.BasicEnablingAppliance)))
			{
				if (!(item == null))
				{
					if (num >= nativeArray.Length)
					{
						Debug.LogError($"Not enough slots to create appliances (used {num} of {nativeArray.Length}, building {((UnityEngine.Object)(object)dish).name})");
						return;
					}
					Entity entity = base.EntityManager.CreateEntity(typeof(CFranchiseKitchenAppliance));
					base.EntityManager.AddComponentData(entity, GetComponent<CPosition>(nativeArray[num++]));
					base.EntityManager.AddComponentData(entity, new CCreateAppliance
					{
						ID = item.ID
					});
				}
			}
			foreach (Item item2 in new HashSet<Item>(dish.MinimumIngredients))
			{
				if (num >= nativeArray.Length)
				{
					Debug.LogError($"Not enough slots to create ingredients (used {num} of {nativeArray.Length}, building {((UnityEngine.Object)(object)dish).name})");
					break;
				}
				if (item2.ID == AssetReference.WaterItem)
				{
					continue;
				}
				Appliance dedicatedProvider = item2.DedicatedProvider;
				Entity entity2 = base.EntityManager.CreateEntity(typeof(CFranchiseKitchenAppliance));
				int iD = ((dedicatedProvider == null || dedicatedProvider.ID == 0) ? base.Data.ReferableObjects.DefaultProvider.ID : dedicatedProvider.ID);
				base.EntityManager.AddComponentData(entity2, new CCreateAppliance
				{
					ID = iD
				});
				bool flag = false;
				if (dedicatedProvider != null && dedicatedProvider.Properties != null)
				{
					foreach (IApplianceProperty property in dedicatedProvider.Properties)
					{
						if (property is CItemProvider)
						{
							flag = true;
							break;
						}
					}
				}
				base.EntityManager.AddComponentData(entity2, GetComponent<CPosition>(nativeArray[num++]));
				if (!flag)
				{
					base.EntityManager.AddComponentData(entity2, CItemProvider.InfiniteItemProvider(item2.ID));
				}
			}
		}

		protected void RecreateMenu(Dish dish)
		{
			foreach (Dish.MenuItem unlocksMenuItem in dish.UnlocksMenuItems)
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CMenuItem), typeof(CFranchiseKitchenMenuItem), typeof(CAvailableIngredient));
				base.EntityManager.AddComponentData(entity, new CMenuItem
				{
					Item = unlocksMenuItem.Item.ID,
					Weight = 1f,
					Phase = unlocksMenuItem.Phase
				});
				switch (unlocksMenuItem.Phase)
				{
				case MenuPhase.Starter:
					base.EntityManager.AddComponent<CMenuItemStarter>(entity);
					break;
				case MenuPhase.Main:
					base.EntityManager.AddComponent<CMenuItemMain>(entity);
					break;
				case MenuPhase.Dessert:
					base.EntityManager.AddComponent<CMenuItemDessert>(entity);
					break;
				case MenuPhase.Side:
					base.EntityManager.AddComponent<CMenuItemSide>(entity);
					break;
				}
				if (!(unlocksMenuItem.Item is ItemGroup itemGroup))
				{
					continue;
				}
				foreach (ItemGroup.ItemSet derivedSet in itemGroup.DerivedSets)
				{
					foreach (Item item in derivedSet.Items)
					{
						if (derivedSet.RequiresUnlock)
						{
							bool flag = false;
							foreach (Dish.IngredientUnlock unlocksIngredient in dish.UnlocksIngredients)
							{
								if (unlocksIngredient.MenuItem == itemGroup && unlocksIngredient.Ingredient == item)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								continue;
							}
						}
						UnlockIngredient(unlocksMenuItem.Item.ID, item.ID);
					}
				}
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SCurrentKitchen_1 = GetEntityQuery(ComponentType.ReadOnly<SCurrentKitchen>());
			_SingletonEntityQuery_SCurrentKitchen_2 = GetEntityQuery(ComponentType.ReadWrite<SCurrentKitchen>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CDirtItem>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0_RunWithoutJobSystem_00000104_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem_00000104_0024BurstDirectCall.Initialize();
		}
	}
}
