using UnityEngine;

namespace PSXShadersPro.URP.Demo
{
	public class Rotate : MonoBehaviour
	{
		[SerializeField]
		private Vector3 rotationAnglesPerSecond;

		private void Update()
		{
			base.transform.Rotate(rotationAnglesPerSecond * Time.deltaTime, Space.Self);
		}
	}
}
