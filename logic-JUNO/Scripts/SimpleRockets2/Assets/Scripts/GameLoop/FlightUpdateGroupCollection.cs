using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Craft;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.GameLoop
{
	internal class FlightUpdateGroupCollection
	{
		private delegate void RegisterDelegate(FlightUpdateGroupCollection groups, IGameLoopItem item);

		public readonly UpdateGroup<BodyScript> BodyScripts;

		public readonly UpdateGroup<IFlightEndOfFramePostUpdate> EndOfFramePostUpdate;

		public readonly UpdateGroup<IFlightEndOfFramePreUpdate> EndOfFramePreUpdate;

		public readonly UpdateGroup<IFlightEndOfFrameUpdate> EndOfFrameUpdate;

		public readonly UpdateGroup<IEndOfFrameUpdate> EndOfFrameUpdateCommon;

		public readonly UpdateGroup<IFlightFixedUpdate> FixedUpdate;

		public readonly UpdateGroup<IFixedUpdate> FixedUpdateCommon;

		public readonly UpdateGroup<IFlightFixedUpdateParallel> FixedUpdateParallel;

		public readonly UpdateGroup<IFlightFixedUpdateWarp> FixedUpdateWarp;

		public readonly UpdateGroup<IFlightLateUpdate> LateUpdate;

		public readonly UpdateGroup<ILateUpdate> LateUpdateCommon;

		public readonly UpdateGroup<IFlightLateUpdateParallel> LateUpdateParallel;

		public readonly UpdateGroup<IFlightLateUpdatePaused> LateUpdatePaused;

		public readonly UpdateGroup<IFlightPostFixedUpdate> PostFixedUpdate;

		public readonly UpdateGroup<IFlightPostFixedUpdateParallel> PostFixedUpdateParallel;

		public readonly UpdateGroup<IFlightPostLateUpdate> PostLateUpdate;

		public readonly UpdateGroup<IFlightPostLateUpdateParallel> PostLateUpdateParallel;

		public readonly StartGroup<IFlightPostStart> PostStart;

		public readonly StartGroup<IPostStart> PostStartCommon;

		public readonly UpdateGroup<IFlightPostUpdate> PostUpdate;

		public readonly UpdateGroup<IFlightPostUpdateParallel> PostUpdateParallel;

		public readonly UpdateGroup<IFlightPreFixedUpdate> PreFixedUpdate;

		public readonly UpdateGroup<IFlightPreFixedUpdateParallel> PreFixedUpdateParallel;

		public readonly UpdateGroup<IFlightPreLateUpdate> PreLateUpdate;

		public readonly UpdateGroup<IFlightPreLateUpdateParallel> PreLateUpdateParallel;

		public readonly UpdateGroup<IFlightPreUpdate> PreUpdate;

		public readonly UpdateGroup<IFlightPreUpdateParallel> PreUpdateParallel;

		public readonly StartGroup<IFlightStart> Start;

		public readonly StartGroup<IStart> StartCommon;

		public readonly UpdateGroup<IFlightUpdate> Update;

		public readonly UpdateGroup<IUpdate> UpdateCommon;

		public readonly UpdateGroup<IFlightUpdateParallel> UpdateParallel;

		public readonly UpdateGroup<IFlightUpdatePaused> UpdatePaused;

		private const int DefaultExecutionOrder = 0;

		private static Dictionary<Type, RegisterDelegate> _registerDelegateCache = new Dictionary<Type, RegisterDelegate>();

		private static Dictionary<Type, RegisterDelegate> _unregisterDelegateCache = new Dictionary<Type, RegisterDelegate>();

		public FlightUpdateGroupCollection(FlightGameLoop loop)
		{
			StartCommon = new StartGroup<IStart>(loop);
			Start = new StartGroup<IFlightStart>(loop);
			PostStartCommon = new StartGroup<IPostStart>(loop);
			PostStart = new StartGroup<IFlightPostStart>(loop);
			PreUpdateParallel = new UpdateGroup<IFlightPreUpdateParallel>(loop);
			PreUpdate = new UpdateGroup<IFlightPreUpdate>(loop);
			UpdateParallel = new UpdateGroup<IFlightUpdateParallel>(loop);
			UpdateCommon = new UpdateGroup<IUpdate>(loop);
			Update = new UpdateGroup<IFlightUpdate>(loop);
			UpdatePaused = new UpdateGroup<IFlightUpdatePaused>(loop);
			PostUpdateParallel = new UpdateGroup<IFlightPostUpdateParallel>(loop);
			PostUpdate = new UpdateGroup<IFlightPostUpdate>(loop);
			PreFixedUpdateParallel = new UpdateGroup<IFlightPreFixedUpdateParallel>(loop);
			PreFixedUpdate = new UpdateGroup<IFlightPreFixedUpdate>(loop);
			FixedUpdateParallel = new UpdateGroup<IFlightFixedUpdateParallel>(loop);
			FixedUpdateCommon = new UpdateGroup<IFixedUpdate>(loop);
			FixedUpdate = new UpdateGroup<IFlightFixedUpdate>(loop);
			FixedUpdateWarp = new UpdateGroup<IFlightFixedUpdateWarp>(loop);
			PostFixedUpdateParallel = new UpdateGroup<IFlightPostFixedUpdateParallel>(loop);
			PostFixedUpdate = new UpdateGroup<IFlightPostFixedUpdate>(loop);
			PreLateUpdateParallel = new UpdateGroup<IFlightPreLateUpdateParallel>(loop);
			PreLateUpdate = new UpdateGroup<IFlightPreLateUpdate>(loop);
			LateUpdateParallel = new UpdateGroup<IFlightLateUpdateParallel>(loop);
			LateUpdateCommon = new UpdateGroup<ILateUpdate>(loop);
			LateUpdate = new UpdateGroup<IFlightLateUpdate>(loop);
			LateUpdatePaused = new UpdateGroup<IFlightLateUpdatePaused>(loop);
			PostLateUpdateParallel = new UpdateGroup<IFlightPostLateUpdateParallel>(loop);
			PostLateUpdate = new UpdateGroup<IFlightPostLateUpdate>(loop);
			EndOfFramePreUpdate = new UpdateGroup<IFlightEndOfFramePreUpdate>(loop);
			EndOfFrameUpdateCommon = new UpdateGroup<IEndOfFrameUpdate>(loop);
			EndOfFrameUpdate = new UpdateGroup<IFlightEndOfFrameUpdate>(loop);
			EndOfFramePostUpdate = new UpdateGroup<IFlightEndOfFramePostUpdate>(loop);
			BodyScripts = new UpdateGroup<BodyScript>(loop);
		}

		public void Register(IGameLoopItem script)
		{
			Type type = script.GetType();
			if (!_registerDelegateCache.TryGetValue(type, out var value))
			{
				BuildRegistrationDelegates(type, out value, out var unregister);
				_registerDelegateCache.Add(type, value);
				_unregisterDelegateCache.Add(type, unregister);
			}
			value(this, script);
		}

		public void Unregister(IGameLoopItem script)
		{
			Type type = script.GetType();
			if (!_unregisterDelegateCache.TryGetValue(type, out var value))
			{
				BuildRegistrationDelegates(type, out var register, out value);
				_registerDelegateCache.Add(type, register);
				_unregisterDelegateCache.Add(type, value);
			}
			value(this, script);
		}

		private static void BuildRegistrationDelegates(Type type, out RegisterDelegate register, out RegisterDelegate unregister)
		{
			register = null;
			unregister = null;
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.StartCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.Start, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostStartCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostStart, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PreUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PreUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.UpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.UpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.Update, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.UpdatePaused, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PreFixedUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PreFixedUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.FixedUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.FixedUpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.FixedUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.FixedUpdateWarp, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostFixedUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostFixedUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PreLateUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PreLateUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.LateUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.LateUpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.LateUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.LateUpdatePaused, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostLateUpdateParallel, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.PostLateUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.EndOfFramePreUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.EndOfFrameUpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.EndOfFrameUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.EndOfFramePostUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((FlightUpdateGroupCollection x) => x.BodyScripts, type, ref register, ref unregister);
			if (register == null)
			{
				register = delegate
				{
				};
			}
			if (unregister == null)
			{
				unregister = delegate
				{
				};
			}
		}

		private static void BuildRegistrationDelegates<T>(Func<FlightUpdateGroupCollection, UpdateGroupBase<T>> group, Type type, ref RegisterDelegate register, ref RegisterDelegate unregister) where T : class, IGameLoopItem
		{
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsAssignableFrom(type))
			{
				return;
			}
			int executionOrder = type.GetCustomAttribute<GameLoopExecutionOrderAttribute>(inherit: true)?.ExecutionOrder ?? 0;
			if (typeFromHandle.IsInterface)
			{
				InterfaceMapping interfaceMap = type.GetInterfaceMap(typeFromHandle);
				if (interfaceMap.TargetMethods.Length == 1)
				{
					GameLoopExecutionOrderAttribute customAttribute = interfaceMap.TargetMethods[0].GetCustomAttribute<GameLoopExecutionOrderAttribute>(inherit: true);
					if (customAttribute != null)
					{
						executionOrder = customAttribute.ExecutionOrder;
					}
				}
			}
			if (typeFromHandle == typeof(IFlightStart) || typeFromHandle == typeof(IFlightPostStart) || typeFromHandle == typeof(IStart) || typeFromHandle == typeof(IPostStart))
			{
				register = (RegisterDelegate)Delegate.Combine(register, (RegisterDelegate)delegate(FlightUpdateGroupCollection groups, IGameLoopItem item)
				{
					if (!item.StartMethodCalled)
					{
						group(groups).Register((T)item, executionOrder);
					}
				});
				unregister = (RegisterDelegate)Delegate.Combine(unregister, (RegisterDelegate)delegate(FlightUpdateGroupCollection groups, IGameLoopItem item)
				{
					if (!item.StartMethodCalled)
					{
						group(groups).Unregister((T)item, executionOrder);
					}
				});
			}
			else
			{
				register = (RegisterDelegate)Delegate.Combine(register, (RegisterDelegate)delegate(FlightUpdateGroupCollection groups, IGameLoopItem item)
				{
					group(groups).Register((T)item, executionOrder);
				});
				unregister = (RegisterDelegate)Delegate.Combine(unregister, (RegisterDelegate)delegate(FlightUpdateGroupCollection groups, IGameLoopItem item)
				{
					group(groups).Unregister((T)item, executionOrder);
				});
			}
		}
	}
}
