using System;
using R3.Collections;
using UnityEngine;

namespace R3
{
	public class UnityFrameProvider : FrameProvider
	{
		public static readonly FrameProvider Initialization = new UnityFrameProvider(PlayerLoopTiming.Initialization);

		public static readonly FrameProvider EarlyUpdate = new UnityFrameProvider(PlayerLoopTiming.EarlyUpdate);

		public static readonly FrameProvider FixedUpdate = new UnityFrameProvider(PlayerLoopTiming.FixedUpdate);

		public static readonly FrameProvider PreUpdate = new UnityFrameProvider(PlayerLoopTiming.PreUpdate);

		public static readonly FrameProvider Update = new UnityFrameProvider(PlayerLoopTiming.Update);

		public static readonly FrameProvider PreLateUpdate = new UnityFrameProvider(PlayerLoopTiming.PreLateUpdate);

		public static readonly FrameProvider PostLateUpdate = new UnityFrameProvider(PlayerLoopTiming.PostLateUpdate);

		public static readonly FrameProvider TimeUpdate = new UnityFrameProvider(PlayerLoopTiming.TimeUpdate);

		public static readonly FrameProvider PostFixedUpdate = new UnityFrameProvider(PlayerLoopTiming.PostFixedUpdate);

		private FreeListCore<IFrameRunnerWorkItem> list;

		private readonly object gate = new object();

		internal PlayerLoopTiming PlayerLoopTiming { get; }

		internal UnityFrameProvider(PlayerLoopTiming playerLoopTiming)
		{
			PlayerLoopTiming = playerLoopTiming;
			list = new FreeListCore<IFrameRunnerWorkItem>(gate);
		}

		public override long GetFrameCount()
		{
			return Time.frameCount;
		}

		public override void Register(IFrameRunnerWorkItem callback)
		{
			list.Add(callback, out var _);
		}

		internal void Run()
		{
			long frameCount = Time.frameCount;
			ReadOnlySpan<IFrameRunnerWorkItem> readOnlySpan = list.AsSpan();
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				ref readonly IFrameRunnerWorkItem reference = ref readOnlySpan[i];
				if (reference == null)
				{
					continue;
				}
				try
				{
					if (!reference.MoveNext(frameCount))
					{
						list.Remove(i);
					}
				}
				catch (Exception obj)
				{
					list.Remove(i);
					try
					{
						ObservableSystem.GetUnhandledExceptionHandler()(obj);
					}
					catch
					{
					}
				}
			}
		}

		internal void Clear()
		{
			list.Clear(removeArray: true);
		}
	}
}
