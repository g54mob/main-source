using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Characters.IK;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Look At")]
	[Image(typeof(IconEye), ColorTheme.Type.Green)]
	[Category("Characters/Look At")]
	[Description("Makes the Character look at the center of the Hotspot when it's activatedand smoothly look away when it's deactivated")]
	public class SpotLook : Spot
	{
		[SerializeField]
		protected int m_Priority;

		[SerializeField]
		protected PropertyGetDirection m_Offset = GetDirectionVector3Zero.Create();

		[NonSerialized]
		private bool m_WasActive;

		public override string Title => "Character look when near";

		public override void OnUpdate(Hotspot hotspot)
		{
			base.OnUpdate(hotspot);
			bool flag = EnableInstance(hotspot);
			if (!m_WasActive && flag)
			{
				GetCharacterLook(hotspot)?.SetTarget(new LookToTransform(m_Priority, hotspot.transform, m_Offset.Get(hotspot.Args)));
			}
			if (m_WasActive && !flag)
			{
				GetCharacterLook(hotspot)?.RemoveTarget(new LookToTransform(m_Priority, hotspot.transform, m_Offset.Get(hotspot.Args)));
			}
			m_WasActive = flag;
		}

		public override void OnDisable(Hotspot hotspot)
		{
			base.OnDisable(hotspot);
			m_WasActive = false;
			GetCharacterLook(hotspot)?.RemoveTarget(new LookToTransform(m_Priority, hotspot.transform, m_Offset.Get(hotspot.Args)));
		}

		public override void OnDestroy(Hotspot hotspot)
		{
			base.OnDestroy(hotspot);
			m_WasActive = false;
			GetCharacterLook(hotspot)?.RemoveTarget(new LookToTransform(m_Priority, hotspot.transform, m_Offset.Get(hotspot.Args)));
		}

		protected virtual bool EnableInstance(Hotspot hotspot)
		{
			return hotspot.IsActive;
		}

		private RigLookTo GetCharacterLook(Hotspot hotspot)
		{
			if (hotspot.Target == null)
			{
				return null;
			}
			Character character = hotspot.Target.Get<Character>();
			if (!(character != null))
			{
				return null;
			}
			return character.IK.GetRig<RigLookTo>();
		}
	}
}
