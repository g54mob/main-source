using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Position Feet")]
	[Category("Characters/Character Position Feet")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow, typeof(OverlayBar))]
	[Description("Returns the bottom (feet) position of the Character")]
	public class GetPositionCharacterBottom : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionCharacterBottom());

		public override Vector3 EditorValue
		{
			get
			{
				GameObject editorValue = m_Character.EditorValue;
				if (editorValue == null)
				{
					return default(Vector3);
				}
				Character component = editorValue.GetComponent<Character>();
				if (!(component != null))
				{
					return default(Vector3);
				}
				return component.Feet;
			}
		}

		public override string String => $"{m_Character} Feet";

		public GetPositionCharacterBottom()
		{
		}

		public GetPositionCharacterBottom(Character character)
		{
			m_Character = GetGameObjectCharactersInstance.CreateWith(character);
		}

		public override Vector3 Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character != null))
			{
				return default(Vector3);
			}
			return character.Feet;
		}

		public static PropertyGetPosition CreateWith(Character character)
		{
			return new PropertyGetPosition(new GetPositionCharacterBottom(character));
		}
	}
}
