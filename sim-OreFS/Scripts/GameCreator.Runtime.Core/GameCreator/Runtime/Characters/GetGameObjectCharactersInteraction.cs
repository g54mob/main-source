using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Interaction")]
	[Category("Characters/Character Interaction")]
	[Image(typeof(IconCharacterInteract), ColorTheme.Type.Yellow)]
	[Description("Reference to the Interactive element selected by a Character")]
	public class GetGameObjectCharactersInteraction : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string String => $"{m_Character} Interaction";

		public override GameObject Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character != null))
			{
				return null;
			}
			return character.Interaction.Target?.Instance;
		}

		public override GameObject Get(GameObject gameObject)
		{
			Character character = m_Character.Get<Character>(gameObject);
			if (!(character != null))
			{
				return null;
			}
			return character.Interaction.Target?.Instance;
		}
	}
}
