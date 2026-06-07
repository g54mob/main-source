using System;
using UnityEngine;

public class InstantiateObjectAnimationEvent : MonoBehaviour
{
	[Serializable]
	private struct FInstantiationInfo
	{
		public GameObject prefabToInstantiate;

		public Transform parent;
	}

	[SerializeField]
	private FInstantiationInfo[] objectsToInstantiate;

	public void AnimationEventInstantiateObject(int idx = -1)
	{
		if (idx < 0)
		{
			for (int i = 0; i < objectsToInstantiate.Length; i++)
			{
				UnityEngine.Object.Instantiate(objectsToInstantiate[i].prefabToInstantiate, objectsToInstantiate[i].parent);
			}
		}
		else
		{
			UnityEngine.Object.Instantiate(objectsToInstantiate[idx].prefabToInstantiate, objectsToInstantiate[idx].parent);
		}
	}
}
