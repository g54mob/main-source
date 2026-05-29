using System;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class LinearMixerTransition : MixerTransition<LinearMixerState, float>, LinearMixerState.ITransition, ITransition<LinearMixerState>, ITransition, IHasKey, IPolymorphic, ICopyable<LinearMixerTransition>
	{
		[SerializeField]
		[Tooltip("Should setting the Parameter above the highest threshold increase the Speed of the mixer proportionally?")]
		private bool _ExtrapolateSpeed = true;

		public ref bool ExtrapolateSpeed => ref _ExtrapolateSpeed;

		public override bool IsValid
		{
			get
			{
				if (!base.IsValid)
				{
					return false;
				}
				float num = float.NegativeInfinity;
				float[] thresholds = base.Thresholds;
				foreach (float num2 in thresholds)
				{
					if (num2 < num)
					{
						return false;
					}
					num = num2;
				}
				return true;
			}
		}

		public override LinearMixerState CreateState()
		{
			base.State = new LinearMixerState();
			InitializeState();
			return base.State;
		}

		public override void Apply(AnimancerState state)
		{
			base.Apply(state);
			base.State.ExtrapolateSpeed = _ExtrapolateSpeed;
		}

		public void SortByThresholds()
		{
			int num = base.Thresholds.Length;
			if (num <= 1)
			{
				return;
			}
			int num2 = base.Speeds.Length;
			int num3 = base.SynchronizeChildren.Length;
			float num4 = base.Thresholds[0];
			for (int i = 1; i < num; i++)
			{
				float num5 = base.Thresholds[i];
				if (num5 >= num4)
				{
					num4 = num5;
					continue;
				}
				base.Thresholds.Swap(i, i - 1);
				base.Animations.Swap(i, i - 1);
				if (i < num2)
				{
					base.Speeds.Swap(i, i - 1);
				}
				if (i == num3 && !base.SynchronizeChildren[i - 1])
				{
					bool[] array = base.SynchronizeChildren;
					Array.Resize(ref array, ++num3);
					array[i - 1] = true;
					array[i] = false;
					base.SynchronizeChildren = array;
				}
				else if (i < num3)
				{
					base.SynchronizeChildren.Swap(i, i - 1);
				}
				if (i == 1)
				{
					i = 0;
					num4 = float.NegativeInfinity;
				}
				else
				{
					i -= 2;
					num4 = base.Thresholds[i];
				}
			}
		}

		public virtual void CopyFrom(LinearMixerTransition copyFrom)
		{
			CopyFrom((MixerTransition<LinearMixerState, float>)copyFrom);
			if (copyFrom == null)
			{
				_ExtrapolateSpeed = true;
			}
			else
			{
				_ExtrapolateSpeed = copyFrom._ExtrapolateSpeed;
			}
		}
	}
}
