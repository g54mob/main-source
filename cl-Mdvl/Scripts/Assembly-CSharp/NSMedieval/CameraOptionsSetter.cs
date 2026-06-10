using System;
using NSEipix.Base;
using NSMedieval.UI;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace NSMedieval
{
	[RequireComponent(typeof(Camera), typeof(PostProcessLayer))]
	public class CameraOptionsSetter : MonoBehaviour
	{
		private Camera cam;

		private PostProcessLayer ppLayer;

		private void Awake()
		{
			cam = GetComponent<Camera>();
			ppLayer = GetComponent<PostProcessLayer>();
		}

		private void OnEnable()
		{
			MonoSingleton<OptionsController>.Instance.AntiAliasingOptionEvent += OnAntiAliasingOptionSet;
			OnAntiAliasingOptionSet();
		}

		private void OnDisable()
		{
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.AntiAliasingOptionEvent -= OnAntiAliasingOptionSet;
			}
		}

		private void OnAntiAliasingOptionSet()
		{
			SubpixelMorphologicalAntialiasing.Quality quality = SubpixelMorphologicalAntialiasing.Quality.High;
			PostProcessLayer.Antialiasing antialiasing;
			switch (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.AntiAliasing)
			{
			case 0:
				antialiasing = PostProcessLayer.Antialiasing.None;
				break;
			case 1:
				antialiasing = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
				break;
			case 2:
				antialiasing = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
				quality = SubpixelMorphologicalAntialiasing.Quality.Low;
				break;
			case 3:
				antialiasing = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
				quality = SubpixelMorphologicalAntialiasing.Quality.Medium;
				break;
			case 4:
				antialiasing = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
				quality = SubpixelMorphologicalAntialiasing.Quality.High;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			ppLayer.antialiasingMode = antialiasing;
			if (antialiasing == PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing)
			{
				ppLayer.subpixelMorphologicalAntialiasing.quality = quality;
			}
		}
	}
}
