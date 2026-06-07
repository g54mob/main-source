using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "DebugSettingData", menuName = "DebugSettingData", order = 1)]
public class DebugSettingSO : ScriptableObject
{
	[SerializeField]
	[HideInInspector]
	public List<DebugSettingData> list_DebugSettingData;

	private void OnValidate()
	{
	}

	private static int SortByKey(DebugSettingData o1, DebugSettingData o2)
	{
		return 0;
	}
}
