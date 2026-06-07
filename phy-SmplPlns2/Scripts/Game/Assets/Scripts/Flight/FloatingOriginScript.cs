using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Input;
using Assets.Scripts.Levels;
using Jundroo.Common.Events;
using Unity.Mathematics;
using UnityEngine;
using WaveHarmonic.Crest.RelativeSpace;

namespace Assets.Scripts.Flight
{
	public class FloatingOriginScript : MonoBehaviour
	{
		private class ParticleSystemHackHelper
		{
			public ParticleSystem ParticleSystem;

			public float SimulationSpeed;

			public ParticleSystemHackHelper(ParticleSystem particleSystem)
			{
				ParticleSystem = particleSystem;
				ParticleSystem.MainModule main = particleSystem.main;
				SimulationSpeed = main.simulationSpeed;
				main.simulationSpeed = 0f;
			}
		}

		public float TargetThreshold = 1500f;

		public float TargetThresholdAndroid = 1000f;

		public float TimeDistanceThreshold = 200f;

		public float TimeThreshold = 10f;

		private static int? _microsplatOriginMatrixKey;

		[SerializeField]
		private Transform _cameraTarget;

		private Vector3 _currentWaterOffset = Vector3.zero;

		private LevelLoaderScript _levelLoader;

		private ParticleSystem.Particle[] _particleBuffer = new ParticleSystem.Particle[2500];

		private List<ParticleSystemHackHelper> _particleSystemFixups = new List<ParticleSystemHackHelper>();

		private float _timeSinceReposition;

		public static bool FloatOriginEnabled { get; set; }

		public static FloatingOriginScript Instance { get; private set; }

		public bool RepositionPending { get; private set; }

		public event EventHandler<FloatingOriginUpdatedEventArgs> Repositioned
		{
			add
			{
				_repositioned += WeakEventHandler.Create(value, delegate(EventHandler<FloatingOriginUpdatedEventArgs> x)
				{
					_repositioned -= x;
				});
			}
			remove
			{
				_repositioned -= WeakEventHandler.FindUnregisterHandler(this._repositioned, value);
			}
		}

		private event EventHandler<FloatingOriginUpdatedEventArgs> _repositioned;

		public void RepositionWorldImmediately()
		{
			RepositionWorld(_cameraTarget.position);
		}

		public void RepositionWorldImmediately(Vector3 preferredTranslation, float minimumDistanceThreshold = 0f, bool exactTranslation = false)
		{
			RepositionWorld(preferredTranslation, minimumDistanceThreshold, exactTranslation);
		}

		protected virtual void Awake()
		{
			Instance = this;
			FloatOriginEnabled = true;
			GameWorld.Instance.FloatingOriginOffsetD = Vector3.zero;
			if (!_microsplatOriginMatrixKey.HasValue)
			{
				_microsplatOriginMatrixKey = Shader.PropertyToID("_GlobalOriginMTX");
			}
		}

		protected virtual void LateUpdate()
		{
			if (FloatOriginEnabled && !RepositionPending && !FlightSceneScript.Instance.Designer.Active)
			{
				_timeSinceReposition += Time.unscaledDeltaTime;
				Vector3 position = _cameraTarget.position;
				float num = Mathf.Max(Mathf.Max(Mathf.Abs(position.x), Mathf.Abs(position.y)), Mathf.Abs(position.z));
				float num2 = (Game.Instance.Device.IsAndroidBuild ? TargetThresholdAndroid : TargetThreshold);
				bool flag = DebugInput.GetKeyDown(KeyCode.KeypadEnter) && DebugInput.GetKey(KeyCode.LeftShift) && DebugInput.GetKey(KeyCode.LeftControl);
				if (num >= num2 || (_timeSinceReposition >= TimeThreshold && Mathf.Abs(position.y) >= TimeDistanceThreshold) || flag)
				{
					if (flag)
					{
						Debug.Log("Debug recenter requested");
					}
					StartCoroutine(RepositionWorldAtEndOfFrame(position));
				}
			}
			if (_particleSystemFixups.Count <= 0)
			{
				return;
			}
			foreach (ParticleSystemHackHelper particleSystemFixup in _particleSystemFixups)
			{
				ParticleSystem particleSystem = particleSystemFixup.ParticleSystem;
				if (particleSystem != null)
				{
					ParticleSystem.MainModule main = particleSystem.main;
					main.simulationSpeed = particleSystemFixup.SimulationSpeed;
				}
			}
			_particleSystemFixups.Clear();
		}

		protected virtual void OnDestroy()
		{
			Instance = null;
		}

		protected virtual void Start()
		{
			_levelLoader = GetComponent<LevelLoaderScript>();
		}

		private void RaiseRepositionedEvent(Vector3 delta)
		{
			if (this._repositioned == null)
			{
				return;
			}
			Delegate[] invocationList = this._repositioned.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<FloatingOriginUpdatedEventArgs> eventHandler = (EventHandler<FloatingOriginUpdatedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new FloatingOriginUpdatedEventArgs(delta));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private void RepositionWorld(Vector3 preferredTranslation, float minimumDistanceThreshold = 0f, bool exactTranslation = false)
		{
			Vector3 vector = preferredTranslation;
			if (!exactTranslation)
			{
				vector.x = Mathf.Sign(preferredTranslation.x) * Mathf.Floor(Mathf.Abs(vector.x / TargetThreshold)) * TargetThreshold;
				vector.z = Mathf.Sign(preferredTranslation.z) * Mathf.Floor(Mathf.Abs(vector.z / TargetThreshold)) * TargetThreshold;
			}
			if (math.all(math.abs(vector) < minimumDistanceThreshold))
			{
				return;
			}
			if (_levelLoader.WaterNumTiles != 1)
			{
				float num = _levelLoader.WaterScale * 2f / (float)_levelLoader.WaterNumTiles;
				Vector3 vector2 = preferredTranslation + _currentWaterOffset;
				Vector3 vector3 = new Vector3(vector2.x, 0f, vector2.z);
				vector3 /= num;
				vector3.x = vector2.x - (float)(int)vector3.x * num;
				vector3.z = vector2.z - (float)(int)vector3.z * num;
				if (num >= TargetThreshold / 4.5f)
				{
					_levelLoader.Water.localPosition = -vector3;
					_currentWaterOffset = vector3;
				}
				else
				{
					_currentWaterOffset = Vector3.zero;
					_levelLoader.Water.localPosition = Vector3.zero;
					vector -= vector3;
				}
			}
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				AircraftScript component2;
				if (child.TryGetComponent<IgnoreFloatingOriginScript>(out var component))
				{
					if (!component.RepositionChildren)
					{
						continue;
					}
					foreach (Transform item in child)
					{
						item.position -= vector;
					}
				}
				else if (!child.TryGetComponent<AircraftScript>(out component2))
				{
					child.position -= vector;
				}
			}
			_particleSystemFixups.Clear();
			ParticleSystem[] array = UnityEngine.Object.FindObjectsByType<ParticleSystem>(FindObjectsSortMode.None);
			foreach (ParticleSystem particleSystem in array)
			{
				if (particleSystem.main.simulationSpace != ParticleSystemSimulationSpace.Local)
				{
					int particleCount = particleSystem.particleCount;
					if (particleCount > _particleBuffer.Length)
					{
						_particleBuffer = new ParticleSystem.Particle[particleCount];
					}
					particleSystem.GetParticles(_particleBuffer, particleCount);
					for (int k = 0; k < particleCount; k++)
					{
						_particleBuffer[k].position -= vector;
					}
					particleSystem.SetParticles(_particleBuffer, particleCount);
					_particleSystemFixups.Add(new ParticleSystemHackHelper(particleSystem));
				}
			}
			_timeSinceReposition = 0f;
			RepositionPending = false;
			GameWorld.Instance.FloatingOriginOffsetD += (Vector3d)vector;
			ShiftingOrigin.ShiftThisFrame = vector;
			ShiftingOrigin.HasTeleportedThisFrame = true;
			StartCoroutine(ResetFrameDeltaValuesAtEndOfFrame());
			Shader.SetGlobalMatrix(_microsplatOriginMatrixKey.Value, Matrix4x4.Translate(GameWorld.Instance.FloatingOriginOffset));
			RaiseRepositionedEvent(vector);
			Physics.SyncTransforms();
		}

		private IEnumerator RepositionWorldAtEndOfFrame(Vector3 preferredTranslation)
		{
			RepositionPending = true;
			yield return new WaitForEndOfFrame();
			while (PauseManager.Paused)
			{
				yield return new WaitForEndOfFrame();
			}
			RepositionWorld(preferredTranslation);
		}

		private IEnumerator ResetFrameDeltaValuesAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			ShiftingOrigin.ShiftThisFrame = Vector3.zero;
			ShiftingOrigin.HasTeleportedThisFrame = false;
		}
	}
}
