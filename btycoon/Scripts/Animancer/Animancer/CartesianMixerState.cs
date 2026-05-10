using System;
using System.Text;
using UnityEngine;

namespace Animancer
{
	public class CartesianMixerState : MixerState<Vector2>, ICopyable<CartesianMixerState>
	{
		private Vector2[][] _BlendFactors;

		private bool _BlendFactorsDirty = true;

		public float ParameterX
		{
			get
			{
				return base.Parameter.x;
			}
			set
			{
				base.Parameter = new Vector2(value, base.Parameter.y);
			}
		}

		public float ParameterY
		{
			get
			{
				return base.Parameter.y;
			}
			set
			{
				base.Parameter = new Vector2(base.Parameter.x, value);
			}
		}

		protected override int ParameterCount => 2;

		public override string GetParameterError(Vector2 value)
		{
			if (!value.IsFinite())
			{
				return "value.x and value.y must not be NaN or Infinity";
			}
			return null;
		}

		public override void OnThresholdsChanged()
		{
			_BlendFactorsDirty = true;
			base.OnThresholdsChanged();
		}

		protected override void ForceRecalculateWeights()
		{
			base.WeightsAreDirty = false;
			int childCount = ChildCount;
			switch (childCount)
			{
			case 0:
				return;
			case 1:
				GetChild(0).Weight = 1f;
				return;
			}
			CalculateBlendFactors(childCount);
			float num = 0f;
			for (int i = 0; i < childCount; i++)
			{
				AnimancerState child = GetChild(i);
				if (child == null)
				{
					continue;
				}
				Vector2[] array = _BlendFactors[i];
				Vector2 threshold = GetThreshold(i);
				Vector2 lhs = base.Parameter - threshold;
				float num2 = 1f;
				for (int j = 0; j < childCount; j++)
				{
					if (j != i && GetChild(j) != null)
					{
						float num3 = 1f - Vector2.Dot(lhs, array[j]);
						if (num2 > num3)
						{
							num2 = num3;
						}
					}
				}
				if (num2 < 0.01f)
				{
					num2 = 0f;
				}
				child.Weight = num2;
				num += num2;
			}
			NormalizeWeights(num);
		}

		private void CalculateBlendFactors(int childCount)
		{
			if (!_BlendFactorsDirty)
			{
				return;
			}
			_BlendFactorsDirty = false;
			if (AnimancerUtilities.SetLength(ref _BlendFactors, childCount))
			{
				for (int i = 0; i < childCount; i++)
				{
					_BlendFactors[i] = new Vector2[childCount];
				}
			}
			for (int j = 0; j < childCount; j++)
			{
				Vector2[] array = _BlendFactors[j];
				Vector2 threshold = GetThreshold(j);
				for (int k = j + 1; k < childCount; k++)
				{
					Vector2 vector = GetThreshold(k) - threshold;
					vector /= vector.sqrMagnitude;
					array[k] = vector;
					_BlendFactors[k][j] = -vector;
				}
			}
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			CartesianMixerState cartesianMixerState = new CartesianMixerState();
			cartesianMixerState.SetNewCloneRoot(root);
			((ICopyable<CartesianMixerState>)cartesianMixerState).CopyFrom(this);
			return cartesianMixerState;
		}

		void ICopyable<CartesianMixerState>.CopyFrom(CartesianMixerState copyFrom)
		{
			_BlendFactorsDirty = copyFrom._BlendFactorsDirty;
			if (!_BlendFactorsDirty)
			{
				_BlendFactors = copyFrom._BlendFactors;
			}
			((ICopyable<MixerState<Vector2>>)this).CopyFrom((MixerState<Vector2>)copyFrom);
		}

		public override void AppendParameter(StringBuilder text, Vector2 parameter)
		{
			text.Append('(').Append(parameter.x).Append(", ")
				.Append(parameter.y)
				.Append(')');
		}

		protected override string GetParameterName(int index)
		{
			return index switch
			{
				0 => "Parameter X", 
				1 => "Parameter Y", 
				_ => throw new ArgumentOutOfRangeException("index"), 
			};
		}

		protected override AnimatorControllerParameterType GetParameterType(int index)
		{
			return AnimatorControllerParameterType.Float;
		}

		protected override object GetParameterValue(int index)
		{
			return index switch
			{
				0 => ParameterX, 
				1 => ParameterY, 
				_ => throw new ArgumentOutOfRangeException("index"), 
			};
		}

		protected override void SetParameterValue(int index, object value)
		{
			switch (index)
			{
			case 0:
				ParameterX = (float)value;
				break;
			case 1:
				ParameterY = (float)value;
				break;
			default:
				throw new ArgumentOutOfRangeException("index");
			}
		}
	}
}
