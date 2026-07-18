using System.Collections.Generic;
using UnityEngine;

public class GrassGrowth : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> grassPrefabs;

	[SerializeField]
	private float minPos;

	[SerializeField]
	private float maxPos;

	private void Start()
	{
		GenerateGrass();
	}

	private void GenerateGrass()
	{
		Object.Instantiate(grassPrefabs[Random.Range(0, grassPrefabs.Count)], base.transform).transform.localPosition = new Vector3(Random.Range(minPos, maxPos), 0f, Random.Range(minPos, maxPos));
	}
}
