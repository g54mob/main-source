using UnityEngine;

namespace Benjathemaker
{
	public class RocketRotator : MonoBehaviour
	{
		[Header("Rotation Settings")]
		[SerializeField]
		private Vector3 rotationAngle = new Vector3(0f, 45f, 0f);

		[SerializeField]
		private bool isRotating = true;

		private void Update()
		{
			if (isRotating)
			{
				RotateObject();
			}
		}

		private void RotateObject()
		{
			base.transform.Rotate(rotationAngle * Time.deltaTime, Space.Self);
		}
	}
}
