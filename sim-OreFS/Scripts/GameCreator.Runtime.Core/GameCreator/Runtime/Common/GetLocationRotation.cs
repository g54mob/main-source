using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Rotation")]
	[Category("Constants/Rotation")]
	[Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
	[Description("A single rotation without translation")]
	public class GetLocationRotation : PropertyTypeGetLocation
	{
		[SerializeField]
		private PropertyGetRotation m_Rotation = GetRotationCharactersPlayer.Create;

		public static PropertyGetLocation Create => new PropertyGetLocation(new GetLocationRotation());

		public override string String => $"{m_Rotation}";

		public override Location Get(Args args)
		{
			return new Location(m_Rotation.Get(args));
		}
	}
}
