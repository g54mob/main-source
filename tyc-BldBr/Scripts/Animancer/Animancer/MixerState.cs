using System;
using System.Text;
using UnityEngine;

namespace Animancer
{
	public abstract class MixerState<TParameter> : ManualMixerState, ICopyable<MixerState<TParameter>>
	{
		private TParameter[] _Thresholds = Array.Empty<TParameter>();

		private TParameter _Parameter;

		public TParameter Parameter
		{
			get
			{
				return _Parameter;
			}
			set
			{
				_Parameter = value;
				base.WeightsAreDirty = true;
				RequireUpdate();
			}
		}

		public bool HasThresholds => _Thresholds.Length >= ChildCount;

		public abstract string GetParameterError(TParameter parameter);

		public TParameter GetThreshold(int index)
		{
			return _Thresholds[index];
		}

		public void SetThreshold(int index, TParameter threshold)
		{
			_Thresholds[index] = threshold;
			OnThresholdsChanged();
		}

		public void SetThresholds(params TParameter[] thresholds)
		{
			if (thresholds.Length < ChildCount)
			{
				throw new ArgumentOutOfRangeException("thresholds", $"Threshold count ({thresholds.Length}) must not be less than child count ({ChildCount}).");
			}
			_Thresholds = thresholds;
			OnThresholdsChanged();
		}

		public bool ValidateThresholdCount()
		{
			if (_Thresholds.Length >= ChildCount)
			{
				return false;
			}
			_Thresholds = new TParameter[base.ChildCapacity];
			return true;
		}

		public virtual void OnThresholdsChanged()
		{
			base.WeightsAreDirty = true;
			RequireUpdate();
		}

		public void CalculateThresholds(Func<AnimancerState, TParameter> calculate)
		{
			ValidateThresholdCount();
			for (int num = ChildCount - 1; num >= 0; num--)
			{
				_Thresholds[num] = calculate(GetChild(num));
			}
			OnThresholdsChanged();
		}

		public override void RecreatePlayable()
		{
			base.RecreatePlayable();
			base.WeightsAreDirty = true;
			RequireUpdate();
		}

		protected override void OnChildCapacityChanged()
		{
			Array.Resize(ref _Thresholds, base.ChildCapacity);
			OnThresholdsChanged();
		}

		public void Add(AnimancerState state, TParameter threshold)
		{
			Add(state);
			SetThreshold(state.Index, threshold);
		}

		public ClipState Add(AnimationClip clip, TParameter threshold)
		{
			ClipState clipState = Add(clip);
			SetThreshold(clipState.Index, threshold);
			return clipState;
		}

		public AnimancerState Add(Animancer.ITransition transition, TParameter threshold)
		{
			AnimancerState animancerState = Add(transition);
			SetThreshold(animancerState.Index, threshold);
			return animancerState;
		}

		public AnimancerState Add(object child, TParameter threshold)
		{
			if (child is AnimationClip clip)
			{
				return Add(clip, threshold);
			}
			if (child is ITransition transition)
			{
				return Add(transition, threshold);
			}
			if (child is AnimancerState animancerState)
			{
				Add(animancerState, threshold);
				return animancerState;
			}
			throw new ArgumentException($"Unable to add '{AnimancerUtilities.ToStringOrNull(child)}' as child of '{this}'.");
		}

		void ICopyable<MixerState<TParameter>>.CopyFrom(MixerState<TParameter> copyFrom)
		{
			((ICopyable<ManualMixerState>)this).CopyFrom((ManualMixerState)copyFrom);
			int childCount = copyFrom.ChildCount;
			if (copyFrom._Thresholds != null)
			{
				_Thresholds = new TParameter[childCount];
				int length = Math.Min(childCount, copyFrom._Thresholds.Length);
				Array.Copy(copyFrom._Thresholds, _Thresholds, length);
			}
			Parameter = copyFrom.Parameter;
		}

		public override string GetDisplayKey(AnimancerState state)
		{
			return $"[{state.Index}] {_Thresholds[state.Index]}";
		}

		protected override void AppendDetails(StringBuilder text, string separator)
		{
			text.Append(separator);
			text.Append("Parameter: ");
			AppendParameter(text, Parameter);
			text.Append(separator).Append("Thresholds: ");
			int num = Math.Min(base.ChildCapacity, _Thresholds.Length);
			for (int i = 0; i < num; i++)
			{
				if (i > 0)
				{
					text.Append(", ");
				}
				AppendParameter(text, _Thresholds[i]);
			}
			base.AppendDetails(text, separator);
		}

		public virtual void AppendParameter(StringBuilder description, TParameter parameter)
		{
			description.Append(parameter);
		}
	}
}
