using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Variable List")]
	public class VariableList : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, bool> _boolVariables = new SerializableDictionary<StringKey, bool>();

		public ReadOnlyDictionary<StringKey, bool> BoolVariables => _boolVariables;

		public void AddToGlobalVariables()
		{
			foreach (var (key, value) in _boolVariables)
			{
				GlobalVariables<bool>.Set(key, value);
			}
		}
	}
}
