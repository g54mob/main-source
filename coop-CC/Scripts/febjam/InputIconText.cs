using System;
using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Global/InputIconText")]
public class InputIconText : GlobalScriptableObject<InputIconText>, ISerializationCallbackReceiver
{
	[Serializable]
	public struct InputActionIconSet
	{
		public string actionName;

		public List<string> gamepadStrings;

		public List<string> keyboardStrings;
	}

	[SerializeField]
	private List<InputActionIconSet> inputActionIconSets = new List<InputActionIconSet>();

	private Dictionary<string, InputActionIconSet> inputActionIcons = new Dictionary<string, InputActionIconSet>();

	public Dictionary<string, InputActionIconSet> GetInputActionIconSets()
	{
		if (inputActionIcons == null || inputActionIcons.Count == 0)
		{
			RebuildDictionary();
		}
		return inputActionIcons;
	}

	public void RebuildDictionary()
	{
		if (inputActionIcons == null)
		{
			inputActionIcons = new Dictionary<string, InputActionIconSet>();
		}
		inputActionIcons.Clear();
		foreach (InputActionIconSet inputActionIconSet in inputActionIconSets)
		{
			inputActionIcons.Add(inputActionIconSet.actionName, inputActionIconSet);
		}
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		RebuildDictionary();
	}
}
