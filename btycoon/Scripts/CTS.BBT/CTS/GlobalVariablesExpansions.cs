using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class GlobalVariablesExpansions : CTSBehaviour
	{
		[SerializeField]
		private SerializableDictionary<StringKey, VariableList> _variableLists;

		private void Start()
		{
			if (!CTSSingleton<GamePlatform>.TryGetInstance(out var outInstance))
			{
				return;
			}
			foreach (var (dlcName, variableList2) in _variableLists)
			{
				if (outInstance.Library.IsDLCInstalled(dlcName))
				{
					variableList2.AddToGlobalVariables();
				}
			}
		}
	}
}
