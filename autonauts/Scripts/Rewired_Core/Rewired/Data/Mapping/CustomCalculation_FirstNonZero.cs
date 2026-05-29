using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_FirstNonZero : CustomCalculation
	{
		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

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
			while (true)
			{
				int num = -460490512;
				while (true)
				{
					switch (num ^ -460490510)
					{
					case 0:
						break;
					case 2:
						if (base.DataCount >= 1)
						{
							_result = lHgbhHjBPskkfJXiCITtryrqfnRL();
							num = -460490509;
							continue;
						}
						goto case 5;
					case 1:
						flag = true;
						num = -460490505;
						continue;
					case 3:
						_resultIsValid = flag;
						num = -460490506;
						continue;
					case 5:
						ClearData();
						num = -460490511;
						continue;
					default:
						return flag;
					}
					break;
				}
			}
		}

		private float lHgbhHjBPskkfJXiCITtryrqfnRL()
		{
			int dataCount = base.DataCount;
			if (dataCount == 0)
			{
				goto IL_000d;
			}
			float result = 0f;
			int num = 1707171771;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			TypeWrapper.DataType type = default(TypeWrapper.DataType);
			while (true)
			{
				switch (num ^ 0x65C15FBE)
				{
				case 0:
					break;
				case 8:
					num2++;
					num = 1707171772;
					continue;
				case 5:
					num2 = 0;
					num = 1707171772;
					continue;
				case 4:
					type = _data[num2].type;
					num = 1707171769;
					continue;
				case 2:
				{
					int num4;
					if (num2 >= dataCount)
					{
						num = 1707171768;
						num4 = num;
					}
					else
					{
						num = 1707171770;
						num4 = num;
					}
					continue;
				}
				case 3:
				{
					float num3 = _data[num2];
					if (num3 != 0f)
					{
						result = num3;
						num = 1707171767;
						continue;
					}
					goto case 8;
				}
				case 7:
					if (type != TypeWrapper.DataType.Single)
					{
						throw new Exception("Data type must be the same on all data fields!");
					}
					goto case 3;
				case 1:
					return 0f;
				case 9:
					num = 1707171768;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 1707171775;
			goto IL_0012;
		}
	}
}
