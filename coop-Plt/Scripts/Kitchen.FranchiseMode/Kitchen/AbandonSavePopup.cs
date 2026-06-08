#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class AbandonSavePopup : GenericChoicePopupManager
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public CLocationPopupRequest request;

			public AbandonSavePopup _003C_003E4__this;

			internal void _003CHandleDecision_003Eb__0(Entity e, ref CLocationChoice choice)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_HandleDecision_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CLocationChoice>.StructuralChangeRuntime runtime_choice;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CLocationChoice> forParameter_choice;

				public void ScheduleTimeInitialize(AbandonSavePopup componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_choice.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_choice = forParameter_choice.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public CLocationPopupRequest request;

			public AbandonSavePopup _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, ref CLocationChoice choice)
			{
				if (choice.Slot == request.Location.Slot)
				{
					choice.State = SaveState.Empty;
					if (!_003C_003E4__this.TryGetSingleton<SSelectedLocation>(out var value) || !value.Valid)
					{
						_003C_003E4__this.Set(new SSelectedLocation
						{
							Valid = true,
							Selected = choice
						});
					}
					_003C_003E4__this.EntityManager.RemoveComponent<CRequiresGenericInputIndicator>(e);
					_003C_003E4__this.EntityManager.RemoveComponent<CHasIndicator>(e);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				request = displayClass.request;
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				displayClass.request = request;
				displayClass._003C_003E4__this = _003C_003E4__this;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CLocationChoice originalComponent;
				CLocationChoice choice = reference.runtime_choice.For(entity, out originalComponent);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_HandleDecision_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref choice);
				reference.runtime_choice.WriteBack(entity, ref choice, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(AbandonSavePopup componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private EntityQuery _003C_003EHandleDecision_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EHandleDecision_LambdaJob0_profilerMarker;

		public override PopupType ManagedType => PopupType.AbandonSave;

		public override Entity CreateNewPopup(Entity request)
		{
			Entity entity = base.PopupUtilities.CreateGenericPopup(GenericChoiceType.AcceptOrCancel, ManagedType, PopupLocation.Centre);
			CopyData<CLocationPopupRequest>(request, entity);
			return entity;
		}

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
			{
				_003C_003E4__this = this
			};
			if (!Require<CLocationPopupRequest>(popup, out displayClass.request))
			{
				return true;
			}
			if (decision != GenericChoiceDecision.Accept)
			{
				return true;
			}
			_ = base.Entities;
			_003C_003Ec__DisplayClass_HandleDecision_LambdaJob0 _003C_003Ec__DisplayClass_HandleDecision_LambdaJob1 = default(_003C_003Ec__DisplayClass_HandleDecision_LambdaJob0);
			_003C_003Ec__DisplayClass_HandleDecision_LambdaJob1.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EHandleDecision_LambdaJob0_entityQuery;
			_003C_003EHandleDecision_LambdaJob0_profilerMarker.Begin();
			try
			{
				_003C_003Ec__DisplayClass_HandleDecision_LambdaJob1.Execute(this, query);
			}
			finally
			{
				_003C_003EHandleDecision_LambdaJob0_profilerMarker.End();
			}
			_003C_003Ec__DisplayClass_HandleDecision_LambdaJob1.WriteToDisplayClass(ref displayClass);
			Persistence.FullWorld.Clear(displayClass.request.Location.Slot);
			return true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EHandleDecision_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForHandleDecision_LambdaJob0_From(this);
			_003C_003EHandleDecision_LambdaJob0_profilerMarker = new ProfilerMarker("HandleDecision_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForHandleDecision_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CLocationChoice>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
