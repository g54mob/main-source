#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using System;
using System.Collections;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.FactoryObjectBehaviours.NatureBehaviour;
using Data.Operator;
using Events;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.Audio
{
	public class AmbientAudioController : MonoBehaviour
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private int _ambientGridSize = 16;

		[SerializeField]
		private float _updateTime = 0.2f;

		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private List<FactoryObjectData> _factoryObjectsWithWaterSound;

		[SerializeField]
		private bool _showGizmos;

		[SerializeField]
		private DecorationsObjectDatabase _decorationsObjectDatabase;

		private Dictionary<Vector3Int, AmbientAudioEmitter> _spawnedEmitters = new Dictionary<Vector3Int, AmbientAudioEmitter>();

		private float[] _volumes;

		private Coroutine _coroutine;

		private void Start()
		{
			_volumes = new float[Enum.GetValues(typeof(AmbientTrackType)).Length];
			_factoryLayer.OnObjectAdded += HandleObjectAdded;
			_factoryLayer.OnObjectRemoved += HandleObjectRemoved;
			_terrainLayer.OnObjectAdded += HandleTerrainObjectAdded;
			_terrainLayer.OnObjectRemoved += HandleTerrainObjectRemoved;
			_preLoadingSaveEvent.Register(HandlePreLoad);
			_finishedLoadingSaveEvent.Register(HandleFinishedLoading);
			StartPlaying();
		}

		private void StopPlaying()
		{
			_audioManagerLocator.AudioManager.StopAmbientTrackLoops();
			if (_coroutine != null)
			{
				StopCoroutine(_coroutine);
			}
			_spawnedEmitters.Clear();
			_volumes = new float[Enum.GetValues(typeof(AmbientTrackType)).Length];
		}

		private void StartPlaying()
		{
			_audioManagerLocator.AudioManager.StartAmbientTrackLoops();
			_coroutine = StartCoroutine(UpdateAmbientAudio());
		}

		private void HandleFinishedLoading()
		{
			this.Log("Handle finished loading!", "HandleFinishedLoading", 69);
			StartPlaying();
		}

		private void HandlePreLoad()
		{
			this.Log("Handle pre load!", "HandlePreLoad", 76);
			StopPlaying();
		}

		public void OnDestroy()
		{
			StopPlaying();
			_factoryLayer.OnObjectAdded -= HandleObjectAdded;
			_factoryLayer.OnObjectRemoved -= HandleObjectRemoved;
			_terrainLayer.OnObjectAdded -= HandleTerrainObjectAdded;
			_terrainLayer.OnObjectRemoved -= HandleTerrainObjectRemoved;
			_preLoadingSaveEvent.UnRegister(HandlePreLoad);
			_finishedLoadingSaveEvent.UnRegister(HandleFinishedLoading);
		}

		private IEnumerator UpdateAmbientAudio()
		{
			while (true)
			{
				yield return new WaitForSeconds(_updateTime);
				GetVolumesFrom4ClosestAudioEmitters();
			}
		}

		private void HandleObjectRemoved(FactoryObject factoryObject)
		{
			AmbientTrackType trackType = (factoryObject.HasFactoryObjectBehaviour<IsNatureBehaviour>() ? AmbientTrackType.NatureAmbient : (factoryObject.HasFactoryObjectBehaviour<ConveyorBehaviour>() ? AmbientTrackType.ConveyorAmbient : AmbientTrackType.FactoryAmbient));
			if (!_decorationsObjectDatabase.Contains(factoryObject.FactoryObjectData))
			{
				RemoveObject(factoryObject.Position, trackType);
			}
		}

		private void HandleTerrainObjectRemoved(FactoryObject factoryObject)
		{
			if (_factoryObjectsWithWaterSound.Contains(factoryObject.FactoryObjectData))
			{
				RemoveObject(factoryObject.Position, AmbientTrackType.WaterAmbient);
			}
		}

		private void HandleObjectAdded(FactoryObject factoryObject)
		{
			AmbientTrackType trackType = AmbientTrackType.FactoryAmbient;
			if (factoryObject.HasFactoryObjectBehaviour<IsNatureBehaviour>())
			{
				trackType = AmbientTrackType.NatureAmbient;
			}
			else if (factoryObject.HasFactoryObjectBehaviour<ConveyorBehaviour>())
			{
				trackType = AmbientTrackType.ConveyorAmbient;
			}
			else if (_decorationsObjectDatabase.Contains(factoryObject.FactoryObjectData))
			{
				return;
			}
			AddNewObject(factoryObject.Position, trackType);
		}

		private void HandleTerrainObjectAdded(FactoryObject factoryObject)
		{
			if (_factoryObjectsWithWaterSound.Contains(factoryObject.FactoryObjectData))
			{
				AddNewObject(factoryObject.Position, AmbientTrackType.WaterAmbient);
			}
		}

		private void GetVolumesFrom4ClosestAudioEmitters()
		{
			Vector3 a = new Vector3(_cameraViewLocator.CameraView.ListenerPosition.x, 0f, _cameraViewLocator.CameraView.ListenerPosition.z);
			Vector3Int position = new Vector3Int((int)a.x - _ambientGridSize / 2, 0, (int)a.z - _ambientGridSize / 2);
			Vector3Int vector3Int = ObjectPositionToAmbientPosition(position);
			AmbientAudioEmitter ambientAudioEmitter = (_spawnedEmitters.ContainsKey(vector3Int) ? _spawnedEmitters[vector3Int] : null);
			AmbientAudioEmitter ambientAudioEmitter2 = (_spawnedEmitters.ContainsKey(vector3Int + new Vector3Int(1, 0, 0)) ? _spawnedEmitters[vector3Int + new Vector3Int(1, 0, 0)] : null);
			AmbientAudioEmitter ambientAudioEmitter3 = (_spawnedEmitters.ContainsKey(vector3Int + new Vector3Int(0, 0, 1)) ? _spawnedEmitters[vector3Int + new Vector3Int(0, 0, 1)] : null);
			AmbientAudioEmitter ambientAudioEmitter4 = (_spawnedEmitters.ContainsKey(vector3Int + new Vector3Int(1, 0, 1)) ? _spawnedEmitters[vector3Int + new Vector3Int(1, 0, 1)] : null);
			if (ambientAudioEmitter != null && ambientAudioEmitter2 != null)
			{
				Debug.DrawLine(ambientAudioEmitter.WorldPosition + Vector3.up, ambientAudioEmitter2.WorldPosition + Vector3.up, Color.black, _updateTime);
			}
			if (ambientAudioEmitter4 != null && ambientAudioEmitter2 != null)
			{
				Debug.DrawLine(ambientAudioEmitter2.WorldPosition + Vector3.up, ambientAudioEmitter4.WorldPosition + Vector3.up, Color.black, _updateTime);
			}
			if (ambientAudioEmitter3 != null && ambientAudioEmitter4 != null)
			{
				Debug.DrawLine(ambientAudioEmitter4.WorldPosition + Vector3.up, ambientAudioEmitter3.WorldPosition + Vector3.up, Color.black, _updateTime);
			}
			if (ambientAudioEmitter3 != null && ambientAudioEmitter != null)
			{
				Debug.DrawLine(ambientAudioEmitter3.WorldPosition + Vector3.up, ambientAudioEmitter.WorldPosition + Vector3.up, Color.black, _updateTime);
			}
			float num = ((ambientAudioEmitter != null) ? Vector3.Distance(a, ambientAudioEmitter.WorldPosition) : ((float)_ambientGridSize));
			float num2 = ((ambientAudioEmitter3 != null) ? Vector3.Distance(a, ambientAudioEmitter3.WorldPosition) : ((float)_ambientGridSize));
			float num3 = ((ambientAudioEmitter2 != null) ? Vector3.Distance(a, ambientAudioEmitter2.WorldPosition) : ((float)_ambientGridSize));
			float num4 = ((ambientAudioEmitter4 != null) ? Vector3.Distance(a, ambientAudioEmitter4.WorldPosition) : ((float)_ambientGridSize));
			foreach (object value in Enum.GetValues(typeof(AmbientTrackType)))
			{
				float num5 = 1f - Mathf.Clamp01(num / (float)_ambientGridSize);
				float num6 = 1f - Mathf.Clamp01(num3 / (float)_ambientGridSize);
				float num7 = 1f - Mathf.Clamp01(num2 / (float)_ambientGridSize);
				float num8 = 1f - Mathf.Clamp01(num4 / (float)_ambientGridSize);
				float num9 = ambientAudioEmitter?.GetVolumeForTrack((AmbientTrackType)value) ?? 0f;
				float num10 = ambientAudioEmitter2?.GetVolumeForTrack((AmbientTrackType)value) ?? 0f;
				float num11 = ambientAudioEmitter3?.GetVolumeForTrack((AmbientTrackType)value) ?? 0f;
				float num12 = ambientAudioEmitter4?.GetVolumeForTrack((AmbientTrackType)value) ?? 0f;
				float num13 = num5 * num9 + num6 * num10 + num7 * num11 + num8 * num12;
				_volumes[(int)value] = num13;
				_audioManagerLocator.AudioManager.SetAmbientTrackLoopVolume((AmbientTrackType)value, num13);
			}
		}

		public void AddNewObject(Vector3Int position, AmbientTrackType trackType)
		{
			Vector3Int vector3Int = ObjectPositionToAmbientPosition(position);
			if (_spawnedEmitters.ContainsKey(vector3Int))
			{
				_spawnedEmitters[vector3Int].AddWeight(trackType);
				return;
			}
			AmbientAudioEmitter ambientAudioEmitter = new AmbientAudioEmitter(vector3Int * _ambientGridSize + new Vector3((float)_ambientGridSize / 2f, 0f, (float)_ambientGridSize / 2f) - new Vector3Int(1024, 0, 1024));
			ambientAudioEmitter.AddWeight(trackType);
			_spawnedEmitters.Add(vector3Int, ambientAudioEmitter);
		}

		public void RemoveObject(Vector3Int position, AmbientTrackType trackType)
		{
			Vector3Int vector3Int = ObjectPositionToAmbientPosition(position);
			if (_spawnedEmitters.ContainsKey(vector3Int))
			{
				AmbientAudioEmitter ambientAudioEmitter = _spawnedEmitters[vector3Int];
				ambientAudioEmitter.RemoveWeight(trackType);
				if (ambientAudioEmitter.AllWeightsAreZero)
				{
					_spawnedEmitters.Remove(vector3Int);
				}
			}
			else
			{
				this.LogError($"No tracked ambient sfx emitter found at {vector3Int}", "RemoveObject", 274);
			}
		}

		private Vector3Int ObjectPositionToAmbientPosition(Vector3Int position)
		{
			position += new Vector3Int(1024, 0, 1024);
			return new Vector3Int(position.x / _ambientGridSize, 0, position.z / _ambientGridSize);
		}
	}
}
