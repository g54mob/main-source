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
			while (true)
			{
				int num = 503532662;
				while (true)
				{
					switch (num ^ 0x1E034C77)
					{
					case 2:
						break;
					case 3:
						ClearData();
						num = 503532663;
						continue;
					case 4:
						_result = QHewkItiFuYBIzHbqDRreXxiRwWT();
						flag = true;
						num = 503532660;
						continue;
					case 1:
					{
						ClearResult();
						int num2;
						if (base.DataCount >= 1)
						{
							num = 503532659;
							num2 = num;
						}
						else
						{
							num = 503532660;
							num2 = num;
						}
						continue;
					}
					default:
						_resultIsValid = flag;
						return flag;
					}
					break;
				}
			}
		}

		private float QHewkItiFuYBIzHbqDRreXxiRwWT()
		{
			int dataCount = base.DataCount;
			int num4 = default(int);
			float num2 = default(float);
			float result = default(float);
			while (true)
			{
				int num = 1680132216;
				while (true)
				{
					switch (num ^ 0x6424C87E)
					{
					case 10:
						break;
					case 5:
					{
						int num5;
						if (num4 < dataCount)
						{
							num = 1680132214;
							num5 = num;
						}
						else
						{
							num = 1680132215;
							num5 = num;
						}
						continue;
					}
					case 1:
						return 0f;
					case 3:
						num4++;
						num = 1680132219;
						continue;
					case 7:
						num2 = _data[num4];
						num = 1680132218;
						continue;
					case 2:
						result = num2;
						num = 1680132222;
						continue;
					case 8:
					{
						TypeWrapper.DataType type = _data[num4].type;
						if (type != TypeWrapper.DataType.Single)
						{
							throw new Exception("Data type must be the same on all data fields!");
						}
						goto case 7;
					}
					case 0:
						num = 1680132215;
						continue;
					case 6:
						if (dataCount != 0)
						{
							result = 0f;
							num4 = 0;
							num = 1680132219;
						}
						else
						{
							num = 1680132223;
						}
						continue;
					case 4:
					{
						int num3;
						if (num2 != 0f)
						{
							num = 1680132220;
							num3 = num;
						}
						else
						{
							num = 1680132221;
							num3 = num;
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
	}
}
