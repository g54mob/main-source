using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class LockToCameraCenter : MonoBehaviour
	{
		public float DistanceFromCamera;

		public bool FixRotationToCamera;

		private Camera _camera;

		private void Start()
		{
			_camera = Camera.main;
		}

		private void Update()
		{
			base.transform.position = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, DistanceFromCamera));
			if (FixRotationToCamera)
			{
				base.transform.eulerAngles = new Vector3(0f, 0f, _camera.gameObject.transform.eulerAngles.z);
			}
		}
	}
}
