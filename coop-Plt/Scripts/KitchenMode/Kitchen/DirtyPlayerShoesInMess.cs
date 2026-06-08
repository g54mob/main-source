#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class DirtyPlayerShoesInMess : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public DirtyPlayerShoesInMess _003C_003E4__this;

			public NativeArray<Entity> messes;

			public EntityContext ctx;

			public float time;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPlayer player, in CPosition position)
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

					public LambdaParameterValueProvider_IComponentData<CPlayer>.StructuralChangeRuntime runtime_player;

					public LambdaParameterValueProvider_IComponentData<CPosition>.StructuralChangeRuntime runtime_position;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPlayer> forParameter_player;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				public void ScheduleTimeInitialize(DirtyPlayerShoesInMess componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_player.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_e = forParameter_e.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_player = forParameter_player.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_position = forParameter_position.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public DirtyPlayerShoesInMess _003C_003E4__this;

			public NativeArray<Entity> messes;

			public EntityContext ctx;

			public float time;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CSlowPlayer> _ComponentDataFromEntity_CSlowPlayer_1;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CAppliance> _ComponentDataFromEntity_CAppliance_2;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity e, ref CPlayer player, in CPosition position)
			{
				CLayoutRoomTile tile = _003C_003E4__this.TileManager.GetTile(position);
				bool flag = false;
				int messID = 0;
				foreach (Entity mess in messes)
				{
					CPosition cPosition = _ComponentDataFromEntity_CPosition_0[mess];
					CSlowPlayer cSlowPlayer = _ComponentDataFromEntity_CSlowPlayer_1[mess];
					CAppliance cAppliance = _ComponentDataFromEntity_CAppliance_2[mess];
					if (!(cSlowPlayer.Factor >= 1.15f) && (cPosition.Position - position).sqrMagnitude < cSlowPlayer.Radius * cSlowPlayer.Radius && _003C_003E4__this.TileManager.GetRoom(cPosition) == tile.RoomID)
					{
						flag = true;
						messID = cAppliance.ID;
						break;
					}
				}
				CPlayerDirtyShoes comp;
				if (flag)
				{
					ctx.Set(e, new CPlayerDirtyShoes
					{
						TimeUntil = time + 3f,
						MessID = messID
					});
				}
				else if (_003C_003E4__this.Require<CPlayerDirtyShoes>(e, out comp) && comp.TimeUntil < time)
				{
					ctx.Remove<CPlayerDirtyShoes>(e);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				messes = displayClass.messes;
				ctx = displayClass.ctx;
				time = displayClass.time;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.messes = messes;
				displayClass.ctx = ctx;
				displayClass.time = time;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity e = reference.runtime_e.For(entity);
				CPlayer originalComponent;
				CPlayer player = reference.runtime_player.For(entity, out originalComponent);
				CPosition originalComponent2;
				CPosition position = reference.runtime_position.For(entity, out originalComponent2);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(e, ref player, in position);
				reference.runtime_player.WriteBack(entity, ref player, ref originalComponent);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(DirtyPlayerShoesInMess componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPosition_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
				_ComponentDataFromEntity_CSlowPlayer_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CSlowPlayer>(true);
				_ComponentDataFromEntity_CAppliance_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAppliance>(true);
			}
		}

		private EntityQuery Mess;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Mess = GetEntityQuery(typeof(CPosition), typeof(CAppliance), typeof(CSlowPlayer));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this
			};
			if (Has<SLayout>())
			{
				displayClass.messes = Mess.ToEntityArray(Allocator.TempJob);
				displayClass.time = base.Time.TotalTime;
				displayClass.ctx = new EntityContext(ecb: new EntityCommandBuffer(Allocator.TempJob), manager: base.EntityManager);
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
				displayClass.ctx.Playback();
				displayClass.ctx.Dispose();
				displayClass.messes.Dispose();
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
				ComponentType.ReadWrite<CPlayer>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
