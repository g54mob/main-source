using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Check Character 3D Fits")]
	[Description("Returns true if the character fits with the new radius and height values")]
	[Category("Physics/Check Character 3D Fits")]
	[Parameter("Character", "The character to check")]
	[Parameter("Height", "The height of the character in Unity units")]
	[Parameter("Radius", "The radius of the character in Unity units")]
	[Parameter("Layer Mask", "A bitmask that skips any objects that don't belong to the list")]
	[Example("Note that this Instruction uses Unity's 3D physics engine. It won't collide with any 2D objects")]
	[Keywords(new string[] { "Check", "Collide", "Capsule", "Touch", "Suit", "Character", "Fit", "3D" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Green, typeof(OverlayPhysics))]
	public class ConditionPhysicsCharacter3DFits : Condition
	{
		private const float SAFE_OFFSET = 0.005f;

		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDecimal m_Height = GetDecimalCharacterHeight.Create;

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalCharacterRadius.Create;

		[SerializeField]
		private LayerMask m_LayerMask = -5;

		[NonSerialized]
		private Collider[] m_Hits = new Collider[32];

		protected override string Summary => $"check {m_Character} fits";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return false;
			}
			Vector3 vector = character.transform.position - Vector3.up * (character.Motion.Height * 0.5f);
			float num = (float)m_Height.Get(args);
			float num2 = (float)m_Radius.Get(args);
			int num3 = Physics.OverlapCapsuleNonAlloc(vector + Vector3.up * (num2 + 0.005f), vector + Vector3.up * (num2 + num + num2), num2 - 0.005f, m_Hits, m_LayerMask, QueryTriggerInteraction.Ignore);
			for (int i = 0; i < num3; i++)
			{
				Collider collider = m_Hits[i];
				if (!(collider == null) && !collider.transform.IsChildOf(character.transform))
				{
					return false;
				}
			}
			return true;
		}
	}
}
