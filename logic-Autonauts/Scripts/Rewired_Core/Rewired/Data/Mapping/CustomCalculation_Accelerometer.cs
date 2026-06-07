using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_Accelerometer : CustomCalculation
	{
		public enum CalculationType
		{
			Pitch = 0,
			Roll = 1
		}

		public enum OutputType
		{
			Axis = 0,
			Angle = 1
		}

		public enum InputType
		{
			Acceleration = 0,
			UserAcceleration = 1,
			Gravity = 2
		}

		public CalculationType _calculationType;

		public InputType _inputType;

		public OutputType _outputType;

		internal override TypeWrapper.DataType ResultType
		{
			get
			{
				return TypeWrapper.DataType.Single;
			}
		}

		internal override bool Process()
		{
			bool flag = false;
			ClearResult();
			if (base.DataCount >= 1)
			{
				goto IL_0011;
			}
			goto IL_0043;
			IL_0011:
			int num = -507297748;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num ^ -507297749)
				{
				case 3:
					break;
				case 2:
					goto IL_0043;
				case 0:
					_result = yxGvtaVNjpirBsXWrXQiBdnZUfy();
					flag = true;
					num = -507297746;
					continue;
				case 5:
					num = -507297751;
					continue;
				case 4:
					num = -507297751;
					continue;
				case 1:
					goto IL_0080;
				case 7:
					switch (_calculationType)
					{
					case CalculationType.Pitch:
						break;
					case CalculationType.Roll:
						goto IL_0080;
					default:
						goto IL_00b3;
					}
					goto case 0;
				default:
					{
						return flag;
					}
					IL_00b3:
					num = -507297745;
					continue;
					IL_0080:
					_result = QlYOhCtoMiuQfXnQrxOUZGwZgMqB();
					flag = true;
					num = -507297751;
					continue;
				}
				break;
			}
			goto IL_0011;
			IL_0043:
			ClearData();
			_resultIsValid = flag;
			num = -507297747;
			goto IL_0016;
		}

		private float yxGvtaVNjpirBsXWrXQiBdnZUfy()
		{
			Vector3 vector = default(Vector3);
			int num = MathTools.Min(base.DataCount, 3);
			int num2 = 0;
			InputType inputType = default(InputType);
			float num5 = default(float);
			OutputType outputType = default(OutputType);
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = -1877607131;
					num4 = num3;
				}
				else
				{
					num3 = -1877607123;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -1877607136)
					{
					case 7:
						num3 = -1877607131;
						continue;
					case 4:
						if (vector.z == 0f)
						{
							return 0f;
						}
						goto IL_007d;
					case 13:
						inputType = _inputType;
						num3 = -1877607125;
						continue;
					case 12:
						if (vector.x == 0f)
						{
							num3 = -1877607133;
							continue;
						}
						goto IL_007d;
					case 6:
						num5 = 0f;
						num3 = -1877607134;
						continue;
					case 11:
					{
						int num6;
						if (inputType != InputType.Gravity)
						{
							num3 = -1877607130;
							num6 = num3;
						}
						else
						{
							num3 = -1877607124;
							num6 = num3;
						}
						continue;
					}
					case 8:
						break;
					case 1:
						num2++;
						num3 = -1877607128;
						continue;
					case 5:
						if (_data[num2].type == TypeWrapper.DataType.Single)
						{
							vector[num2] = _data[num2];
							num3 = -1877607135;
							continue;
						}
						goto case 1;
					case 3:
						if (vector.y == 0f)
						{
							num3 = -1877607132;
							continue;
						}
						goto IL_007d;
					case 9:
						switch (outputType)
						{
						case OutputType.Angle:
							break;
						case OutputType.Axis:
							return wJtoiNlpuyoZSleSkjrETJViFjC(num5);
						default:
							return 0f;
						}
						goto default;
					case 0:
						num3 = -1877607134;
						continue;
					case 2:
						outputType = _outputType;
						num3 = -1877607127;
						continue;
					default:
						{
							return num5;
						}
						IL_007d:
						num5 = (0f - MathTools.Atan2(0f - vector.z, 0f - vector.y)) * 57.29578f;
						num3 = -1877607136;
						continue;
					}
					break;
				}
			}
		}

		private float QlYOhCtoMiuQfXnQrxOUZGwZgMqB()
		{
			Vector3 vector = default(Vector3);
			int num3 = default(int);
			int num4 = default(int);
			InputType inputType = default(InputType);
			float num2 = default(float);
			while (true)
			{
				int num = -1034052929;
				while (true)
				{
					switch (num ^ -1034052938)
					{
					case 4:
						break;
					case 5:
						if (num3 >= num4)
						{
							inputType = _inputType;
							num = -1034052940;
							continue;
						}
						goto case 8;
					case 6:
						num3 = 0;
						num = -1034052941;
						continue;
					case 0:
						switch (_outputType)
						{
						case OutputType.Angle:
							break;
						case OutputType.Axis:
							return wJtoiNlpuyoZSleSkjrETJViFjC(num2);
						default:
							return 0f;
						}
						goto default;
					case 7:
						num = -1034052938;
						continue;
					case 8:
						vector[num3] = _data[num3];
						num3++;
						num = -1034052941;
						continue;
					case 1:
						num2 = 0f;
						num = -1034052938;
						continue;
					case 2:
					{
						int num5;
						if (inputType == InputType.Gravity)
						{
							num = -1034052939;
							num5 = num;
						}
						else
						{
							num = -1034052937;
							num5 = num;
						}
						continue;
					}
					case 9:
						num4 = MathTools.Min(base.DataCount, 3);
						num = -1034052944;
						continue;
					case 3:
						if (vector.x == 0f && vector.y == 0f)
						{
							num = -1034052931;
							continue;
						}
						goto IL_0138;
					case 11:
						if (vector.z == 0f)
						{
							return 0f;
						}
						goto IL_0138;
					default:
						{
							return num2;
						}
						IL_0138:
						num2 = (0f - MathTools.Atan2(vector.x, 0f - vector.y)) * 57.29578f;
						num = -1034052943;
						continue;
					}
					break;
				}
			}
		}

		private float wJtoiNlpuyoZSleSkjrETJViFjC(float P_0)
		{
			if (P_0 == 0f)
			{
				return 0f;
			}
			return MathTools.Abs(P_0) / 180f * MathTools.Sign(P_0);
		}
	}
}
