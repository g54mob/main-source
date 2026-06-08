using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_CompareElementValues : CustomCalculation
	{
		public enum ComparisonType
		{
			Min = 0,
			Max = 1,
			MinAbs = 2,
			MaxAbs = 3
		}

		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		[SerializeField]
		private ComparisonType _comparisonType;

		internal override TypeWrapper.DataType ResultType => TypeWrapper.DataType.Single;

		internal bool sXtPDNTNOVOSqfKrJdRnFVmEfzD()
		{
			bool flag = false;
			ClearResult();
			if (base.DataCount >= 1)
			{
				_result = AFmYuGjoOwfCieDVVkUmoPMnwGa();
				flag = true;
				goto IL_0025;
			}
			goto IL_0047;
			IL_0047:
			ClearData();
			int num = -1625478931;
			goto IL_002a;
			IL_0025:
			num = -1625478930;
			goto IL_002a;
			IL_002a:
			while (true)
			{
				switch (num ^ -1625478932)
				{
				case 3:
					break;
				case 2:
					goto IL_0047;
				case 1:
					_resultIsValid = flag;
					num = -1625478932;
					continue;
				default:
					return flag;
				}
				break;
			}
			goto IL_0025;
		}

		private float AFmYuGjoOwfCieDVVkUmoPMnwGa()
		{
			int dataCount = base.DataCount;
			if (dataCount == 0)
			{
				goto IL_000a;
			}
			float num = _data[0];
			int num2 = 1;
			int num3 = 1669558979;
			goto IL_000f;
			IL_000f:
			float num4 = default(float);
			ComparisonType comparisonType = default(ComparisonType);
			while (true)
			{
				switch (num3 ^ 0x638372C5)
				{
				case 9:
					break;
				case 2:
					num3 = 1669558977;
					continue;
				case 1:
					num = MathTools.MinMagnitude(num, num4);
					num3 = 1669558983;
					continue;
				case 12:
					goto IL_006a;
				case 8:
					return 0f;
				case 4:
					num2++;
					num3 = 1669558979;
					continue;
				case 3:
					num4 = _data[num2];
					comparisonType = _comparisonType;
					num3 = 1669558978;
					continue;
				case 0:
					goto IL_00d3;
				case 5:
				{
					TypeWrapper.DataType type = _data[num2].type;
					if (type != TypeWrapper.DataType.Single)
					{
						throw new Exception("Data type must be the same on all data fields!");
					}
					goto case 3;
				}
				case 11:
					num3 = 1669558977;
					continue;
				case 7:
					switch (comparisonType)
					{
					case ComparisonType.MinAbs:
						break;
					case ComparisonType.Max:
						goto IL_006a;
					case ComparisonType.Min:
						goto IL_00d3;
					default:
						goto IL_0133;
					case ComparisonType.MaxAbs:
						goto IL_013d;
					}
					goto case 1;
				case 10:
					goto IL_013d;
				default:
					{
						if (num2 >= dataCount)
						{
							return num;
						}
						goto case 5;
					}
					IL_013d:
					num = MathTools.MaxMagnitude(num, num4);
					num3 = 1669558977;
					continue;
					IL_0133:
					num3 = 1669558977;
					continue;
					IL_00d3:
					num = Math.Min(num, num4);
					num3 = 1669558990;
					continue;
					IL_006a:
					num = Math.Max(num, num4);
					num3 = 1669558977;
					continue;
				}
				break;
			}
			goto IL_000a;
			IL_000a:
			num3 = 1669558989;
			goto IL_000f;
		}
	}
}
