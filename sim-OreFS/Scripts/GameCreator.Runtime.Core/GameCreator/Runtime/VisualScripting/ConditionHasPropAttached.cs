using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Has Prop Attached")]
	[Description("Returns true if the Character has a Prop attached to the specified bone")]
	[Category("Characters/Visuals/Has Prop Attached")]
	[Parameter("Bone", "The bone that has the prop attached to")]
	[Keywords(new string[] { "Characters", "Holds", "Grab", "Draw", "Pull", "Take", "Object" })]
	[Image(typeof(IconTennis), ColorTheme.Type.Yellow)]
	public class ConditionHasPropAttached : TConditionCharacter
	{
		[SerializeField]
		private Bone m_Bone = new Bone(HumanBodyBones.RightHand);

		protected override string Summary => $"has {m_Character} Prop at {m_Bone}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Props.HasAtBone(m_Bone);
			}
			return false;
		}
	}
}
