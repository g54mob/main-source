using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Scale")]
	[Category("Characters/Character Scale")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	[Description("Scale of the Character game object in local or world space")]
	public class GetScaleCharacter : PropertyTypeGetScale
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private ScaleSpace m_Space;

		public static PropertyGetScale Create => new PropertyGetScale(new GetScaleCharacter());

		public override string String => $"{m_Space} {m_Character}";

		public override Vector3 Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Vector3.one;
			}
			return m_Space switch
			{
				ScaleSpace.Local => character.transform.localScale, 
				ScaleSpace.Global => character.transform.lossyScale, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
