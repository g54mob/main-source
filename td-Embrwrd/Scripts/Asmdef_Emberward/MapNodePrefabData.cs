using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "MapNodePrefabData", menuName = "設定檔/地圖節點使用的Prefab資料 (MapNodePrefabData)", order = 1)]
public class MapNodePrefabData : ScriptableObject
{
	[Serializable]
	public class StageTypePrefabPair
	{
		public eStageType stageType;

		public GameObject prefab;
	}

	public List<StageTypePrefabPair> stageTypePrefabPairs;

	private void OnValidate()
	{
	}

	public GameObject GetPrefabForStageType(eStageType stageType)
	{
		return null;
	}

	private bool ValidateStageTypePairs(List<StageTypePrefabPair> pairs, ref string errorMessage)
	{
		return false;
	}
}
