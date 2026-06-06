using UnityEngine;

namespace PSXShadersPro.URP.Demo
{
	public class RandomSway : MonoBehaviour
	{
		[SerializeField]
		private Vector2 rotationBounds;

		[SerializeField]
		private Vector2 speedBounds;

		private float randomOffset;

		private float speed;

		private float maxRotation;

		private void Start()
		{
			randomOffset = Random.value;
			speed = Random.Range(speedBounds.x, speedBounds.y);
			maxRotation = Random.Range(rotationBounds.x, rotationBounds.y);
		}

		private void Update()
		{
			float z = Mathf.Sin(Time.time * speed + randomOffset) * maxRotation;
			base.transform.localRotation = Quaternion.Euler(0f, -90f, z);
		}
	}
}
