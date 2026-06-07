using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Raycast Floor")]
	[Description("Returns true if there is an obstacle the specified units below the character")]
	[Category("Characters/Navigation/Raycast Floor")]
	[Keywords(new string[] { "Floor", "Stand", "Land", "Ground", "Obstacle" })]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Blue, typeof(OverlayArrowDown))]
	public class ConditionCharacterRaycastFloor : TConditionCharacter
	{
		[SerializeField]
		private LayerMask m_LayerMask = -5;

		[SerializeField]
		private PropertyGetDecimal m_Distance = GetDecimalDecimal.Create(5f);

		protected override string Summary => $"is floor below {m_Character} {m_Distance}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return false;
			}
			if (character.Driver.IsGrounded)
			{
				return true;
			}
			float maxDistance = (float)m_Distance.Get(args);
			return Physics.Raycast(character.Feet, Vector3.down, maxDistance, m_LayerMask, QueryTriggerInteraction.Ignore);
		}
	}
}
