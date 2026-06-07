using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Model")]
	[Category("Characters/Character Model")]
	[Description("Game Object that represents the model of a Character (under Mannequin)")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	public class GetGameObjectCharacterModel : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string String => $"{m_Character} Model";

		public override GameObject EditorValue
		{
			get
			{
				GameObject editorValue = m_Character.EditorValue;
				if (editorValue == null)
				{
					return null;
				}
				Character component = editorValue.GetComponent<Character>();
				if (component == null)
				{
					return null;
				}
				if (!(component.Animim.Animator != null))
				{
					return null;
				}
				return component.Animim.Animator.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character != null))
			{
				return null;
			}
			return character.Animim.Animator.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			Character character = m_Character.Get<Character>(gameObject);
			if (!(character != null) || !(character.Animim.Animator != null))
			{
				return null;
			}
			return character.Animim.Animator.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectCharacterModel());
		}
	}
}
