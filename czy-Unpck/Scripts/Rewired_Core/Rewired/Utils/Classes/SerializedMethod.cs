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
		private const int tZPHAgJbmUVHlkKPiwhtEicqOCk = 3;

		[NonSerialized]
		private bool SkFKXQgWYqSFJEyjlpatgIrLsWw;

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

		internal TypeWrapper Result => _result;

		internal bool ResultIsValid => _resultIsValid;

		internal TypeWrapper GetData(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 1130878651;
					while (true)
					{
						switch (num ^ 0x4367D6BA)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							return _data[index];
						}
						break;
						IL_0026:
						int num2;
						if (index >= DataCount)
						{
							num = 1130878648;
							num2 = num;
						}
						else
						{
							num = 1130878649;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new IndexOutOfRangeException();
		}

		internal void AddData(byte item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				FtvSHSGXHWhaTEGyiFJERNPUtVF();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(sbyte item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				while (true)
				{
					int num = -479825407;
					while (true)
					{
						switch (num ^ -479825408)
						{
						case 0:
							break;
						case 1:
							FtvSHSGXHWhaTEGyiFJERNPUtVF();
							num = -479825406;
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
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				FtvSHSGXHWhaTEGyiFJERNPUtVF();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(int item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				FtvSHSGXHWhaTEGyiFJERNPUtVF();
				goto IL_000e;
			}
			goto IL_002c;
			IL_002c:
			_data.Add(new TypeWrapper(item));
			int num = -588921350;
			goto IL_0013;
			IL_000e:
			num = -588921349;
			goto IL_0013;
			IL_0013:
			switch (num ^ -588921350)
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

		internal void AddData(uint item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				while (true)
				{
					int num = -831544105;
					while (true)
					{
						switch (num ^ -831544106)
						{
						case 0:
							break;
						case 1:
							FtvSHSGXHWhaTEGyiFJERNPUtVF();
							num = -831544108;
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
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				FtvSHSGXHWhaTEGyiFJERNPUtVF();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(ulong item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				goto IL_0008;
			}
			goto IL_0037;
			IL_0008:
			int num = 1537567284;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x5BA56A35)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					FtvSHSGXHWhaTEGyiFJERNPUtVF();
					num = 1537567286;
					continue;
				case 3:
					goto IL_0037;
				case 2:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0037:
			_data.Add(new TypeWrapper(item));
			num = 1537567287;
			goto IL_000d;
		}

		internal void AddData(float item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				while (true)
				{
					int num = 423650829;
					while (true)
					{
						switch (num ^ 0x1940660C)
						{
						case 2:
							break;
						case 1:
							FtvSHSGXHWhaTEGyiFJERNPUtVF();
							num = 423650828;
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

		internal void AddData(double item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				FtvSHSGXHWhaTEGyiFJERNPUtVF();
				goto IL_000e;
			}
			goto IL_002c;
			IL_002c:
			_data.Add(new TypeWrapper(item));
			int num = 1837032197;
			goto IL_0013;
			IL_000e:
			num = 1837032196;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x6D7EE305)
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

		internal void AddData(bool item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				while (true)
				{
					int num = 1758395154;
					while (true)
					{
						switch (num ^ 0x68CEFB13)
						{
						case 0:
							break;
						case 1:
							FtvSHSGXHWhaTEGyiFJERNPUtVF();
							num = 1758395153;
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
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				while (true)
				{
					int num = -344038193;
					while (true)
					{
						switch (num ^ -344038194)
						{
						case 2:
							break;
						case 1:
							FtvSHSGXHWhaTEGyiFJERNPUtVF();
							num = -344038194;
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

		internal void AddData(object item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				goto IL_0008;
			}
			goto IL_0037;
			IL_0008:
			int num = 435473354;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x19F4CBCB)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					FtvSHSGXHWhaTEGyiFJERNPUtVF();
					num = 435473355;
					continue;
				case 0:
					goto IL_0037;
				case 3:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0037:
			_data.Add(new TypeWrapper(item));
			num = 435473352;
			goto IL_000d;
		}

		internal void AddData(TypeWrapper item)
		{
			if (!SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				FtvSHSGXHWhaTEGyiFJERNPUtVF();
			}
			_data.Add(item);
		}

		internal void ClearData()
		{
			if (SkFKXQgWYqSFJEyjlpatgIrLsWw)
			{
				_data.Clear();
			}
		}

		internal void ClearResult()
		{
			_resultIsValid = false;
			_result.Clear();
		}

		internal abstract bool Process();

		private void FtvSHSGXHWhaTEGyiFJERNPUtVF()
		{
			_data = new List<TypeWrapper>(3);
			SkFKXQgWYqSFJEyjlpatgIrLsWw = true;
		}
	}
}
