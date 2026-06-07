using System;
using UnityEngine;

namespace Gh.Tk
{
	public class CameraViewToggle : MonoBehaviour
	{
		[SerializeField]
		private GameObject _standardCameraView;

		[SerializeField]
		private GameObject _freeCameraView;

		private void Awake()
		{
		}

		private void OnActiveCameraChanged(object sender, EventArgs e)
		{
		}

		private void OnEnable()
		{
		}

		private void UpdateView()
		{
		}
	}
}
