#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
using MessagePack;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AI;

namespace Kitchen
{
	[Serializable]
	public class LayoutView : UpdatableObjectView<LayoutView.InitialViewData>
	{
		[Serializable]
		public class UpdateView : ViewSystemBase
		{
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

						public LambdaParameterValueProvider_IComponentData<CLayoutView>.Runtime runtime_layout;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLayoutView> forParameter_layout;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_layout.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_layout = forParameter_layout.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CLinkedView linked_view, [In] ref CLayoutView layout)
				{
					hostInstance._003COnUpdate_003Eb__2_0(entity, entityInQueryIndex, ref linked_view, in layout);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_layout.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					hostInstance = componentSystem;
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private LayoutBlueprint Blueprint;

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void Initialise()
			{
				base.Initialise();
				Blueprint = LayoutBlueprint.New;
			}

			protected override void OnUpdate()
			{
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
				jobData.ScheduleTimeInitialize(this);
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
			}

			[CompilerGenerated]
			private void _003COnUpdate_003Eb__2_0(Entity entity, int entityInQueryIndex, ref CLinkedView linked_view, in CLayoutView layout)
			{
				if (!linked_view.DoNotUpdate)
				{
					linked_view.DoNotUpdate = true;
					Blueprint.FromEntity(base.EntityManager, layout.Layout);
					base.Router?.BroadcastUpdate(linked_view, new InitialViewData
					{
						Floorplan = Blueprint
					});
				}
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadWrite<CLinkedView>(),
					ComponentType.ReadOnly<CLayoutView>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct InitialViewData : IViewData, IViewResponseData
		{
			[Key(0)]
			public LayoutBlueprint Floorplan;
		}

		[Header("References")]
		[SerializeField]
		private LayoutPrefabSet Prefabs;

		[Header("State")]
		public LayoutBuilder Builder;

		public bool IsInitialised;

		private List<NavMeshSurface> Surfaces = new List<NavMeshSurface>();

		private Vector3 NavMeshSurfaceCentre => new Vector3(-10f, 0f, 0f);

		private Vector3 NavMeshSurfaceSize => new Vector3(40f, 0.01f, 20f);

		public void UpdateNavmesh()
		{
			foreach (NavMeshSurface surface in Surfaces)
			{
				surface.BuildNavMesh();
			}
		}

		public override void Initialise()
		{
			base.Initialise();
			NavMeshSurface navMeshSurface = base.gameObject.AddComponent<NavMeshSurface>();
			navMeshSurface.collectObjects = CollectObjects.Children;
			navMeshSurface.layerMask = LayerMask.GetMask("Statics", "NavMesh Level Geometry");
			navMeshSurface.tileSize = 32;
			navMeshSurface.overrideTileSize = true;
			navMeshSurface.voxelSize = 0.075f;
			navMeshSurface.overrideVoxelSize = true;
			navMeshSurface.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
			Surfaces.Add(navMeshSurface);
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			boxCollider.center = NavMeshSurfaceCentre;
			boxCollider.size = NavMeshSurfaceSize;
			base.gameObject.SetLayer(LayerMask.NameToLayer("NavMesh Level Geometry"));
		}

		protected GameObject CreateExteriorNavSurface(Vector3 centre, Vector3 size)
		{
			GameObject gameObject = new GameObject("NavSurface");
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.Reset();
			gameObject.transform.localPosition = centre;
			NavMeshSurface navMeshSurface = gameObject.AddComponent<NavMeshSurface>();
			navMeshSurface.collectObjects = CollectObjects.Children;
			navMeshSurface.layerMask = LayerMask.GetMask("NavMesh Exterior Geometry");
			navMeshSurface.tileSize = 256;
			navMeshSurface.overrideTileSize = true;
			navMeshSurface.voxelSize = 0.1f;
			navMeshSurface.overrideVoxelSize = true;
			navMeshSurface.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
			Surfaces.Add(navMeshSurface);
			gameObject.AddComponent<BoxCollider>().size = size;
			gameObject.SetLayer(LayerMask.NameToLayer("NavMesh Exterior Geometry"));
			return gameObject;
		}

		protected override void UpdateData(InitialViewData view_data)
		{
			if (!IsInitialised)
			{
				IsInitialised = true;
				Builder = new LayoutBuilder(view_data.Floorplan, Prefabs, base.transform);
				LayoutMapGenerator.GenerateFor(view_data.Floorplan);
				Builder.Build();
				UpdateNavmesh();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Builder.Dispose();
		}
	}
}
