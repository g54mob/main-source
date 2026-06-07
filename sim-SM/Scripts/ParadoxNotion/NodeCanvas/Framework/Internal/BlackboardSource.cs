using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public class BlackboardSource : IBlackboard
	{
		[SerializeField]
		private Dictionary<string, Variable> _variables;

		public string identifier => null;

		public Dictionary<string, Variable> variables
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IBlackboard parent { get; set; }

		public UnityEngine.Object unityContextObject { get; set; }

		public Component propertiesBindTarget { get; set; }

		string IBlackboard.independantVariablesFieldName => null;

		public event Action<Variable> onVariableAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Variable> onVariableRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		void IBlackboard.TryInvokeOnVariableAdded(Variable variable)
		{
		}

		void IBlackboard.TryInvokeOnVariableRemoved(Variable variable)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
