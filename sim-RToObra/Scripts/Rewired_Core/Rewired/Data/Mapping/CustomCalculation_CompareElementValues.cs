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
				_result = QHewkItiFuYBIzHbqDRreXxiRwWT();
				flag = true;
			}
			ClearData();
			_resultIsValid = flag;
			return flag;
		}

		private float QHewkItiFuYBIzHbqDRreXxiRwWT()
		{
			int dataCount = base.DataCount;
			if (dataCount == 0)
			{
				return 0f;
			}
			float num = _data[0];
			int num2 = 1;
			float num4 = default(float);
			while (true)
			{
				int num3 = -259050885;
				while (true)
				{
					switch (num3 ^ -259050887)
					{
					case 8:
						break;
					case 12:
						num2++;
						num3 = -259050888;
						continue;
					case 11:
						num = MathTools.MaxMagnitude(num, num4);
						num3 = -259050891;
						continue;
					case 2:
						num3 = -259050888;
						continue;
					case 9:
						num3 = -259050891;
						continue;
					case 6:
						num3 = -259050891;
						continue;
					case 5:
					{
						TypeWrapper.DataType type = _data[num2].type;
						int num5;
						if (type == TypeWrapper.DataType.Single)
						{
							num3 = -259050892;
							num5 = num3;
						}
						else
						{
							num3 = -259050887;
							num5 = num3;
						}
						continue;
					}
					case 13:
						num4 = _data[num2];
						switch (_comparisonType)
						{
						case ComparisonType.MaxAbs:
							break;
						default:
							goto IL_0100;
						case ComparisonType.Min:
							goto IL_011f;
						case ComparisonType.MinAbs:
							goto IL_0132;
						case ComparisonType.Max:
							goto IL_0145;
						}
						goto case 11;
					case 0:
						throw new Exception("Data type must be the same on all data fields!");
					case 4:
						goto IL_011f;
					case 3:
						goto IL_0132;
					case 10:
						goto IL_0145;
					case 7:
						num3 = -259050891;
						continue;
					default:
						{
							if (num2 >= dataCount)
							{
								return num;
							}
							goto case 5;
						}
						IL_0145:
						num = Math.Max(num, num4);
						num3 = -259050882;
						continue;
						IL_0132:
						num = MathTools.MinMagnitude(num, num4);
						num3 = -259050881;
						continue;
						IL_011f:
						num = Math.Min(num, num4);
						num3 = -259050896;
						continue;
						IL_0100:
						num3 = -259050891;
						continue;
					}
					break;
				}
			}
		}
	}
}
