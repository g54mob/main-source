using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RandomObjectEnabler : MonoBehaviour
{
	public List<GameObject> variations;

	private void OnEnable()
	{
		for (int i = 0; i < variations.Count; i++)
		{
			variations[i].SetActive(value: false);
		}
		StartCoroutine(EnableRandomVariation());
	}

	public IEnumerator EnableRandomVariation()
	{
		if (variations != null && variations.Count != 0)
		{
			yield return null;
			int index = Unity.Mathematics.Random.CreateFromIndex((uint)(EntityMonoBehaviour.ToWorldFromRender(base.transform.position).GetHashCode() + 1)).NextInt(0, variations.Count);
			if (variations[index] != base.gameObject)
			{
				variations[index].SetActive(value: true);
			}
		}
	}
}
