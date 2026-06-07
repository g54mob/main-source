using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Character", "The game object with the Character target")]
	[Keywords(new string[] { "Character", "Player" })]
	public abstract class TInstructionCharacterNavigation : Instruction
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();
	}
}
