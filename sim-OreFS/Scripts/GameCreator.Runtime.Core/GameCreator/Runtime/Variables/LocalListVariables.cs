using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[HelpURL("https://docs.gamecreator.io/gamecreator/variables/local-list-variables")]
	[AddComponentMenu("Game Creator/Variables/Local List Variables")]
	[DisallowMultipleComponent]
	public class LocalListVariables : TLocalVariables, IListVariable
	{
		[SerializeReference]
		private ListVariableRuntime m_Runtime = new ListVariableRuntime();

		public int Count => m_Runtime.Count;

		public IdString TypeID => m_Runtime.TypeID;

		public override Type SaveType => typeof(SaveSingleListVariables);

		public event Action<ListVariableRuntime.Change, int> EventChange;

		protected override void Awake()
		{
			m_Runtime.OnStartup();
			m_Runtime.EventChange += OnRuntimeChange;
			base.Awake();
		}

		public static LocalListVariables Create(GameObject target, ListVariableRuntime variables)
		{
			LocalListVariables localListVariables = target.Add<LocalListVariables>();
			localListVariables.m_Runtime = variables;
			localListVariables.m_Runtime.OnStartup();
			localListVariables.m_Runtime.EventChange += localListVariables.OnRuntimeChange;
			return localListVariables;
		}

		public object Get(IListGetPick pick, Args args)
		{
			int index = pick?.GetIndex(Count, args) ?? (-1);
			return Get(index);
		}

		public object Get(IListSetPick pick, Args args)
		{
			int index = pick?.GetIndex(Count, args) ?? (-1);
			return Get(index);
		}

		public object Get(int index)
		{
			return m_Runtime.Get(index);
		}

		public void Set(IListSetPick pick, object value, Args args)
		{
			int index = pick?.GetIndex(m_Runtime, Count, args) ?? 0;
			Set(index, value);
		}

		public void Set(int index, object value)
		{
			m_Runtime.Set(index, value);
		}

		public void Insert(IListGetPick pick, object value, Args args)
		{
			int index = pick?.GetIndex(Count, args) ?? 0;
			Insert(index, value);
		}

		public void Insert(int index, object value)
		{
			m_Runtime.Insert(index, value);
		}

		public void Push(object value)
		{
			m_Runtime.Push(value);
		}

		public void Remove(IListGetPick pick, Args args)
		{
			int index = pick?.GetIndex(Count, args) ?? 0;
			Remove(index);
		}

		public void Remove(int index)
		{
			m_Runtime.Remove(index);
		}

		public void Clear()
		{
			for (int num = Count - 1; num >= 0; num--)
			{
				Remove(num);
			}
		}

		public void Move(IListGetPick pickA, IListGetPick pickB, Args args)
		{
			int source = pickA?.GetIndex(Count, args) ?? 0;
			int destination = pickB?.GetIndex(Count, args) ?? 0;
			Move(source, destination);
		}

		public void Move(int source, int destination)
		{
			m_Runtime.Move(source, destination);
		}

		public void Register(Action<ListVariableRuntime.Change, int> callback)
		{
			EventChange += callback;
		}

		public void Unregister(Action<ListVariableRuntime.Change, int> callback)
		{
			EventChange -= callback;
		}

		public bool Contains(object value)
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				object obj = m_Runtime.Get(i);
				if (obj != null && obj == value)
				{
					return true;
				}
			}
			return false;
		}

		private void OnRuntimeChange(ListVariableRuntime.Change change, int index)
		{
			this.EventChange?.Invoke(change, index);
		}

		public override object GetSaveData(bool includeNonSavable)
		{
			if (!m_SaveUniqueID.SaveValue)
			{
				return null;
			}
			return new SaveSingleListVariables(m_Runtime);
		}

		public override Task OnLoad(object value)
		{
			SaveSingleListVariables saveSingleListVariables = value as SaveSingleListVariables;
			if (saveSingleListVariables != null && m_SaveUniqueID.SaveValue)
			{
				IndexVariable[] indexList = saveSingleListVariables.Variables.ToArray();
				m_Runtime = new ListVariableRuntime(saveSingleListVariables.TypeID, indexList);
			}
			m_Runtime.OnStartup();
			return Task.FromResult(saveSingleListVariables != null || !m_SaveUniqueID.SaveValue);
		}
	}
}
