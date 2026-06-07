using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class FurnitureSpaceChecker : MonoBehaviour
	{
		[Header("Type")]
		[Tooltip("Whether this part of the space checker is the core of the furniture or just extra space in front of it")]
		[SerializeField]
		private bool m_furnitureCore;

		[Header("References")]
		[SerializeField]
		private BoxCollider m_collider;

		[SerializeField]
		private List<Renderer> m_renderers;

		private void OnEnable()
		{
			m_collider.enabled = false;
			foreach (Renderer renderer in m_renderers)
			{
				if (renderer != null)
				{
					renderer.enabled = false;
				}
				else
				{
					Debug.LogWarning("Missing renderer", this);
				}
			}
		}

		public void SetActive(bool active, bool phantom, Material material)
		{
			m_collider.enabled = active;
			if (active && m_furnitureCore && !phantom)
			{
				active = false;
			}
			m_collider.gameObject.layer = (phantom ? FurnitureSettings.PhantomLayer : FurnitureSettings.SpaceIndicatorLayer);
			foreach (Renderer renderer in m_renderers)
			{
				if (renderer != null)
				{
					renderer.enabled = active;
					renderer.sharedMaterial = material;
				}
			}
		}

		public bool SpaceCheck(int layerMask)
		{
			bool flag = !Physics.CheckBox(m_collider.bounds.center, new Vector3(m_collider.transform.lossyScale.x * m_collider.size.x / 2f, m_collider.transform.lossyScale.y * m_collider.size.y / 2f, m_collider.transform.lossyScale.z * m_collider.size.z / 2f), m_collider.transform.rotation, layerMask, (!m_furnitureCore) ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			SetSpaceCheckVisual(flag);
			return flag;
		}

		public void SetSpaceCheckVisual(bool result)
		{
			Material sharedMaterial = (result ? FurnitureSettings.ValidPhantomMaterial : FurnitureSettings.InvalidPhantomMaterial);
			foreach (Renderer renderer in m_renderers)
			{
				if (renderer != null)
				{
					renderer.sharedMaterial = sharedMaterial;
				}
			}
		}

		public Bounds GetBounds()
		{
			return m_collider.bounds;
		}
	}
}
