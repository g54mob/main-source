using UnityEngine;

namespace emotiontheory
{
	public class Rotate : MonoBehaviour
	{
		public float Speed = 90f;

		private void Start()
		{
		}

		private void Update()
		{
			base.transform.Rotate(0f, Speed * Time.deltaTime, 0f);
		}
	}
}
