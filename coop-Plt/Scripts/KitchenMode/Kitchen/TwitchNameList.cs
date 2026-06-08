#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;
using WebSocketSharp;

namespace Kitchen
{
	public class TwitchNameList : GenericSystemBase
	{
		public struct CAssignName : IComponentData
		{
			public bool IsRequested;

			public bool IsAssigned;
		}

		public struct TwitchCustomerData
		{
			public string Name;

			public int BitsTip;

			public Color Color;

			public int OrderIndex;

			public bool IsTrick;

			public bool IsTreat;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SHasAskedForReshuffle : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CReshuffleNameList : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CResetNameList : IComponentData
		{
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CAssignName>.Runtime runtime_request;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CAssignName> forParameter_request;

				public void ScheduleTimeInitialize(TwitchNameList componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_request.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_request = forParameter_request.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public TwitchNameList hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity e, ref CAssignName request)
			{
				hostInstance._003COnUpdate_003Eb__7_0(e, ref request);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_request.For(i));
				}
			}

			public void ScheduleTimeInitialize(TwitchNameList componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private Queue<string> QueuedNames = new Queue<string>();

		private Dictionary<Entity, TwitchCustomerData> AssignedData = new Dictionary<Entity, TwitchCustomerData>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

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
			if (!Has<SPerformSceneTransition>() && !Has<SKitchenMarker>())
			{
				Clear<SHasAskedForReshuffle>();
			}
		}

		public string GetName(Entity e)
		{
			if (AssignedData.TryGetValue(e, out var value))
			{
				return value.Name;
			}
			return "";
		}

		private bool GetNewName(Entity e)
		{
			if (QueuedNames.Count == 0)
			{
				return false;
			}
			if (AssignedData.ContainsKey(e))
			{
				return false;
			}
			AssignedData[e] = new TwitchCustomerData
			{
				Name = QueuedNames.Dequeue()
			};
			return true;
		}

		public void AddData(string name)
		{
			if (!name.IsNullOrEmpty() && !QueuedNames.Contains(name))
			{
				QueuedNames.Enqueue(name);
			}
		}

		public bool GetOrder(Entity e, out CManualOrder order)
		{
			if (AssignedData.TryGetValue(e, out var value) && value.Name != null)
			{
				order = new CManualOrder
				{
					Index = value.OrderIndex
				};
				return true;
			}
			order = default(CManualOrder);
			return false;
		}

		public bool IsTrick(Entity e)
		{
			if (AssignedData.TryGetValue(e, out var value) && value.Name != null)
			{
				return value.IsTrick;
			}
			return false;
		}

		public bool IsTreat(Entity e)
		{
			if (AssignedData.TryGetValue(e, out var value) && value.Name != null)
			{
				return value.IsTreat;
			}
			return false;
		}

		public int GetBits(Entity e)
		{
			if (AssignedData.TryGetValue(e, out var value) && value.Name != null)
			{
				return value.BitsTip;
			}
			return 0;
		}

		public void ClearOrder(Entity e)
		{
			if (AssignedData.TryGetValue(e, out var value))
			{
				value.OrderIndex = 0;
				AssignedData[e] = value;
			}
		}

		public void ClearData()
		{
			AssignedData.Clear();
			QueuedNames.Clear();
		}

		public void SetData(string name, TwitchCustomerData data)
		{
			foreach (KeyValuePair<Entity, TwitchCustomerData> assignedDatum in AssignedData)
			{
				if (assignedDatum.Value.Name == name)
				{
					AssignedData[assignedDatum.Key] = data;
					break;
				}
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__7_0(Entity e, ref CAssignName request)
		{
			if (!request.IsAssigned)
			{
				request.IsAssigned = GetNewName(e);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CAssignName>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
