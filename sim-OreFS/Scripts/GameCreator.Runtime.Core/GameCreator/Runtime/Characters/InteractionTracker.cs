using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	public class InteractionTracker : MonoBehaviour, IInteractive, ISpatialHash
	{
		private const HideFlags FLAGS = HideFlags.HideAndDontSave | HideFlags.HideInInspector;

		[NonSerialized]
		private Vector3 m_LastPosition;

		[NonSerialized]
		private int m_InstanceID;

		[NonSerialized]
		private bool m_IsInteracting;

		[NonSerialized]
		private Character m_Character;

		GameObject IInteractive.Instance => base.gameObject;

		int IInteractive.InstanceID => m_InstanceID;

		bool IInteractive.IsInteracting => m_IsInteracting;

		public event Action<Character, IInteractive> EventInteract;

		public event Action<Character, IInteractive> EventStop;

		public static InteractionTracker Require(GameObject target)
		{
			InteractionTracker interactionTracker = target.Get<InteractionTracker>();
			if (!(interactionTracker != null))
			{
				return target.Add<InteractionTracker>();
			}
			return interactionTracker;
		}

		private void Awake()
		{
			base.hideFlags = HideFlags.HideAndDontSave | HideFlags.HideInInspector;
			m_InstanceID = base.gameObject.GetInstanceID();
		}

		private void OnEnable()
		{
			m_LastPosition = base.transform.position;
			SpatialHashInteractions.Insert(this);
		}

		private void OnDisable()
		{
			SpatialHashInteractions.Remove(this);
		}

		void IInteractive.Interact(Character character)
		{
			if (!m_IsInteracting)
			{
				m_IsInteracting = true;
				m_Character = character;
				this.EventInteract?.Invoke(character, this);
			}
		}

		void IInteractive.Stop()
		{
			if (m_IsInteracting)
			{
				m_IsInteracting = false;
				this.EventStop?.Invoke(m_Character, this);
			}
		}
	}
}
