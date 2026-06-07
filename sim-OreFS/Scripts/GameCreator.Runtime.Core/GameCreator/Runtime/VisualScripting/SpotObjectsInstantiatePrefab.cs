using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Instantiate Prefab")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Category("Game Objects/Instantiate Prefab")]
	[Description("Creates or Activates a prefab game object when the Hotspot is enabled and deactivates it when the Hotspot is disabled")]
	public class SpotObjectsInstantiatePrefab : Spot
	{
		[SerializeField]
		protected PropertyGetGameObject m_Prefab = GetGameObjectInstance.Create();

		[SerializeField]
		protected PropertyGetDirection m_Offset = GetDirectionVector3Zero.Create();

		[NonSerialized]
		private GameObject m_Hint;

		public override string Title => $"Instantiate {m_Prefab}";

		public override void OnUpdate(Hotspot hotspot)
		{
			base.OnUpdate(hotspot);
			GameObject gameObject = RequireInstance(hotspot);
			if (!(gameObject == null))
			{
				Vector3 vector = m_Offset.Get(hotspot.Args);
				gameObject.transform.SetPositionAndRotation(hotspot.transform.position + vector, hotspot.transform.rotation);
				bool active = EnableInstance(hotspot);
				gameObject.SetActive(active);
			}
		}

		public override void OnDisable(Hotspot hotspot)
		{
			base.OnDisable(hotspot);
			if (m_Hint != null)
			{
				m_Hint.SetActive(value: false);
			}
		}

		public override void OnDestroy(Hotspot hotspot)
		{
			base.OnDestroy(hotspot);
			if (m_Hint != null)
			{
				UnityEngine.Object.Destroy(m_Hint);
			}
		}

		protected virtual bool EnableInstance(Hotspot hotspot)
		{
			return hotspot.IsActive;
		}

		private GameObject RequireInstance(Hotspot hotspot)
		{
			if (m_Hint == null)
			{
				GameObject gameObject = m_Prefab.Get(hotspot.Args);
				if (gameObject == null)
				{
					return null;
				}
				m_Hint = UnityEngine.Object.Instantiate(gameObject, hotspot.transform.position, hotspot.transform.rotation);
				m_Hint.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_Hint;
		}
	}
}
