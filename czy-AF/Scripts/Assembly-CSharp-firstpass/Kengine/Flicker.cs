using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Flicker")]
	public class Flicker : MonoBehaviour
	{
		public float interval = 0.5f;

		public float speed = 4f;

		private float intensity = 1f;

		private void Start()
		{
			InvokeRepeating("PerformFlicker", 0f, interval);
		}

		private void Update()
		{
			GetComponent<Light>().intensity -= (GetComponent<Light>().intensity - intensity) / speed;
		}

		private void PerformFlicker()
		{
			intensity = Random.value;
		}
	}
}
