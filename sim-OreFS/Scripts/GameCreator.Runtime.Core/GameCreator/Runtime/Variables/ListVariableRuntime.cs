using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class ListVariableRuntime : TVariableRuntime<IndexVariable>
	{
		public enum Change
		{
			Set = 1,
			Insert = 0x10,
			Remove = 0x100,
			Move = 0x1000
		}

		[SerializeReference]
		private IndexList m_List = new IndexList();

		internal List<IndexVariable> Variables { get; private set; }

		public IdString TypeID => m_List.TypeID;

		public int Count => Variables.Count;

		public event Action<Change, int> EventChange;

		public ListVariableRuntime()
		{
			Variables = new List<IndexVariable>();
		}

		public ListVariableRuntime(IndexList indexList)
			: this()
		{
			m_List = indexList;
		}

		public ListVariableRuntime(IdString typeID, params IndexVariable[] indexList)
			: this()
		{
			m_List = new IndexList(typeID, indexList);
		}

		public override void OnStartup()
		{
			Variables = new List<IndexVariable>();
			for (int i = 0; i < m_List.Length; i++)
			{
				IndexVariable indexVariable = m_List.Get(i);
				if (indexVariable != null)
				{
					Variables.Add(indexVariable.Copy as IndexVariable);
				}
			}
		}

		public object Get(int index)
		{
			if (index < 0)
			{
				return null;
			}
			if (index >= Count)
			{
				return null;
			}
			return Variables[index]?.Value;
		}

		public void Set(int index, object value)
		{
			index = Mathf.Clamp(index, 0, Count);
			if (index < Count)
			{
				Variables[index].Value = value;
				this.EventChange?.Invoke(Change.Set, index);
			}
		}

		public void Insert(int index, object value)
		{
			index = Mathf.Clamp(index, 0, Count);
			TValue value2 = TValue.CreateValue(TypeID, value);
			Variables.Insert(index, new IndexVariable(value2));
			this.EventChange?.Invoke(Change.Insert, index);
		}

		public void Push(object value)
		{
			TValue value2 = TValue.CreateValue(TypeID, value);
			Variables.Add(new IndexVariable(value2));
			this.EventChange?.Invoke(Change.Insert, Count - 1);
		}

		public void Remove(int index)
		{
			index = Mathf.Clamp(index, 0, Count);
			if (index < Count)
			{
				Variables.RemoveAt(index);
				this.EventChange?.Invoke(Change.Remove, index);
			}
		}

		public void Move(int source, int destination)
		{
			source = Mathf.Clamp(source, 0, Count);
			destination = Mathf.Clamp(destination, 0, Count);
			if (source < Count && destination < Count)
			{
				IndexVariable item = Variables[source];
				Variables.RemoveAt(source);
				Variables.Insert(destination, item);
				this.EventChange?.Invoke(Change.Move, destination);
			}
		}

		public string Title(int index)
		{
			if (index < 0)
			{
				return null;
			}
			if (index >= Count)
			{
				return string.Empty;
			}
			return Variables[index]?.Title;
		}

		public Texture Icon(int index)
		{
			if (index < 0)
			{
				return null;
			}
			if (index >= Count)
			{
				return null;
			}
			return Variables[index]?.Icon;
		}

		public override IEnumerator<IndexVariable> GetEnumerator()
		{
			return Variables.GetEnumerator();
		}
	}
}
