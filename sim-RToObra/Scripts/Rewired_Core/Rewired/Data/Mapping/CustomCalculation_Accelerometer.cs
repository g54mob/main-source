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
				int num;
				switch (_calculationType)
				{
				case CalculationType.Pitch:
					_result = HpIfovKhtbECklIRPNKyBklFrojc();
					flag = true;
					num = -464234213;
					goto IL_002d;
				case CalculationType.Roll:
					goto IL_0065;
					IL_002d:
					while (true)
					{
						switch (num ^ -464234216)
						{
						case 2:
							num = -464234215;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0065;
						default:
							goto end_IL_0019;
						}
						break;
					}
					goto case CalculationType.Pitch;
					IL_0065:
					_result = fTQfeHTsGqvxMhCRDbQKJiuDqXxD();
					flag = true;
					num = -464234213;
					goto IL_002d;
					end_IL_0019:
					break;
				}
			}
			ClearData();
			_resultIsValid = flag;
			return flag;
		}

		private float HpIfovKhtbECklIRPNKyBklFrojc()
		{
			Vector3 vector = default(Vector3);
			int num = MathTools.Min(base.DataCount, 3);
			int num2 = 0;
			float num3 = default(float);
			while (true)
			{
				IL_00eb:
				if (num2 < num)
				{
					goto IL_0059;
				}
				InputType inputType = _inputType;
				int num4;
				if (inputType == InputType.Gravity)
				{
					if (vector.x != 0f || vector.y != 0f || vector.z != 0f)
					{
						num3 = (0f - MathTools.Atan2(0f - vector.z, 0f - vector.y)) * 57.29578f;
						num4 = -592201392;
					}
					else
					{
						num4 = -592201378;
					}
					goto IL_0021;
				}
				goto IL_00cd;
				IL_0021:
				while (true)
				{
					switch (num4 ^ -592201384)
					{
					case 2:
						num4 = -592201377;
						continue;
					case 7:
						break;
					case 6:
						return 0f;
					case 8:
						goto IL_00ac;
					case 5:
						goto IL_00cd;
					case 9:
						num2++;
						num4 = -592201381;
						continue;
					case 3:
						goto IL_00eb;
					case 0:
						vector[num2] = _data[num2];
						num4 = -592201391;
						continue;
					default:
						goto IL_016c;
					case 1:
						return 0f;
					}
					break;
					IL_00ac:
					switch (_outputType)
					{
					default:
						num4 = -592201383;
						continue;
					case OutputType.Angle:
						break;
					case OutputType.Axis:
						return HxlvOMXteqLxjFpVEdQPqFKmSHo(num3);
					}
					goto IL_016c;
					IL_016c:
					return num3;
				}
				goto IL_0059;
				IL_00cd:
				num3 = 0f;
				num4 = -592201392;
				goto IL_0021;
				IL_0059:
				int num5;
				if (_data[num2].type == TypeWrapper.DataType.Single)
				{
					num4 = -592201384;
					num5 = num4;
				}
				else
				{
					num4 = -592201391;
					num5 = num4;
				}
				goto IL_0021;
			}
		}

		private float fTQfeHTsGqvxMhCRDbQKJiuDqXxD()
		{
			Vector3 vector = default(Vector3);
			int num2 = default(int);
			float num5 = default(float);
			int num3 = default(int);
			while (true)
			{
				int num = -1748902652;
				while (true)
				{
					switch (num ^ -1748902651)
					{
					case 0:
						break;
					case 8:
						vector[num2] = _data[num2];
						num = -1748902654;
						continue;
					case 5:
						num5 = 0f;
						num = -1748902653;
						continue;
					case 2:
						if (num2 >= num3)
						{
							InputType inputType = _inputType;
							int num4;
							if (inputType != InputType.Gravity)
							{
								num = -1748902656;
								num4 = num;
							}
							else
							{
								num = -1748902655;
								num4 = num;
							}
							continue;
						}
						goto case 8;
					case 7:
						num2++;
						num = -1748902649;
						continue;
					case 4:
						if (vector.x == 0f)
						{
							num = -1748902642;
							continue;
						}
						goto IL_0138;
					case 1:
						num3 = MathTools.Min(base.DataCount, 3);
						num = -1748902641;
						continue;
					case 10:
						num2 = 0;
						num = -1748902649;
						continue;
					case 6:
						switch (_outputType)
						{
						case OutputType.Angle:
							break;
						case OutputType.Axis:
							return HxlvOMXteqLxjFpVEdQPqFKmSHo(num5);
						default:
							return 0f;
						}
						goto default;
					case 11:
						if (vector.y == 0f)
						{
							num = -1748902644;
							continue;
						}
						goto IL_0138;
					case 9:
						if (vector.z == 0f)
						{
							return 0f;
						}
						goto IL_0138;
					default:
						{
							return num5;
						}
						IL_0138:
						num5 = (0f - MathTools.Atan2(vector.x, 0f - vector.y)) * 57.29578f;
						num = -1748902653;
						continue;
					}
					break;
				}
			}
		}

		private float HxlvOMXteqLxjFpVEdQPqFKmSHo(float P_0)
		{
			if (P_0 == 0f)
			{
				return 0f;
			}
			return MathTools.Abs(P_0) / 180f * MathTools.Sign(P_0);
		}
	}
}
