using System;
using UnityEngine;

[Serializable]
public class ChildGameObjectCache : ChildObjectCache<GameObject>
{
	protected override void SetActive(GameObject instance, bool active)
	{
		instance.SetActive(active);
	}
}
