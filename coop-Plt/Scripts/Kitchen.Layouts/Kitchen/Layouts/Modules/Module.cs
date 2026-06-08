using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	public abstract class Module<T> : Module
	{
		protected T Result;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public LayoutGraphConnection Output;

		protected abstract T Generate();

		protected override void PerformUpdate()
		{
			Result = Generate();
		}

		public override object GetValue(NodePort port)
		{
			if (port.fieldName == "Output")
			{
				return Result;
			}
			return null;
		}
	}
	[NodeWidth(300)]
	public abstract class Module : Node
	{
		[HideInInspector]
		public Texture2D Texture;

		public IEnumerable<Module> Parents => from p in base.Ports
			where p.IsInput && p.IsConnected && p.Connection?.node is Module
			select p.Connection?.node as Module;

		protected bool TryGetInput<T>(string portName, out T result)
		{
			NodePort inputPort = GetInputPort(portName);
			if (inputPort != null && inputPort.IsConnected && inputPort.Connection != null && inputPort.GetInputValue() is T val)
			{
				result = val;
				return true;
			}
			result = default(T);
			return false;
		}

		protected bool TryGetInput<T>(string portName, out List<T> result)
		{
			NodePort inputPort = GetInputPort(portName);
			if (inputPort != null && inputPort.IsConnected && inputPort.Connection != null)
			{
				using List<NodePort>.Enumerator enumerator = inputPort.GetConnections().GetEnumerator();
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					object[] inputValues = inputPort.GetInputValues();
					result = inputValues.FilterCast<T>().ToList();
					return true;
				}
			}
			result = new List<T>();
			return false;
		}

		public void UpdateAll()
		{
			if (graph is LayoutGraph layoutGraph)
			{
				layoutGraph.Update();
			}
		}

		public virtual void UpdateDisplay()
		{
			Update();
			UpdateChildren();
		}

		public virtual void Update()
		{
			PerformUpdate();
			GenerateTexture();
		}

		protected abstract void PerformUpdate();

		private void UpdateChildren()
		{
			foreach (NodePort item in base.Ports.Where((NodePort p) => !p.IsInput))
			{
				foreach (NodePort connection in item.GetConnections())
				{
					if (connection.node is Module module)
					{
						module.Update();
					}
				}
			}
		}

		public override void OnCreateConnection(NodePort from, NodePort to)
		{
			Update();
		}

		public override void OnRemoveConnection(NodePort port)
		{
			Update();
		}

		public virtual Texture2D GenerateTexture()
		{
			return null;
		}
	}
}
