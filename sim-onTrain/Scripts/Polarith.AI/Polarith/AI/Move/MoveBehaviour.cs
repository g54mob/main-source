using System;
using Polarith.AI.Criteria;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class MoveBehaviour : CriteriaBehaviour
	{
		[NonSerialized]
		public Context Context;

		[NonSerialized]
		protected Problem intermediate = new Problem();

		public static float MapSpecial(MappingType mapping, float min, float max, float value)
		{
			if (mapping == MappingType.Constant)
			{
				return 1f;
			}
			if (value < min + 1E-06f)
			{
				if ((int)mapping % 2 == 0)
				{
					return 1f;
				}
				return 0f;
			}
			if (value > max - 1E-06f)
			{
				if ((int)mapping % 2 == 0)
				{
					return 0f;
				}
				return 1f;
			}
			switch (mapping)
			{
			case MappingType.Linear:
				return Mathf2.MapLinear(0f, 1f, min, max, value);
			case MappingType.InverseLinear:
				return 1f - Mathf2.MapLinear(0f, 1f, min, max, value);
			case MappingType.Quadratic:
			{
				float num = Mathf2.MapLinear(0f, 1f, min, max, value);
				return num * num;
			}
			case MappingType.InverseQuadratic:
			{
				float num = Mathf2.MapLinear(0f, 1f, min, max, value);
				num *= num;
				return 1f - num;
			}
			case MappingType.SquareRoot:
				return Mathf.Sqrt(Mathf2.MapLinear(0f, 1f, min, max, value));
			case MappingType.InverseSquareRoot:
				return 1f - Mathf.Sqrt(Mathf2.MapLinear(0f, 1f, min, max, value));
			default:
				return 1f;
			}
		}

		public static float MapSpecialSqr(MappingType mapping, float sqrMin, float sqrMax, float sqrValue)
		{
			if (mapping == MappingType.Constant)
			{
				return 1f;
			}
			if (sqrValue < sqrMin + 1E-06f)
			{
				if ((int)mapping % 2 == 0)
				{
					return 1f;
				}
				return 0f;
			}
			if (sqrValue > sqrMax - 1E-06f)
			{
				if ((int)mapping % 2 == 0)
				{
					return 0f;
				}
				return 1f;
			}
			sqrMin = Mathf.Sqrt(sqrMin);
			sqrMax = Mathf.Sqrt(sqrMax);
			sqrValue = Mathf.Sqrt(sqrValue);
			switch (mapping)
			{
			case MappingType.Linear:
				return Mathf2.MapLinear(0f, 1f, sqrMin, sqrMax, sqrValue);
			case MappingType.InverseLinear:
				return 1f - Mathf2.MapLinear(0f, 1f, sqrMin, sqrMax, sqrValue);
			case MappingType.Quadratic:
			{
				float num = Mathf2.MapLinear(0f, 1f, sqrMin, sqrMax, sqrValue);
				return num * num;
			}
			case MappingType.InverseQuadratic:
			{
				float num = 1f - Mathf2.MapLinear(0f, 1f, sqrMin, sqrMax, sqrValue);
				return num * num;
			}
			case MappingType.SquareRoot:
				return Mathf.Sqrt(Mathf2.MapLinear(0f, 1f, sqrMin, sqrMax, sqrValue));
			case MappingType.InverseSquareRoot:
				return 1f - Mathf.Sqrt(Mathf2.MapLinear(0f, 1f, sqrMin, sqrMax, sqrValue));
			default:
				return 1f;
			}
		}

		protected float MapBySensitivity(MappingType mapping, Structure structure, Vector3 direction, float sensitivityOffset = 0f)
		{
			float num = structure.Sensitivity + sensitivityOffset;
			float num2 = Vector3.Angle(direction, Context.LocalToWorldMatrix.MultiplyVector(structure.Direction));
			if (num < 1E-06f || num2 > num)
			{
				return 0f;
			}
			return MapSpecial(mapping, 0f, num, num2);
		}

		protected float MapBySensitivityPlane(MappingType mapping, Structure structure, Vector3 planeDirection1, Vector3 planeDirection2, float offset, float sensitivityOffset = 0f)
		{
			float num = structure.Sensitivity + sensitivityOffset;
			Vector3 normalized = Context.LocalToWorldMatrix.MultiplyVector(structure.Direction).normalized;
			float num2 = Mathf.Abs(Vector3.Dot(normalized, planeDirection1));
			float num3 = Mathf.Abs(Vector3.Dot(normalized, planeDirection2));
			float num4 = ((num2 > num3) ? num2 : num3);
			num4 = ((!(num4 + 1E-06f >= 1f)) ? (Mathf.Acos(num4) * 57.29578f) : 0f);
			num4 -= offset;
			num4 = ((num4 < 0f) ? (0f - num4) : num4);
			if (num < 1E-06f || num4 > num)
			{
				return 0f;
			}
			return MapSpecial(mapping, 0f, num, num4);
		}

		protected void WriteValue(ValueWritingType valueWriting, int objectiveIndex, int valueIndex, float value, bool intermediate = false)
		{
			IProblem<float> problem = Context.Problem;
			if (intermediate)
			{
				objectiveIndex = 0;
				problem = this.intermediate;
			}
			switch (valueWriting)
			{
			case ValueWritingType.AssignGreater:
				if (value > problem[objectiveIndex][valueIndex] + 1E-06f)
				{
					problem.SetValue(objectiveIndex, valueIndex, value);
				}
				break;
			case ValueWritingType.AssignLesser:
				if (value < problem[objectiveIndex][valueIndex] - 1E-06f)
				{
					problem.SetValue(objectiveIndex, valueIndex, value);
				}
				break;
			case ValueWritingType.Addition:
				problem.SetValue(objectiveIndex, valueIndex, problem[objectiveIndex][valueIndex] + value);
				break;
			case ValueWritingType.Subtraction:
				problem.SetValue(objectiveIndex, valueIndex, problem[objectiveIndex][valueIndex] - value);
				break;
			case ValueWritingType.Multiplication:
				problem.SetValue(objectiveIndex, valueIndex, problem[objectiveIndex][valueIndex] * value);
				break;
			case ValueWritingType.Division:
				if (value != 0f)
				{
					problem.SetValue(objectiveIndex, valueIndex, problem[objectiveIndex][valueIndex] / value);
				}
				break;
			default:
				if (value > problem[objectiveIndex][valueIndex] + 1E-06f)
				{
					problem.SetValue(objectiveIndex, valueIndex, value);
				}
				break;
			}
		}

		protected void BlendValues(LayerBlendingType layerBlending, int objectiveIndex)
		{
			if (layerBlending == LayerBlendingType.None)
			{
				return;
			}
			IProblem<float> problem = Context.Problem;
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < problem.ValueCount; i++)
			{
				num = problem[objectiveIndex][i];
				num2 = intermediate[0][i];
				switch (layerBlending)
				{
				case LayerBlendingType.AssignGreater:
					if (num2 > num + 1E-06f)
					{
						problem.SetValue(objectiveIndex, i, num2);
					}
					break;
				case LayerBlendingType.AssignLesser:
					if (num2 < num - 1E-06f)
					{
						problem.SetValue(objectiveIndex, i, num2);
					}
					break;
				case LayerBlendingType.Addition:
					problem.SetValue(objectiveIndex, i, num + num2);
					break;
				case LayerBlendingType.Subtraction:
					problem.SetValue(objectiveIndex, i, num - num2);
					break;
				case LayerBlendingType.Multiplication:
					problem.SetValue(objectiveIndex, i, num * num2);
					break;
				case LayerBlendingType.Division:
					if (num2 != 0f)
					{
						problem.SetValue(objectiveIndex, i, num / num2);
					}
					break;
				default:
					if (num2 > num + 1E-06f)
					{
						problem.SetValue(objectiveIndex, i, num2);
					}
					break;
				}
			}
		}
	}
}
