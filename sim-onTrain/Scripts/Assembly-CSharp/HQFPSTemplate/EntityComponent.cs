using UnityEngine;

namespace HQFPSTemplate
{
	public abstract class EntityComponent : MonoBehaviour
	{
		private Entity m_Entity;

		public Entity Entity
		{
			get
			{
				if (!m_Entity)
				{
					m_Entity = GetComponent<Entity>();
				}
				if (!m_Entity)
				{
					m_Entity = GetComponentInParent<Entity>();
				}
				return m_Entity;
			}
		}

		public virtual void OnEntityStart()
		{
		}
	}
}
