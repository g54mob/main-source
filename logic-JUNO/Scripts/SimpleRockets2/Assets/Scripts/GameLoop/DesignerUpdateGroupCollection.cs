using System;
using System.Collections.Generic;
using System.Reflection;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.GameLoop
{
	internal class DesignerUpdateGroupCollection
	{
		private delegate void RegisterDelegate(DesignerUpdateGroupCollection groups, IGameLoopItem item);

		public readonly UpdateGroup<IDesignerEndOfFramePostUpdate> EndOfFramePostUpdate;

		public readonly UpdateGroup<IDesignerEndOfFramePreUpdate> EndOfFramePreUpdate;

		public readonly UpdateGroup<IDesignerEndOfFrameUpdate> EndOfFrameUpdate;

		public readonly UpdateGroup<IEndOfFrameUpdate> EndOfFrameUpdateCommon;

		public readonly UpdateGroup<IDesignerFixedUpdate> FixedUpdate;

		public readonly UpdateGroup<IFixedUpdate> FixedUpdateCommon;

		public readonly UpdateGroup<IDesignerLateUpdate> LateUpdate;

		public readonly UpdateGroup<ILateUpdate> LateUpdateCommon;

		public readonly UpdateGroup<IDesignerPostFixedUpdate> PostFixedUpdate;

		public readonly UpdateGroup<IDesignerPostLateUpdate> PostLateUpdate;

		public readonly StartGroup<IDesignerPostStart> PostStart;

		public readonly StartGroup<IPostStart> PostStartCommon;

		public readonly UpdateGroup<IDesignerPostUpdate> PostUpdate;

		public readonly UpdateGroup<IDesignerPreFixedUpdate> PreFixedUpdate;

		public readonly UpdateGroup<IDesignerPreLateUpdate> PreLateUpdate;

		public readonly UpdateGroup<IDesignerPreUpdate> PreUpdate;

		public readonly StartGroup<IDesignerStart> Start;

		public readonly StartGroup<IStart> StartCommon;

		public readonly UpdateGroup<IDesignerUpdate> Update;

		public readonly UpdateGroup<IUpdate> UpdateCommon;

		private const int DefaultExecutionOrder = 0;

		private static Dictionary<Type, RegisterDelegate> _registerDelegateCache = new Dictionary<Type, RegisterDelegate>();

		private static Dictionary<Type, RegisterDelegate> _unregisterDelegateCache = new Dictionary<Type, RegisterDelegate>();

		public DesignerUpdateGroupCollection(DesignerGameLoop loop)
		{
			StartCommon = new StartGroup<IStart>(loop);
			Start = new StartGroup<IDesignerStart>(loop);
			PostStartCommon = new StartGroup<IPostStart>(loop);
			PostStart = new StartGroup<IDesignerPostStart>(loop);
			PreUpdate = new UpdateGroup<IDesignerPreUpdate>(loop);
			UpdateCommon = new UpdateGroup<IUpdate>(loop);
			Update = new UpdateGroup<IDesignerUpdate>(loop);
			PostUpdate = new UpdateGroup<IDesignerPostUpdate>(loop);
			PreFixedUpdate = new UpdateGroup<IDesignerPreFixedUpdate>(loop);
			FixedUpdateCommon = new UpdateGroup<IFixedUpdate>(loop);
			FixedUpdate = new UpdateGroup<IDesignerFixedUpdate>(loop);
			PostFixedUpdate = new UpdateGroup<IDesignerPostFixedUpdate>(loop);
			PreLateUpdate = new UpdateGroup<IDesignerPreLateUpdate>(loop);
			LateUpdateCommon = new UpdateGroup<ILateUpdate>(loop);
			LateUpdate = new UpdateGroup<IDesignerLateUpdate>(loop);
			PostLateUpdate = new UpdateGroup<IDesignerPostLateUpdate>(loop);
			EndOfFramePreUpdate = new UpdateGroup<IDesignerEndOfFramePreUpdate>(loop);
			EndOfFrameUpdateCommon = new UpdateGroup<IEndOfFrameUpdate>(loop);
			EndOfFrameUpdate = new UpdateGroup<IDesignerEndOfFrameUpdate>(loop);
			EndOfFramePostUpdate = new UpdateGroup<IDesignerEndOfFramePostUpdate>(loop);
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
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.StartCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.Start, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PostStartCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PostStart, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PreUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.UpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.Update, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PostUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PreFixedUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.FixedUpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.FixedUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PostFixedUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PreLateUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.LateUpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.LateUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.PostLateUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.EndOfFramePreUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.EndOfFrameUpdateCommon, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.EndOfFrameUpdate, type, ref register, ref unregister);
			BuildRegistrationDelegates((DesignerUpdateGroupCollection x) => x.EndOfFramePostUpdate, type, ref register, ref unregister);
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

		private static void BuildRegistrationDelegates<T>(Func<DesignerUpdateGroupCollection, UpdateGroupBase<T>> group, Type type, ref RegisterDelegate register, ref RegisterDelegate unregister) where T : class, IGameLoopItem
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
			if (typeFromHandle == typeof(IDesignerStart) || typeFromHandle == typeof(IDesignerPostStart) || typeFromHandle == typeof(IStart) || typeFromHandle == typeof(IPostStart))
			{
				register = (RegisterDelegate)Delegate.Combine(register, (RegisterDelegate)delegate(DesignerUpdateGroupCollection groups, IGameLoopItem item)
				{
					if (!item.StartMethodCalled)
					{
						group(groups).Register((T)item, executionOrder);
					}
				});
				unregister = (RegisterDelegate)Delegate.Combine(unregister, (RegisterDelegate)delegate(DesignerUpdateGroupCollection groups, IGameLoopItem item)
				{
					if (!item.StartMethodCalled)
					{
						group(groups).Unregister((T)item, executionOrder);
					}
				});
			}
			else
			{
				register = (RegisterDelegate)Delegate.Combine(register, (RegisterDelegate)delegate(DesignerUpdateGroupCollection groups, IGameLoopItem item)
				{
					group(groups).Register((T)item, executionOrder);
				});
				unregister = (RegisterDelegate)Delegate.Combine(unregister, (RegisterDelegate)delegate(DesignerUpdateGroupCollection groups, IGameLoopItem item)
				{
					group(groups).Unregister((T)item, executionOrder);
				});
			}
		}
	}
}
