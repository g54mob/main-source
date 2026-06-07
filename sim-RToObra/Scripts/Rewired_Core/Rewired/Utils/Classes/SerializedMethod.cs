using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Utils.Classes
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public abstract class SerializedMethod : ScriptableObject
	{
		private const int boVdwwZoVKHxZrRnNKGatSWthKO = 3;

		[NonSerialized]
		private bool YUDatIsYdexhrFOLCBZeHQTCxEC;

		[NonSerialized]
		internal List<TypeWrapper> _data;

		[NonSerialized]
		internal TypeWrapper _result;

		[NonSerialized]
		internal bool _resultIsValid;

		internal abstract TypeWrapper.DataType ResultType { get; }

		internal int DataCount
		{
			get
			{
				if (_data == null)
				{
					return 0;
				}
				return _data.Count;
			}
		}

		internal TypeWrapper Result
		{
			get
			{
				return _result;
			}
		}

		internal bool ResultIsValid
		{
			get
			{
				return _resultIsValid;
			}
		}

		internal TypeWrapper GetData(int index)
		{
			if (index >= 0)
			{
				if (index < DataCount)
				{
					goto IL_0038;
				}
				while (true)
				{
					switch (0xA3DEDEB ^ 0xA3DEDE9)
					{
					case 0:
						break;
					case 2:
						goto end_IL_000d;
					default:
						goto IL_0038;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			throw new IndexOutOfRangeException();
			IL_0038:
			return _data[index];
		}

		internal void AddData(byte item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				PIdggUKFqWQBhZnCDHiPmKlFcDl();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(sbyte item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				while (true)
				{
					int num = -456166075;
					while (true)
					{
						switch (num ^ -456166076)
						{
						case 2:
							break;
						case 1:
							PIdggUKFqWQBhZnCDHiPmKlFcDl();
							num = -456166076;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(char item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				while (true)
				{
					int num = 981702692;
					while (true)
					{
						switch (num ^ 0x3A839825)
						{
						case 2:
							break;
						case 1:
							PIdggUKFqWQBhZnCDHiPmKlFcDl();
							num = 981702693;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(int item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				while (true)
				{
					int num = 250218793;
					while (true)
					{
						switch (num ^ 0xEEA0928)
						{
						case 2:
							break;
						case 1:
							PIdggUKFqWQBhZnCDHiPmKlFcDl();
							num = 250218792;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(uint item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				while (true)
				{
					int num = 2135403341;
					while (true)
					{
						switch (num ^ 0x7F47AB4F)
						{
						case 0:
							break;
						case 2:
							PIdggUKFqWQBhZnCDHiPmKlFcDl();
							num = 2135403342;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(long item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				PIdggUKFqWQBhZnCDHiPmKlFcDl();
				goto IL_000e;
			}
			goto IL_002c;
			IL_002c:
			_data.Add(new TypeWrapper(item));
			int num = -1945765485;
			goto IL_0013;
			IL_000e:
			num = -1945765488;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1945765487)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_002c;
			case 2:
				return;
			}
			goto IL_000e;
		}

		internal void AddData(ulong item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				PIdggUKFqWQBhZnCDHiPmKlFcDl();
				goto IL_000e;
			}
			goto IL_002c;
			IL_002c:
			_data.Add(new TypeWrapper(item));
			int num = -1023420418;
			goto IL_0013;
			IL_000e:
			num = -1023420417;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1023420418)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_002c;
			case 0:
				return;
			}
			goto IL_000e;
		}

		internal void AddData(float item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				PIdggUKFqWQBhZnCDHiPmKlFcDl();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(double item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				while (true)
				{
					int num = -1043374879;
					while (true)
					{
						switch (num ^ -1043374880)
						{
						case 0:
							break;
						case 1:
							PIdggUKFqWQBhZnCDHiPmKlFcDl();
							num = -1043374878;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(bool item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				while (true)
				{
					int num = -1911109354;
					while (true)
					{
						switch (num ^ -1911109353)
						{
						case 0:
							break;
						case 1:
							PIdggUKFqWQBhZnCDHiPmKlFcDl();
							num = -1911109355;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(string item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				PIdggUKFqWQBhZnCDHiPmKlFcDl();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(object item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				PIdggUKFqWQBhZnCDHiPmKlFcDl();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(TypeWrapper item)
		{
			if (!YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				goto IL_0008;
			}
			goto IL_0037;
			IL_0008:
			int num = 36971847;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x2342546)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					PIdggUKFqWQBhZnCDHiPmKlFcDl();
					num = 36971845;
					continue;
				case 3:
					goto IL_0037;
				case 0:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0037:
			_data.Add(item);
			num = 36971846;
			goto IL_000d;
		}

		internal void ClearData()
		{
			if (YUDatIsYdexhrFOLCBZeHQTCxEC)
			{
				_data.Clear();
			}
		}

		internal void ClearResult()
		{
			_resultIsValid = false;
			while (true)
			{
				int num = 1313833796;
				while (true)
				{
					switch (num ^ 0x4E4F8345)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0025;
					case 0:
						return;
					}
					break;
					IL_0025:
					_result.Clear();
					num = 1313833797;
				}
			}
		}

		internal abstract bool Process();

		private void PIdggUKFqWQBhZnCDHiPmKlFcDl()
		{
			_data = new List<TypeWrapper>(3);
			while (true)
			{
				int num = 79444532;
				while (true)
				{
					switch (num ^ 0x4BC3A36)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002a;
					case 1:
						return;
					}
					break;
					IL_002a:
					YUDatIsYdexhrFOLCBZeHQTCxEC = true;
					num = 79444535;
				}
			}
		}
	}
}
