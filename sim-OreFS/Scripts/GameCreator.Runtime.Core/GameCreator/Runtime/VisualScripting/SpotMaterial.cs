using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Material")]
	[Image(typeof(IconMaterial), ColorTheme.Type.Blue)]
	[Category("Materials/Change Material")]
	[Description("Changes the Material depending on whether the Hotspot is active or not")]
	[Keywords(new string[] { "Material", "Color", "Shader" })]
	public class SpotMaterial : Spot
	{
		[SerializeField]
		private PropertySetMaterial m_Target = SetMaterialNone.Create;

		[SerializeField]
		private PropertyGetMaterial m_OnActive = new PropertyGetMaterial();

		[SerializeField]
		private PropertyGetMaterial m_OnInactive = new PropertyGetMaterial();

		[NonSerialized]
		private bool m_WasActive;

		public override string Title => $"Material {m_OnActive} / {m_OnInactive}";

		public override void OnEnable(Hotspot hotspot)
		{
			base.OnEnable(hotspot);
			m_WasActive = false;
		}

		public override void OnDisable(Hotspot hotspot)
		{
			base.OnDisable(hotspot);
			if (!ApplicationManager.IsExiting && m_WasActive)
			{
				Args args = new Args(hotspot.gameObject, hotspot.Target);
				Material value = m_OnInactive.Get(args);
				m_Target.Set(value, args);
			}
		}

		public override void OnUpdate(Hotspot hotspot)
		{
			base.OnUpdate(hotspot);
			if (!m_WasActive)
			{
				if (hotspot.IsActive)
				{
					Args args = new Args(hotspot.gameObject, hotspot.Target);
					Material value = m_OnActive.Get(args);
					m_Target.Set(value, args);
				}
			}
			else if (!hotspot.IsActive)
			{
				Args args2 = new Args(hotspot.gameObject, hotspot.Target);
				Material value2 = m_OnInactive.Get(args2);
				m_Target.Set(value2, args2);
			}
			m_WasActive = hotspot.IsActive;
		}
	}
}
