using UnityEngine;

namespace Other
{
	public class LookAtCamera : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		private void LateUpdate()
		{
			base.transform.LookAt(2f * base.transform.position - _camera.transform.position);
		}
	}
}
