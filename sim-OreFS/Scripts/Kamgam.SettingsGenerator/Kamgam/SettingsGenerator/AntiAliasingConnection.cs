using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class AntiAliasingConnection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		public AntiAliasingConnection()
		{
			CameraDetector instance = CameraDetector.Instance;
			instance.OnNewCameraFound = (CameraDetector.OnNewCameraFoundDelegate)Delegate.Combine(instance.OnNewCameraFound, new CameraDetector.OnNewCameraFoundDelegate(onNewCameraFound));
		}

		protected void onNewCameraFound(Camera cam)
		{
			setOnCamera(cam, lastKnownValue);
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels == null)
			{
				_labels = new List<string>();
				_labels.Add("Disabled");
				_labels.Add("FXAA");
				_labels.Add("SMAA");
				_labels.Add("TAA");
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			if (optionLabels == null || optionLabels.Count != 4)
			{
				Debug.LogError("Invalid new labels. Need to be three.");
			}
			else
			{
				_labels = optionLabels;
			}
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		public override int Get()
		{
			if (Camera.main == null)
			{
				return 0;
			}
			UniversalAdditionalCameraData component = Camera.main.GetComponent<UniversalAdditionalCameraData>();
			if (component == null)
			{
				return 0;
			}
			return component.antialiasing switch
			{
				AntialiasingMode.None => 0, 
				AntialiasingMode.FastApproximateAntialiasing => 1, 
				AntialiasingMode.SubpixelMorphologicalAntiAliasing => 2, 
				AntialiasingMode.TemporalAntiAliasing => 3, 
				_ => 0, 
			};
		}

		public override void Set(int index)
		{
			Camera[] allCameras = Camera.allCameras;
			foreach (Camera camera in allCameras)
			{
				if (camera.gameObject.activeInHierarchy && camera.isActiveAndEnabled)
				{
					setOnCamera(camera, index);
				}
			}
			NotifyListenersIfChanged(index);
		}

		private static void setOnCamera(Camera cam, int index)
		{
			UniversalAdditionalCameraData component = cam.GetComponent<UniversalAdditionalCameraData>();
			if (!(component == null))
			{
				if (index == 0)
				{
					component.antialiasing = AntialiasingMode.None;
				}
				if (index == 1)
				{
					component.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
				}
				if (index == 2)
				{
					component.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
				}
				if (index == 3)
				{
					component.antialiasing = AntialiasingMode.TemporalAntiAliasing;
				}
			}
		}
	}
}
