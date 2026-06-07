using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Start Following")]
	[Description("Instructs a Character to follow another game object")]
	[Category("Characters/Navigation/Start Following")]
	[Parameter("Target", "The target game object to follow")]
	[Parameter("Min Distance", "Distance from the Target the Character aims to move when approaching the Target")]
	[Parameter("Max Distance", "Maximum distance to the Target the Character leaves before attempting to move closer")]
	[Keywords(new string[] { "Lead", "Pursue", "Chase", "Walk", "Run", "Position", "Location", "Destination" })]
	[Image(typeof(IconCharacterRun), ColorTheme.Type.Blue)]
	public class InstructionCharacterNavigationFollowStart : TInstructionCharacterNavigation
	{
		[SerializeField]
		private PropertyGetGameObject m_FollowTarget = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDecimal m_MinDistance = GetDecimalDecimal.Create(2f);

		[SerializeField]
		private PropertyGetDecimal m_MaxDistance = GetDecimalDecimal.Create(4f);

		public override string Title => $"{m_Character} Follow {m_FollowTarget}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			GameObject gameObject = m_FollowTarget.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			character.Motion.StartFollowingTarget(gameObject.transform, (float)m_MinDistance.Get(args), (float)m_MaxDistance.Get(args));
			return Instruction.DefaultResult;
		}
	}
}
