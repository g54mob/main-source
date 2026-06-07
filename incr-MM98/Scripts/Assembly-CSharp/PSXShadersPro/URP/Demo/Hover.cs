using UnityEngine;

namespace PSXShadersPro.URP.Demo
{
	public class Hover : MonoBehaviour
	{
		[SerializeField]
		private Vector3 offset;

		[SerializeField]
		private float animDuration;

		[SerializeField]
		private Vector3 rotationAngles;

		private Vector3 startPosition;

		private void Start()
		{
			startPosition = base.transform.position;
		}

		private void Update()
		{
			float t = Mathf.Sin(Time.time / animDuration) * 0.5f + 0.5f;
			base.transform.position = Vector3.Lerp(startPosition - offset, startPosition + offset, t);
			base.transform.Rotate(rotationAngles * Time.deltaTime);
		}
	}
}
