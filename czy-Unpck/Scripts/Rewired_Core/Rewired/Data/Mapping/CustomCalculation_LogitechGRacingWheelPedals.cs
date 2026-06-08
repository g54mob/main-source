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
		private Mode PVgEWvobJPRolmhNAStYSIWwXDc;

		internal override TypeWrapper.DataType ResultType => TypeWrapper.DataType.Single;

		internal bool sXtPDNTNOVOSqfKrJdRnFVmEfzD()
		{
			bool flag = false;
			while (true)
			{
				int num = 1492847133;
				while (true)
				{
					switch (num ^ 0x58FB0A1F)
					{
					case 4:
						break;
					case 5:
						_result = AFmYuGjoOwfCieDVVkUmoPMnwGa();
						flag = true;
						num = 1492847132;
						continue;
					case 1:
					{
						int num2;
						if (base.DataCount < 1)
						{
							num = 1492847132;
							num2 = num;
						}
						else
						{
							num = 1492847130;
							num2 = num;
						}
						continue;
					}
					case 2:
						ClearResult();
						num = 1492847134;
						continue;
					case 3:
						ClearData();
						_resultIsValid = flag;
						num = 1492847135;
						continue;
					default:
						return flag;
					}
					break;
				}
			}
		}

		private float AFmYuGjoOwfCieDVVkUmoPMnwGa()
		{
			int dataCount = base.DataCount;
			float result = default(float);
			float num6 = default(float);
			float num2 = default(float);
			while (true)
			{
				int num = 2019210579;
				while (true)
				{
					switch (num ^ 0x785AB555)
					{
					case 5:
						break;
					case 6:
					{
						if (dataCount < 2)
						{
							num = 2019210588;
							continue;
						}
						result = _data[0];
						if (_data[0].type != TypeWrapper.DataType.Single)
						{
							return 0f;
						}
						if (_data[1].type != TypeWrapper.DataType.Single)
						{
							num = 2019210578;
							continue;
						}
						num6 = _data[0];
						float num7 = _data[1];
						LZVfZBGUfQeusCWnfDmEbNUKzWNb(num6, num7);
						if (PVgEWvobJPRolmhNAStYSIWwXDc == Mode.SharedAxis)
						{
							num2 = num7;
							num = 2019210583;
							continue;
						}
						goto case 0;
					}
					case 2:
					{
						num2 = MathTools.ValueInNewRange(num2, 0f, 1f, 1f, -1f);
						int num4;
						if (num2 > 0f)
						{
							num = 2019210577;
							num4 = num;
						}
						else
						{
							num = 2019210591;
							num4 = num;
						}
						continue;
					}
					case 0:
						if (PVgEWvobJPRolmhNAStYSIWwXDc == Mode.SeparateAxes)
						{
							result = num6;
							num = 2019210580;
							continue;
						}
						goto default;
					case 9:
						return 0f;
					case 3:
						result = num2;
						num = 2019210580;
						continue;
					case 8:
						num2 = 1f;
						num = 2019210582;
						continue;
					case 4:
						if (!(num2 > 1f))
						{
							int num5;
							if (1f - num2 > 0.001f)
							{
								num = 2019210582;
								num5 = num;
							}
							else
							{
								num = 2019210589;
								num5 = num;
							}
							continue;
						}
						goto case 8;
					case 7:
						return 0f;
					case 11:
						num2 = -1f;
						num = 2019210582;
						continue;
					case 10:
						if (!(num2 < 0f))
						{
							goto case 3;
						}
						if (!(num2 < -1f))
						{
							int num3;
							if (num2 + 1f <= 0.001f)
							{
								num = 2019210590;
								num3 = num;
							}
							else
							{
								num = 2019210582;
								num3 = num;
							}
							continue;
						}
						goto case 11;
					default:
						return result;
					}
					break;
				}
			}
		}

		private void LZVfZBGUfQeusCWnfDmEbNUKzWNb(float P_0, float P_1)
		{
			int num;
			switch (PVgEWvobJPRolmhNAStYSIWwXDc)
			{
			case Mode.SharedAxis:
				if (MathTools.Abs(P_0) >= 0.01f && MathTools.Abs(P_1) <= 0.01f)
				{
					PVgEWvobJPRolmhNAStYSIWwXDc = Mode.SeparateAxes;
					num = -1599027718;
					goto IL_001b;
				}
				break;
			case Mode.SeparateAxes:
				goto IL_0064;
				IL_001b:
				while (true)
				{
					switch (num ^ -1599027717)
					{
					case 4:
						num = -1599027719;
						continue;
					default:
						return;
					case 2:
						break;
					case 0:
						goto IL_0064;
					case 1:
						return;
					case 3:
						return;
					}
					break;
				}
				goto case Mode.SharedAxis;
				IL_0064:
				if (MathTools.Abs(P_1) >= 0.01f && MathTools.Abs(P_0) <= 0.01f)
				{
					PVgEWvobJPRolmhNAStYSIWwXDc = Mode.SharedAxis;
					num = -1599027720;
					goto IL_001b;
				}
				break;
			}
		}
	}
}
