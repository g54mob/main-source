using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Driver")]
	public abstract class TUnitDriver : TUnit, IUnitDriver, IUnitCommon
	{
		protected const float COYOTE_TIME = 0.3f;

		protected const int COYOTE_FRAMES = 2;

		[NonSerialized]
		private Dictionary<int, float> m_GravityInfluence;

		[NonSerialized]
		protected bool m_ForceGrounded;

		public abstract Vector3 WorldMoveDirection { get; }

		public abstract Vector3 LocalMoveDirection { get; }

		public abstract float SkinWidth { get; }

		public abstract bool IsGrounded { get; }

		public abstract Vector3 FloorNormal { get; }

		public float GravityInfluence
		{
			get
			{
				if (m_GravityInfluence.Count == 0)
				{
					return 1f;
				}
				float num = 1f;
				foreach (KeyValuePair<int, float> item in m_GravityInfluence)
				{
					if (!(num < item.Value))
					{
						num = item.Value;
					}
				}
				return num;
			}
		}

		[field: NonSerialized]
		public bool UpdateKinematics { get; set; } = true;

		public abstract bool Collision { get; set; }

		public abstract Axonometry Axonometry { get; set; }

		public virtual void OnStartup(Character character)
		{
			base.Character = character;
			m_GravityInfluence = new Dictionary<int, float>();
		}

		public virtual void AfterStartup(Character character)
		{
			base.Character = character;
		}

		public virtual void OnDispose(Character character)
		{
			base.Character = character;
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public abstract void SetPosition(Vector3 position);

		public abstract void SetRotation(Quaternion rotation);

		public abstract void SetScale(Vector3 scale);

		public abstract void AddPosition(Vector3 amount);

		public abstract void AddRotation(Quaternion amount);

		public abstract void AddScale(Vector3 scale);

		public virtual void OnUpdate()
		{
		}

		public virtual void OnFixedUpdate()
		{
		}

		public virtual void OnDrawGizmos(Character character)
		{
		}

		public abstract void ResetVerticalVelocity();

		public void SetGravityInfluence(int key, float influence)
		{
			m_GravityInfluence[key] = influence;
		}

		public void RemoveGravityInfluence(int key)
		{
			m_GravityInfluence.Remove(key);
		}

		public void ForceGrounded(bool value)
		{
			m_ForceGrounded = value;
		}
	}
}
