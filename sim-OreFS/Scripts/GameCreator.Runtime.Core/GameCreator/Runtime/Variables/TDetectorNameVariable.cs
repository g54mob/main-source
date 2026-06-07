using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public abstract class TDetectorNameVariable<T> where T : INameVariable
	{
		private enum Detection
		{
			Any = 0,
			Name = 1
		}

		[SerializeField]
		private T m_Variable;

		[SerializeField]
		private Detection m_When;

		[SerializeField]
		private IdPathString m_Name;

		private int ListenersCount
		{
			get
			{
				Action<string> action = this.EventOnChange;
				if (action == null)
				{
					return 0;
				}
				return action.GetInvocationList().Length;
			}
		}

		protected event Action<string> EventOnChange;

		public void StartListening(Action<string> callback)
		{
			if (m_Variable != null)
			{
				if (ListenersCount == 0)
				{
					ref T variable = ref m_Variable;
					Action<string> callback2 = OnChange;
					variable.Register(callback2);
				}
				EventOnChange += callback;
			}
		}

		public void StopListening(Action<string> callback)
		{
			if (m_Variable != null)
			{
				if (ListenersCount == 1)
				{
					ref T variable = ref m_Variable;
					Action<string> callback2 = OnChange;
					variable.Unregister(callback2);
				}
				EventOnChange -= callback;
			}
		}

		protected void OnChange(string name)
		{
			if (m_When != Detection.Name || !(m_Name.String.Split('/')[^1] != name))
			{
				this.EventOnChange?.Invoke(name);
			}
		}
	}
}
