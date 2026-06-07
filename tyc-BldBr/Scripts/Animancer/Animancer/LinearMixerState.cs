using System;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;

namespace Animancer
{
	public class LinearMixerState : MixerState<float>, ICopyable<LinearMixerState>
	{
		public new interface ITransition : ITransition<LinearMixerState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		private bool _ExtrapolateSpeed = true;

		public bool ExtrapolateSpeed
		{
			get
			{
				return _ExtrapolateSpeed;
			}
			set
			{
				if (_ExtrapolateSpeed == value)
				{
					return;
				}
				_ExtrapolateSpeed = value;
				if (!_Playable.IsValid())
				{
					return;
				}
				float num = base.Speed;
				int childCount = ChildCount;
				if (value && childCount > 0)
				{
					float threshold = GetThreshold(childCount - 1);
					if (base.Parameter > threshold)
					{
						num *= base.Parameter / threshold;
					}
				}
				_Playable.SetSpeed(num);
			}
		}

		protected override int ParameterCount => 1;

		public override string GetParameterError(float value)
		{
			if (!value.IsFinite())
			{
				return "must not be NaN or Infinity";
			}
			return null;
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			LinearMixerState linearMixerState = new LinearMixerState();
			linearMixerState.SetNewCloneRoot(root);
			((ICopyable<LinearMixerState>)linearMixerState).CopyFrom(this);
			return linearMixerState;
		}

		void ICopyable<LinearMixerState>.CopyFrom(LinearMixerState copyFrom)
		{
			_ExtrapolateSpeed = copyFrom._ExtrapolateSpeed;
			((ICopyable<MixerState<float>>)this).CopyFrom((MixerState<float>)copyFrom);
		}

		public void AssertThresholdsSorted()
		{
			if (!base.HasThresholds)
			{
				throw new InvalidOperationException("Thresholds have not been initialized");
			}
			float num = float.NegativeInfinity;
			int childCount = ChildCount;
			for (int i = 0; i < childCount; i++)
			{
				if (base.ChildStates[i] != null)
				{
					float threshold = GetThreshold(i);
					if (!(threshold > num))
					{
						throw new ArgumentException(((threshold == num) ? "Mixer has multiple identical thresholds." : "Mixer has thresholds out of order.") + " They must be sorted from lowest to highest with no equal values.\n" + GetDescription());
					}
					num = threshold;
				}
			}
		}

		protected override void ForceRecalculateWeights()
		{
			base.WeightsAreDirty = false;
			int childCount = ChildCount;
			int num;
			AnimancerState animancerState;
			float parameter;
			float num2;
			AnimancerState animancerState2;
			float threshold;
			if (childCount != 0)
			{
				num = 0;
				animancerState = base.ChildStates[num];
				parameter = base.Parameter;
				num2 = GetThreshold(num);
				if (parameter <= num2)
				{
					DisableRemainingStates(num);
					if (num2 >= 0f)
					{
						animancerState.Weight = 1f;
						goto IL_00e2;
					}
				}
				else
				{
					while (++num < childCount)
					{
						animancerState2 = base.ChildStates[num];
						threshold = GetThreshold(num);
						if (!(parameter > num2) || !(parameter <= threshold))
						{
							animancerState.Weight = 0f;
							animancerState = animancerState2;
							num2 = threshold;
							continue;
						}
						goto IL_0071;
					}
				}
				animancerState.Weight = 1f;
				if (ExtrapolateSpeed)
				{
					_Playable.SetSpeed(base.Speed * (parameter / num2));
				}
				return;
			}
			goto IL_00e2;
			IL_00e2:
			if (ExtrapolateSpeed && _Playable.IsValid())
			{
				_Playable.SetSpeed(base.Speed);
			}
			return;
			IL_0071:
			float num3 = (parameter - num2) / (threshold - num2);
			animancerState.Weight = 1f - num3;
			animancerState2.Weight = num3;
			DisableRemainingStates(num);
			goto IL_00e2;
		}

		public LinearMixerState AssignLinearThresholds(float min = 0f, float max = 1f)
		{
			int childCount = ChildCount;
			float[] array = new float[childCount];
			float num = (max - min) / (float)(childCount - 1);
			for (int i = 0; i < childCount; i++)
			{
				array[i] = ((i < childCount - 1) ? (min + (float)i * num) : max);
			}
			SetThresholds(array);
			return this;
		}

		protected override void AppendDetails(StringBuilder text, string separator)
		{
			text.Append(separator).Append("ExtrapolateSpeed: ").Append(ExtrapolateSpeed);
			base.AppendDetails(text, separator);
		}

		protected override string GetParameterName(int index)
		{
			return "Parameter";
		}

		protected override AnimatorControllerParameterType GetParameterType(int index)
		{
			return AnimatorControllerParameterType.Float;
		}

		protected override object GetParameterValue(int index)
		{
			return base.Parameter;
		}

		protected override void SetParameterValue(int index, object value)
		{
			base.Parameter = (float)value;
		}
	}
}
