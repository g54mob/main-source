using System;
using System.Collections.Generic;

namespace LitMotion
{
	public sealed class ManualMotionDispatcher
	{
		public static readonly ManualMotionDispatcher Default = new ManualMotionDispatcher();

		private readonly ManualMotionDispatcherScheduler scheduler;

		private readonly Dictionary<Type, IUpdateRunner> runners = new Dictionary<Type, IUpdateRunner>();

		private double time;

		public IMotionScheduler Scheduler => scheduler;

		public double Time
		{
			get
			{
				return time;
			}
			set
			{
				Update(value - time);
			}
		}

		public ManualMotionDispatcher()
		{
			scheduler = new ManualMotionDispatcherScheduler(this);
		}

		public void EnsureStorageCapacity<TValue, TOptions, TAdapter>(int capacity) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			GetOrCreateRunner<TValue, TOptions, TAdapter>().Storage.EnsureCapacity(capacity);
		}

		public void Update(double deltaTime)
		{
			time += deltaTime;
			foreach (KeyValuePair<Type, IUpdateRunner> runner in runners)
			{
				runner.Value.Update(time, time, time);
			}
		}

		public void Reset()
		{
			foreach (KeyValuePair<Type, IUpdateRunner> runner in runners)
			{
				runner.Value.Reset();
			}
			time = 0.0;
		}

		internal UpdateRunner<TValue, TOptions, TAdapter> GetOrCreateRunner<TValue, TOptions, TAdapter>() where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Type typeFromHandle = typeof((TValue, TOptions, TAdapter));
			if (!runners.TryGetValue(typeFromHandle, out var value))
			{
				MotionStorage<TValue, TOptions, TAdapter> storage = new MotionStorage<TValue, TOptions, TAdapter>(MotionManager.MotionTypeCount);
				MotionManager.Register(storage);
				value = new UpdateRunner<TValue, TOptions, TAdapter>(storage, 0.0, 0.0, 0.0);
				runners.Add(typeFromHandle, value);
			}
			return (UpdateRunner<TValue, TOptions, TAdapter>)value;
		}
	}
}
