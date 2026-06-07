using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Position")]
	[Category("Characters/Character Position")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	[Description("Returns the position of the Character")]
	public class GetPositionCharacter : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionCharacter());

		public override Vector3 EditorValue
		{
			get
			{
				GameObject editorValue = m_Character.EditorValue;
				if (!(editorValue != null))
				{
					return default(Vector3);
				}
				return editorValue.transform.position;
			}
		}

		public override string String => m_Character.ToString();

		public GetPositionCharacter()
		{
		}

		public GetPositionCharacter(Character character)
		{
			m_Character = GetGameObjectCharactersInstance.CreateWith(character);
		}

		public override Vector3 Get(Args args)
		{
			Transform transform = m_Character.Get<Transform>(args);
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.position;
		}

		public static PropertyGetPosition CreateWith(Character character)
		{
			return new PropertyGetPosition(new GetPositionCharacter(character));
		}
	}
}
