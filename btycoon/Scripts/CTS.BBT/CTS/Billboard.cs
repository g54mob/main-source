using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class Billboard : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroupController _controller;

		private Camera _camera;

		private void Start()
		{
			_camera = Camera.main;
		}

		private void Update()
		{
			if ((bool)_camera && _controller.IsShown)
			{
				base.transform.LookAt(base.transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
			}
		}
	}
}
