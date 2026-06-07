using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineCollisionImpulseSource : CinemachineImpulseSource
	{
		public LayerMask m_LayerMask;

		[TagField]
		public string m_IgnoreTag;

		public bool m_UseImpactDirection;

		public bool m_ScaleImpactWithMass;

		public bool m_ScaleImpactWithSpeed;

		private Rigidbody mRigidBody;

		private Rigidbody2D mRigidBody2D;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnCollisionEnter(Collision c)
		{
		}

		private void OnTriggerEnter(Collider c)
		{
		}

		private float GetMassAndVelocity(Collider other, ref Vector3 vel)
		{
			return 0f;
		}

		private void GenerateImpactEvent(Collider other, Vector3 vel)
		{
		}

		private void OnCollisionEnter2D(Collision2D c)
		{
		}

		private void OnTriggerEnter2D(Collider2D c)
		{
		}

		private float GetMassAndVelocity2D(Collider2D other2d, ref Vector3 vel)
		{
			return 0f;
		}

		private void GenerateImpactEvent2D(Collider2D other2d, Vector3 vel)
		{
		}
	}
}
