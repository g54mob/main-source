using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Position")]
	[Category("Constants/Position")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Description("A translation in space without rotation")]
	public class GetLocationPosition : PropertyTypeGetLocation
	{
		[SerializeField]
		private PropertyGetPosition m_Position = GetPositionCharactersPlayer.Create;

		public static PropertyGetLocation Create => new PropertyGetLocation(new GetLocationPosition());

		public override string String => m_Position.ToString();

		public override Location Get(Args args)
		{
			return new Location(m_Position.Get(args));
		}
	}
}
