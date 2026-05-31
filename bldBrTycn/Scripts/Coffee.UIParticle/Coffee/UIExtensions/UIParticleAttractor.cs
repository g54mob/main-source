using System;
using Coffee.UIParticleExtensions;
using UnityEngine;
using UnityEngine.Events;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	public class UIParticleAttractor : MonoBehaviour
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
		private ParticleSystem m_ParticleSystem;

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

		private UIParticle _uiParticle;

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

		public ParticleSystem particleSystem
		{
			get
			{
				return m_ParticleSystem;
			}
			set
			{
				m_ParticleSystem = value;
				ApplyParticleSystem();
			}
		}

		private void OnEnable()
		{
			ApplyParticleSystem();
			UIParticleUpdater.Register(this);
		}

		private void OnDisable()
		{
			UIParticleUpdater.Unregister(this);
		}

		private void OnDestroy()
		{
			_uiParticle = null;
			m_ParticleSystem = null;
		}

		internal void Attract()
		{
			if (m_ParticleSystem == null)
			{
				return;
			}
			int particleCount = m_ParticleSystem.particleCount;
			if (particleCount == 0)
			{
				return;
			}
			ParticleSystem.Particle[] particleArray = ParticleSystemExtensions.GetParticleArray(particleCount);
			m_ParticleSystem.GetParticles(particleArray, particleCount);
			Vector3 destinationPosition = GetDestinationPosition();
			for (int i = 0; i < particleCount; i++)
			{
				ParticleSystem.Particle particle = particleArray[i];
				if (0f < particle.remainingLifetime && Vector3.Distance(particle.position, destinationPosition) < m_DestinationRadius)
				{
					particle.remainingLifetime = 0f;
					particleArray[i] = particle;
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
						particleArray[i] = particle;
					}
				}
			}
			m_ParticleSystem.SetParticles(particleArray, particleCount);
		}

		private Vector3 GetDestinationPosition()
		{
			bool num = (bool)_uiParticle && _uiParticle.enabled;
			Vector3 position = m_ParticleSystem.transform.position;
			Vector3 vector = base.transform.position;
			if (m_ParticleSystem.IsLocalSpace())
			{
				vector = m_ParticleSystem.transform.InverseTransformPoint(vector);
			}
			if (num)
			{
				Vector3 vector2 = _uiParticle.parentScale.Inverse();
				Vector3 scale3DForCalc = _uiParticle.scale3DForCalc;
				vector = vector.GetScaled(vector2, scale3DForCalc.Inverse());
				if (_uiParticle.positionMode == UIParticle.PositionMode.Relative)
				{
					Vector3 vector3 = _uiParticle.transform.position - position;
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

		private void ApplyParticleSystem()
		{
			_uiParticle = null;
			if (m_ParticleSystem == null)
			{
				Debug.LogError("No particle system attached to particle attractor script", this);
				return;
			}
			_uiParticle = m_ParticleSystem.GetComponentInParent<UIParticle>(includeInactive: true);
			if ((bool)_uiParticle && !_uiParticle.particles.Contains(m_ParticleSystem))
			{
				_uiParticle = null;
			}
		}
	}
}
