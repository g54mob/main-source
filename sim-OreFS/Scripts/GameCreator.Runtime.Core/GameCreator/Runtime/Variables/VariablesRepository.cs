using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class VariablesRepository : TRepository<VariablesRepository>
	{
		[SerializeField]
		private GlobalVariables m_Variables = new GlobalVariables();

		public override string RepositoryID => "core.variables";

		public GlobalVariables Variables => m_Variables;
	}
}
