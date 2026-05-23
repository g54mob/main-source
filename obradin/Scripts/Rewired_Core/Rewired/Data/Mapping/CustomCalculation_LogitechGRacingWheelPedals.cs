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
		private Mode TIyLgvwwsJanPbWnnrjVxLizjZSd;

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
				int num = 1039800727;
				while (true)
				{
					switch (num ^ 0x3DFA1996)
					{
					case 4:
						break;
					case 0:
						_resultIsValid = flag;
						num = 1039800725;
						continue;
					case 2:
						ClearData();
						num = 1039800726;
						continue;
					case 1:
						ClearResult();
						if (base.DataCount >= 1)
						{
							_result = QHewkItiFuYBIzHbqDRreXxiRwWT();
							flag = true;
							num = 1039800724;
							continue;
						}
						goto case 2;
					default:
						return flag;
					}
					break;
				}
			}
		}

		private float QHewkItiFuYBIzHbqDRreXxiRwWT()
		{
			int dataCount = base.DataCount;
			if (dataCount < 2)
			{
				return 0f;
			}
			float result = _data[0];
			if (_data[0].type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			if (_data[1].type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			float num = _data[0];
			float num5 = default(float);
			float num3 = default(float);
			while (true)
			{
				int num2 = -870328847;
				while (true)
				{
					switch (num2 ^ -870328840)
					{
					case 0:
						break;
					case 10:
						if (TIyLgvwwsJanPbWnnrjVxLizjZSd == Mode.SeparateAxes)
						{
							result = num;
							num2 = -870328839;
							continue;
						}
						goto default;
					case 7:
						num5 = 1f;
						num2 = -870328844;
						continue;
					case 8:
					{
						int num6;
						if (num5 < 0f)
						{
							num2 = -870328835;
							num6 = num2;
						}
						else
						{
							num2 = -870328844;
							num6 = num2;
						}
						continue;
					}
					case 4:
						num5 = -1f;
						num2 = -870328844;
						continue;
					case 11:
						num5 = num3;
						num2 = -870328838;
						continue;
					case 6:
					{
						int num8;
						if (num5 + 1f <= 0.001f)
						{
							num2 = -870328836;
							num8 = num2;
						}
						else
						{
							num2 = -870328844;
							num8 = num2;
						}
						continue;
					}
					case 3:
						if (!(num5 > 1f))
						{
							int num10;
							if (1f - num5 <= 0.001f)
							{
								num2 = -870328833;
								num10 = num2;
							}
							else
							{
								num2 = -870328844;
								num10 = num2;
							}
							continue;
						}
						goto case 7;
					case 12:
						result = num5;
						num2 = -870328839;
						continue;
					case 5:
					{
						int num9;
						if (!(num5 >= -1f))
						{
							num2 = -870328836;
							num9 = num2;
						}
						else
						{
							num2 = -870328834;
							num9 = num2;
						}
						continue;
					}
					case 2:
					{
						num5 = MathTools.ValueInNewRange(num5, 0f, 1f, 1f, -1f);
						int num7;
						if (num5 <= 0f)
						{
							num2 = -870328848;
							num7 = num2;
						}
						else
						{
							num2 = -870328837;
							num7 = num2;
						}
						continue;
					}
					case 9:
					{
						num3 = _data[1];
						VfJfLtIWDOOEVXLYKNFIosBFQBn(num, num3);
						int num4;
						if (TIyLgvwwsJanPbWnnrjVxLizjZSd == Mode.SharedAxis)
						{
							num2 = -870328845;
							num4 = num2;
						}
						else
						{
							num2 = -870328846;
							num4 = num2;
						}
						continue;
					}
					default:
						return result;
					}
					break;
				}
			}
		}

		private void VfJfLtIWDOOEVXLYKNFIosBFQBn(float P_0, float P_1)
		{
			int num;
			switch (TIyLgvwwsJanPbWnnrjVxLizjZSd)
			{
			default:
				num = 1493041773;
				goto IL_001a;
			case Mode.SeparateAxes:
				goto IL_0043;
			case Mode.SharedAxis:
				goto IL_0093;
				IL_001a:
				while (true)
				{
					switch (num ^ 0x58FE026C)
					{
					case 3:
						break;
					default:
						return;
					case 4:
						goto IL_0043;
					case 2:
						TIyLgvwwsJanPbWnnrjVxLizjZSd = Mode.SharedAxis;
						num = 1493041770;
						continue;
					case 0:
						TIyLgvwwsJanPbWnnrjVxLizjZSd = Mode.SeparateAxes;
						return;
					case 1:
						return;
					case 5:
						goto IL_0093;
					case 6:
						return;
					}
					break;
				}
				goto default;
				IL_0093:
				if (MathTools.Abs(P_0) >= 0.01f)
				{
					int num2;
					if (MathTools.Abs(P_1) > 0.01f)
					{
						num = 1493041770;
						num2 = num;
					}
					else
					{
						num = 1493041772;
						num2 = num;
					}
					goto IL_001a;
				}
				break;
				IL_0043:
				if (MathTools.Abs(P_1) >= 0.01f)
				{
					int num3;
					if (MathTools.Abs(P_0) <= 0.01f)
					{
						num = 1493041774;
						num3 = num;
					}
					else
					{
						num = 1493041770;
						num3 = num;
					}
					goto IL_001a;
				}
				break;
			}
		}
	}
}
