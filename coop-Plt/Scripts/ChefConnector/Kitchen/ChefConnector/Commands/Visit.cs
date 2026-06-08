#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sirenix.Utilities;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen.ChefConnector.Commands
{
	public class Visit : GameSystemBase, IChefIntegration
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass11_0
		{
			public Visit _003C_003E4__this;

			public bool request_orders;

			internal void _003COnUpdate_003Eb__0(Entity e, ref TwitchNameList.CAssignName request)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__1(Entity e, in CGroupLeaving leaving, in DynamicBuffer<CGroupMember> members)
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<TwitchNameList.CAssignName>.Runtime runtime_request;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<TwitchNameList.CAssignName> forParameter_request;

				public void ScheduleTimeInitialize(Visit componentSystem)
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

			public Visit _003C_003E4__this;

			public bool request_orders;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref TwitchNameList.CAssignName request)
			{
				if (!request.IsRequested)
				{
					_003C_003E4__this.RequestedNames++;
					request.IsRequested = true;
				}
				else if (request.IsAssigned & request_orders)
				{
					_003C_003E4__this.NamedCustomers.Add(_003C_003E4__this.System.GetName(e));
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				request_orders = displayClass.request_orders;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.request_orders = request_orders;
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

			public void ScheduleTimeInitialize(Visit componentSystem, ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData_Tag<CGroupLeaving>.Runtime runtime_leaving;

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_members;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<CGroupLeaving> forParameter_leaving;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_members;

				public void ScheduleTimeInitialize(Visit componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_leaving.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_members.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_leaving = forParameter_leaving.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_members = forParameter_members.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public Visit _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CGroupLeaving leaving, in DynamicBuffer<CGroupMember> members)
			{
				foreach (CGroupMember member in members)
				{
					_003C_003E4__this.ClearCustomers.Add(member);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_leaving.For(i), runtimes.runtime_members.For(i));
				}
			}

			public void ScheduleTimeInitialize(Visit componentSystem, ref _003C_003Ec__DisplayClass11_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		private TwitchNameList System;

		private int RequestedNames;

		private bool RequestWipe;

		private bool RequestReshuffle;

		private EntityQuery ResetRequests;

		private EntityQuery ReshuffleRequests;

		private List<string> NamedCustomers = new List<string>();

		private List<Entity> ClearCustomers = new List<Entity>();

		private float LastOrderUpdateTime;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		protected override void Initialise()
		{
			ResetRequests = GetEntityQuery(typeof(TwitchNameList.CResetNameList));
			ReshuffleRequests = GetEntityQuery(typeof(TwitchNameList.CReshuffleNameList));
		}

		public override void PostInitialisation()
		{
			base.PostInitialisation();
			if (System == null)
			{
				System = base.EntityManager.World.GetExistingSystem<TwitchNameList>();
			}
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass11_0 displayClass = new _003C_003Ec__DisplayClass11_0
			{
				_003C_003E4__this = this
			};
			if (!ResetRequests.IsEmpty)
			{
				base.EntityManager.DestroyEntity(ResetRequests);
				RequestWipe = true;
			}
			if (!ReshuffleRequests.IsEmpty)
			{
				base.EntityManager.DestroyEntity(ReshuffleRequests);
				RequestReshuffle = true;
				System?.ClearData();
			}
			float totalTime = base.Time.TotalTime;
			displayClass.request_orders = totalTime > LastOrderUpdateTime + 3f;
			if (displayClass.request_orders)
			{
				NamedCustomers.Clear();
				LastOrderUpdateTime = totalTime;
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
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query2 = _003C_003EOnUpdate_LambdaJob1_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst2 = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData2, query2, s_RunWithoutJobSystemDelegateFieldNoBurst2);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob1_profilerMarker.End();
			}
			jobData2.WriteToDisplayClass(ref displayClass);
		}

		public bool Handle(ChefCommandUpdate update)
		{
			if (!update.Type.StartsWith("VISIT"))
			{
				return false;
			}
			if (System == null)
			{
				System = base.EntityManager.World.GetExistingSystem<TwitchNameList>();
			}
			if (System == null)
			{
				return true;
			}
			try
			{
				if (update.Type == "VISIT_ADD_NAME")
				{
					ChefVisitUpdate chefVisitUpdate = JsonUtility.FromJson<ChefVisitUpdate>(update.Data);
					System.AddData(chefVisitUpdate.Name);
				}
				else if (update.Type == "VISIT_DETAILS")
				{
					ChefVisitDetails chefVisitDetails = JsonUtility.FromJson<ChefVisitDetails>(update.Data);
					System.SetData(chefVisitDetails.Name, new TwitchNameList.TwitchCustomerData
					{
						Name = chefVisitDetails.Name,
						OrderIndex = chefVisitDetails.Order,
						BitsTip = chefVisitDetails.Bits,
						IsTrick = chefVisitDetails.IsTrick,
						IsTreat = chefVisitDetails.IsTreat
					});
				}
				else if (update.Type == "VISIT_ORDERING_ENABLE")
				{
					GetOrCreate<STwitchOrderingActive>();
				}
				else if (update.Type == "VISIT_ORDERING_DISABLE")
				{
					Clear<STwitchOrderingActive>();
				}
			}
			catch (Exception message)
			{
				Debug.LogWarning("[Chef Connector] Malformed data");
				Debug.LogWarning(message);
				return true;
			}
			return true;
		}

		public void SendMessages(Action<string> send)
		{
			foreach (Entity clearCustomer in ClearCustomers)
			{
				string name = System.GetName(clearCustomer);
				if (!name.IsNullOrWhitespace())
				{
					send(JsonUtility.ToJson(new ChefNamedRequest
					{
						Type = "VISIT",
						Instruction = "clear_customer",
						Name = name
					}));
				}
			}
			ClearCustomers.Clear();
			for (int i = 0; i < RequestedNames; i++)
			{
				send(JsonUtility.ToJson(new ChefRequest
				{
					Type = "VISIT",
					Instruction = "request"
				}));
			}
			RequestedNames = 0;
			foreach (string namedCustomer in NamedCustomers)
			{
				send(JsonUtility.ToJson(new ChefNamedRequest
				{
					Type = "VISIT",
					Instruction = "details",
					Name = namedCustomer
				}));
			}
			NamedCustomers.Clear();
			if (RequestWipe)
			{
				send(JsonUtility.ToJson(new ChefRequest
				{
					Type = "VISIT",
					Instruction = "clear"
				}));
				RequestWipe = false;
			}
			if (RequestReshuffle)
			{
				send(JsonUtility.ToJson(new ChefRequest
				{
					Type = "VISIT",
					Instruction = "shuffle"
				}));
				RequestReshuffle = false;
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_003C_003EOnUpdate_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob1");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<TwitchNameList.CAssignName>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CGroupLeaving>(),
				ComponentType.ReadOnly<CGroupMember>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
