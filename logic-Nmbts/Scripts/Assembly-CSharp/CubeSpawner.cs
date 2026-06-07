using System.Collections;
using UnityEngine;

[AddComponentMenu("")]
public class CubeSpawner : MonoBehaviour
{
	public Transform CubePrefab;

	public float Interval = 0.5f;

	private void Start()
	{
		if (!(CubePrefab == null))
		{
			StartCoroutine(SpawnCube());
		}
	}

	private IEnumerator SpawnCube()
	{
		float timer = 0f;
		while (true)
		{
			timer += Time.deltaTime;
			if (timer > Interval)
			{
				timer = 0f;
				Object.Instantiate(CubePrefab, base.transform.position, Random.rotationUniform);
			}
			yield return null;
		}
	}
}
