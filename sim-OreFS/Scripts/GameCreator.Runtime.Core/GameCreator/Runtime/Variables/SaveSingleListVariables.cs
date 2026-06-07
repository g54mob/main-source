using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	internal class SaveSingleListVariables
	{
		[SerializeField]
		private IdString m_TypeID;

		[SerializeReference]
		private List<IndexVariable> m_Variables;

		public IdString TypeID => m_TypeID;

		public List<IndexVariable> Variables => m_Variables;

		public SaveSingleListVariables(ListVariableRuntime runtime)
		{
			m_TypeID = runtime.TypeID;
			m_Variables = new List<IndexVariable>();
			for (int i = 0; i < runtime.Count; i++)
			{
				m_Variables.Add(runtime.Variables[i].Copy as IndexVariable);
			}
		}
	}
}
