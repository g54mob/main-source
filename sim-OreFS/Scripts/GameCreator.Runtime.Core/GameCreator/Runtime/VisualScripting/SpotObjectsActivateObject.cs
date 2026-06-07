using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Activate Object")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Yellow)]
	[Category("Game Objects/Activate Object")]
	[Description("Activates a game object scene instance when the Hotspot is enabled and deactivates it when the Hotspot is disabled")]
	public class SpotObjectsActivateObject : Spot
	{
		[SerializeField]
		protected PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		public override string Title => $"Activate {m_GameObject}";

		public override void OnUpdate(Hotspot hotspot)
		{
			base.OnUpdate(hotspot);
			GameObject gameObject = m_GameObject.Get(hotspot.Args);
			if (!(gameObject == null))
			{
				bool active = EnableInstance(hotspot);
				gameObject.SetActive(active);
			}
		}

		public override void OnDisable(Hotspot hotspot)
		{
			base.OnDisable(hotspot);
			GameObject gameObject = m_GameObject.Get(hotspot.Args);
			if (!(gameObject == null))
			{
				gameObject.SetActive(value: false);
			}
		}

		protected virtual bool EnableInstance(Hotspot hotspot)
		{
			return hotspot.IsActive;
		}
	}
}
