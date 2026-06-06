using System.Runtime.CompilerServices;
using LitMotion.Collections;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace LitMotion
{
	internal struct MotionData
	{
		public struct MotionState
		{
			public MotionStatus Status;

			public MotionStatus PrevStatus;

			public bool IsPreserved;

			public bool IsInSequence;

			public ushort CompletedLoops;

			public ushort PrevCompletedLoops;

			public double Time;

			public float PlaybackSpeed;

			public readonly bool WasStatusChanged => Status != PrevStatus;

			public readonly bool WasLoopCompleted => CompletedLoops > PrevCompletedLoops;
		}

		public struct MotionParameters
		{
			public float Duration;

			public Ease Ease;

			public NativeAnimationCurve AnimationCurve;

			public MotionTimeKind TimeKind;

			public float Delay;

			public int Loops;

			public DelayType DelayType;

			public LoopType LoopType;

			public readonly double TotalDuration
			{
				get
				{
					if (Loops < 0)
					{
						return double.PositiveInfinity;
					}
					return Delay * (float)((DelayType != DelayType.EveryLoop) ? 1 : Loops) + Duration * (float)Loops;
				}
			}
		}

		public MotionState State;

		public MotionParameters Parameters;

		public readonly double TimeSinceStart => State.Time - (double)Parameters.Delay;

		public void Update(double time, out float progress)
		{
			State.PrevCompletedLoops = State.CompletedLoops;
			State.PrevStatus = State.Status;
			State.Time = time;
			time = math.max(time, 0.0);
			bool flag;
			double num;
			int clampedCompletedLoops;
			bool flag2;
			if (Hint.Unlikely(Parameters.Duration <= 0f))
			{
				if (Parameters.DelayType == DelayType.FirstLoop || Parameters.Delay == 0f)
				{
					flag = Parameters.Loops >= 0 && TimeSinceStart > 0.0;
					int completedLoops;
					if (flag)
					{
						num = 1.0;
						completedLoops = Parameters.Loops;
					}
					else
					{
						num = 0.0;
						completedLoops = ((TimeSinceStart < 0.0) ? (-1) : 0);
					}
					clampedCompletedLoops = GetClampedCompletedLoops(completedLoops);
					flag2 = TimeSinceStart < 0.0;
				}
				else
				{
					int completedLoops = (int)math.floor(time / (double)Parameters.Delay);
					clampedCompletedLoops = GetClampedCompletedLoops(completedLoops);
					flag = Parameters.Loops >= 0 && clampedCompletedLoops > Parameters.Loops - 1;
					flag2 = !flag;
					num = (flag ? 1f : 0f);
				}
			}
			else if (Parameters.DelayType == DelayType.FirstLoop)
			{
				int completedLoops = (int)math.floor(TimeSinceStart / (double)Parameters.Duration);
				clampedCompletedLoops = GetClampedCompletedLoops(completedLoops);
				flag = Parameters.Loops >= 0 && clampedCompletedLoops > Parameters.Loops - 1;
				flag2 = TimeSinceStart < 0.0;
				num = ((!flag) ? math.clamp((TimeSinceStart - (double)(Parameters.Duration * (float)clampedCompletedLoops)) / (double)Parameters.Duration, 0.0, 1.0) : 1.0);
			}
			else
			{
				double num2 = math.fmod(time, Parameters.Duration + Parameters.Delay) - (double)Parameters.Delay;
				int completedLoops = (int)math.floor(time / (double)(Parameters.Duration + Parameters.Delay));
				clampedCompletedLoops = GetClampedCompletedLoops(completedLoops);
				flag = Parameters.Loops >= 0 && clampedCompletedLoops > Parameters.Loops - 1;
				flag2 = num2 < 0.0;
				num = ((!flag) ? math.clamp(num2 / (double)Parameters.Duration, 0.0, 1.0) : 1.0);
			}
			State.CompletedLoops = (ushort)clampedCompletedLoops;
			switch (Parameters.LoopType)
			{
			default:
				progress = GetEasedValue((float)num);
				break;
			case LoopType.Flip:
				progress = GetEasedValue((float)num);
				if ((clampedCompletedLoops + (int)num) % 2 == 1)
				{
					progress = 1f - progress;
				}
				break;
			case LoopType.Incremental:
				progress = GetEasedValue(1f) * (float)clampedCompletedLoops + GetEasedValue((float)math.fmod(num, 1.0));
				break;
			case LoopType.Yoyo:
				progress = (((clampedCompletedLoops + (int)num) % 2 == 1) ? GetEasedValue((float)(1.0 - num)) : GetEasedValue((float)num));
				break;
			}
			if (flag)
			{
				State.Status = MotionStatus.Completed;
			}
			else if (flag2 || State.Time < 0.0)
			{
				State.Status = MotionStatus.Delayed;
			}
			else
			{
				State.Status = MotionStatus.Playing;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Complete(out float progress)
		{
			State.Status = MotionStatus.Completed;
			State.Time = Parameters.TotalDuration;
			State.CompletedLoops = (ushort)Parameters.Loops;
			float value;
			switch (Parameters.LoopType)
			{
			case LoopType.Restart:
				value = 1f;
				break;
			case LoopType.Flip:
			case LoopType.Yoyo:
				value = ((Parameters.Loops % 2 == 0) ? 0f : 1f);
				break;
			case LoopType.Incremental:
				value = Parameters.Loops;
				break;
			default:
				value = 1f;
				break;
			}
			progress = GetEasedValue(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private readonly int GetClampedCompletedLoops(int completedLoops)
		{
			if (Parameters.Loops >= 0)
			{
				return math.clamp(completedLoops, 0, Parameters.Loops);
			}
			return math.max(0, completedLoops);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private readonly float GetEasedValue(float value)
		{
			if (Parameters.Ease == Ease.CustomAnimationCurve)
			{
				return Parameters.AnimationCurve.Evaluate(value);
			}
			return EaseUtility.Evaluate(value, Parameters.Ease);
		}
	}
	internal struct MotionData<TValue, TOptions> where TValue : unmanaged where TOptions : unmanaged, IMotionOptions
	{
		public MotionData Core;

		public TValue StartValue;

		public TValue EndValue;

		public TOptions Options;

		public void Update<TAdapter>(double time, out TValue result) where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Core.Update(time, out var progress);
			TAdapter val = default(TAdapter);
			ref TValue startValue = ref StartValue;
			ref TValue endValue = ref EndValue;
			ref TOptions options = ref Options;
			MotionEvaluationContext context = new MotionEvaluationContext
			{
				Progress = progress,
				Time = time
			};
			result = val.Evaluate(ref startValue, ref endValue, ref options, in context);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Complete<TAdapter>(out TValue result) where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Core.Complete(out var progress);
			TAdapter val = default(TAdapter);
			ref TValue startValue = ref StartValue;
			ref TValue endValue = ref EndValue;
			ref TOptions options = ref Options;
			MotionEvaluationContext context = new MotionEvaluationContext
			{
				Progress = progress,
				Time = Core.State.Time
			};
			result = val.Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
