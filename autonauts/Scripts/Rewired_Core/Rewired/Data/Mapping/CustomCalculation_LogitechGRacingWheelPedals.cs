using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_LogitechGRacingWheelPedals : CustomCalculation
	{
		public enum Mode
		{
			SharedAxis = 0,
			SeparateAxes = 1
		}

		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		private const float dead = 0.01f;

		[NonSerialized]
		private Mode eZgEjmSxyBYkcHCaJInRYlkdhWPD;

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
			while (true)
			{
				int num = -1366534214;
				while (true)
				{
					switch (num ^ -1366534213)
					{
					case 2:
						break;
					case 4:
						_result = lHgbhHjBPskkfJXiCITtryrqfnRL();
						flag = true;
						num = -1366534213;
						continue;
					case 3:
					{
						int num2;
						if (base.DataCount >= 1)
						{
							num = -1366534209;
							num2 = num;
						}
						else
						{
							num = -1366534213;
							num2 = num;
						}
						continue;
					}
					case 1:
						ClearResult();
						num = -1366534216;
						continue;
					default:
						ClearData();
						_resultIsValid = flag;
						return flag;
					}
					break;
				}
			}
		}

		private float lHgbhHjBPskkfJXiCITtryrqfnRL()
		{
			int dataCount = base.DataCount;
			if (dataCount < 2)
			{
				goto IL_000e;
			}
			float result = _data[0];
			int num = -1946924860;
			goto IL_0013;
			IL_0013:
			float num5 = default(float);
			float num2 = default(float);
			float num6 = default(float);
			while (true)
			{
				switch (num ^ -1946924855)
				{
				case 0:
					break;
				case 7:
					result = num2;
					num = -1946924852;
					continue;
				case 13:
					if (_data[0].type != TypeWrapper.DataType.Single)
					{
						num = -1946924864;
						continue;
					}
					if (_data[1].type != TypeWrapper.DataType.Single)
					{
						return 0f;
					}
					num5 = _data[0];
					num = -1946924861;
					continue;
				case 2:
					if (!(num2 > 1f))
					{
						int num8;
						if (1f - num2 > 0.001f)
						{
							num = -1946924850;
							num8 = num;
						}
						else
						{
							num = -1946924863;
							num8 = num;
						}
						continue;
					}
					goto case 8;
				case 6:
					num2 = -1f;
					num = -1946924850;
					continue;
				case 11:
					return 0f;
				case 12:
					if (eZgEjmSxyBYkcHCaJInRYlkdhWPD == Mode.SharedAxis)
					{
						num2 = num6;
						num2 = MathTools.ValueInNewRange(num2, 0f, 1f, 1f, -1f);
						int num7;
						if (num2 > 0f)
						{
							num = -1946924853;
							num7 = num;
						}
						else
						{
							num = -1946924851;
							num7 = num;
						}
						continue;
					}
					goto case 1;
				case 10:
					num6 = _data[1];
					uSTiHGwDSSjqdzpWmXxZPOyRPwy(num5, num6);
					num = -1946924859;
					continue;
				case 9:
					return 0f;
				case 8:
					num2 = 1f;
					num = -1946924850;
					continue;
				case 3:
					result = num5;
					num = -1946924852;
					continue;
				case 1:
				{
					int num4;
					if (eZgEjmSxyBYkcHCaJInRYlkdhWPD != Mode.SeparateAxes)
					{
						num = -1946924852;
						num4 = num;
					}
					else
					{
						num = -1946924854;
						num4 = num;
					}
					continue;
				}
				case 4:
					if (!(num2 < 0f))
					{
						goto case 7;
					}
					if (!(num2 < -1f))
					{
						int num3;
						if (num2 + 1f <= 0.001f)
						{
							num = -1946924849;
							num3 = num;
						}
						else
						{
							num = -1946924850;
							num3 = num;
						}
						continue;
					}
					goto case 6;
				default:
					return result;
				}
				break;
			}
			goto IL_000e;
			IL_000e:
			num = -1946924862;
			goto IL_0013;
		}

		private void uSTiHGwDSSjqdzpWmXxZPOyRPwy(float P_0, float P_1)
		{
			int num;
			switch (eZgEjmSxyBYkcHCaJInRYlkdhWPD)
			{
			case Mode.SeparateAxes:
			{
				int num2;
				if (MathTools.Abs(P_1) < 0.01f)
				{
					num = 1342023436;
					num2 = num;
				}
				else
				{
					num = 1342023439;
					num2 = num;
				}
				goto IL_001b;
			}
			case Mode.SharedAxis:
				goto IL_0096;
				IL_001b:
				while (true)
				{
					switch (num ^ 0x4FFDA70D)
					{
					case 3:
						num = 1342023433;
						continue;
					default:
						return;
					case 5:
						eZgEjmSxyBYkcHCaJInRYlkdhWPD = Mode.SharedAxis;
						num = 1342023436;
						continue;
					case 2:
						break;
					case 0:
						goto end_IL_001b;
					case 6:
						return;
					case 4:
						goto IL_0096;
					case 1:
						return;
					}
					int num3;
					if (MathTools.Abs(P_0) > 0.01f)
					{
						num = 1342023436;
						num3 = num;
					}
					else
					{
						num = 1342023432;
						num3 = num;
					}
					continue;
					end_IL_001b:
					break;
				}
				goto case Mode.SeparateAxes;
				IL_0096:
				if (MathTools.Abs(P_0) >= 0.01f && MathTools.Abs(P_1) <= 0.01f)
				{
					eZgEjmSxyBYkcHCaJInRYlkdhWPD = Mode.SeparateAxes;
					num = 1342023435;
					goto IL_001b;
				}
				break;
			}
		}
	}
}
