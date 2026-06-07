using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[CreateAssetMenu(fileName = "Global Variables", menuName = "Game Creator/Variables/List Variables")]
	public class GlobalListVariables : TGlobalVariables, IListVariable
	{
		[SerializeReference]
		private IndexList m_IndexList = new IndexList(ValueNumber.TYPE_ID, new IndexVariable(new ValueNumber(5f)));

		internal IndexList IndexList => m_IndexList;

		public IdString TypeID => m_IndexList.TypeID;

		public int Count => Singleton<GlobalListVariablesManager>.Instance.Count(this);

		public object Get(IListGetPick pick, Args args)
		{
			return Singleton<GlobalListVariablesManager>.Instance.Get(this, pick, args);
		}

		public object Get(IListSetPick pick, Args args)
		{
			return Singleton<GlobalListVariablesManager>.Instance.Get(this, pick, args);
		}

		public object Get(int index)
		{
			return Singleton<GlobalListVariablesManager>.Instance.Get(this, index);
		}

		public void Set(IListSetPick pick, object value, Args args)
		{
			Singleton<GlobalListVariablesManager>.Instance.Set(this, pick, value, args);
		}

		public void Set(int index, object value)
		{
			Singleton<GlobalListVariablesManager>.Instance.Set(this, index, value);
		}

		public void Insert(IListGetPick pick, object value, Args args)
		{
			Singleton<GlobalListVariablesManager>.Instance.Insert(this, pick, value, args);
		}

		public void Insert(int index, object value)
		{
			Singleton<GlobalListVariablesManager>.Instance.Insert(this, index, value);
		}

		public void Push(object value)
		{
			Singleton<GlobalListVariablesManager>.Instance.Push(this, value);
		}

		public void Remove(IListGetPick pick, Args args)
		{
			Singleton<GlobalListVariablesManager>.Instance.Remove(this, pick, args);
		}

		public void Remove(int index)
		{
			Singleton<GlobalListVariablesManager>.Instance.Remove(this, index);
		}

		public void Clear()
		{
			Singleton<GlobalListVariablesManager>.Instance.Clear(this);
		}

		public void Move(IListGetPick pickSource, IListGetPick pickDestination, Args args)
		{
			Singleton<GlobalListVariablesManager>.Instance.Move(this, pickSource, pickDestination, args);
		}

		public void Move(int source, int destination)
		{
			Singleton<GlobalListVariablesManager>.Instance.Move(this, source, destination);
		}

		public bool Contains(object value)
		{
			return Singleton<GlobalListVariablesManager>.Instance.Contains(this, value);
		}

		public void Register(Action<ListVariableRuntime.Change, int> callback)
		{
			if (!ApplicationManager.IsExiting)
			{
				Singleton<GlobalListVariablesManager>.Instance.Register(this, callback);
			}
		}

		public void Unregister(Action<ListVariableRuntime.Change, int> callback)
		{
			if (!ApplicationManager.IsExiting)
			{
				Singleton<GlobalListVariablesManager>.Instance.Unregister(this, callback);
			}
		}

		public string Title(int index)
		{
			return Singleton<GlobalListVariablesManager>.Instance.Title(this, index);
		}

		public Texture Icon(int index)
		{
			return Singleton<GlobalListVariablesManager>.Instance.Icon(this, index);
		}
	}
}
