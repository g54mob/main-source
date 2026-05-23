using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;

namespace Libs
{
	public static class GameObjectPoolManager
	{
		private struct DelayedReturn
		{
			public CancellationTokenSource Cts;

			public UniTask Task;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReturnAsync_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public float delay;

			public CancellationToken token;

			public GameObject instance;

			private UniTask.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private static readonly Dictionary<string, ObjectPool<GameObject>> Pools;

		private static readonly Dictionary<GameObject, ObjectPool<GameObject>> InstanceToPool;

		private static readonly HashSet<GameObject> PooledInstances;

		private static readonly Dictionary<GameObject, DelayedReturn> DelayedReturns;

		private static Transform _poolParent;

		private static Transform PoolParent => null;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
		}

		public static GameObject Rent(GameObject original, string keyName = "")
		{
			return null;
		}

		public static GameObject Rent(GameObject original, Transform parent, bool worldPositionStays = false, string keyName = "")
		{
			return null;
		}

		public static GameObject Rent(GameObject original, Vector3 position, Quaternion rotation, string keyName = "")
		{
			return null;
		}

		private static GameObject RentInternal(GameObject original, string keyName, Action<GameObject, GameObject> setupTransform)
		{
			return null;
		}

		public static TComponent Rent<TComponent>(TComponent original, string keyName = "") where TComponent : Component
		{
			return null;
		}

		public static TComponent Rent<TComponent>(TComponent original, Transform parent, bool worldPositionStays = false, string keyName = "") where TComponent : Component
		{
			return null;
		}

		public static TComponent Rent<TComponent>(TComponent original, Vector3 position, Quaternion rotation, string keyName = "") where TComponent : Component
		{
			return null;
		}

		public static void Return(GameObject instance, float delay)
		{
		}

		[AsyncStateMachine(typeof(_003CReturnAsync_003Ed__17))]
		private static UniTask ReturnAsync(GameObject instance, float delay, CancellationToken token)
		{
			return default(UniTask);
		}

		public static void Return(GameObject instance)
		{
		}

		private static ObjectPool<GameObject> GetOrCreatePool(GameObject original, string keyName)
		{
			return null;
		}

		private static ObjectPool<GameObject> CreateNewPool(GameObject original)
		{
			return null;
		}

		private static GameObject CreatePooledObject(GameObject template)
		{
			return null;
		}

		private static void OnGetFromPool(GameObject obj)
		{
		}

		private static void OnReleaseToPool(GameObject obj)
		{
		}

		private static void OnDestroyPooledObject(GameObject obj)
		{
		}

		public static void Dispose()
		{
		}
	}
}
