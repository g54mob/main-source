using System.Collections.Generic;
using Data.Variables;
using UnityEngine;

namespace DefaultNamespace.Data.TechTree
{
	[CreateAssetMenu(menuName = "Tech Tree/TechTreeRefunableDatabase", fileName = "TechTreeRefunableDatabase", order = 0)]
	public class TechTreeRefunableDatabase : ScriptableObject
	{
		[SerializeField]
		private List<VariableSO> _variables = new List<VariableSO>();

		public void AddVariable(VariableSO variable)
		{
			if (!_variables.Contains(variable))
			{
				_variables.Add(variable);
			}
		}

		public void RemoveNulls()
		{
			for (int num = _variables.Count - 1; num >= 0; num--)
			{
				if (_variables[num] == null)
				{
					_variables.RemoveAt(num);
				}
			}
		}

		public void SetAllVariablesToDefault()
		{
			foreach (VariableSO variable in _variables)
			{
				variable.ResetToDefault();
			}
		}
	}
}
