using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Bone")]
	[Category("Characters/Character Bone")]
	[Image(typeof(IconBoneSolid), ColorTheme.Type.Yellow)]
	[Description("The bone references on a Character game object")]
	public class GetGameObjectCharactersBone : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private Bone m_Bone = new Bone(HumanBodyBones.RightHand);

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
				Animator animator = component.Animim?.Animator;
				if (animator == null)
				{
					return null;
				}
				Transform transform = m_Bone.GetTransform(animator);
				if (!(transform != null))
				{
					return null;
				}
				return transform.gameObject;
			}
		}

		public override string String => $"{m_Character}/{m_Bone}";

		public override GameObject Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return null;
			}
			if (!(character.Animim?.Animator != null))
			{
				return null;
			}
			return m_Bone.Get(character.Animim?.Animator);
		}

		public GetGameObjectCharactersBone(PropertyGetGameObject character, Bone bone)
		{
			m_Character = character;
			m_Bone = bone;
		}

		public GetGameObjectCharactersBone()
		{
		}

		public static PropertyGetGameObject Create(PropertyGetGameObject character, Bone bone)
		{
			return new PropertyGetGameObject(new GetGameObjectCharactersBone(character, bone));
		}
	}
}
