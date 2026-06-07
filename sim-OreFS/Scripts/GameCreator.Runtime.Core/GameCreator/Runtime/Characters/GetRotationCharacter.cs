using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Rotation")]
	[Category("Characters/Character Rotation")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	[Description("Rotation of the Character in local or world space")]
	public class GetRotationCharacter : PropertyTypeGetRotation
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private RotationSpace m_Space = RotationSpace.Global;

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationCharacter());

		public override string String => $"{m_Space} {m_Character}";

		public override Quaternion Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return default(Quaternion);
			}
			return m_Space switch
			{
				RotationSpace.Local => character.transform.localRotation, 
				RotationSpace.Global => character.transform.rotation, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
