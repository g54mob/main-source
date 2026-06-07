using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class DisableUi : MonoBehaviour
	{
		private bool _isDisabled = true;

		private Camera _camera;

		public void Start()
		{
			_camera = GetComponent<Camera>();
		}

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.U))
			{
				_isDisabled = !_isDisabled;
			}
			_camera.enabled = !_isDisabled;
		}
	}
}
