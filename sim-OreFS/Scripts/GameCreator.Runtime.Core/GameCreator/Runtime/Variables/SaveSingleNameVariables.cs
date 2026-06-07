using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	internal class SaveSingleNameVariables
	{
		[SerializeReference]
		private List<NameVariable> m_Variables;

		public List<NameVariable> Variables => m_Variables;

		public SaveSingleNameVariables(NameVariableRuntime runtime)
		{
			m_Variables = new List<NameVariable>();
			foreach (KeyValuePair<string, NameVariable> variable in runtime.Variables)
			{
				m_Variables.Add(variable.Value.Copy as NameVariable);
			}
		}
	}
}
