using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class CameraFOV : MonoSingleton<CameraFOV>
	{
		[SerializeField]
		private List<FOVStruct> _fOVStructs = new List<FOVStruct>();

		[SerializeField]
		private float _aspectRatioTolerance = 0.01f;

		private Camera _camera;

		protected override void SingletonAwake()
		{
			_camera = GetComponent<Camera>();
			ApplyFOVBasedOnAspectRatio();
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void ApplyFOVBasedOnAspectRatio()
		{
			float num = (float)Screen.width / (float)Screen.height;
			num = (float)Math.Round(num, 3);
			foreach (FOVStruct fOVStruct in _fOVStructs)
			{
				if (Mathf.Abs((float)Math.Round(fOVStruct.aspectRation, 3) - num) <= _aspectRatioTolerance)
				{
					_camera.fieldOfView = fOVStruct.FOV;
					return;
				}
			}
			Debug.LogWarning($"Aucun FOV trouvé pour le ratio d'aspect {num}. Utilisation du FOV par défaut.");
		}
	}
}
