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

		internal override TypeWrapper.DataType ResultType => TypeWrapper.DataType.Single;

		internal bool sXtPDNTNOVOSqfKrJdRnFVmEfzD()
		{
			bool flag = false;
			ClearResult();
			while (true)
			{
				int num = -1314667115;
				while (true)
				{
					switch (num ^ -1314667118)
					{
					case 3:
						break;
					case 7:
						if (base.DataCount >= 1)
						{
							switch (_calculationType)
							{
							case CalculationType.Pitch:
								goto IL_009b;
							case CalculationType.Roll:
								goto IL_00c1;
							}
							num = -1314667117;
							continue;
						}
						goto case 6;
					case 8:
						_resultIsValid = flag;
						num = -1314667114;
						continue;
					case 0:
						flag = true;
						num = -1314667120;
						continue;
					case 6:
						ClearData();
						num = -1314667110;
						continue;
					case 2:
						num = -1314667116;
						continue;
					case 9:
						goto IL_009b;
					case 1:
						num = -1314667116;
						continue;
					case 5:
						goto IL_00c1;
					default:
						{
							return flag;
						}
						IL_00c1:
						_result = hhWAITJPvmUNaiKxkPtRLkEYRLJ();
						flag = true;
						num = -1314667116;
						continue;
						IL_009b:
						_result = HvCIfuxCPfgOZDbcsnhWPLLCaJQ();
						num = -1314667118;
						continue;
					}
					break;
				}
			}
		}

		private float HvCIfuxCPfgOZDbcsnhWPLLCaJQ()
		{
			Vector3 vector = default(Vector3);
			OutputType outputType = default(OutputType);
			float num5 = default(float);
			int num2 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num = -1365277236;
				while (true)
				{
					switch (num ^ -1365277244)
					{
					case 14:
						break;
					case 5:
						switch (outputType)
						{
						case OutputType.Angle:
							break;
						case OutputType.Axis:
							return RQvfFIELMgXdTPIHbyGNvVvrWQtQ(num5);
						default:
							return 0f;
						}
						goto default;
					case 6:
						vector[num2] = _data[num2];
						num = -1365277243;
						continue;
					case 3:
					{
						int num7;
						if (num2 < num6)
						{
							num = -1365277242;
							num7 = num;
						}
						else
						{
							num = -1365277245;
							num7 = num;
						}
						continue;
					}
					case 7:
					{
						InputType inputType = _inputType;
						int num4;
						if (inputType == InputType.Gravity)
						{
							num = -1365277234;
							num4 = num;
						}
						else
						{
							num = -1365277235;
							num4 = num;
						}
						continue;
					}
					case 0:
						num = -1365277241;
						continue;
					case 13:
						if (vector.z == 0f)
						{
							return 0f;
						}
						goto IL_00ef;
					case 10:
						if (vector.x == 0f && vector.y == 0f)
						{
							num = -1365277239;
							continue;
						}
						goto IL_00ef;
					case 1:
						num2++;
						num = -1365277241;
						continue;
					case 8:
						num6 = MathTools.Min(base.DataCount, 3);
						num2 = 0;
						num = -1365277244;
						continue;
					case 11:
						num = -1365277240;
						continue;
					case 12:
						outputType = _outputType;
						num = -1365277247;
						continue;
					case 9:
						num5 = 0f;
						num = -1365277240;
						continue;
					case 2:
					{
						int num3;
						if (_data[num2].type != TypeWrapper.DataType.Single)
						{
							num = -1365277243;
							num3 = num;
						}
						else
						{
							num = -1365277246;
							num3 = num;
						}
						continue;
					}
					default:
						{
							return num5;
						}
						IL_00ef:
						num5 = (0f - MathTools.Atan2(0f - vector.z, 0f - vector.y)) * 57.29578f;
						num = -1365277233;
						continue;
					}
					break;
				}
			}
		}

		private float hhWAITJPvmUNaiKxkPtRLkEYRLJ()
		{
			Vector3 vector = default(Vector3);
			int num = MathTools.Min(base.DataCount, 3);
			int num2 = 0;
			float num3 = default(float);
			while (true)
			{
				IL_00b7:
				int num4;
				if (num2 >= num)
				{
					InputType inputType = _inputType;
					if (inputType == InputType.Gravity)
					{
						if (vector.x != 0f || vector.y != 0f || vector.z != 0f)
						{
							num3 = (0f - MathTools.Atan2(vector.x, 0f - vector.y)) * 57.29578f;
							num4 = -1938715058;
						}
						else
						{
							num4 = -1938715059;
						}
						goto IL_0021;
					}
					goto IL_00a7;
				}
				goto IL_0102;
				IL_0021:
				while (true)
				{
					switch (num4 ^ -1938715060)
					{
					case 4:
						num4 = -1938715062;
						continue;
					case 1:
						return 0f;
					case 2:
						num4 = -1938715063;
						continue;
					case 5:
						break;
					case 3:
						goto IL_00a7;
					case 0:
						goto IL_00b7;
					case 6:
						goto IL_0102;
					default:
						goto end_IL_00b7;
					}
					break;
				}
				switch (_outputType)
				{
				case OutputType.Angle:
					break;
				case OutputType.Axis:
					return RQvfFIELMgXdTPIHbyGNvVvrWQtQ(num3);
				default:
					return 0f;
				}
				break;
				IL_00a7:
				num3 = 0f;
				num4 = -1938715063;
				goto IL_0021;
				IL_0102:
				vector[num2] = _data[num2];
				num2++;
				num4 = -1938715060;
				goto IL_0021;
				continue;
				end_IL_00b7:
				break;
			}
			return num3;
		}

		private float RQvfFIELMgXdTPIHbyGNvVvrWQtQ(float P_0)
		{
			if (P_0 == 0f)
			{
				return 0f;
			}
			return MathTools.Abs(P_0) / 180f * MathTools.Sign(P_0);
		}
	}
}
