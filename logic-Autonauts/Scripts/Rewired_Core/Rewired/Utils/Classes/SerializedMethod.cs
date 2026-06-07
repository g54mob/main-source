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
		private const int QVBfSztTJSSGuXDabhKaApEpJDD = 3;

		[NonSerialized]
		private bool jlBqbDMyvoEuWpREyJJuwAXCFvJ;

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
					switch (-1103959792 ^ -1103959791)
					{
					case 0:
						break;
					case 1:
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
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(sbyte item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(char item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(int item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(uint item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(long item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
				goto IL_000e;
			}
			goto IL_002c;
			IL_002c:
			_data.Add(new TypeWrapper(item));
			int num = 1147613181;
			goto IL_0013;
			IL_000e:
			num = 1147613180;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x44672FFD)
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

		internal void AddData(ulong item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(float item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(double item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(bool item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
				goto IL_000e;
			}
			goto IL_002c;
			IL_002c:
			_data.Add(new TypeWrapper(item));
			int num = 1775452470;
			goto IL_0013;
			IL_000e:
			num = 1775452469;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x69D34137)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_002c;
			case 1:
				return;
			}
			goto IL_000e;
		}

		internal void AddData(string item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(object item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				cxjlfJimkGTcYfUTrImNNUtHcSg();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(TypeWrapper item)
		{
			if (!jlBqbDMyvoEuWpREyJJuwAXCFvJ)
			{
				goto IL_0008;
			}
			goto IL_0037;
			IL_0008:
			int num = -823682063;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -823682061)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					cxjlfJimkGTcYfUTrImNNUtHcSg();
					num = -823682064;
					continue;
				case 3:
					goto IL_0037;
				case 1:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0037:
			_data.Add(item);
			num = -823682062;
			goto IL_000d;
		}

		internal void ClearData()
		{
			if (jlBqbDMyvoEuWpREyJJuwAXCFvJ)
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

		private void cxjlfJimkGTcYfUTrImNNUtHcSg()
		{
			_data = new List<TypeWrapper>(3);
			jlBqbDMyvoEuWpREyJJuwAXCFvJ = true;
		}
	}
}
