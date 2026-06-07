using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Character", "The Character instance referenced in the condition")]
	[Keywords(new string[] { "Character", "Player" })]
	public abstract class TConditionCharacter : Condition
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();
	}
}
