using System;
using System.Runtime.CompilerServices;
using LitMotion.Collections;
using UnityEngine;

namespace LitMotion
{
	public static class MotionDispatcher
	{
		private static class StorageCache<TValue, TOptions, TAdapter> where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			public static MotionStorage<TValue, TOptions, TAdapter> initialization;

			public static MotionStorage<TValue, TOptions, TAdapter> earlyUpdate;

			public static MotionStorage<TValue, TOptions, TAdapter> fixedUpdate;

			public static MotionStorage<TValue, TOptions, TAdapter> preUpdate;

			public static MotionStorage<TValue, TOptions, TAdapter> update;

			public static MotionStorage<TValue, TOptions, TAdapter> preLateUpdate;

			public static MotionStorage<TValue, TOptions, TAdapter> postLateUpdate;

			public static MotionStorage<TValue, TOptions, TAdapter> timeUpdate;

			public static MotionStorage<TValue, TOptions, TAdapter> GetOrCreate(PlayerLoopTiming playerLoopTiming)
			{
				return playerLoopTiming switch
				{
					PlayerLoopTiming.Initialization => CreateIfNull(ref initialization), 
					PlayerLoopTiming.EarlyUpdate => CreateIfNull(ref earlyUpdate), 
					PlayerLoopTiming.FixedUpdate => CreateIfNull(ref fixedUpdate), 
					PlayerLoopTiming.PreUpdate => CreateIfNull(ref preUpdate), 
					PlayerLoopTiming.Update => CreateIfNull(ref update), 
					PlayerLoopTiming.PreLateUpdate => CreateIfNull(ref preLateUpdate), 
					PlayerLoopTiming.PostLateUpdate => CreateIfNull(ref postLateUpdate), 
					PlayerLoopTiming.TimeUpdate => CreateIfNull(ref timeUpdate), 
					_ => null, 
				};
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static MotionStorage<TValue, TOptions, TAdapter> CreateIfNull(ref MotionStorage<TValue, TOptions, TAdapter> storage)
			{
				if (storage == null)
				{
					storage = new MotionStorage<TValue, TOptions, TAdapter>(MotionManager.MotionTypeCount);
					MotionManager.Register(storage);
				}
				return storage;
			}
		}

		private static class RunnerCache<TValue, TOptions, TAdapter> where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			public static UpdateRunner<TValue, TOptions, TAdapter> initialization;

			public static UpdateRunner<TValue, TOptions, TAdapter> earlyUpdate;

			public static UpdateRunner<TValue, TOptions, TAdapter> fixedUpdate;

			public static UpdateRunner<TValue, TOptions, TAdapter> preUpdate;

			public static UpdateRunner<TValue, TOptions, TAdapter> update;

			public static UpdateRunner<TValue, TOptions, TAdapter> preLateUpdate;

			public static UpdateRunner<TValue, TOptions, TAdapter> postLateUpdate;

			public static UpdateRunner<TValue, TOptions, TAdapter> timeUpdate;

			public static (UpdateRunner<TValue, TOptions, TAdapter> runner, bool isCreated) GetOrCreate(PlayerLoopTiming playerLoopTiming, MotionStorage<TValue, TOptions, TAdapter> storage)
			{
				return playerLoopTiming switch
				{
					PlayerLoopTiming.Initialization => CreateIfNull(playerLoopTiming, ref initialization, storage), 
					PlayerLoopTiming.EarlyUpdate => CreateIfNull(playerLoopTiming, ref earlyUpdate, storage), 
					PlayerLoopTiming.FixedUpdate => CreateIfNull(playerLoopTiming, ref fixedUpdate, storage), 
					PlayerLoopTiming.PreUpdate => CreateIfNull(playerLoopTiming, ref preUpdate, storage), 
					PlayerLoopTiming.Update => CreateIfNull(playerLoopTiming, ref update, storage), 
					PlayerLoopTiming.PreLateUpdate => CreateIfNull(playerLoopTiming, ref preLateUpdate, storage), 
					PlayerLoopTiming.PostLateUpdate => CreateIfNull(playerLoopTiming, ref postLateUpdate, storage), 
					PlayerLoopTiming.TimeUpdate => CreateIfNull(playerLoopTiming, ref timeUpdate, storage), 
					_ => default((UpdateRunner<TValue, TOptions, TAdapter>, bool)), 
				};
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static (UpdateRunner<TValue, TOptions, TAdapter>, bool) CreateIfNull(PlayerLoopTiming playerLoopTiming, ref UpdateRunner<TValue, TOptions, TAdapter> runner, MotionStorage<TValue, TOptions, TAdapter> storage)
			{
				if (runner == null)
				{
					if (playerLoopTiming == PlayerLoopTiming.FixedUpdate)
					{
						runner = new UpdateRunner<TValue, TOptions, TAdapter>(storage, Time.fixedTimeAsDouble, Time.fixedUnscaledTimeAsDouble, Time.realtimeSinceStartupAsDouble);
					}
					else
					{
						runner = new UpdateRunner<TValue, TOptions, TAdapter>(storage, Time.timeAsDouble, Time.unscaledTimeAsDouble, Time.realtimeSinceStartupAsDouble);
					}
					GetRunnerList(playerLoopTiming).Add(runner);
					return (runner, true);
				}
				return (runner, false);
			}
		}

		private static FastListCore<IUpdateRunner> initializationRunners;

		private static FastListCore<IUpdateRunner> earlyUpdateRunners;

		private static FastListCore<IUpdateRunner> fixedUpdateRunners;

		private static FastListCore<IUpdateRunner> preUpdateRunners;

		private static FastListCore<IUpdateRunner> updateRunners;

		private static FastListCore<IUpdateRunner> preLateUpdateRunners;

		private static FastListCore<IUpdateRunner> postLateUpdateRunners;

		private static FastListCore<IUpdateRunner> timeUpdateRunners;

		internal static FastListCore<IUpdateRunner> EmptyList = FastListCore<IUpdateRunner>.Empty;

		private static Action<Exception> unhandledException = DefaultUnhandledExceptionHandler;

		private static readonly PlayerLoopTiming[] playerLoopTimings = (PlayerLoopTiming[])Enum.GetValues(typeof(PlayerLoopTiming));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ref FastListCore<IUpdateRunner> GetRunnerList(PlayerLoopTiming playerLoopTiming)
		{
			return playerLoopTiming switch
			{
				PlayerLoopTiming.Initialization => ref initializationRunners, 
				PlayerLoopTiming.EarlyUpdate => ref earlyUpdateRunners, 
				PlayerLoopTiming.FixedUpdate => ref fixedUpdateRunners, 
				PlayerLoopTiming.PreUpdate => ref preUpdateRunners, 
				PlayerLoopTiming.Update => ref updateRunners, 
				PlayerLoopTiming.PreLateUpdate => ref preLateUpdateRunners, 
				PlayerLoopTiming.PostLateUpdate => ref postLateUpdateRunners, 
				PlayerLoopTiming.TimeUpdate => ref timeUpdateRunners, 
				_ => ref EmptyList, 
			};
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			Clear();
		}

		public static void RegisterUnhandledExceptionHandler(Action<Exception> unhandledExceptionHandler)
		{
			unhandledException = unhandledExceptionHandler;
		}

		public static Action<Exception> GetUnhandledExceptionHandler()
		{
			return unhandledException;
		}

		private static void DefaultUnhandledExceptionHandler(Exception exception)
		{
			Debug.LogException(exception);
		}

		public static void Clear()
		{
			PlayerLoopTiming[] array = playerLoopTimings;
			for (int i = 0; i < array.Length; i++)
			{
				Span<IUpdateRunner> span = GetRunnerList(array[i]).AsSpan();
				for (int j = 0; j < span.Length; j++)
				{
					span[j].Reset();
				}
			}
		}

		public static void EnsureStorageCapacity<TValue, TOptions, TAdapter>(int capacity) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			PlayerLoopTiming[] array = playerLoopTimings;
			for (int i = 0; i < array.Length; i++)
			{
				StorageCache<TValue, TOptions, TAdapter>.GetOrCreate(array[i]).EnsureCapacity(capacity);
			}
		}

		internal static MotionHandle Schedule<TValue, TOptions, TAdapter>(ref MotionBuilder<TValue, TOptions, TAdapter> builder, PlayerLoopTiming playerLoopTiming) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			MotionStorage<TValue, TOptions, TAdapter> orCreate = StorageCache<TValue, TOptions, TAdapter>.GetOrCreate(playerLoopTiming);
			RunnerCache<TValue, TOptions, TAdapter>.GetOrCreate(playerLoopTiming, orCreate);
			return orCreate.Create(ref builder);
		}

		internal static void Update(PlayerLoopTiming playerLoopTiming)
		{
			Span<IUpdateRunner> span = GetRunnerList(playerLoopTiming).AsSpan();
			if (playerLoopTiming == PlayerLoopTiming.FixedUpdate)
			{
				for (int i = 0; i < span.Length; i++)
				{
					span[i].Update(Time.fixedTimeAsDouble, Time.fixedUnscaledTimeAsDouble, Time.realtimeSinceStartupAsDouble);
				}
			}
			else
			{
				for (int j = 0; j < span.Length; j++)
				{
					span[j].Update(Time.timeAsDouble, Time.unscaledTimeAsDouble, Time.realtimeSinceStartupAsDouble);
				}
			}
		}
	}
}
