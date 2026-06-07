using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace WaveHarmonic.Crest.RelativeSpace
{
	[AddComponentMenu("Crest/Crest Shifting Origin")]
	public sealed class ShiftingOrigin : MonoBehaviour
	{
		[Serializable]
		internal sealed class DebugFields
		{
			[Tooltip("Pause editor on origin shift.")]
			[SerializeField]
			internal bool _PauseOnShift;

			[Tooltip("Pause editor before origin shift. When it meets the threshold it postpones the shift to the next frame and pauses this frame.")]
			[SerializeField]
			internal bool _PauseBeforeShift;

			[Tooltip("Log to console on origin shift.")]
			[SerializeField]
			internal bool _LogOnShift;

			internal bool _IsCapturing;

			internal bool _ShiftNextX;

			internal bool _ShiftNextY;

			internal bool _ShiftNextZ;
		}

		public static class ShaderIDs
		{
			public static readonly int s_ShiftingOriginOffset = Shader.PropertyToID("g_Crest_ShiftingOriginOffset");
		}

		[SerializeField]
		[HideInInspector]
		private int _Version;

		[Tooltip("Use a power of 2 to avoid pops in water surface geometry.")]
		[SerializeField]
		internal int _Threshold = 16384;

		[Tooltip("The threshold to apply the sleep threshold.\n\nSet to zero to disable.")]
		[SerializeField]
		private float _PhysicsThreshold = 1000f;

		[Tooltip("The mass-normalized energy threshold, below which objects start going to sleep.")]
		[FormerlySerializedAs("_DefaultSleepThreshold")]
		[SerializeField]
		private float _PhysicsSleepThreshold = 0.14f;

		[Tooltip("Optionally provide a list of transforms to avoid doing a FindObjectsByType call.")]
		[SerializeField]
		private Transform[] _OverrideTransformList;

		[Tooltip("Optionally provide a list of particle systems to avoid doing a FindObjectsByType call.")]
		[SerializeField]
		private ParticleSystem[] _OverrideParticleSystemList;

		[Tooltip("Optionally provide a list of rigidbodies to avoid doing a FindObjectsByType call.")]
		[SerializeField]
		private Rigidbody[] _OverrideRigidBodyList;

		[Tooltip("Whether to operate in Integration Mode.\n\nIf enabled, it will no longer shift the origin for everything automatically. To shift the water origin, call ShiftWaterOrigin. This is useful if you are handling origin shift for other objects yourself.")]
		[SerializeField]
		private bool _IntegrationMode;

		[SpaceAttribute(10f)]
		[SerializeField]
		internal DebugFields _Debug = new DebugFields();

		private int _LastUpdateFrame;

		private ParticleSystem.Particle[] _ParticleBuffer;

		private Vector3 _OriginOffset;

		public bool IntegrationMode
		{
			get
			{
				return _IntegrationMode;
			}
			set
			{
				_IntegrationMode = value;
			}
		}

		public ParticleSystem[] OverrideParticleSystemList
		{
			get
			{
				return _OverrideParticleSystemList;
			}
			set
			{
				_OverrideParticleSystemList = value;
			}
		}

		public Rigidbody[] OverrideRigidBodyList
		{
			get
			{
				return _OverrideRigidBodyList;
			}
			set
			{
				_OverrideRigidBodyList = value;
			}
		}

		public Transform[] OverrideTransformList
		{
			get
			{
				return _OverrideTransformList;
			}
			set
			{
				_OverrideTransformList = value;
			}
		}

		public float PhysicsSleepThreshold
		{
			get
			{
				return _PhysicsSleepThreshold;
			}
			set
			{
				_PhysicsSleepThreshold = value;
			}
		}

		public float PhysicsThreshold
		{
			get
			{
				return _PhysicsThreshold;
			}
			set
			{
				_PhysicsThreshold = value;
			}
		}

		public int Threshold
		{
			get
			{
				return _Threshold;
			}
			set
			{
				_Threshold = value;
			}
		}

		public static Action<Vector3> OnShift { get; set; }

		public static Vector3 ShiftThisFrame { get; set; }

		public static bool HasTeleportedThisFrame { get; set; }

		private static WaitForEndOfFrame WaitForEndOfFrame { get; } = new WaitForEndOfFrame();

		private IEnumerator Start()
		{
			while (true)
			{
				yield return WaitForEndOfFrame;
				ShiftThisFrame = Vector3.zero;
				HasTeleportedThisFrame = false;
			}
		}

		private void OnDisable()
		{
			Shader.SetGlobalVector(ShaderIDs.s_ShiftingOriginOffset, Vector3.zero);
		}

		private void FixedUpdate()
		{
			if (_IntegrationMode || _LastUpdateFrame == Time.frameCount)
			{
				return;
			}
			_LastUpdateFrame = Time.frameCount;
			Vector3 zero = Vector3.zero;
			if (Mathf.Abs(base.transform.position.x) > (float)_Threshold)
			{
				zero.x += Mathf.Floor(base.transform.position.x / (float)_Threshold) * (float)_Threshold;
			}
			if (Mathf.Abs(base.transform.position.y) > (float)_Threshold)
			{
				zero.y += Mathf.Floor(base.transform.position.y / (float)_Threshold) * (float)_Threshold;
			}
			if (Mathf.Abs(base.transform.position.z) > (float)_Threshold)
			{
				zero.z += Mathf.Floor(base.transform.position.z / (float)_Threshold) * (float)_Threshold;
			}
			if (zero == Vector3.zero)
			{
				return;
			}
			if (_Debug._LogOnShift)
			{
				Debug.Log($"Crest.ShiftingOrigin.MoveOrigin({zero})");
			}
			if (zero == Vector3.zero)
			{
				return;
			}
			Transform[] overrideTransformList = _OverrideTransformList;
			Transform[] array = ((overrideTransformList != null && overrideTransformList.Length != 0) ? _OverrideTransformList : Helpers.FindObjectsByType<Transform>());
			foreach (Transform transform in array)
			{
				if (transform.parent == null)
				{
					transform.position -= zero;
				}
			}
			ParticleSystem[] overrideParticleSystemList = _OverrideParticleSystemList;
			ParticleSystem[] array2 = ((overrideParticleSystemList != null && overrideParticleSystemList.Length != 0) ? _OverrideParticleSystemList : Helpers.FindObjectsByType<ParticleSystem>());
			foreach (ParticleSystem particleSystem in array2)
			{
				if (particleSystem.main.simulationSpace != ParticleSystemSimulationSpace.World)
				{
					continue;
				}
				int maxParticles = particleSystem.main.maxParticles;
				if (maxParticles > 0)
				{
					bool isPaused = particleSystem.isPaused;
					bool isPlaying = particleSystem.isPlaying;
					if (!isPaused)
					{
						particleSystem.Pause();
					}
					if (_ParticleBuffer == null || _ParticleBuffer.Length < maxParticles)
					{
						_ParticleBuffer = new ParticleSystem.Particle[maxParticles];
					}
					int particles = particleSystem.GetParticles(_ParticleBuffer);
					for (int j = 0; j < particles; j++)
					{
						_ParticleBuffer[j].position -= zero;
					}
					particleSystem.SetParticles(_ParticleBuffer, particles);
					if (isPlaying)
					{
						particleSystem.Play();
					}
				}
			}
			if (_PhysicsThreshold > 0f)
			{
				float num = _PhysicsThreshold * _PhysicsThreshold;
				Rigidbody[] overrideRigidBodyList = _OverrideRigidBodyList;
				Rigidbody[] array3 = ((overrideRigidBodyList != null && overrideRigidBodyList.Length != 0) ? _OverrideRigidBodyList : Helpers.FindObjectsByType<Rigidbody>());
				foreach (Rigidbody rigidbody in array3)
				{
					if (rigidbody.gameObject.transform.position.sqrMagnitude > num)
					{
						rigidbody.sleepThreshold = float.MaxValue;
					}
					else
					{
						rigidbody.sleepThreshold = _PhysicsSleepThreshold;
					}
				}
			}
			ShiftWaterOrigin(zero);
		}

		public void ShiftWaterOrigin(Vector3 offset)
		{
			if (!(offset == Vector3.zero))
			{
				ShiftThisFrame = offset;
				HasTeleportedThisFrame = true;
				_OriginOffset -= offset;
				Shader.SetGlobalVector(ShaderIDs.s_ShiftingOriginOffset, _OriginOffset);
				OnShift?.Invoke(offset);
			}
		}
	}
}
