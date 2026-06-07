using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Marker")]
	[Category("Navigation/Marker")]
	[Image(typeof(IconMarker), ColorTheme.Type.Yellow)]
	[Description("The position and rotation of a Marker component")]
	public class GetLocationNavigationMarker : PropertyTypeGetLocation
	{
		[SerializeField]
		private PropertyGetGameObject m_Marker = GetGameObjectNavigationMarker.Create();

		public static PropertyGetLocation Create => new PropertyGetLocation(new GetLocationNavigationMarker());

		public override string String => m_Marker.ToString();

		public override Location Get(Args args)
		{
			return new Location(m_Marker.Get<Marker>(args));
		}
	}
}
