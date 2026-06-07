using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Ragdoll
	{
		[SerializeReference]
		private TRagdollSystem m_Ragdoll = new RagdollNone();

		private Character m_Character;

		[field: NonSerialized]
		public bool IsRagdoll { get; private set; }

		public event Action EventBeforeStartRagdoll;

		public event Action EventAfterStartRagdoll;

		public event Action EventBeforeStartRecover;

		public event Action EventAfterStartRecover;

		public event Action EventAfterFinishRecover;

		internal void OnStartup(Character character)
		{
			m_Character = character;
			m_Ragdoll?.OnStartup(character);
		}

		internal void OnDispose(Character character)
		{
			m_Character = character;
			m_Ragdoll?.OnDispose(character);
		}

		internal void OnEnable()
		{
			m_Ragdoll?.OnEnable(m_Character);
		}

		internal void OnDisable()
		{
			m_Ragdoll?.OnDisable(m_Character);
		}

		internal void OnUpdate()
		{
			m_Ragdoll?.OnUpdate(m_Character);
		}

		internal void OnLateUpdate()
		{
			m_Ragdoll?.OnLateUpdate(m_Character);
		}

		public T Get<T>() where T : TRagdollSystem
		{
			return m_Ragdoll as T;
		}

		public async Task StartRagdoll()
		{
			if (m_Ragdoll != null && !(m_Character.Animim.Animator == null) && !IsRagdoll)
			{
				this.EventBeforeStartRagdoll?.Invoke();
				await m_Ragdoll.StartRagdoll(m_Character);
				IsRagdoll = true;
				await Task.Yield();
				this.EventAfterStartRagdoll?.Invoke();
			}
		}

		public async Task StartRecover()
		{
			if (m_Ragdoll != null && !(m_Character.Animim.Animator == null) && IsRagdoll)
			{
				this.EventBeforeStartRecover?.Invoke();
				await m_Ragdoll.StopRagdoll(m_Character);
				this.EventAfterStartRecover?.Invoke();
				await m_Ragdoll.RecoverRagdoll(m_Character);
				IsRagdoll = false;
				this.EventAfterFinishRecover?.Invoke();
			}
		}

		internal void OnDrawGizmos(Character character)
		{
		}
	}
}
