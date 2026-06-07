using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Dash
	{
		private static readonly int HASH = Tween.GetHash(typeof(Transform), "position");

		private const int GRAVITY_INFLUENCE_KEY = 1;

		[NonSerialized]
		private Character m_Character;

		[NonSerialized]
		private bool m_HasDodged;

		[NonSerialized]
		private float m_LastDashFinishTime = -100f;

		[NonSerialized]
		private int m_NumDashes;

		[field: NonSerialized]
		public bool IsDashing { get; private set; }

		public bool IsDodge
		{
			get
			{
				if (IsDashing)
				{
					return m_Character.Combat.Invincibility.IsInvincible;
				}
				return false;
			}
		}

		public event Action EventDashStart;

		public event Action EventDashFinish;

		public event Action EventDodge;

		internal void OnStartup(Character character)
		{
			m_Character = character;
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnDispose(Character character)
		{
			m_Character = character;
		}

		internal void OnEnable()
		{
		}

		internal void OnDisable()
		{
		}

		public bool CanDash()
		{
			if (m_Character.Busy.AreLegsBusy)
			{
				return false;
			}
			if (!m_Character.Motion.DashInAir && !m_Character.Driver.IsGrounded)
			{
				return false;
			}
			if (IsDashing)
			{
				return false;
			}
			float num = m_LastDashFinishTime + m_Character.Motion.DashCooldown;
			if (m_Character.Time.Time >= num)
			{
				return true;
			}
			return m_NumDashes <= m_Character.Motion.DashInSuccession;
		}

		public async Task Execute(Vector3 direction, float speed, float gravity, float duration, float fade)
		{
			m_HasDodged = false;
			float num = m_LastDashFinishTime + m_Character.Motion.DashCooldown;
			m_NumDashes = ((!(m_Character.Time.Time < num)) ? 1 : (m_NumDashes + 1));
			IsDashing = true;
			if (!Mathf.Approximately(gravity, 1f))
			{
				m_Character.Driver.SetGravityInfluence(1, gravity);
			}
			this.EventDashStart?.Invoke();
			direction = Vector3.Scale(direction, Vector3Plane.NormalUp);
			direction = ((direction.sqrMagnitude > float.Epsilon) ? direction.normalized : Vector3.forward);
			m_Character.Motion.SetMotionTransient(direction, speed, duration, fade);
			TweenInput<float> tweenInput = new TweenInput<float>(0f, 1f, duration, HASH, Easing.Type.Linear);
			tweenInput.EventFinish += OnDashFinish;
			Tween.To(m_Character.gameObject, tweenInput);
			while (IsDashing && !ApplicationManager.IsExiting)
			{
				await Task.Yield();
			}
			m_LastDashFinishTime = m_Character.Time.Time;
		}

		public void Cancel()
		{
			if (IsDashing)
			{
				Tween.Cancel(m_Character.gameObject, HASH);
			}
		}

		public void OnDodge(Args args)
		{
			if (!m_HasDodged)
			{
				Weapon[] weapons = m_Character.Combat.Weapons;
				for (int i = 0; i < weapons.Length; i++)
				{
					weapons[i].Asset.RunOnDodge(m_Character, args);
				}
				this.EventDodge?.Invoke();
				m_HasDodged = true;
			}
		}

		private void OnDashFinish(bool isComplete)
		{
			m_Character.Busy.RemoveLegsBusy();
			IsDashing = false;
			m_Character.Driver.RemoveGravityInfluence(1);
			this.EventDashFinish?.Invoke();
		}
	}
}
