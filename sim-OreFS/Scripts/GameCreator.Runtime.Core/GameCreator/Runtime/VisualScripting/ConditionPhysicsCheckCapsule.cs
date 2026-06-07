using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Check Capsule")]
	[Description("Returns true if casting a capsule at a position collides with something")]
	[Category("Physics/Check Capsule")]
	[Parameter("Position", "The scene position where the capsule's center is cast")]
	[Parameter("Height", "The height of the capsule in Unity units")]
	[Parameter("Radius", "The radius of the capsule in Unity units")]
	[Parameter("Layer Mask", "A bitmask that skips any objects that don't belong to the list")]
	[Example("Note that this Instruction uses Unity's 3D physics engine. It won't collide with any 2D objects")]
	[Keywords(new string[] { "Check", "Collide", "Touch", "Suit", "Character", "Fit", "3D" })]
	[Image(typeof(IconCapsuleSolid), ColorTheme.Type.Green)]
	public class ConditionPhysicsCheckCapsule : Condition
	{
		[SerializeField]
		private PropertyGetPosition m_Position = GetPositionCharactersPlayer.Create;

		[SerializeField]
		private PropertyGetDecimal m_Height = GetDecimalCharacterHeight.Create;

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalCharacterRadius.Create;

		[SerializeField]
		private LayerMask m_LayerMask = -5;

		protected override string Summary => $"check Capsule at {m_Position}";

		protected override bool Run(Args args)
		{
			Vector3 vector = m_Position.Get(args);
			float num = (float)m_Height.Get(args);
			return Physics.CheckCapsule(vector + Vector3.up * (num * 0.5f), vector - Vector3.up * (num * 0.5f), (float)m_Radius.Get(args), m_LayerMask, QueryTriggerInteraction.Ignore);
		}
	}
}
