using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Loxodon.Framework.Views.Variables
{
	[Serializable]
	public class VariableArray
	{
		[SerializeField]
		private List<Variable> variables;

		public ReadOnlyCollection<Variable> Variables => variables.AsReadOnly();

		public Variable this[int index] => variables[index];

		public object Get(string name)
		{
			if (variables == null || variables.Count <= 0)
			{
				return null;
			}
			return variables.Find((Variable v) => v.Name.Equals(name))?.GetValue();
		}

		public T Get<T>(string name)
		{
			if (variables == null || variables.Count <= 0)
			{
				return default(T);
			}
			Variable variable = variables.Find((Variable v) => v.Name.Equals(name));
			if (variable == null)
			{
				return default(T);
			}
			return variable.GetValue<T>();
		}

		public static implicit operator List<Variable>(VariableArray array)
		{
			return array.variables;
		}

		public static implicit operator VariableArray(List<Variable> variables)
		{
			return new VariableArray
			{
				variables = variables
			};
		}
	}
}
