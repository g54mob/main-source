using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	public class UIParticleAttractor : MonoBehaviour, ISerializationCallbackReceiver
	{
		public enum Movement
		{
			Linear = 0,
			Smooth = 1,
			Sphere = 2
		}

		public enum UpdateMode
		{
			Normal = 0,
			UnscaledTime = 1
		}

		[SerializeField]
		[HideInInspector]
		private ParticleSystem m_ParticleSystem;

		[SerializeField]
		private List<ParticleSystem> m_ParticleSystems;

		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_DestinationRadius;

		[Range(0f, 0.95f)]
		[SerializeField]
		private float m_DelayRate;

		[Range(0.001f, 100f)]
		[SerializeField]
		private float m_MaxSpeed;

		[SerializeField]
		private Movement m_Movement;

		[SerializeField]
		private UpdateMode m_UpdateMode;

		[SerializeField]
		private UnityEvent m_OnAttracted;

		private List<UIParticle> _uiParticles;

		public float destinationRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float delay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Movement movement
		{
			get
			{
				return default(Movement);
			}
			set
			{
			}
		}

		public UpdateMode updateMode
		{
			get
			{
				return default(UpdateMode);
			}
			set
			{
			}
		}

		public UnityEvent onAttracted
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IReadOnlyList<ParticleSystem> particleSystems => null;

		public void AddParticleSystem(ParticleSystem ps)
		{
		}

		public void RemoveParticleSystem(ParticleSystem ps)
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		internal void Attract()
		{
		}

		private Vector3 GetDestinationPosition(UIParticle uiParticle, ParticleSystem particleSystem)
		{
			return default(Vector3);
		}

		private Vector3 GetAttractedPosition(Vector3 current, Vector3 target, float duration, float time)
		{
			return default(Vector3);
		}

		private void CollectUIParticlesIfNeeded()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		private void UpgradeIfNeeded()
		{
		}
	}
}
