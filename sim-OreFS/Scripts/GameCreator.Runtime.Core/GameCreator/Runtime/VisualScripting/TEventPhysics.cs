using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	public abstract class TEventPhysics : Event
	{
		private Args m_ArgsCollider;

		[SerializeField]
		private CompareGameObjectOrAny m_Collider = new CompareGameObjectOrAny();

		public override bool RequiresCollider => true;

		protected GameObject Collider => m_Collider.Get(m_ArgsCollider);

		protected internal override void OnAwake(Trigger trigger)
		{
			base.OnAwake(trigger);
			m_ArgsCollider = new Args(trigger.gameObject);
			trigger.RequireRigidbody();
		}

		protected bool Match(GameObject gameObject)
		{
			return m_Collider.Match(gameObject, m_ArgsCollider);
		}
	}
}
