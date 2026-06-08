using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_FirstNonZero : CustomCalculation
	{
		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		internal override TypeWrapper.DataType ResultType => TypeWrapper.DataType.Single;

		internal bool sXtPDNTNOVOSqfKrJdRnFVmEfzD()
		{
			bool flag = false;
			ClearResult();
			while (true)
			{
				int num = -1185575927;
				while (true)
				{
					switch (num ^ -1185575928)
					{
					case 0:
						break;
					case 1:
						if (base.DataCount >= 1)
						{
							_result = AFmYuGjoOwfCieDVVkUmoPMnwGa();
							num = -1185575926;
							continue;
						}
						goto default;
					case 2:
						flag = true;
						num = -1185575925;
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

		private float AFmYuGjoOwfCieDVVkUmoPMnwGa()
		{
			int dataCount = base.DataCount;
			if (dataCount == 0)
			{
				goto IL_000a;
			}
			float result = 0f;
			int num = -2021778344;
			goto IL_000f;
			IL_000f:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -2021778340)
				{
				case 8:
					break;
				case 7:
					num3++;
					num = -2021778340;
					continue;
				case 4:
					num3 = 0;
					num = -2021778340;
					continue;
				case 2:
					return 0f;
				case 5:
					throw new Exception("Data type must be the same on all data fields!");
				case 9:
					num = -2021778342;
					continue;
				case 0:
				{
					int num5;
					if (num3 < dataCount)
					{
						num = -2021778337;
						num5 = num;
					}
					else
					{
						num = -2021778342;
						num5 = num;
					}
					continue;
				}
				case 3:
				{
					TypeWrapper.DataType type = _data[num3].type;
					int num4;
					if (type == TypeWrapper.DataType.Single)
					{
						num = -2021778339;
						num4 = num;
					}
					else
					{
						num = -2021778343;
						num4 = num;
					}
					continue;
				}
				case 1:
				{
					float num2 = _data[num3];
					if (num2 != 0f)
					{
						result = num2;
						num = -2021778347;
						continue;
					}
					goto case 7;
				}
				default:
					return result;
				}
				break;
			}
			goto IL_000a;
			IL_000a:
			num = -2021778338;
			goto IL_000f;
		}
	}
}
