using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class MetagameMapAmbience : MustCallDestroy
	{
		private struct AmbienceEntry
		{
			public string AudioEventName;

			public float Distance;

			public HeightVolumePreset HeightVolumePreset;

			public int Count;
		}

		private struct AmbienceEmitters
		{
			public AudioEmitter AudioEmitter;
		}

		private MetagameMapAmbienceConfig _config;

		private TopDownCameraLogic _cameraLogic;

		private Camera _cameraComponent;

		private RaycastHit[] _cachedHits = new RaycastHit[8];

		private AmbienceEntry[] _cachedHitVolumes;

		private AudioEmitter _skyAmbiencEmitter;

		private List<AudioEmitter> _activeAmbienceEmitters = new List<AudioEmitter>(32);

		public MetagameMapAmbience(TopDownCameraLogic cameraLogic, MetagameMapAmbienceConfig config)
		{
			_config = config;
			_cameraLogic = cameraLogic;
			_cameraComponent = cameraLogic.CameraComponent;
			_cachedHitVolumes = new AmbienceEntry[_config.VerticalSamples * _config.HorizontalSamples];
			_skyAmbiencEmitter = AudioManager.Instance.Play(_config.SkyAmbienceAudioEvent);
			if (_skyAmbiencEmitter != null)
			{
				_skyAmbiencEmitter.Volume = 0f;
				_skyAmbiencEmitter.Pause();
			}
		}

		private bool TryGetAmbienceEntry(string audioEventName, out AmbienceEntry ambienceEntry)
		{
			for (int i = 0; i < _cachedHitVolumes.Length; i++)
			{
				if (_cachedHitVolumes[i].AudioEventName == audioEventName)
				{
					ambienceEntry = _cachedHitVolumes[i];
					return true;
				}
			}
			ambienceEntry = default(AmbienceEntry);
			return false;
		}

		private void ResetVolumeCount()
		{
			for (int i = 0; i < _cachedHitVolumes.Length; i++)
			{
				_cachedHitVolumes[i] = default(AmbienceEntry);
			}
		}

		private void IncrementVolumeCount(MetagameAmbienceVolume ambienceVolume, float distance)
		{
			for (int i = 0; i < _cachedHitVolumes.Length; i++)
			{
				if (_cachedHitVolumes[i].AudioEventName == ambienceVolume.AudioEventName)
				{
					_cachedHitVolumes[i].Count++;
					if (distance < _cachedHitVolumes[i].Distance)
					{
						_cachedHitVolumes[i].Distance = distance;
					}
					return;
				}
			}
			for (int j = 0; j < _cachedHitVolumes.Length; j++)
			{
				if (_cachedHitVolumes[j].AudioEventName == null)
				{
					_cachedHitVolumes[j].AudioEventName = ambienceVolume.AudioEventName;
					_cachedHitVolumes[j].HeightVolumePreset = ambienceVolume.HeightVolumePreset;
					_cachedHitVolumes[j].Distance = distance;
					_cachedHitVolumes[j].Count = 1;
					break;
				}
			}
		}

		public void Update()
		{
			int mask = LayerMask.GetMask("Metagame Ambience");
			Vector3[] frustumCorners = _cameraLogic.FrustumCorners;
			Vector3 a = frustumCorners[0];
			Vector3 a2 = frustumCorners[1];
			Vector3 b = frustumCorners[2];
			Vector3 b2 = frustumCorners[3];
			Vector3 position = _cameraComponent.transform.position;
			ResetVolumeCount();
			for (int i = 0; i < _config.HorizontalSamples; i++)
			{
				Vector3 b3 = Vector3.Lerp(a2, b, ((float)i + 1f) / ((float)_config.HorizontalSamples + 1f));
				Vector3 a3 = Vector3.Lerp(a, b2, ((float)i + 1f) / ((float)_config.HorizontalSamples + 1f));
				for (int j = 0; j < _config.VerticalSamples; j++)
				{
					Vector3 direction = Vector3.Lerp(a3, b3, ((float)j + 1f) / ((float)_config.VerticalSamples + 1f));
					int num = Physics.RaycastNonAlloc(new Ray(position, direction), _cachedHits, float.MaxValue, mask, QueryTriggerInteraction.Collide);
					if (num == 0)
					{
						continue;
					}
					RaycastHit raycastHit = _cachedHits.FindLowest(0, num, (RaycastHit hit) => (hit.transform.GetComponent<MetagameAmbienceVolume>() == null) ? float.PositiveInfinity : hit.distance);
					if (!(raycastHit.transform == null))
					{
						MetagameAmbienceVolume component = raycastHit.transform.GetComponent<MetagameAmbienceVolume>();
						if (component != null)
						{
							IncrementVolumeCount(component, raycastHit.distance);
						}
					}
				}
			}
			for (int num2 = 0; num2 < _cachedHitVolumes.Length && _cachedHitVolumes[num2].AudioEventName != null; num2++)
			{
				string audioEventName = _cachedHitVolumes[num2].AudioEventName;
				bool flag = false;
				for (int num3 = 0; num3 < _activeAmbienceEmitters.Count; num3++)
				{
					if (_activeAmbienceEmitters[num3].AudioEvent.EventName == audioEventName)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					AudioEmitter audioEmitter = AudioManager.Instance.Play(audioEventName);
					if (audioEmitter != null)
					{
						audioEmitter.Volume = 0f;
						audioEmitter.Pause();
						_activeAmbienceEmitters.Add(audioEmitter);
					}
				}
			}
			for (int num4 = 0; num4 < _activeAmbienceEmitters.Count; num4++)
			{
				AudioEmitter audioEmitter2 = _activeAmbienceEmitters[num4];
				float targetVolume;
				if (TryGetAmbienceEntry(audioEmitter2.AudioEvent.EventName, out var ambienceEntry))
				{
					float num5 = (float)ambienceEntry.Count / (float)(_config.VerticalSamples * _config.HorizontalSamples);
					AnimationCurve heightVolumeCurve = _config.HeightVolumeCurve;
					if (ambienceEntry.HeightVolumePreset != null)
					{
						heightVolumeCurve = ambienceEntry.HeightVolumePreset.HeightVolumeCurve;
					}
					targetVolume = num5 * heightVolumeCurve.Evaluate(ambienceEntry.Distance);
				}
				else
				{
					targetVolume = 0f;
				}
				UpdateAudioEmitter(audioEmitter2, targetVolume, _config.AmbienceFadeDuration);
			}
			if (_skyAmbiencEmitter != null)
			{
				Plane plane = new Plane(Vector3.up, Vector3.zero);
				Ray ray = new Ray(_cameraComponent.transform.position, _cameraComponent.transform.forward);
				UpdateAudioEmitter(targetVolume: (!plane.Raycast(ray, out var enter)) ? 0f : _config.SkyAmbienceHeightVolumeCurve.Evaluate(enter), audioEmitter: _skyAmbiencEmitter, ambienceFadeDuration: _config.AmbienceFadeDuration);
			}
		}

		private static void UpdateAudioEmitter(AudioEmitter audioEmitter, float targetVolume, float ambienceFadeDuration)
		{
			float volume = audioEmitter.Volume;
			float num = Time.unscaledDeltaTime / ambienceFadeDuration;
			if (volume < targetVolume)
			{
				audioEmitter.Volume = Mathf.Min(targetVolume, volume + num);
			}
			else
			{
				audioEmitter.Volume = Mathf.Max(targetVolume, volume - num);
			}
			if (Mathf.Approximately(0f, audioEmitter.Volume))
			{
				audioEmitter.Pause();
			}
			else
			{
				audioEmitter.UnPause();
			}
		}

		public override void Destroy()
		{
			if (_skyAmbiencEmitter != null)
			{
				_skyAmbiencEmitter.Stop(playOutro: false);
				_skyAmbiencEmitter = null;
			}
			foreach (AudioEmitter activeAmbienceEmitter in _activeAmbienceEmitters)
			{
				activeAmbienceEmitter.Stop(playOutro: false);
			}
			_activeAmbienceEmitters.Clear();
			base.Destroy();
		}
	}
}
