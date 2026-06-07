using System.Collections;
using UnityEngine;

namespace UltimateReplay.Demo
{
	public class CubeSpawner : MonoBehaviour
	{
		public float spawnRange = 4f;

		public float spawnHeight = 6f;

		public int spawnAmount = 300;

		public float explosiveForce = 5f;

		public Transform parent;

		public GameObject[] spawnCubes;

		public IEnumerator Start()
		{
			yield return new WaitForSeconds(1f);
			Transform setParent = parent;
			if (setParent == null)
			{
				GameObject gameObject = new GameObject("DemoCubes");
				setParent = gameObject.transform;
			}
			for (int i = 0; i < spawnAmount; i++)
			{
				Vector3 position = randomPosition();
				Quaternion rotation = randomRotation();
				int num = Random.Range(0, spawnCubes.Length);
				GameObject obj = Object.Instantiate(spawnCubes[num], position, rotation);
				obj.transform.SetParent(setParent);
				Rigidbody component = obj.GetComponent<Rigidbody>();
				if (component != null)
				{
					Vector3 vector = new Vector3(Random.Range(-1, 1), 0f, Random.Range(-1, 1));
					vector *= 2f;
					Vector3 vector2 = Vector3.up * explosiveForce;
					component.AddForce(vector + vector2, ForceMode.Impulse);
				}
				yield return null;
			}
		}

		private Vector3 randomPosition()
		{
			return new Vector3(Random.Range(0f - spawnRange, spawnRange), z: Random.Range(0f - spawnRange, spawnRange), y: spawnHeight);
		}

		private Quaternion randomRotation()
		{
			float x = Random.Range(0, 360);
			float y = Random.Range(0, 360);
			float z = Random.Range(0, 360);
			return Quaternion.Euler(x, y, z);
		}
	}
}
