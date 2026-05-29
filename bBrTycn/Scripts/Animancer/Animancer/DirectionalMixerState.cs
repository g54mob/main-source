using System;
using System.Text;
using UnityEngine;

namespace Animancer
{
	public class DirectionalMixerState : MixerState<Vector2>, ICopyable<DirectionalMixerState>
	{
		private float[] _ThresholdMagnitudes;

		private Vector2[][] _BlendFactors;

		private bool _BlendFactorsDirty = true;

		private const float AngleFactor = 2f;

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
			float magnitude = base.Parameter.magnitude;
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
				float num2 = _ThresholdMagnitudes[i];
				float num3 = magnitude - num2;
				float y = SignedAngle(threshold, base.Parameter) * 2f;
				float num4 = 1f;
				for (int j = 0; j < childCount; j++)
				{
					if (j != i && GetChild(j) != null)
					{
						float num5 = (_ThresholdMagnitudes[j] + num2) * 0.5f;
						Vector2 lhs = new Vector2(num3 / num5, y);
						float num6 = 1f - Vector2.Dot(lhs, array[j]);
						if (num4 > num6)
						{
							num4 = num6;
						}
					}
				}
				if (num4 < 0.01f)
				{
					num4 = 0f;
				}
				child.Weight = num4;
				num += num4;
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
			if (_BlendFactors == null || _BlendFactors.Length != childCount)
			{
				_ThresholdMagnitudes = new float[childCount];
				_BlendFactors = new Vector2[childCount][];
				for (int i = 0; i < childCount; i++)
				{
					_BlendFactors[i] = new Vector2[childCount];
				}
			}
			for (int j = 0; j < childCount; j++)
			{
				_ThresholdMagnitudes[j] = GetThreshold(j).magnitude;
			}
			for (int k = 0; k < childCount; k++)
			{
				Vector2[] array = _BlendFactors[k];
				Vector2 threshold = GetThreshold(k);
				float num = _ThresholdMagnitudes[k];
				for (int l = 0; l < childCount; l++)
				{
					if (k != l)
					{
						Vector2 threshold2 = GetThreshold(l);
						float num2 = _ThresholdMagnitudes[l];
						float num3 = (num + num2) * 0.5f;
						float num4 = num2 - num;
						float num5 = SignedAngle(threshold, threshold2);
						Vector2 vector = new Vector2(num4 / num3, num5 * 2f);
						vector *= 1f / vector.sqrMagnitude;
						array[l] = vector;
						_BlendFactors[l][k] = -vector;
					}
				}
			}
		}

		private static float SignedAngle(Vector2 a, Vector2 b)
		{
			if ((a.x == 0f && a.y == 0f) || (b.x == 0f && b.y == 0f))
			{
				return 0f;
			}
			return Mathf.Atan2(a.x * b.y - a.y * b.x, a.x * b.x + a.y * b.y);
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			DirectionalMixerState directionalMixerState = new DirectionalMixerState();
			directionalMixerState.SetNewCloneRoot(root);
			((ICopyable<DirectionalMixerState>)directionalMixerState).CopyFrom(this);
			return directionalMixerState;
		}

		void ICopyable<DirectionalMixerState>.CopyFrom(DirectionalMixerState copyFrom)
		{
			_ThresholdMagnitudes = copyFrom._ThresholdMagnitudes;
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
