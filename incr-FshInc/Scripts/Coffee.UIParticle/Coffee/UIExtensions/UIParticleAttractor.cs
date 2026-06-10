using System;
using System.Collections.Generic;
using Coffee.UIParticleInternal;
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
		private List<ParticleSystem> m_ParticleSystems = new List<ParticleSystem>();

		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_DestinationRadius = 1f;

		[Range(0f, 0.95f)]
		[SerializeField]
		private float m_DelayRate;

		[Range(0.001f, 100f)]
		[SerializeField]
		private float m_MaxSpeed = 1f;

		[SerializeField]
		private Movement m_Movement;

		[SerializeField]
		private UpdateMode m_UpdateMode;

		[SerializeField]
		private UnityEvent m_OnAttracted;

		private List<UIParticle> _uiParticles = new List<UIParticle>();

		public float destinationRadius
		{
			get
			{
				return m_DestinationRadius;
			}
			set
			{
				m_DestinationRadius = Mathf.Clamp(value, 0.1f, 10f);
			}
		}

		public float delay
		{
			get
			{
				return m_DelayRate;
			}
			set
			{
				m_DelayRate = value;
			}
		}

		public float maxSpeed
		{
			get
			{
				return m_MaxSpeed;
			}
			set
			{
				m_MaxSpeed = value;
			}
		}

		public Movement movement
		{
			get
			{
				return m_Movement;
			}
			set
			{
				m_Movement = value;
			}
		}

		public UpdateMode updateMode
		{
			get
			{
				return m_UpdateMode;
			}
			set
			{
				m_UpdateMode = value;
			}
		}

		public UnityEvent onAttracted
		{
			get
			{
				return m_OnAttracted;
			}
			set
			{
				m_OnAttracted = value;
			}
		}

		public IReadOnlyList<ParticleSystem> particleSystems => m_ParticleSystems;

		public void AddParticleSystem(ParticleSystem ps)
		{
			if (m_ParticleSystems == null)
			{
				m_ParticleSystems = new List<ParticleSystem>();
			}
			int num = m_ParticleSystems.IndexOf(ps);
			if (0 > num)
			{
				m_ParticleSystems.Add(ps);
				_uiParticles.Clear();
			}
		}

		public void RemoveParticleSystem(ParticleSystem ps)
		{
			if (m_ParticleSystems != null)
			{
				int num = m_ParticleSystems.IndexOf(ps);
				if (num >= 0)
				{
					m_ParticleSystems.RemoveAt(num);
					_uiParticles.Clear();
				}
			}
		}

		private void Awake()
		{
			UpgradeIfNeeded();
		}

		private void OnEnable()
		{
			UIParticleUpdater.Register(this);
		}

		private void OnDisable()
		{
			UIParticleUpdater.Unregister(this);
		}

		private void OnDestroy()
		{
			_uiParticles = null;
			m_ParticleSystems = null;
		}

		internal void Attract()
		{
			CollectUIParticlesIfNeeded();
			for (int i = 0; i < m_ParticleSystems.Count; i++)
			{
				ParticleSystem particleSystem = m_ParticleSystems[i];
				if (particleSystem == null || !particleSystem.gameObject.activeInHierarchy)
				{
					continue;
				}
				int particleCount = particleSystem.particleCount;
				if (particleCount == 0)
				{
					continue;
				}
				ParticleSystem.Particle[] particleArray = ParticleSystemExtensions.GetParticleArray(particleCount);
				particleSystem.GetParticles(particleArray, particleCount);
				UIParticle uiParticle = _uiParticles[i];
				Vector3 destinationPosition = GetDestinationPosition(uiParticle, particleSystem);
				for (int j = 0; j < particleCount; j++)
				{
					ParticleSystem.Particle particle = particleArray[j];
					if (0f < particle.remainingLifetime && Vector3.Distance(particle.position, destinationPosition) < m_DestinationRadius)
					{
						particle.remainingLifetime = 0f;
						particleArray[j] = particle;
						if (m_OnAttracted != null)
						{
							try
							{
								m_OnAttracted.Invoke();
							}
							catch (Exception exception)
							{
								Debug.LogException(exception);
							}
						}
					}
					else
					{
						float num = particle.startLifetime * m_DelayRate;
						float duration = particle.startLifetime - num;
						float num2 = Mathf.Max(0f, particle.startLifetime - particle.remainingLifetime - num);
						if (!(num2 <= 0f))
						{
							particle.position = GetAttractedPosition(particle.position, destinationPosition, duration, num2);
							particle.velocity *= 0.5f;
							particleArray[j] = particle;
						}
					}
				}
				particleSystem.SetParticles(particleArray, particleCount);
			}
		}

		private Vector3 GetDestinationPosition(UIParticle uiParticle, ParticleSystem particleSystem)
		{
			bool num = (bool)uiParticle && uiParticle.enabled;
			Vector3 position = particleSystem.transform.position;
			Vector3 vector = base.transform.position;
			if (particleSystem.IsLocalSpace())
			{
				vector = particleSystem.transform.InverseTransformPoint(vector);
			}
			if (num)
			{
				Vector3 vector2 = uiParticle.parentScale.Inverse();
				Vector3 scale3DForCalc = uiParticle.scale3DForCalc;
				vector = vector.GetScaled(vector2, scale3DForCalc.Inverse());
				if (uiParticle.positionMode == UIParticle.PositionMode.Relative)
				{
					Vector3 vector3 = uiParticle.transform.position - position;
					vector3.Scale(scale3DForCalc - vector2);
					vector3.Scale(scale3DForCalc.Inverse());
					vector += vector3;
				}
			}
			return vector;
		}

		private Vector3 GetAttractedPosition(Vector3 current, Vector3 target, float duration, float time)
		{
			float num = m_MaxSpeed;
			switch (m_UpdateMode)
			{
			case UpdateMode.Normal:
				num *= 60f * Time.deltaTime;
				break;
			case UpdateMode.UnscaledTime:
				num *= 60f * Time.unscaledDeltaTime;
				break;
			}
			switch (m_Movement)
			{
			case Movement.Linear:
				num /= duration;
				break;
			case Movement.Smooth:
				target = Vector3.Lerp(current, target, time / duration);
				break;
			case Movement.Sphere:
				target = Vector3.Slerp(current, target, time / duration);
				break;
			}
			return Vector3.MoveTowards(current, target, num);
		}

		private void CollectUIParticlesIfNeeded()
		{
			if (m_ParticleSystems.Count == 0 || _uiParticles.Count != 0)
			{
				return;
			}
			if (_uiParticles.Capacity < m_ParticleSystems.Capacity)
			{
				_uiParticles.Capacity = m_ParticleSystems.Capacity;
			}
			for (int i = 0; i < m_ParticleSystems.Count; i++)
			{
				ParticleSystem particleSystem = m_ParticleSystems[i];
				if (particleSystem == null)
				{
					_uiParticles.Add(null);
					continue;
				}
				UIParticle componentInParent = particleSystem.GetComponentInParent<UIParticle>(includeInactive: true);
				_uiParticles.Add(componentInParent.particles.Contains(particleSystem) ? componentInParent : null);
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			UpgradeIfNeeded();
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		private void UpgradeIfNeeded()
		{
			if (m_ParticleSystem != null)
			{
				if (!m_ParticleSystems.Contains(m_ParticleSystem))
				{
					m_ParticleSystems.Add(m_ParticleSystem);
				}
				m_ParticleSystem = null;
				Debug.Log("Upgraded!");
			}
		}
	}
}
