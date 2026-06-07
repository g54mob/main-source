using System;
using UnityEngine;

namespace LitMotion
{
	internal sealed class MotionBuilderBuffer<TValue, TOptions> where TValue : unmanaged where TOptions : unmanaged, IMotionOptions
	{
		private static MotionBuilderBuffer<TValue, TOptions> PoolRoot = new MotionBuilderBuffer<TValue, TOptions>();

		public ushort Version;

		public MotionBuilderBuffer<TValue, TOptions> NextNode;

		public TValue StartValue;

		public TValue EndValue;

		public TOptions Options;

		public float Duration;

		public Ease Ease;

		public MotionTimeKind TimeKind;

		public float Delay;

		public int Loops = 1;

		public DelayType DelayType;

		public LoopType LoopType;

		public bool CancelOnError;

		public bool SkipValuesDuringDelay;

		public bool ImmediateBind = true;

		public object State0;

		public object State1;

		public object State2;

		public byte StateCount;

		public object UpdateAction;

		public Action<int> OnLoopCompleteAction;

		public Action OnCompleteAction;

		public Action OnCancelAction;

		public AnimationCurve AnimationCurve;

		public IMotionScheduler Scheduler;

		public static MotionBuilderBuffer<TValue, TOptions> Rent()
		{
			MotionBuilderBuffer<TValue, TOptions> motionBuilderBuffer;
			if (PoolRoot == null)
			{
				motionBuilderBuffer = new MotionBuilderBuffer<TValue, TOptions>();
			}
			else
			{
				motionBuilderBuffer = PoolRoot;
				PoolRoot = PoolRoot.NextNode;
				motionBuilderBuffer.NextNode = null;
			}
			return motionBuilderBuffer;
		}

		public static void Return(MotionBuilderBuffer<TValue, TOptions> buffer)
		{
			buffer.Version++;
			buffer.ImmediateBind = true;
			buffer.StartValue = default(TValue);
			buffer.EndValue = default(TValue);
			buffer.Options = default(TOptions);
			buffer.Duration = 0f;
			buffer.Ease = Ease.Linear;
			buffer.AnimationCurve = null;
			buffer.TimeKind = MotionTimeKind.Time;
			buffer.Delay = 0f;
			buffer.Loops = 1;
			buffer.LoopType = LoopType.Restart;
			buffer.State0 = null;
			buffer.State1 = null;
			buffer.State2 = null;
			buffer.StateCount = 0;
			buffer.UpdateAction = null;
			buffer.OnLoopCompleteAction = null;
			buffer.OnCompleteAction = null;
			buffer.OnCancelAction = null;
			buffer.CancelOnError = false;
			buffer.SkipValuesDuringDelay = false;
			buffer.Scheduler = null;
			if (buffer.Version != ushort.MaxValue)
			{
				buffer.NextNode = PoolRoot;
				PoolRoot = buffer;
			}
		}
	}
}
