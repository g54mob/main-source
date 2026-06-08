using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class Scatter : MonoBehaviour
	{
		public GameObject PrimaryObject;

		public List<GameObject> Children;

		public int Min;

		public int Max = 5;

		public float Distance = 0.75f;

		private void Start()
		{
			int num = Random.Range(Min, Max);
			for (int i = 0; i < num; i++)
			{
				Vector2 vector = Random.insideUnitCircle * Distance;
				Object.Instantiate(Children.Random(), base.transform.position + new Vector3(vector.x, 0f, vector.y), Quaternion.Euler(0f, Random.Range(0, 360), 0f), base.transform).transform.localScale = Random.Range(0.75f, 1f) * Vector3.one;
			}
		}
	}
}
