using System.Collections.Generic;
using MoonSharp.Interpreter.DataStructs;

namespace MoonSharp.Interpreter
{
	public class Table : RefIdObject, IScriptPrivateResource
	{
		private readonly LinkedList<TablePair> m_Values;

		private readonly LinkedListIndex<DynValue, TablePair> m_ValueMap;

		private readonly LinkedListIndex<string, TablePair> m_StringMap;

		private readonly LinkedListIndex<int, TablePair> m_ArrayMap;

		private readonly Script m_Owner;

		private int m_InitArray;

		private int m_CachedLength;

		private bool m_ContainsNilEntries;

		private Table m_MetaTable;

		public Script OwnerScript => null;

		public object this[params object[] keys]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Length => 0;

		public Table MetaTable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IEnumerable<TablePair> Pairs => null;

		public IEnumerable<DynValue> Keys => null;

		public IEnumerable<DynValue> Values => null;

		public Table(Script owner)
		{
		}

		public Table(Script owner, params DynValue[] arrayValues)
		{
		}

		public void Clear()
		{
		}

		private int GetIntegralKey(double d)
		{
			return 0;
		}

		private Table ResolveMultipleKeys(object[] keys, out object key)
		{
			key = null;
			return null;
		}

		public void Append(DynValue value)
		{
		}

		private void PerformTableSet<T>(LinkedListIndex<T, TablePair> listIndex, T key, DynValue keyDynValue, DynValue value, bool isNumber, int appendKey)
		{
		}

		public void Set(string key, DynValue value)
		{
		}

		public void Set(int key, DynValue value)
		{
		}

		public void Set(DynValue key, DynValue value)
		{
		}

		public void Set(object key, DynValue value)
		{
		}

		public void Set(object[] keys, DynValue value)
		{
		}

		public DynValue Get(string key)
		{
			return null;
		}

		public DynValue Get(int key)
		{
			return null;
		}

		public DynValue Get(DynValue key)
		{
			return null;
		}

		public DynValue Get(object key)
		{
			return null;
		}

		public DynValue Get(params object[] keys)
		{
			return null;
		}

		private static DynValue RawGetValue(LinkedListNode<TablePair> linkedListNode)
		{
			return null;
		}

		public DynValue RawGet(string key)
		{
			return null;
		}

		public DynValue RawGet(int key)
		{
			return null;
		}

		public DynValue RawGet(DynValue key)
		{
			return null;
		}

		public DynValue RawGet(object key)
		{
			return null;
		}

		public DynValue RawGet(params object[] keys)
		{
			return null;
		}

		private bool PerformTableRemove<T>(LinkedListIndex<T, TablePair> listIndex, T key, bool isNumber)
		{
			return false;
		}

		public bool Remove(string key)
		{
			return false;
		}

		public bool Remove(int key)
		{
			return false;
		}

		public bool Remove(DynValue key)
		{
			return false;
		}

		public bool Remove(object key)
		{
			return false;
		}

		public bool Remove(params object[] keys)
		{
			return false;
		}

		public void CollectDeadKeys()
		{
		}

		public TablePair? NextKey(DynValue v)
		{
			return null;
		}

		private TablePair? GetNextOf(LinkedListNode<TablePair> linkedListNode)
		{
			return null;
		}

		internal void InitNextArrayKeys(DynValue val, bool lastpos)
		{
		}
	}
}
