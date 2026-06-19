using System;
using System.Collections.Generic;

namespace RoslynCSharp
{
	public sealed class ScriptExecution
	{
		private HashSet<ScriptProxy> behaviourProxies = new HashSet<ScriptProxy>();

		private HashSet<ScriptProxy> instanceProxies = new HashSet<ScriptProxy>();

		private Stack<ScriptProxy> deadInstances = new Stack<ScriptProxy>();

		public IEnumerable<ScriptProxy> Proxies
		{
			get
			{
				RemoveDeadInstances();
				foreach (ScriptProxy behaviourProxy in behaviourProxies)
				{
					yield return behaviourProxy;
				}
				foreach (ScriptProxy instanceProxy in instanceProxies)
				{
					yield return instanceProxy;
				}
			}
		}

		public IReadOnlyCollection<ScriptProxy> BehaviourProxies
		{
			get
			{
				RemoveDeadInstances();
				return behaviourProxies;
			}
		}

		public IReadOnlyCollection<ScriptProxy> InstanceProxies
		{
			get
			{
				RemoveDeadInstances();
				return instanceProxies;
			}
		}

		public void AddScriptProxy(ScriptProxy proxy)
		{
			if (proxy == null)
			{
				throw new ArgumentNullException("proxy");
			}
			if (!proxy.IsDisposed)
			{
				if (proxy.IsMonoBehaviour)
				{
					behaviourProxies.Add(proxy);
				}
				else if (!proxy.IsUnityObject)
				{
					instanceProxies.Add(proxy);
				}
			}
		}

		public void Terminate()
		{
			foreach (ScriptProxy proxy in Proxies)
			{
				if (!proxy.IsDisposed)
				{
					proxy.Dispose();
				}
			}
			behaviourProxies.Clear();
			instanceProxies.Clear();
		}

		private void RemoveDeadInstances()
		{
			foreach (ScriptProxy behaviourProxy in behaviourProxies)
			{
				if (behaviourProxy.IsDisposed || behaviourProxy.MonoBehaviourInstance == null)
				{
					deadInstances.Push(behaviourProxy);
				}
			}
			while (deadInstances.Count > 0)
			{
				behaviourProxies.Remove(deadInstances.Pop());
			}
			foreach (ScriptProxy instanceProxy in instanceProxies)
			{
				if (instanceProxy.IsDisposed)
				{
					deadInstances.Push(instanceProxy);
				}
			}
			while (deadInstances.Count > 0)
			{
				instanceProxies.Remove(deadInstances.Pop());
			}
		}
	}
}
