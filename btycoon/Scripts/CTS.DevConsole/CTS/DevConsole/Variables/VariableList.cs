using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[CreateAssetMenu(fileName = "New Variable List", menuName = "CTS/Dev Console/Variable List")]
	internal class VariableList : ScriptableObject, IEnumerable<CVarReference>, IEnumerable
	{
		[Serializable]
		internal struct VariableData
		{
			public string name;

			public CVarReference variable;

			public void Deconstruct(out string outName, out CVarReference outCvar)
			{
				outName = name;
				outCvar = variable;
			}
		}

		[SerializeField]
		private List<VariableData> _variables = new List<VariableData>();

		internal bool ContainsKey(string key)
		{
			key = key.ToLowerInvariant();
			foreach (VariableData variable in _variables)
			{
				variable.Deconstruct(out var outName, out var _);
				if (outName.ToLowerInvariant() == key)
				{
					return true;
				}
			}
			return false;
		}

		internal bool ContainsValue(CVarReference variable)
		{
			foreach (VariableData variable2 in _variables)
			{
				variable2.Deconstruct(out var _, out var outCvar);
				if (outCvar == variable)
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerator<CVarReference> GetEnumerator()
		{
			foreach (VariableData variable in _variables)
			{
				yield return variable.variable;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
