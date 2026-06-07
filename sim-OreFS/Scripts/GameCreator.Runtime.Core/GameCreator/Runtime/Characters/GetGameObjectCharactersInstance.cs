using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character")]
	[Category("Characters/Character")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	[Description("Reference to a Character game object")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectCharactersInstance : PropertyTypeGetGameObject
	{
		[SerializeField]
		private Character m_Character;

		public static PropertyGetGameObject Create => new PropertyGetGameObject(new GetGameObjectCharactersInstance());

		public override string String
		{
			get
			{
				if (!(m_Character != null))
				{
					return "(none)";
				}
				return m_Character.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Character != null))
				{
					return null;
				}
				return m_Character.gameObject;
			}
		}

		public GetGameObjectCharactersInstance()
		{
		}

		public GetGameObjectCharactersInstance(Character character)
		{
			m_Character = character;
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Character != null))
			{
				return null;
			}
			return m_Character.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Character != null))
			{
				return null;
			}
			return m_Character.gameObject;
		}

		public static PropertyGetGameObject CreateWith(Character character)
		{
			return new PropertyGetGameObject(new GetGameObjectCharactersInstance(character));
		}
	}
}
