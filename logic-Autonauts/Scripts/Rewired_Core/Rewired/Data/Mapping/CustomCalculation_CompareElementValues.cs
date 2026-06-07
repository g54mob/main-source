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
				while (true)
				{
					int num = 507524402;
					while (true)
					{
						switch (num ^ 0x1E403533)
						{
						case 0:
							break;
						case 1:
							_result = lHgbhHjBPskkfJXiCITtryrqfnRL();
							flag = true;
							num = 507524401;
							continue;
						default:
							goto end_IL_0011;
						}
						break;
					}
					continue;
					end_IL_0011:
					break;
				}
			}
			ClearData();
			_resultIsValid = flag;
			return flag;
		}

		private float lHgbhHjBPskkfJXiCITtryrqfnRL()
		{
			int dataCount = base.DataCount;
			float num3 = default(float);
			float num4 = default(float);
			int num2 = default(int);
			while (true)
			{
				int num = -1886333967;
				while (true)
				{
					switch (num ^ -1886333966)
					{
					case 8:
						break;
					case 9:
						num = -1886333962;
						continue;
					case 11:
						num3 = Math.Max(num3, num4);
						num = -1886333962;
						continue;
					case 12:
						goto IL_0067;
					case 0:
						num4 = _data[num2];
						num = -1886333960;
						continue;
					case 3:
						if (dataCount == 0)
						{
							num = -1886333968;
							continue;
						}
						num3 = _data[0];
						num2 = 1;
						num = -1886333965;
						continue;
					case 7:
						goto IL_00a2;
					case 6:
						goto IL_00b5;
					case 2:
						return 0f;
					case 5:
					{
						TypeWrapper.DataType type = _data[num2].type;
						if (type != TypeWrapper.DataType.Single)
						{
							throw new Exception("Data type must be the same on all data fields!");
						}
						goto case 0;
					}
					case 10:
						switch (_comparisonType)
						{
						case ComparisonType.Max:
							break;
						case ComparisonType.MinAbs:
							goto IL_0067;
						case ComparisonType.Min:
							goto IL_00a2;
						case ComparisonType.MaxAbs:
							goto IL_00b5;
						default:
							goto IL_013b;
						}
						goto case 11;
					case 4:
						num2++;
						num = -1886333965;
						continue;
					default:
						{
							if (num2 >= dataCount)
							{
								return num3;
							}
							goto case 5;
						}
						IL_013b:
						num = -1886333957;
						continue;
						IL_0067:
						num3 = MathTools.MinMagnitude(num3, num4);
						num = -1886333962;
						continue;
						IL_00b5:
						num3 = MathTools.MaxMagnitude(num3, num4);
						num = -1886333962;
						continue;
						IL_00a2:
						num3 = Math.Min(num3, num4);
						num = -1886333962;
						continue;
					}
					break;
				}
			}
		}
	}
}
