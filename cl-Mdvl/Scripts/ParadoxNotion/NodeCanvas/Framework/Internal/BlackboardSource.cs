using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public class BlackboardSource : IBlackboard
	{
		[SerializeField]
		private Dictionary<string, Variable> _variables = new Dictionary<string, Variable>(StringComparer.Ordinal);

		public string identifier => "Graph";

		public Dictionary<string, Variable> variables
		{
			get
			{
				return _variables;
			}
			set
			{
				_variables = value;
			}
		}

		public IBlackboard parent { get; set; }

		public UnityEngine.Object unityContextObject { get; set; }

		public Component propertiesBindTarget { get; set; }

		string IBlackboard.independantVariablesFieldName => null;

		public event Action<Variable> onVariableAdded;

		public event Action<Variable> onVariableRemoved;

		void IBlackboard.TryInvokeOnVariableAdded(Variable variable)
		{
			if (this.onVariableAdded != null)
			{
				this.onVariableAdded(variable);
			}
		}

		void IBlackboard.TryInvokeOnVariableRemoved(Variable variable)
		{
			if (this.onVariableRemoved != null)
			{
				this.onVariableRemoved(variable);
			}
		}

		public override string ToString()
		{
			return identifier;
		}
	}
}
