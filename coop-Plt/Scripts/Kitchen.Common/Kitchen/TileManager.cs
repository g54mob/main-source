#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
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
	[UpdateInGroup(typeof(GameTransitionsCreateGroup))]
	public class TileManager : GenericSystemBase
	{
		protected struct OccupancyKey : IEquatable<OccupancyKey>
		{
			public IntVector3 Position;

			public OccupancyLayer Layer;

			public bool IsEquivalent(IntVector3 position, OccupancyLayer layer = OccupancyLayer.Default)
			{
				if (Layer != layer)
				{
					return false;
				}
				if (Position == position)
				{
					return false;
				}
				return true;
			}

			public bool Equals(OccupancyKey other)
			{
				if (Position.Equals(other.Position))
				{
					return Layer == other.Layer;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is OccupancyKey other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (Position.GetHashCode() * 397) ^ (int)Layer;
			}

			public static bool operator ==(OccupancyKey left, OccupancyKey right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(OccupancyKey left, OccupancyKey right)
			{
				return !left.Equals(right);
			}

			public OccupancyKey(IntVector3 position, OccupancyLayer layer = OccupancyLayer.Default)
			{
				Position = position;
				Layer = layer;
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass16_0
		{
			public NativeList<(IntVector3, Entity, OccupancyLayer, bool)> occupant_list;

			internal void _003CBuildOccupanciesCache_003Eb__0(Entity e, in CPosition pos, in CCreateAppliance app)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003CBuildOccupanciesCache_003Eb__1(Entity e, in CPosition pos, in CAppliance app)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003CBuildOccupanciesCache_003Eb__2(Entity e, in CPosition pos)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		private struct _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CCreateAppliance>.Runtime runtime_app;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCreateAppliance> forParameter_app;

				public void ScheduleTimeInitialize(TileManager componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_app.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_app = forParameter_app.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000BFC_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000BFC_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000BFC_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000BFC_0024BurstDirectCall()
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

			public NativeList<(IntVector3, Entity, OccupancyLayer, bool)> occupant_list;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in CPosition pos, in CCreateAppliance app)
			{
				occupant_list.Add(((IntVector3)pos.Position, e, app.ForceLayer, true));
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				occupant_list = displayClass.occupant_list;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				displayClass.occupant_list = occupant_list;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_pos.For(i), in runtimes.runtime_app.For(i));
				}
			}

			public void ScheduleTimeInitialize(TileManager componentSystem, ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000BFC_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			[BurstCompile]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[NoAlias]
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_app;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_app;

				public void ScheduleTimeInitialize(TileManager componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_app.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_app = forParameter_app.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000C05_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000C05_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000C05_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000C05_0024BurstDirectCall()
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

			public NativeList<(IntVector3, Entity, OccupancyLayer, bool)> occupant_list;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in CPosition pos, in CAppliance app)
			{
				occupant_list.Add(((IntVector3)pos.Position, e, app.Layer, true));
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				occupant_list = displayClass.occupant_list;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				displayClass.occupant_list = occupant_list;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_pos.For(i), in runtimes.runtime_app.For(i));
				}
			}

			public void ScheduleTimeInitialize(TileManager componentSystem, ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000C05_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		private struct _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(TileManager componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000C0E_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000C0E_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000C0E_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000C0E_0024BurstDirectCall()
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

			public NativeList<(IntVector3, Entity, OccupancyLayer, bool)> occupant_list;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity e, in CPosition pos)
			{
				occupant_list.Add(((IntVector3)pos.Position, e, OccupancyLayer.Default, false));
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				occupant_list = displayClass.occupant_list;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				displayClass.occupant_list = occupant_list;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(TileManager componentSystem, ref _003C_003Ec__DisplayClass16_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000C0E_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2>(jobData), ref *archetypeChunkIterator);
			}
		}

		public const int TILES_AT_FRONT = 2;

		protected Dictionary<OccupancyKey, Entity> OccupancyCache = new Dictionary<OccupancyKey, Entity>();

		protected Dictionary<IntVector3, CLayoutRoomTile> TileCache = new Dictionary<IntVector3, CLayoutRoomTile>();

		private EntityQuery _003C_003EBuildOccupanciesCache_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EBuildOccupanciesCache_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EBuildOccupanciesCache_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EBuildOccupanciesCache_LambdaJob1_profilerMarker;

		private EntityQuery _003C_003EBuildOccupanciesCache_LambdaJob2_entityQuery;

		private ProfilerMarker _003C_003EBuildOccupanciesCache_LambdaJob2_profilerMarker;

		protected override void OnUpdate()
		{
			BuildTileCache();
			BuildOccupanciesCache();
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			BuildTileCache();
			BuildOccupanciesCache();
		}

		public override void AfterSaving(SaveSystemType system_type)
		{
			BuildTileCache();
			BuildOccupanciesCache();
		}

		public void InvalidateTileCache()
		{
			BuildTileCache();
		}

		public void SetOccupant(IntVector3 position, Entity e, OccupancyLayer layer = OccupancyLayer.Default)
		{
			OccupancyCache[new OccupancyKey(position, layer)] = e;
		}

		public Entity GetOccupant(IntVector3 position, OccupancyLayer layer = OccupancyLayer.Default)
		{
			if (OccupancyCache.TryGetValue(new OccupancyKey(position, layer), out var value) && base.EntityManager.Exists(value))
			{
				return value;
			}
			return default(Entity);
		}

		public Entity GetPrimaryOccupant(IntVector3 position)
		{
			foreach (OccupancyLayer value in Enum.GetValues(typeof(OccupancyLayer)))
			{
				Entity occupant = GetOccupant(position, value);
				if (occupant != default(Entity))
				{
					return occupant;
				}
			}
			return default(Entity);
		}

		public bool IsSuitableEmptyTile(IntVector3 position, bool allow_oob = false, bool allow_outside = true, bool allow_features = false)
		{
			CLayoutRoomTile tile = GetTile(position);
			if (!allow_oob)
			{
				Bounds bounds = base.Bounds;
				bounds.Expand(0.1f);
				bounds.Encapsulate(bounds.min - new Vector3(0f, 0f, 2f));
				if (!bounds.Contains(position))
				{
					return false;
				}
			}
			if (!allow_outside && (tile.Type == RoomType.NoRoom || tile.Type == RoomType.Garden))
			{
				return false;
			}
			if (!allow_features)
			{
				bool flag = tile.HasFeature;
				if (tile.Type == RoomType.NoRoom)
				{
					flag |= position == (IntVector3)GetFrontDoor(get_external_tile: true);
				}
				if (flag)
				{
					return false;
				}
			}
			if (base.TileManager.GetOccupant(position) != default(Entity))
			{
				return false;
			}
			return true;
		}

		public int GetRoom(IntVector3 position)
		{
			return GetTile(position).RoomID;
		}

		public CLayoutRoomTile GetTile(IntVector3 position)
		{
			TileCache.TryGetValue(position, out var value);
			return value;
		}

		public bool CanReach(IntVector3 from, IntVector3 to, bool do_not_swap = false)
		{
			CLayoutRoomTile tile = GetTile(from);
			CLayoutRoomTile tile2 = GetTile(to);
			if (tile.RoomID == tile2.RoomID)
			{
				return true;
			}
			if (tile2.RoomID == 0)
			{
				if (!do_not_swap)
				{
					return CanReach(to, from, do_not_swap: true);
				}
				return false;
			}
			IntVector3 intVector = to - from;
			return tile.Reachability[intVector.x, intVector.z];
		}

		protected void BuildTileCache()
		{
			TileCache.Clear();
			if (!RequireEntity<SLayout>(out var comp) || !RequireBuffer(comp, out DynamicBuffer<CLayoutRoomTile> comp2))
			{
				return;
			}
			foreach (CLayoutRoomTile item in comp2)
			{
				TileCache[item.Position] = item;
			}
		}

		protected void BuildOccupanciesCache()
		{
			_003C_003Ec__DisplayClass16_0 displayClass = default(_003C_003Ec__DisplayClass16_0);
			OccupancyCache.Clear();
			displayClass.occupant_list = new NativeList<(IntVector3, Entity, OccupancyLayer, bool)>(Allocator.Temp);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EBuildOccupanciesCache_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EBuildOccupanciesCache_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
			}
			finally
			{
				_003C_003EBuildOccupanciesCache_LambdaJob0_profilerMarker.End();
			}
			jobData.WriteToDisplayClass(ref displayClass);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query2 = _003C_003EBuildOccupanciesCache_LambdaJob1_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer2 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EBuildOccupanciesCache_LambdaJob1_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData2, query2, functionPointer2);
			}
			finally
			{
				_003C_003EBuildOccupanciesCache_LambdaJob1_profilerMarker.End();
			}
			jobData2.WriteToDisplayClass(ref displayClass);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2 jobData3 = default(_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2);
			jobData3.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query3 = _003C_003EBuildOccupanciesCache_LambdaJob2_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer3 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EBuildOccupanciesCache_LambdaJob2_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData3, query3, functionPointer3);
			}
			finally
			{
				_003C_003EBuildOccupanciesCache_LambdaJob2_profilerMarker.End();
			}
			jobData3.WriteToDisplayClass(ref displayClass);
			foreach (var item in displayClass.occupant_list)
			{
				if (item.Item4 || !(GetOccupant(item.Item1) != default(Entity)))
				{
					SetOccupant(item.Item1, item.Item2, item.Item3);
				}
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EBuildOccupanciesCache_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForBuildOccupanciesCache_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EBuildOccupanciesCache_LambdaJob0_profilerMarker = new ProfilerMarker("BuildOccupanciesCache_LambdaJob0");
			_003C_003EBuildOccupanciesCache_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForBuildOccupanciesCache_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EBuildOccupanciesCache_LambdaJob1_profilerMarker = new ProfilerMarker("BuildOccupanciesCache_LambdaJob1");
			_003C_003EBuildOccupanciesCache_LambdaJob2_entityQuery = _003C_003EGetEntityQuery_ForBuildOccupanciesCache_LambdaJob2_From(this);
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EBuildOccupanciesCache_LambdaJob2_profilerMarker = new ProfilerMarker("BuildOccupanciesCache_LambdaJob2");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForBuildOccupanciesCache_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CCreateAppliance>()
			};
			entityQueryDesc.None = new ComponentType[3]
			{
				ComponentType.ReadWrite<CHeldBy>(),
				ComponentType.ReadWrite<CAllowPlacingOver>(),
				ComponentType.ReadWrite<CDoesNotOccupy>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForBuildOccupanciesCache_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CAppliance>()
			};
			entityQueryDesc.None = new ComponentType[3]
			{
				ComponentType.ReadWrite<CHeldBy>(),
				ComponentType.ReadWrite<CAllowPlacingOver>(),
				ComponentType.ReadWrite<CDoesNotOccupy>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForBuildOccupanciesCache_LambdaJob2_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CAllowPlacingOver>(),
				ComponentType.ReadOnly<CPosition>()
			};
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CHeldBy>(),
				ComponentType.ReadWrite<CDoesNotOccupy>()
			};
			entityQueryDesc.Any = new ComponentType[2]
			{
				ComponentType.ReadWrite<CCreateAppliance>(),
				ComponentType.ReadWrite<CAppliance>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0_RunWithoutJobSystem_00000BFC_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob0.RunWithoutJobSystem_00000BFC_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1_RunWithoutJobSystem_00000C05_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob1.RunWithoutJobSystem_00000C05_0024BurstDirectCall.Initialize();
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2_RunWithoutJobSystem_00000C0E_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_BuildOccupanciesCache_LambdaJob2.RunWithoutJobSystem_00000C0E_0024BurstDirectCall.Initialize();
		}
	}
}
