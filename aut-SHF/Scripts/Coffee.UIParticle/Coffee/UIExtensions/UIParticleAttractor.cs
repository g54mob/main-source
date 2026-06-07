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

		[SerializeField]
		private ParticleSystem m_ParticleSystem;

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
		private UnityEvent m_OnAttracted;

		private UIParticle _uiParticle;

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

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		internal void Attract()
		{
		}

		private Vector3 GetDestinationPosition()
		{
			return default(Vector3);
		}

		private Vector3 GetAttractedPosition(Vector3 current, Vector3 target, float duration, float time)
		{
			return default(Vector3);
		}
	}
}
