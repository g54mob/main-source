using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public abstract class TDetectorListVariable<T> where T : IListVariable
	{
		private enum Detection
		{
			AnyChange = -2,
			SetIndex = -1,
			SetAny = 1,
			Insert = 16,
			Remove = 256,
			Move = 4096
		}

		[SerializeField]
		private T m_Variable;

		[SerializeField]
		private Detection m_When = Detection.AnyChange;

		[SerializeReference]
		private TListGetPick m_Index = new GetPickFirst();

		[NonSerialized]
		private Args m_Args;

		private int ListenersCount
		{
			get
			{
				Action action = this.EventOnChange;
				if (action == null)
				{
					return 0;
				}
				return action.GetInvocationList().Length;
			}
		}

		protected event Action EventOnChange;

		public void StartListening(Action callback, Args args)
		{
			m_Args = args;
			if (m_Variable != null)
			{
				if (ListenersCount == 0)
				{
					ref T variable = ref m_Variable;
					Action<ListVariableRuntime.Change, int> callback2 = OnChange;
					variable.Register(callback2);
				}
				EventOnChange += callback;
			}
		}

		public void StopListening(Action callback, Args args)
		{
			m_Args = args;
			if (m_Variable != null)
			{
				if (ListenersCount == 1)
				{
					ref T variable = ref m_Variable;
					Action<ListVariableRuntime.Change, int> callback2 = OnChange;
					variable.Unregister(callback2);
				}
				EventOnChange -= callback;
			}
		}

		protected void OnChange(ListVariableRuntime.Change change, int index)
		{
			if (m_Variable == null)
			{
				return;
			}
			int count = m_Variable.Count;
			switch (m_When)
			{
			case Detection.AnyChange:
				this.EventOnChange?.Invoke();
				break;
			case Detection.SetIndex:
				if (change == ListVariableRuntime.Change.Set && index == m_Index.GetIndex(count, m_Args))
				{
					this.EventOnChange?.Invoke();
				}
				break;
			case Detection.SetAny:
				if (change == ListVariableRuntime.Change.Set)
				{
					this.EventOnChange?.Invoke();
				}
				break;
			case Detection.Insert:
				if (change == ListVariableRuntime.Change.Insert)
				{
					this.EventOnChange?.Invoke();
				}
				break;
			case Detection.Remove:
				if (change == ListVariableRuntime.Change.Remove)
				{
					this.EventOnChange?.Invoke();
				}
				break;
			case Detection.Move:
				if (change == ListVariableRuntime.Change.Move)
				{
					this.EventOnChange?.Invoke();
				}
				break;
			}
		}
	}
}
