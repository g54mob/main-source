using UnityEngine;

namespace Assets.Scripts
{
	public class BillboardScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _cameraTransform;

		public Transform CameraTransform
		{
			get
			{
				return _cameraTransform;
			}
			set
			{
				_cameraTransform = value;
			}
		}

		protected virtual void LateUpdate()
		{
			base.transform.LookAt(_cameraTransform.position, Vector3.up);
		}
	}
}
