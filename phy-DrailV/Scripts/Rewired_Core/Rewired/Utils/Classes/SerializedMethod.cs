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
		private const int kHKaXYLNlNAcAEUpKddXIRwaPrVSb = 3;

		[NonSerialized]
		private bool ZGWCOcJkXxmayGmPZykHwhlsJbZyA;

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
			if (index < 0 || index >= DataCount)
			{
				throw new IndexOutOfRangeException();
			}
			return _data[index];
		}

		internal void AddData(byte item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(sbyte item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(char item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(int item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(uint item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(long item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(ulong item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(float item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(double item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(bool item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(string item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(object item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(new TypeWrapper(item));
		}

		internal void AddData(TypeWrapper item)
		{
			if (!ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
			{
				AcoLGaQWQFGGyqMtMZueOTbpitee();
			}
			_data.Add(item);
		}

		internal void ClearData()
		{
			if (ZGWCOcJkXxmayGmPZykHwhlsJbZyA)
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

		private void AcoLGaQWQFGGyqMtMZueOTbpitee()
		{
			_data = new List<TypeWrapper>(3);
			ZGWCOcJkXxmayGmPZykHwhlsJbZyA = true;
		}
	}
}
