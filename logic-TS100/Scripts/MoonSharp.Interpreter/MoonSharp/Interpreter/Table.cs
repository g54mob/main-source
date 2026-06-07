using System.Collections.Generic;
using System.Linq;
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

		private int m_CachedLength = -1;

		public Script OwnerScript
		{
			get
			{
				return m_Owner;
			}
		}

		public object this[object key, params object[] subkeys]
		{
			get
			{
				Table table = ResolveMultipleKeys(ref key, subkeys);
				return table.GetAsObject(key);
			}
			set
			{
				Table table = ResolveMultipleKeys(ref key, subkeys);
				table.SetAsObject(key, value);
			}
		}

		public object this[object key]
		{
			get
			{
				return GetAsObject(key);
			}
			set
			{
				SetAsObject(key, value);
			}
		}

		public int Length
		{
			get
			{
				if (m_CachedLength < 0)
				{
					m_CachedLength = 0;
					for (int i = 1; m_ArrayMap.ContainsKey(i) && !m_ArrayMap.Find(i).Value.Value.IsNil(); i++)
					{
						m_CachedLength = i;
					}
				}
				return m_CachedLength;
			}
		}

		public Table MetaTable { get; set; }

		public IEnumerable<TablePair> Pairs
		{
			get
			{
				return m_Values.Select((TablePair n) => new TablePair(n.Key, n.Value));
			}
		}

		public IEnumerable<DynValue> Keys
		{
			get
			{
				return m_Values.Select((TablePair n) => n.Key);
			}
		}

		public IEnumerable<DynValue> Values
		{
			get
			{
				return m_Values.Select((TablePair n) => n.Value);
			}
		}

		public Table(Script owner)
		{
			m_Values = new LinkedList<TablePair>();
			m_StringMap = new LinkedListIndex<string, TablePair>(m_Values);
			m_ArrayMap = new LinkedListIndex<int, TablePair>(m_Values);
			m_ValueMap = new LinkedListIndex<DynValue, TablePair>(m_Values);
			m_Owner = owner;
		}

		public void Clear()
		{
			m_Values.Clear();
			m_StringMap.Clear();
			m_ArrayMap.Clear();
			m_ValueMap.Clear();
		}

		private int GetIntegralKey(double d)
		{
			int num = (int)d;
			if (d >= 1.0 && d == (double)num)
			{
				return num;
			}
			return -1;
		}

		private Table ResolveMultipleKeys(ref object key, object[] subkeys)
		{
			if (subkeys.Length == 0)
			{
				return this;
			}
			Table table = this;
			int num = -1;
			do
			{
				DynValue withObjectKey = table.GetWithObjectKey(key);
				if (withObjectKey.Type != DataType.Table)
				{
					throw new ScriptRuntimeException("Key '{0}' did not point to a table");
				}
				table = withObjectKey.Table;
				key = subkeys[++num];
			}
			while (num < subkeys.Length - 1);
			return table;
		}

		public DynValue GetWithObjectKey(object key)
		{
			if (key is string)
			{
				return Get((string)key);
			}
			if (key is int)
			{
				return Get((int)key);
			}
			DynValue key2 = DynValue.FromObject(OwnerScript, key);
			return Get(key2);
		}

		public object GetAsObject(object key)
		{
			if (key is string)
			{
				return Get((string)key).ToObject();
			}
			if (key is int)
			{
				return Get((int)key).ToObject();
			}
			DynValue key2 = DynValue.FromObject(OwnerScript, key);
			return Get(key2).ToObject();
		}

		public void SetAsObject(object key, object value)
		{
			DynValue value2 = DynValue.FromObject(OwnerScript, value);
			if (key is string)
			{
				Set((string)key, value2);
			}
			else if (key is int)
			{
				Set((int)key, value2);
			}
			else
			{
				Set(DynValue.FromObject(OwnerScript, key), value2);
			}
		}

		public void Set(DynValue key, DynValue value)
		{
			if (key.IsNilOrNan())
			{
				if (key.IsNil())
				{
					throw ScriptRuntimeException.TableIndexIsNil();
				}
				throw ScriptRuntimeException.TableIndexIsNaN();
			}
			if (key.Type == DataType.String)
			{
				Set(key.String, value);
				return;
			}
			if (key.Type == DataType.Number)
			{
				int integralKey = GetIntegralKey(key.Number);
				if (integralKey > 0)
				{
					Set(integralKey, value);
					return;
				}
			}
			CheckValueOwner(key);
			CheckValueOwner(value);
			PerformTableSet(m_ValueMap, key, key, value, false);
		}

		private void PerformTableSet<T>(LinkedListIndex<T, TablePair> listIndex, T key, DynValue keyDynValue, DynValue value, bool isNumber)
		{
			TablePair tablePair = listIndex.Set(key, new TablePair(keyDynValue, value));
			if (tablePair.Value == null || tablePair.Value.IsNil())
			{
				CollectDeadKeys();
				if (isNumber)
				{
					m_CachedLength = -1;
				}
			}
			if (isNumber && value.IsNil())
			{
				m_CachedLength = -1;
			}
		}

		public DynValue Get(DynValue key)
		{
			if (key.Type == DataType.Number)
			{
				int integralKey = GetIntegralKey(key.Number);
				if (integralKey > 0)
				{
					return GetValueOrNil(m_ArrayMap.Find(integralKey));
				}
			}
			else if (key.Type == DataType.String)
			{
				return GetValueOrNil(m_StringMap.Find(key.String));
			}
			return GetValueOrNil(m_ValueMap.Find(key));
		}

		private DynValue GetValueOrNil(LinkedListNode<TablePair> linkedListNode)
		{
			if (linkedListNode != null)
			{
				return linkedListNode.Value.Value;
			}
			return DynValue.Nil;
		}

		public void Set(string key, DynValue value)
		{
			CheckValueOwner(value);
			PerformTableSet(m_StringMap, key, DynValue.NewString(key), value, false);
		}

		public DynValue Get(string key)
		{
			return GetValueOrNil(m_StringMap.Find(key));
		}

		public DynValue RawGet(string key)
		{
			LinkedListNode<TablePair> linkedListNode = m_StringMap.Find(key);
			if (linkedListNode != null)
			{
				return linkedListNode.Value.Value;
			}
			return null;
		}

		public void Set(int key, DynValue value)
		{
			CheckValueOwner(value);
			PerformTableSet(m_ArrayMap, key, DynValue.NewNumber(key), value, true);
		}

		public DynValue Get(int key)
		{
			return GetValueOrNil(m_ArrayMap.Find(key));
		}

		private void CheckValueOwner(DynValue value)
		{
		}

		public void CollectDeadKeys()
		{
			for (LinkedListNode<TablePair> linkedListNode = m_Values.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (!linkedListNode.Value.Value.IsNil())
				{
					continue;
				}
				if (linkedListNode.Value.Key.Type == DataType.Number)
				{
					int integralKey = GetIntegralKey(linkedListNode.Value.Key.Number);
					if (integralKey > 0)
					{
						m_ArrayMap.Remove(integralKey);
						continue;
					}
				}
				if (linkedListNode.Value.Key.Type == DataType.String)
				{
					m_StringMap.Remove(linkedListNode.Value.Key.String);
				}
				else
				{
					m_ValueMap.Remove(linkedListNode.Value.Key);
				}
			}
		}

		public TablePair? NextKey(DynValue v)
		{
			if (v.IsNil())
			{
				LinkedListNode<TablePair> first = m_Values.First;
				if (first == null)
				{
					return TablePair.Nil;
				}
				if (first.Value.Value.IsNil())
				{
					return NextKey(first.Value.Key);
				}
				return first.Value;
			}
			if (v.Type == DataType.String)
			{
				return GetNextOf(m_StringMap.Find(v.String));
			}
			if (v.Type == DataType.Number)
			{
				int integralKey = GetIntegralKey(v.Number);
				if (integralKey > 0)
				{
					return GetNextOf(m_ArrayMap.Find(integralKey));
				}
			}
			return GetNextOf(m_ValueMap.Find(v));
		}

		private TablePair? GetNextOf(LinkedListNode<TablePair> linkedListNode)
		{
			do
			{
				if (linkedListNode == null)
				{
					return null;
				}
				if (linkedListNode.Next == null)
				{
					return TablePair.Nil;
				}
				linkedListNode = linkedListNode.Next;
			}
			while (linkedListNode.Value.Value.IsNil());
			return linkedListNode.Value;
		}

		internal void InitNextArrayKeys(DynValue val, bool lastpos)
		{
			if (val.Type == DataType.Tuple && lastpos)
			{
				DynValue[] tuple = val.Tuple;
				foreach (DynValue val2 in tuple)
				{
					InitNextArrayKeys(val2, true);
				}
			}
			else
			{
				Set(++m_InitArray, val.ToScalar());
			}
		}
	}
}
