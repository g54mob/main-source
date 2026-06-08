#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using KitchenData;
using MessagePack;
using TMPro;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class ApplianceInfoView : UpdatableObjectView<ApplianceInfoView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass2_0
			{
				public UpdateView _003C_003E4__this;

				public int money;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView view, in CApplianceInfo info)
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_view;

						public LambdaParameterValueProvider_IComponentData<CApplianceInfo>.Runtime runtime_info;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CApplianceInfo> forParameter_info;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_info.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_view = forParameter_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_info = forParameter_info.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public int money;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView view, in CApplianceInfo info)
				{
					_003C_003E4__this.SendUpdate(view.Identifier, new ViewData
					{
						ID = info.ID,
						PlayerMoney = money,
						Mode = info.Mode,
						Price = info.Price,
						AnyEnchantingDesk = !_003C_003E4__this.EnchantingDesks.IsEmpty
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					money = displayClass.money;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.money = money;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_view.For(i), in runtimes.runtime_info.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery EnchantingDesks;

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SMoney_2;

			protected override void Initialise()
			{
				base.Initialise();
				EnchantingDesks = GetEntityQuery(typeof(CEnchantBlueprintAfterDuration));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
				{
					_003C_003E4__this = this,
					money = (HasSingleton<SMoney>() ? _SingletonEntityQuery_SMoney_2.GetSingleton<SMoney>().Amount : 0)
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
				_SingletonEntityQuery_SMoney_2 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CApplianceInfo>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int ID;

			[Key(1)]
			public int PlayerMoney;

			[Key(2)]
			public CApplianceInfo.ApplianceInfoMode Mode;

			[Key(3)]
			public int Price;

			[Key(4)]
			public bool AnyEnchantingDesk;

			public bool IsChangedFrom(ViewData check)
			{
				if (ID == check.ID && PlayerMoney == check.PlayerMoney && Mode == check.Mode && Price == check.Price)
				{
					return AnyEnchantingDesk != check.AnyEnchantingDesk;
				}
				return true;
			}
		}

		[Header("Configuration")]
		[SerializeField]
		private float TopTextHeight = 0.95f;

		[SerializeField]
		private float SectionStartOffset = 2.2f;

		[SerializeField]
		private float SectionHeight = -0.8f;

		[SerializeField]
		private float TagHeight = -0.5f;

		[SerializeField]
		private Color Affordable;

		[SerializeField]
		private Color Unaffordable;

		[SerializeField]
		[Header("References")]
		private TextMeshPro Title;

		[SerializeField]
		private TextMeshPro Description;

		[SerializeField]
		private GameObject Sections;

		[SerializeField]
		private GameObject PriceTag;

		[SerializeField]
		private TextMeshPro Price;

		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private GameObject Backing;

		[SerializeField]
		private GameObject TemplateTag;

		[SerializeField]
		private GameObject TemplateInfo;

		protected override void UpdateData(ViewData data)
		{
			GameObject obj = new GameObject();
			obj.transform.parent = Sections.transform.parent;
			obj.transform.localPosition = Sections.transform.localPosition;
			obj.transform.localRotation = Sections.transform.localRotation;
			obj.transform.localScale = Sections.transform.localScale;
			GameObject sections = obj;
			UnityEngine.Object.Destroy(Sections);
			Sections = sections;
			if (!GameData.Main.TryGet<Appliance>(data.ID, out var output))
			{
				Title.text = $"{data.ID}";
				Description.text = "Something mysterious";
				return;
			}
			float num = SectionStartOffset;
			Title.text = output.Name;
			Description.text = output.Description;
			foreach (IApplianceProperty property in output.Properties)
			{
				if (!(property is CGivesDecoration cGivesDecoration))
				{
					if (property is CHighlyFlammable)
					{
						num += AddTag(num, base.Localisation["CHighlyFlammable"]);
					}
				}
				else
				{
					num += AddDecorationInfo(num, cGivesDecoration.DecorationValues, output.EffectRange);
				}
			}
			for (int i = 0; i < output.Tags.Count; i++)
			{
				num += AddTag(num, output.Tags[i]);
			}
			for (int j = 0; j < output.Sections.Count; j++)
			{
				num += AddSection(num, output.Sections[j]);
			}
			if (output.HasUpgrades)
			{
				num += AddTag(num, base.Localisation["Upgradable"]);
			}
			if (data.AnyEnchantingDesk && output.HasEnchantments)
			{
				num += AddTag(num, base.Localisation["Enchantable"]);
			}
			if (data.Mode == CApplianceInfo.ApplianceInfoMode.Shop)
			{
				PriceTag.SetActive(value: true);
				PriceTag.transform.localPosition = new Vector3(0.8f, num + 0.21f, 0f);
				Price.text = $"{data.Price}";
				num += -0.3f;
				Price.color = ((data.PlayerMoney >= data.Price) ? Affordable : Unaffordable);
			}
			else
			{
				PriceTag.SetActive(value: false);
			}
			float num2 = num - SectionStartOffset;
			Vector3 localScale = Backing.transform.localScale;
			localScale.z = TopTextHeight - num2;
			Backing.transform.localScale = localScale;
			Animator?.Update(0f);
		}

		private float AddDecorationInfo(float offset, DecorationValues values, IEffectRange range)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DecorationType[] types = DecorationValues.Types;
			foreach (DecorationType decorationType in types)
			{
				for (int j = 0; j < values[decorationType]; j++)
				{
					stringBuilder.Append(GameData.Main.GlobalLocalisation.GetIcon(decorationType));
					stringBuilder.Append(" ");
				}
			}
			return AddSection(offset, new Appliance.Section
			{
				Title = base.Localisation["ADDS_DECORATION"],
				Description = stringBuilder.ToString(),
				RangeDescription = ""
			}, centre: true);
		}

		private float AddTag(float offset, string tag)
		{
			GameObject obj = UnityEngine.Object.Instantiate(TemplateTag, Sections.transform, worldPositionStays: true);
			obj.SetActive(value: true);
			obj.transform.localPosition = new Vector3(0f, offset, 0f);
			obj.transform.Find("Text").GetComponent<TextMeshPro>().text = tag;
			return TagHeight;
		}

		private float AddSection(float offset, Appliance.Section details, bool centre = false)
		{
			GameObject obj = UnityEngine.Object.Instantiate(TemplateInfo, Sections.transform, worldPositionStays: true);
			obj.SetActive(value: true);
			obj.transform.localPosition = new Vector3(0f, offset, 0f);
			obj.transform.Find("Title").GetComponent<TextMeshPro>().text = details.Title;
			TextMeshPro component = obj.transform.Find("Description").GetComponent<TextMeshPro>();
			component.text = details.Description;
			component.alignment = (centre ? TextAlignmentOptions.Center : TextAlignmentOptions.Left);
			obj.transform.Find("Range").GetComponent<TextMeshPro>().text = details.RangeDescription;
			return SectionHeight;
		}
	}
}
