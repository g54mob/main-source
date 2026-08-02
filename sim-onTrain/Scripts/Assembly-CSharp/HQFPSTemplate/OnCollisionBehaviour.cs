using UnityEngine;
using UnityEngine.Events;

namespace HQFPSTemplate
{
	[DisallowMultipleComponent]
	public class OnCollisionBehaviour : MonoBehaviour, IObjectReferenceFiller
	{
		[SerializeField]
		private bool m_ListenForCollisions = true;

		[Space]
		[SerializeField]
		private LayerMask m_LayerMask;

		[SerializeField]
		private AudioSource m_AudioSource;

		[Space]
		[SerializeField]
		[EnableIf("m_ListenForCollisions", true, 0f)]
		private int m_MaxCollisionsAmount;

		[SerializeField]
		[EnableIf("m_ListenForCollisions", true, 0f)]
		private float m_CollisionTimeThreshold = 0.5f;

		[SerializeField]
		[EnableIf("m_ListenForCollisions", true, 0f)]
		private float m_CollisionVelocityThreshold = 2f;

		[Space]
		[SerializeField]
		private UnityEvent m_OnCollisionEvent = new UnityEvent();

		[SerializeField]
		[Group]
		private SoundPlayer m_OnCollisionAudio;

		private int m_CurrentCollisionsAmount;

		private float m_NextTimeStartCollisionEvent;

		public bool ListenForCollisions
		{
			get
			{
				return m_ListenForCollisions;
			}
			set
			{
				m_ListenForCollisions = value;
			}
		}

		public void TryAutoFillObjectReferences()
		{
			m_AudioSource = GetComponent<AudioSource>();
		}

		private void OnCollisionEnter(Collision col)
		{
			if ((m_MaxCollisionsAmount <= 0 || m_CurrentCollisionsAmount <= m_MaxCollisionsAmount) && !(Time.time < m_NextTimeStartCollisionEvent) && (int)m_LayerMask == ((int)m_LayerMask | (1 << col.collider.gameObject.layer)) && !(col.relativeVelocity.magnitude < m_CollisionVelocityThreshold))
			{
				float volume = Mathf.Clamp(col.relativeVelocity.sqrMagnitude / m_CollisionVelocityThreshold / 10f, 0.2f, 1f);
				if (m_AudioSource != null)
				{
					m_OnCollisionAudio.Play(ItemSelection.Method.RandomExcludeLast, m_AudioSource, volume);
				}
				else
				{
					m_OnCollisionAudio.PlayAtPosition(ItemSelection.Method.RandomExcludeLast, base.transform.position, volume);
				}
				m_OnCollisionEvent.Invoke();
				m_NextTimeStartCollisionEvent = Time.time + m_CollisionTimeThreshold;
				m_CurrentCollisionsAmount++;
			}
		}
	}
}
