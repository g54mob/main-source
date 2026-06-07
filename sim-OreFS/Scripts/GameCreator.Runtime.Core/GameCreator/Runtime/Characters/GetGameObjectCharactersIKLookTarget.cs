using System;
using GameCreator.Runtime.Characters.IK;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Look Target")]
	[Category("Characters/IK/Character Look Target")]
	[Image(typeof(IconIK), ColorTheme.Type.Yellow)]
	[Description("Reference to the IK Look Target by a Character (if any)")]
	public class GetGameObjectCharactersIKLookTarget : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string String => $"{m_Character} Look Target";

		public override GameObject Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character != null))
			{
				return null;
			}
			return character.IK.GetRig<RigLookTo>()?.LookToTarget.Target;
		}

		public override GameObject Get(GameObject gameObject)
		{
			Character character = m_Character.Get<Character>(gameObject);
			if (!(character != null))
			{
				return null;
			}
			return character.IK.GetRig<RigLookTo>()?.LookToTarget.Target;
		}
	}
}
