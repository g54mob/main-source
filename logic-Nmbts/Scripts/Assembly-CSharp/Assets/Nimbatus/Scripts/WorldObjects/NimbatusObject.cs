using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects
{
	public abstract class NimbatusObject : SerializedMonoBehaviour
	{
		[SerializeField]
		[ReadOnly]
		public string UniqueId;

		[SerializeField]
		public List<string> OldUniqueIds;

		public TranslationTerm Name;

		public bool DeactivateGravity;

		internal Rigidbody Rigidbody;

		internal List<Collider> Colliders;

		internal bool HasWokenUp;

		private AudioObject _audioLoop;

		private bool _isPlaying;

		internal bool HasPlanetaryGravity;

		internal float StartDrag;

		internal float StartAngularDrag;

		private Vector3 _lastVelocity;

		private Vector3 _acceleration;

		private bool _hasRigidbody;

		private float _airResistance;

		private float _gravity;

		public bool HasUniqueId(string id)
		{
			if (id == UniqueId)
			{
				return true;
			}
			if (OldUniqueIds != null)
			{
				return OldUniqueIds.Contains(id);
			}
			return false;
		}

		protected virtual void Awake()
		{
			Rigidbody = GetComponent<Rigidbody>();
			_hasRigidbody = Rigidbody != null;
			Colliders = (from c in GetComponentsInChildren<Collider>()
				where !c.isTrigger
				select c).ToList();
			HasPlanetaryGravity = RunningModeSpecifics.Has(ERunningModeSpecific.CentralGravity);
		}

		protected virtual void Start()
		{
			_gravity = WorldController.TerrainSettings.GetGravityModifier();
			_airResistance = WorldController.TerrainSettings.GetAirResistanceModifier();
			if (_hasRigidbody)
			{
				StartDrag = Rigidbody.drag;
				StartAngularDrag = Rigidbody.angularDrag;
				Rigidbody.drag = StartDrag * _airResistance;
				Rigidbody.angularDrag = StartAngularDrag * _airResistance;
			}
		}

		[ContextMenu("GenerateNewUniqueId")]
		public void GenerateNewUniqueId()
		{
			UniqueId = Guid.NewGuid().ToString();
		}

		public virtual void OnDisable()
		{
			HasWokenUp = false;
			StopActiveSoundLoop();
		}

		internal void StartSoundLoop(string sound, float volume = 1f, float pitch = 1f)
		{
			if (!_isPlaying && !string.IsNullOrEmpty(sound) && (!(_audioLoop != null) || !_audioLoop.IsPlaying()))
			{
				_audioLoop = AudioController.Play(sound, base.transform, volume);
				if (_audioLoop != null)
				{
					_audioLoop.pitch = RuntimeGlobals.TimeScale;
					_isPlaying = true;
				}
			}
		}

		internal AudioObject PlaySound(string sound, bool parent = true)
		{
			if (string.IsNullOrEmpty(sound))
			{
				return null;
			}
			AudioObject audioObject = AudioController.Play(sound, base.transform.position, parent ? base.transform : null);
			if (audioObject != null)
			{
				audioObject.pitch = RuntimeGlobals.TimeScale;
			}
			return audioObject;
		}

		internal void StopActiveSoundLoop()
		{
			if (_isPlaying)
			{
				if (_audioLoop != null)
				{
					_audioLoop.Stop(0.1f);
					_isPlaying = false;
				}
				_isPlaying = false;
			}
		}

		public virtual void FixedUpdate()
		{
			_gravity = WorldController.TerrainSettings.GetGravityModifier();
			float airResistanceModifier = WorldController.TerrainSettings.GetAirResistanceModifier();
			if (_hasRigidbody && Math.Abs(airResistanceModifier - _airResistance) > 0.01f)
			{
				_airResistance = airResistanceModifier;
				Rigidbody.drag = StartDrag * _airResistance;
				Rigidbody.angularDrag = StartAngularDrag * _airResistance;
			}
			if (_hasRigidbody && !Rigidbody.isKinematic && !DeactivateGravity)
			{
				Vector3 velocity = Rigidbody.velocity;
				float fixedDeltaTime = Time.fixedDeltaTime;
				Vector3 vector = ((!HasPlanetaryGravity) ? (velocity + 9.81f * fixedDeltaTime * -Vector3.up * _gravity) : (velocity + 9.81f * fixedDeltaTime * -base.transform.position.normalized * _gravity));
				_acceleration = (vector - _lastVelocity) / fixedDeltaTime;
				_lastVelocity = vector;
				Rigidbody.velocity = vector;
			}
		}

		public void EnableColliders(bool enable)
		{
			foreach (Collider collider in Colliders)
			{
				collider.enabled = enable;
			}
		}

		public Vector2 GetAcceleration()
		{
			return _acceleration;
		}

		public Vector2 GetGravityDirection(Vector2 position)
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.BossFight && BossfightManager.Instance.Settings.HasCustomGravity)
			{
				return BossfightManager.Instance.Settings.GravityCenter - position;
			}
			if (HasPlanetaryGravity)
			{
				return Vector2.zero - position;
			}
			return -Vector2.up;
		}

		public virtual void Update()
		{
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !HasWokenUp)
			{
				WakeUp();
				HasWokenUp = true;
			}
			if (_audioLoop != null)
			{
				_audioLoop.pitch = RuntimeGlobals.TimeScale;
			}
		}

		public virtual void WakeUp()
		{
		}
	}
}
