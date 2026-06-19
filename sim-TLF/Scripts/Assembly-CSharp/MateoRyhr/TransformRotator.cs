using UnityEngine;

namespace MateoRyhr
{
	public class TransformRotator : MonoBehaviour
	{
		public void RotateX(float rotation)
		{
			base.transform.Rotate(Vector3.right, rotation);
		}

		public void RotateY(float rotation)
		{
			base.transform.Rotate(Vector3.up, rotation);
		}

		public void RotateZ(float rotation)
		{
			base.transform.Rotate(Vector3.forward, rotation);
		}

		public void Rotate(Transform rotationTransform)
		{
			base.transform.rotation = rotationTransform.rotation;
		}
	}
}
