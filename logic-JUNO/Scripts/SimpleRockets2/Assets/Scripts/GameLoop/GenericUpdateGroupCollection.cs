using System;
using System.Collections.Generic;
using System.Reflection;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.GameLoop
{
	internal class GenericUpdateGroupCollection
	{
		private delegate void RegisterDelegate(GenericUpdateGroupCollection groups, IGameLoopItem item);

		public readonly UpdateGroup<IEndOfFrameUpdate> EndOfFrameUpdate;

		public readonly UpdateGroup<IFixedUpdate> FixedUpdate;

		public readonly UpdateGroup<ILateUpdate> LateUpdate;

		public readonly StartGroup<IPostStart> PostStart;

		public readonly StartGroup<IStart> Start;

		public readonly UpdateGroup<IUpdate> Update;

		private const int DefaultExecutionOrder = 0;

		private static Dictionary<Type, RegisterDelegate> _registerDelegateCache = new Dictionary<Type, RegisterDelegate>();

		private static Dictionary<Type, RegisterDelegate> _unregisterDelegateCache = new Dictionary<Type, RegisterDelegate>();

		public GenericUpdateGroupCollection(GenericGameLoop loop)
		{
			Start = new StartGroup<IStart>(loop);
			PostStart = new StartGroup<IPostStart>(loop);
			Update = new UpdateGroup<IUpdate>(loop);
			FixedUpdate = new UpdateGroup<IFixedUpdate>(loop);
			LateUpdate = new UpdateGroup<ILateUpdate>(loop);
			EndOfFrameUpdate = new UpdateGroup<IEndOfFrameUpdate>(loop);
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
			BuildRegistrationDelegates((GenericUpdateGroupCollection x) => x.Start, type, ref register, ref unregister);
			BuildRegistrationDelegates((GenericUpdateGroupCollection x) => x.PostStart, type, ref register, ref unregister);
			BuildRegistrationDelegates((GenericUpdateGroupCollection x) => x.Update, type, ref register, ref unregister);
			BuildRegistrationDelegates((GenericUpdateGroupCollection x) => x.FixedUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((GenericUpdateGroupCollection x) => x.LateUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((GenericUpdateGroupCollection x) => x.EndOfFrameUpdate, type, ref register, ref unregister);
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

		private static void BuildRegistrationDelegates<T>(Func<GenericUpdateGroupCollection, UpdateGroupBase<T>> group, Type type, ref RegisterDelegate register, ref RegisterDelegate unregister) where T : class, IGameLoopItem
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
			if (typeFromHandle == typeof(IStart) || typeFromHandle == typeof(IPostStart))
			{
				register = (RegisterDelegate)Delegate.Combine(register, (RegisterDelegate)delegate(GenericUpdateGroupCollection groups, IGameLoopItem item)
				{
					if (!item.StartMethodCalled)
					{
						group(groups).Register((T)item, executionOrder);
					}
				});
				unregister = (RegisterDelegate)Delegate.Combine(unregister, (RegisterDelegate)delegate(GenericUpdateGroupCollection groups, IGameLoopItem item)
				{
					if (!item.StartMethodCalled)
					{
						group(groups).Unregister((T)item, executionOrder);
					}
				});
			}
			else
			{
				register = (RegisterDelegate)Delegate.Combine(register, (RegisterDelegate)delegate(GenericUpdateGroupCollection groups, IGameLoopItem item)
				{
					group(groups).Register((T)item, executionOrder);
				});
				unregister = (RegisterDelegate)Delegate.Combine(unregister, (RegisterDelegate)delegate(GenericUpdateGroupCollection groups, IGameLoopItem item)
				{
					group(groups).Unregister((T)item, executionOrder);
				});
			}
		}
	}
}
