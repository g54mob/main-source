using System;
using System.Reflection;

namespace RoslynCSharp
{
	public class ScriptEventHandler
	{
		private EventInfo eventInfo;

		private object instance;

		private MethodInfo addHandler;

		private MethodInfo removeHandler;

		public ScriptEventHandler(EventInfo eventInfo, object instance)
		{
			this.eventInfo = eventInfo;
			this.instance = instance;
		}

		public virtual void AddListener(Delegate methodDelegate)
		{
			if (addHandler == null)
			{
				addHandler = eventInfo.GetAddMethod(nonPublic: true);
			}
			addHandler.Invoke(instance, new object[1] { methodDelegate });
		}

		public void AddListener(Action methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T>(Action<T> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T0, T1>(Action<T0, T1> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T0, T1, T2>(Action<T0, T1, T2> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T0, T1, T2, T3>(Action<T0, T1, T2, T3> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<TR>(Func<TR> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T0, TR>(Func<T0, TR> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T0, T1, TR>(Func<T0, T1, TR> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T0, T1, T2, TR>(Func<T0, T1, T2, TR> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public void AddListener<T0, T1, T2, T3, TR>(Func<T0, T1, T2, T3, TR> methodDelegate)
		{
			AddListener((Delegate)methodDelegate);
		}

		public virtual void RemoveListener(Delegate methodDelegate)
		{
			if (removeHandler == null)
			{
				removeHandler = eventInfo.GetRemoveMethod(nonPublic: true);
			}
			removeHandler.Invoke(instance, new object[1] { methodDelegate });
		}

		public void RemoveListener(Action methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T>(Action<T> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T0, T1>(Action<T0, T1> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T0, T1, T2>(Action<T0, T1, T2> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T0, T1, T2, T3>(Action<T0, T1, T2, T3> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<TR>(Func<TR> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T0, TR>(Func<T0, TR> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T0, T1, TR>(Func<T0, T1, TR> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T0, T1, T2, TR>(Func<T0, T1, T2, TR> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}

		public void RemoveListener<T0, T1, T2, T3, TR>(Func<T0, T1, T2, T3, TR> methodDelegate)
		{
			RemoveListener((Delegate)methodDelegate);
		}
	}
}
