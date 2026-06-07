using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Infrastructure.Scenes.Sandbox.Services.Creatures
{
	public class CollisionFilter : MonoBehaviour
	{
		private struct CollisionData
		{
			public Vector3 contactPoint;

			public Vector3 impulseDirection;

			public float impulseMagnitude;

			public float timestamp;
		}

		[SerializeField]
		private float m_positionThreshold;

		[SerializeField]
		private float m_angleTolerance;

		[SerializeField]
		private float m_impulseTolerancePercent;

		[SerializeField]
		private int m_maxStoredCollisions;

		[SerializeField]
		private float m_collisionLifetime;

		private CollisionData[] stg;

		private int sth;

		private int sti;

		private float stj;

		private float stk;

		private float stl;

		private float stm;

		public event Action<Collision> stf
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void inm()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private bool inn(CollisionData a)
		{
			return false;
		}

		private void ino(CollisionData a)
		{
		}

		private void inp()
		{
		}

		public bool inq(Collision a)
		{
			return false;
		}
	}
}
