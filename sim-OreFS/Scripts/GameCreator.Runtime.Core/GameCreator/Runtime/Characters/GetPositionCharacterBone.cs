using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Bone Position")]
	[Category("Characters/Character Bone Position")]
	[Image(typeof(IconBoneSolid), ColorTheme.Type.Yellow)]
	[Description("The bone position of a Character game object")]
	public class GetPositionCharacterBone : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private Bone m_Bone = new Bone(HumanBodyBones.RightHand);

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
				if (component == null)
				{
					return default(Vector3);
				}
				Animator animator = component.Animim?.Animator;
				if (animator == null)
				{
					return default(Vector3);
				}
				Transform transform = m_Bone.GetTransform(animator);
				if (!(transform != null))
				{
					return default(Vector3);
				}
				return transform.position;
			}
		}

		public override string String => $"{m_Character}/{m_Bone}";

		public GetPositionCharacterBone()
		{
		}

		public GetPositionCharacterBone(PropertyGetGameObject character, Bone bone)
		{
			m_Character = character;
			m_Bone = bone;
		}

		public override Vector3 Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null || character.Animim?.Animator == null)
			{
				return default(Vector3);
			}
			GameObject gameObject = m_Bone.Get(character.Animim?.Animator);
			if (!(gameObject != null))
			{
				return default(Vector3);
			}
			return gameObject.transform.position;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionCharacterBone());
		}

		public static PropertyGetPosition Create(PropertyGetGameObject character, Bone bone)
		{
			return new PropertyGetPosition(new GetPositionCharacterBone(character, bone));
		}
	}
}
