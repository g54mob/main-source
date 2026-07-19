using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniJSON
{
	public struct ListTreeNode<T> : ITreeNode<ListTreeNode<T>, T> where T : IListTreeItem, IValue<T>
	{
		private List<T> m_Values;

		private int _valueIndex;

		public bool IsValid => m_Values != null;

		public int ValueIndex
		{
			get
			{
				if (m_Values == null)
				{
					return -1;
				}
				return _valueIndex;
			}
		}

		public ListTreeNode<T> Prev => new ListTreeNode<T>(m_Values, ValueIndex - 1);

		public T Value
		{
			get
			{
				if (m_Values == null)
				{
					return default(T);
				}
				return m_Values[ValueIndex];
			}
		}

		public int ChildCount => Value.ChildCount;

		public IEnumerable<ListTreeNode<T>> Children
		{
			get
			{
				int count = 0;
				int i = ValueIndex;
				while (count < ChildCount && i < m_Values.Count)
				{
					int num;
					if (m_Values[i].ParentIndex == ValueIndex)
					{
						num = count + 1;
						count = num;
						yield return new ListTreeNode<T>(m_Values, i);
					}
					num = i + 1;
					i = num;
				}
			}
		}

		public ListTreeNode<T> this[string key] => this[Utf8String.From(key)];

		public ListTreeNode<T> this[Utf8String key] => this.GetObjectItem(key);

		public ListTreeNode<T> this[int index] => this.GetArrayItem(index);

		public bool HasParent
		{
			get
			{
				if (Value.ParentIndex >= 0)
				{
					return Value.ParentIndex < m_Values.Count;
				}
				return false;
			}
		}

		public ListTreeNode<T> Parent
		{
			get
			{
				if (Value.ParentIndex < 0)
				{
					throw new Exception("no parent");
				}
				if (Value.ParentIndex >= m_Values.Count)
				{
					throw new IndexOutOfRangeException();
				}
				return new ListTreeNode<T>(m_Values, Value.ParentIndex);
			}
		}

		public override int GetHashCode()
		{
			return ((ValueType)this).GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ListTreeNode<T> self))
			{
				return false;
			}
			if (((Value.ValueType != ValueNodeType.Integer && Value.ValueType != ValueNodeType.Null) || (self.Value.ValueType != ValueNodeType.Integer && self.Value.ValueType != ValueNodeType.Number)) && Value.ValueType != self.Value.ValueType)
			{
				return false;
			}
			switch (Value.ValueType)
			{
			case ValueNodeType.Null:
				return true;
			case ValueNodeType.Boolean:
				return Value.GetBoolean() == self.GetBoolean();
			case ValueNodeType.Integer:
			case ValueNodeType.Number:
				return Value.GetDouble() == self.GetDouble();
			case ValueNodeType.String:
				return Value.GetString() == self.GetString();
			case ValueNodeType.Array:
				return this.ArrayItems().SequenceEqual(self.ArrayItems());
			case ValueNodeType.Object:
				return (from x in this.ObjectItems()
					orderby x.Key.GetUtf8String()
					select x).SequenceEqual(from x in self.ObjectItems()
					orderby x.Key.GetUtf8String()
					select x);
			default:
				return false;
			}
		}

		public override string ToString()
		{
			if (this.IsArray())
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("[");
				stringBuilder.Append("]");
				return stringBuilder.ToString();
			}
			if (this.IsMap())
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.Append("{");
				stringBuilder2.Append("}");
				return stringBuilder2.ToString();
			}
			return Value.ToString();
		}

		private IEnumerable<string> ToString(string indent, int level, bool value = false)
		{
			if (this.IsArray())
			{
				int i;
				if (!value)
				{
					i = 0;
					while (i < level)
					{
						yield return indent;
						int num = i + 1;
						i = num;
					}
				}
				yield return "[\n";
				bool isFirst = true;
				int childLevel = level + 1;
				foreach (ListTreeNode<T> x in this.ArrayItems())
				{
					if (isFirst)
					{
						isFirst = false;
					}
					else
					{
						yield return ",\n";
					}
					foreach (string item in x.ToString(indent, childLevel))
					{
						yield return item;
					}
				}
				if (!isFirst)
				{
					yield return "\n";
				}
				i = 0;
				while (i < level)
				{
					yield return indent;
					int num = i + 1;
					i = num;
				}
				yield return "]";
				yield break;
			}
			if (this.IsMap())
			{
				int i;
				if (!value)
				{
					i = 0;
					while (i < level)
					{
						yield return indent;
						int num = i + 1;
						i = num;
					}
				}
				yield return "{\n";
				bool isFirst = true;
				int childLevel = level + 1;
				foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> kv in from keyValuePair in this.ObjectItems()
					orderby keyValuePair.Key.ToString()
					select keyValuePair)
				{
					if (isFirst)
					{
						isFirst = false;
					}
					else
					{
						yield return ",\n";
					}
					i = 0;
					while (i < childLevel)
					{
						yield return indent;
						int num = i + 1;
						i = num;
					}
					yield return kv.Key.ToString();
					yield return ": ";
					foreach (string item2 in kv.Value.ToString(indent, childLevel, value: true))
					{
						yield return item2;
					}
				}
				if (!isFirst)
				{
					yield return "\n";
				}
				i = 0;
				while (i < level)
				{
					yield return indent;
					int num = i + 1;
					i = num;
				}
				yield return "}";
				yield break;
			}
			if (!value)
			{
				int childLevel = 0;
				while (childLevel < level)
				{
					yield return indent;
					int num = childLevel + 1;
					childLevel = num;
				}
			}
			yield return Value.ToString();
		}

		public string ToString(string indent)
		{
			return string.Join("", ToString(indent, 0).ToArray());
		}

		public IEnumerable<JsonDiff> Diff(ListTreeNode<T> rhs, JsonPointer path = default(JsonPointer))
		{
			ValueNodeType valueType = Value.ValueType;
			if ((uint)valueType <= 2u || (uint)(valueType - 4) <= 1u)
			{
				if (!Equals(rhs))
				{
					yield return JsonDiff.Create(this, JsonDiffType.ValueChanged, $"{Value} => {rhs.Value}");
				}
				yield break;
			}
			if (Value.ValueType != rhs.Value.ValueType)
			{
				yield return JsonDiff.Create(this, JsonDiffType.ValueChanged, $"{Value.ValueType} => {rhs.Value}");
				yield break;
			}
			if (Value.ValueType == ValueNodeType.Object)
			{
				Dictionary<ListTreeNode<T>, ListTreeNode<T>> dictionary = this.ObjectItems().ToDictionary((KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> x) => x.Key, (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> x) => x.Value);
				Dictionary<ListTreeNode<T>, ListTreeNode<T>> r = rhs.ObjectItems().ToDictionary((KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> x) => x.Key, (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> x) => x.Value);
				foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> item in dictionary)
				{
					if (r.TryGetValue(item.Key, out var value))
					{
						r.Remove(item.Key);
						foreach (JsonDiff item2 in item.Value.Diff(value))
						{
							yield return item2;
						}
					}
					else
					{
						yield return JsonDiff.Create(item.Value, JsonDiffType.KeyRemoved, item.Value.Value.ToString());
					}
				}
				foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> item3 in r)
				{
					yield return JsonDiff.Create(item3.Value, JsonDiffType.KeyAdded, item3.Value.Value.ToString());
				}
				yield break;
			}
			if (Value.ValueType == ValueNodeType.Array)
			{
				IEnumerator<ListTreeNode<T>> ll = this.ArrayItems().GetEnumerator();
				IEnumerator<ListTreeNode<T>> rr = rhs.ArrayItems().GetEnumerator();
				while (true)
				{
					bool flag = ll.MoveNext();
					bool flag2 = rr.MoveNext();
					if (flag && flag2)
					{
						foreach (JsonDiff item4 in ll.Current.Diff(rr.Current))
						{
							yield return item4;
						}
						continue;
					}
					if (flag)
					{
						yield return JsonDiff.Create(ll.Current, JsonDiffType.KeyRemoved, ll.Current.Value.ToString());
						continue;
					}
					if (flag2)
					{
						yield return JsonDiff.Create(rr.Current, JsonDiffType.KeyAdded, rr.Current.Value.ToString());
						continue;
					}
					break;
				}
				yield break;
			}
			throw new NotImplementedException();
		}

		public void SetValue(T value)
		{
			m_Values[ValueIndex] = value;
		}

		public ListTreeNode(List<T> values, int index = 0)
		{
			this = default(ListTreeNode<T>);
			m_Values = values;
			_valueIndex = index;
		}

		public ListTreeNode<T> AddKey(Utf8String key)
		{
			return AddValue(default(T).Key(key, ValueIndex));
		}

		public ListTreeNode<T> AddValue(ArraySegment<byte> bytes, ValueNodeType valueType)
		{
			return AddValue(default(T).New(bytes, valueType, ValueIndex));
		}

		public ListTreeNode<T> AddValue(T value)
		{
			if (m_Values == null)
			{
				m_Values = new List<T>();
				_valueIndex = -1;
			}
			else
			{
				IncrementChildCount();
			}
			int count = m_Values.Count;
			m_Values.Add(value);
			return new ListTreeNode<T>(m_Values, count);
		}

		private void IncrementChildCount()
		{
			T value = Value;
			int childCount = value.ChildCount + 1;
			value.SetChildCount(childCount);
			SetValue(value);
		}

		public void SetValueBytesCount(int count)
		{
			T value = Value;
			value.SetBytesCount(count);
			SetValue(value);
		}
	}
}
