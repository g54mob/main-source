#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Kitchen.ShopBuilder;
using KitchenData;
using MessagePack;
using TMPro;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kitchen
{
	[Serializable]
	public class BlueprintView : UpdatableObjectView<BlueprintView.ViewData>
	{
		public class UpdateBlueprintView : IncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass3_0
			{
				public int money;

				public UpdateBlueprintView _003C_003E4__this;

				public NativeArray<CShopBuilderOption> opts;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CApplianceBlueprint appliance, in CForSale sale)
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
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_IComponentData<CApplianceBlueprint>.Runtime runtime_appliance;

						public LambdaParameterValueProvider_IComponentData<CForSale>.Runtime runtime_sale;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CApplianceBlueprint> forParameter_appliance;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CForSale> forParameter_sale;

					public void ScheduleTimeInitialize(UpdateBlueprintView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_sale.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_appliance = forParameter_appliance.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_sale = forParameter_sale.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public int money;

				public UpdateBlueprintView _003C_003E4__this;

				public NativeArray<CShopBuilderOption> opts;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CApplianceBlueprint appliance, in CForSale sale)
				{
					ViewData update = new ViewData
					{
						IconPrefab = appliance.Appliance,
						PlayerMoney = money,
						Price = sale.Price,
						IsCopy = appliance.IsCopy,
						AnyEnchantingDesk = !_003C_003E4__this.EnchantingDesks.IsEmpty
					};
					foreach (CShopBuilderOption opt in opts)
					{
						if (opt.Appliance == appliance.Appliance)
						{
							update.Staple = opt.Staple;
							break;
						}
					}
					_003C_003E4__this.SendUpdate(linked_view, update, MessageType.SpecificViewUpdate);
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					money = displayClass.money;
					_003C_003E4__this = displayClass._003C_003E4__this;
					opts = displayClass.opts;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					displayClass.money = money;
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.opts = opts;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_appliance.For(i), in runtimes.runtime_sale.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateBlueprintView componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery ShopBuilderOptions;

			private EntityQuery EnchantingDesks;

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SMoney_3;

			protected override void Initialise()
			{
				base.Initialise();
				ShopBuilderOptions = GetEntityQuery(typeof(CShopBuilderOption));
				EnchantingDesks = GetEntityQuery(typeof(CEnchantBlueprintAfterDuration));
				RequireForUpdate(GetEntityQuery(typeof(CApplianceBlueprint), typeof(CLinkedView)));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
				{
					_003C_003E4__this = this,
					money = (HasSingleton<SMoney>() ? _SingletonEntityQuery_SMoney_3.GetSingleton<SMoney>().Amount : 0),
					opts = ShopBuilderOptions.ToComponentDataArray<CShopBuilderOption>(Allocator.Temp)
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
				_SingletonEntityQuery_SMoney_3 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CApplianceBlueprint>(),
					ComponentType.ReadOnly<CForSale>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int IconPrefab;

			[Key(1)]
			public int PlayerMoney;

			[Key(2)]
			public int Price;

			[Key(3)]
			public bool IsCopy;

			[Key(4)]
			public ShopStapleType Staple;

			[Key(5)]
			public bool AnyEnchantingDesk;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<BlueprintView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (IconPrefab == check.IconPrefab && PlayerMoney == check.PlayerMoney && Price == check.Price && IsCopy == check.IsCopy && Staple == check.Staple)
				{
					return AnyEnchantingDesk != check.AnyEnchantingDesk;
				}
				return true;
			}
		}

		[SerializeField]
		[Header("References")]
		private TextMeshPro Title;

		[SerializeField]
		private TextMeshPro Rarity;

		[SerializeField]
		private MeshRenderer IconRenderer;

		[SerializeField]
		private TextMeshPro PriceIcon;

		[SerializeField]
		[FormerlySerializedAs("Localisation")]
		private RarityTierLocalisation RarityLocalisation;

		[SerializeField]
		private MeshRenderer Colour;

		private string Affordable = "<sprite name=\"coin\" color=#FF9800>";

		private string Unaffordable = "<sprite name=\"coin\" color=#660700>";

		private string Copy = "<sprite name=\"copy\" color=#ffffff>";

		private string Upgradable = "<sprite name=\"upgrade\" color=#A8FF1E>";

		private string Enchantable = "<sprite name=\"enchant\" color=#DA20FF>";

		protected override void UpdateData(ViewData data)
		{
			RegisterDisposable(IconRenderer.material).SetTexture("_Image", PrefabSnapshot.GetSnapshot(GameData.Main.GetPrefab(data.IconPrefab)));
			RegisterDisposable(IconRenderer.material).SetFloat("_IsBlowout", data.IsCopy ? 1 : 0);
			if (!GameData.Main.TryGet<Appliance>(data.IconPrefab, out var output))
			{
				Title.text = data.IconPrefab.ToString();
				return;
			}
			Title.text = output.Name;
			Rarity.text = RarityLocalisation[output.RarityTier];
			StringBuilder stringBuilder = new StringBuilder();
			if (data.IsCopy)
			{
				stringBuilder.Append(Copy);
			}
			if (output.HasUpgrades)
			{
				stringBuilder.Append(Upgradable);
			}
			if (data.AnyEnchantingDesk && output.HasEnchantments)
			{
				stringBuilder.Append(Enchantable);
			}
			stringBuilder.Append((data.PlayerMoney >= data.Price) ? Affordable : Unaffordable);
			PriceIcon.text = stringBuilder.ToString();
			Color color = data.Staple switch
			{
				ShopStapleType.FixedStaple => new Color(0.44f, 0.44f, 0.44f), 
				ShopStapleType.WhenMissing => new Color(0.53f, 0.49f, 0.2f), 
				ShopStapleType.BonusStaple => new Color(1f, 0.26f, 0.82f), 
				ShopStapleType.NonStaple => output.IsAnUpgrade ? new Color(0.26f, 0.83f, 1f) : new Color(1f, 1f, 1f), 
				_ => new Color(1f, 1f, 1f), 
			};
			float num = ((data.Staple != ShopStapleType.NonStaple) ? 0.2f : (output.IsAnUpgrade ? 0.3f : 0f));
			float value = num;
			Material material = RegisterDisposable(Colour.material);
			material.SetFloat("_IsCopy", data.IsCopy ? 1 : 0);
			material.SetFloat("_HasColour", value);
			material.color = color;
			Rarity.color = color;
		}
	}
}
