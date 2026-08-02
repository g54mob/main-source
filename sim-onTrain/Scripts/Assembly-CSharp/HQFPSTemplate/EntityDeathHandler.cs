using UnityEngine;

namespace HQFPSTemplate
{
	public class EntityDeathHandler : EntityComponent
	{
		[Header("Audio")]
		[SerializeField]
		private AudioSource m_AudioSource;

		[SerializeField]
		private SoundPlayer m_DeathAudio;

		[Header("Stuff To Disable On Death")]
		[SerializeField]
		private GameObject[] m_ObjectsToDisable;

		[SerializeField]
		private Behaviour[] m_BehavioursToDisable;

		[SerializeField]
		private Collider[] m_CollidersToDisable;

		[Header("Death Animation")]
		[SerializeField]
		[Tooltip("On death, you can either have a ragdoll, or an animation to play.")]
		private bool m_EnableDeathAnim;

		[SerializeField]
		private Animator m_Animator;

		[Header("Destroy Timer")]
		[SerializeField]
		[Clamp(0f, 1000f)]
		[Tooltip("")]
		private float m_DestroyTimer;

		private void Awake()
		{
		}

		private void OnChanged_Health(float health)
		{
			if (health == 0f)
			{
				On_Death();
			}
		}

		private void On_Death()
		{
			m_DeathAudio.Play(ItemSelection.Method.Random, m_AudioSource);
			if (m_EnableDeathAnim && (bool)m_Animator)
			{
				m_Animator.SetTrigger("Die");
			}
			GameObject[] objectsToDisable = m_ObjectsToDisable;
			for (int i = 0; i < objectsToDisable.Length; i++)
			{
				objectsToDisable[i].SetActive(value: false);
			}
			Behaviour[] behavioursToDisable = m_BehavioursToDisable;
			foreach (Behaviour behaviour in behavioursToDisable)
			{
				Animator animator = behaviour as Animator;
				if (animator != null)
				{
					Object.Destroy(animator);
				}
				else
				{
					behaviour.enabled = false;
				}
			}
			Collider[] collidersToDisable = m_CollidersToDisable;
			for (int i = 0; i < collidersToDisable.Length; i++)
			{
				collidersToDisable[i].enabled = false;
			}
			Object.Destroy(base.gameObject, m_DestroyTimer);
			base.Entity.Death.Send();
		}
	}
}
