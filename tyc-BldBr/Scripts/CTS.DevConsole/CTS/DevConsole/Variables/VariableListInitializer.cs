using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[DefaultExecutionOrder(-1000)]
	public class VariableListInitializer : MonoBehaviour
	{
		[SerializeField]
		private VariableList[] _variableLists;

		[SerializeField]
		private bool _resetDefaultValues = true;

		private void Awake()
		{
			VariableList[] variableLists = _variableLists;
			foreach (VariableList variableList in variableLists)
			{
				if ((object)variableList == null)
				{
					continue;
				}
				foreach (CVarReference item in variableList)
				{
					ConsoleVar.AddVariable(item);
				}
			}
		}

		private void OnDestroy()
		{
			VariableList[] variableLists = _variableLists;
			foreach (VariableList variableList in variableLists)
			{
				if ((object)variableList == null)
				{
					continue;
				}
				foreach (CVarReference item in variableList)
				{
					if (_resetDefaultValues)
					{
						item.GetVariable().SetDefaultValues();
					}
					ConsoleVar.RemoveVariable(item);
				}
			}
		}
	}
}
