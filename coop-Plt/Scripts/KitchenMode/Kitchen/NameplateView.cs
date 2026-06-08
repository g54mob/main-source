#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using KitchenData;
using MessagePack;
using Platforms;
using Sirenix.Utilities;
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
	public class NameplateView : UpdatableObjectView<NameplateView.ViewData>, ISpecificViewResponse
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
		{
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public StructuralChangeEntityProvider _entityProvider;

						public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_entity;

						public LambdaParameterValueProvider_EntityInQueryIndex.StructuralChangeRuntime runtime_entityInQueryIndex;

						public LambdaParameterValueProvider_IComponentData<CRenameRestaurant>.StructuralChangeRuntime runtime_name;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.StructuralChangeRuntime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CRenameRestaurant> forParameter_name;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_name.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
					{
						Runtimes result = default(Runtimes);
						result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
						result.runtime_entity = forParameter_entity.PrepareToExecuteWithStructuralChanges(p0, p1);
						result.runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteWithStructuralChanges(p0, p1);
						result.runtime_name = forParameter_name.PrepareToExecuteWithStructuralChanges(p0, p1);
						result.runtime_linked_view = forParameter_linked_view.PrepareToExecuteWithStructuralChanges(p0, p1);
						return result;
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CRenameRestaurant name, [In] ref CLinkedView linked_view)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, ref name, in linked_view);
				}

				public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
				{
					ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
					Entity entity2 = reference.runtime_entity.For(entity);
					int entityInQueryIndex = reference.runtime_entityInQueryIndex.For(entity);
					CRenameRestaurant originalComponent;
					CRenameRestaurant name = reference.runtime_name.For(entity, out originalComponent);
					CLinkedView originalComponent2;
					CLinkedView linked_view = reference.runtime_linked_view.For(entity, out originalComponent2);
					UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(entity2, entityInQueryIndex, ref name, ref linked_view);
					reference.runtime_name.WriteBack(entity, ref name, ref originalComponent);
				}

				public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
				{
					LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
					_runtimes = &runtimes;
					runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem)
				{
					hostInstance = componentSystem;
				}
			}

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void OnUpdate()
			{
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this);
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
			}

			[CompilerGenerated]
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, ref CRenameRestaurant name, in CLinkedView linked_view)
			{
				int requestingInputSource = 0;
				if (!RequireBuffer(entity, out DynamicBuffer<CBeingActedOnBy> comp))
				{
					return;
				}
				if (!Has<CIsOnFire>(entity) && !comp.IsEmpty)
				{
					Entity interactor = comp[0].Interactor;
					if (Require<CAttemptingInteraction>(interactor, out CAttemptingInteraction comp2) && comp2.Type == InteractionType.Act && !comp2.IsHeld && Require<CPlayer>(interactor, out CPlayer comp3))
					{
						requestingInputSource = comp3.InputSource;
					}
				}
				SendUpdate(linked_view, new ViewData
				{
					RequestingInputSource = requestingInputSource,
					RestaurantName = name.Name.Value,
					StartingRestaurantName = GetOrDefault<SRestaurantStartingName>().Name.Value
				});
				ResponseData result = default(ResponseData);
				if (ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
				{
					result = data;
				}, only_final_update: true))
				{
					name.Name = result.NewName;
					if (GetSafeNames().Contains(result.NewName))
					{
						Set(new SRestaurantStartingName
						{
							Name = result.NewName
						});
					}
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
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadWrite<CRenameRestaurant>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int RequestingInputSource;

			[Key(1)]
			public string RestaurantName;

			[Key(2)]
			public string StartingRestaurantName;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<NameplateView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (RequestingInputSource == check.RequestingInputSource && !(RestaurantName != check.RestaurantName))
				{
					return StartingRestaurantName != check.StartingRestaurantName;
				}
				return true;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData
		{
			[Key(0)]
			public string NewName;
		}

		private static List<string> _SafeNames = new List<string>();

		private string safeRestaurantName;

		[SerializeField]
		[Header("References")]
		private TextMeshPro Nameplate;

		public Action<IResponseData, Type> Callback;

		private static List<string> GetSafeNames()
		{
			if (_SafeNames == null)
			{
				_SafeNames = new List<string>();
			}
			_SafeNames.Clear();
			List<Dish> currentlyAvailableDishes = GameInfo.CurrentlyAvailableDishes;
			if (currentlyAvailableDishes.IsNullOrEmpty())
			{
				return _SafeNames;
			}
			foreach (Dish item in currentlyAvailableDishes)
			{
				if (!item.StartingNameSet.IsNullOrEmpty())
				{
					_SafeNames.AddRange(item.StartingNameSet);
				}
			}
			_SafeNames.Sort();
			return _SafeNames;
		}

		protected override void UpdateData(ViewData view_data)
		{
			Nameplate.text = (PlatformSettings.AllowUGC ? view_data.RestaurantName : view_data.StartingRestaurantName);
			if (view_data.RequestingInputSource == InputSourceIdentifier.Identifier)
			{
				if (PlatformSettings.AllowUGC)
				{
					TextInputView.RequestTextInput(base.Localisation["INPUT_TITLE_RENAME_RESTAURANT"], "", 24, HandleNewName);
				}
				else
				{
					RequestNewPredefinedName(view_data.RestaurantName);
				}
			}
		}

		private void RequestNewPredefinedName(string current_name)
		{
			List<string> safeNames = GetSafeNames();
			if (safeNames.Any())
			{
				int num = safeNames.IndexOf(current_name);
				if (num == -1)
				{
					num = UnityEngine.Random.Range(0, safeNames.Count);
				}
				string newName = safeNames[(num + 1) % safeNames.Count];
				Callback?.Invoke(new ResponseData
				{
					NewName = newName
				}, typeof(ResponseData));
			}
		}

		private void HandleNewName(TextInputView.TextInputState state, string result)
		{
			if (state == TextInputView.TextInputState.TextEntryComplete)
			{
				if (result == "")
				{
					result = Nameplate.text;
				}
				Callback?.Invoke(new ResponseData
				{
					NewName = result
				}, typeof(ResponseData));
			}
		}

		public void SetCallback(Action<IResponseData, Type> callback)
		{
			Callback = callback;
		}
	}
}
