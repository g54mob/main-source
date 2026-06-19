using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicles.Plane.Audio
{
	public class EngineAudioComponent : MonoBehaviour
	{
		[Serializable]
		public class AudioLayer
		{
			[Tooltip("Name shown in debug overlay")]
			public string layerName = "Layer";

			[Tooltip("AudioSource for this RPM layer")]
			public AudioSource source;

			[Header("RPM Range")]
			[Tooltip("RPM at which this layer starts fading in (volume = 0)")]
			public float rpmFadeInStart;

			[Tooltip("RPM at which this layer is fully audible (volume = 1)")]
			public float rpmPeakStart = 800f;

			[Tooltip("RPM at which this layer starts fading out (volume = 1)")]
			public float rpmPeakEnd = 3000f;

			[Tooltip("RPM at which this layer is fully silent (volume = 0)")]
			public float rpmFadeOutEnd = 4500f;

			[Header("Pitch")]
			[Tooltip("Pitch at the bottom of this layer's RPM range")]
			public float pitchMin = 0.9f;

			[Tooltip("Pitch at the top of this layer's RPM range")]
			public float pitchMax = 1.1f;

			[Header("Volume")]
			[Range(0f, 1f)]
			[Tooltip("Master volume multiplier for this layer")]
			public float masterVolume = 1f;

			[NonSerialized]
			public float VolSmooth;

			[NonSerialized]
			public float VolVelocity;

			[NonSerialized]
			public float PitchSmooth;

			[NonSerialized]
			public float PitchVelocity;

			public float EvaluateVolume(float rpm)
			{
				if (rpm <= rpmFadeInStart || rpm >= rpmFadeOutEnd)
				{
					return 0f;
				}
				if (rpm < rpmPeakStart)
				{
					return Mathf.InverseLerp(rpmFadeInStart, rpmPeakStart, rpm);
				}
				if (rpm <= rpmPeakEnd)
				{
					return 1f;
				}
				return Mathf.InverseLerp(rpmFadeOutEnd, rpmPeakEnd, rpm);
			}

			public float EvaluatePitch(float rpm)
			{
				float t = Mathf.InverseLerp(rpmFadeInStart, rpmFadeOutEnd, rpm);
				return Mathf.Lerp(pitchMin, pitchMax, t);
			}
		}

		[Header("Audio Layers")]
		public List<AudioLayer> layers = new List<AudioLayer>();

		[Header("Smoothing")]
		[Tooltip("How fast volume changes track RPM (lower = smoother)")]
		[Range(0.01f, 1f)]
		public float volumeSmoothSpeed = 0.1f;

		[Tooltip("How fast pitch changes track RPM")]
		[Range(0.01f, 1f)]
		public float pitchSmoothSpeed = 0.05f;

		[Header("Master")]
		[Range(0f, 1f)]
		public float masterVolume = 1f;

		[SerializeField]
		private EngineComponent _engine;

		private void Awake()
		{
			foreach (AudioLayer layer in layers)
			{
				InitLayer(layer);
			}
		}

		private void OnEnable()
		{
			_engine.OnEngineStarted += HandleEngineStarted;
			_engine.OnEngineStopped += HandleEngineStopped;
			_engine.OnEngineStalled += HandleEngineStopped;
		}

		private void OnDisable()
		{
			_engine.OnEngineStarted -= HandleEngineStarted;
			_engine.OnEngineStopped -= HandleEngineStopped;
			_engine.OnEngineStalled -= HandleEngineStopped;
		}

		private void Update()
		{
			if (!_engine.IsRunning)
			{
				foreach (AudioLayer layer in layers)
				{
					FadeOutLayer(layer);
				}
				return;
			}
			float rPM = _engine.RPM;
			foreach (AudioLayer layer2 in layers)
			{
				UpdateLayer(layer2, rPM);
			}
		}

		private void InitLayer(AudioLayer layer)
		{
			if (!(layer?.source == null))
			{
				layer.source.loop = true;
				layer.source.volume = 0f;
				layer.source.playOnAwake = false;
				layer.PitchSmooth = layer.pitchMin;
			}
		}

		private void UpdateLayer(AudioLayer layer, float rpm)
		{
			if (!(layer?.source == null))
			{
				float target = layer.EvaluateVolume(rpm) * layer.masterVolume * masterVolume;
				float target2 = layer.EvaluatePitch(rpm);
				layer.VolSmooth = Mathf.SmoothDamp(layer.VolSmooth, target, ref layer.VolVelocity, volumeSmoothSpeed);
				layer.PitchSmooth = Mathf.SmoothDamp(layer.PitchSmooth, target2, ref layer.PitchVelocity, pitchSmoothSpeed);
				layer.source.volume = layer.VolSmooth;
				layer.source.pitch = layer.PitchSmooth;
				if (layer.VolSmooth > 0.001f && !layer.source.isPlaying)
				{
					layer.source.Play();
				}
				else if (layer.VolSmooth <= 0.001f && layer.source.isPlaying)
				{
					layer.source.Stop();
				}
			}
		}

		private void FadeOutLayer(AudioLayer layer)
		{
			if (!(layer?.source == null))
			{
				layer.VolSmooth = Mathf.SmoothDamp(layer.VolSmooth, 0f, ref layer.VolVelocity, volumeSmoothSpeed);
				layer.source.volume = layer.VolSmooth;
				if (layer.VolSmooth <= 0.001f && layer.source.isPlaying)
				{
					layer.source.Stop();
				}
			}
		}

		private void HandleEngineStarted()
		{
			foreach (AudioLayer layer in layers)
			{
				if (layer?.source != null && !layer.source.isPlaying)
				{
					layer.source.Play();
				}
			}
		}

		private void HandleEngineStopped()
		{
		}

		public void AddLayer(AudioLayer layer)
		{
			InitLayer(layer);
			layers.Add(layer);
			if (_engine.IsRunning && layer.source != null)
			{
				layer.source.Play();
			}
		}

		public void RemoveLayer(AudioLayer layer)
		{
			if (layer?.source != null && layer.source.isPlaying)
			{
				layer.source.Stop();
			}
			layers.Remove(layer);
		}
	}
}
