using System;
using UnityEngine;

[Serializable]
public class HintBox
{
	public string hintBoxTag;

	public GameObject prefab;

	public bool shown;

	public GameObject SpawnBox(Transform container)
	{
		GameObject result = UnityEngine.Object.Instantiate(prefab, container);
		shown = true;
		return result;
	}
}
