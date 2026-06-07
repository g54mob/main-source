using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("A location with an unspecified position and location")]
	public class GetLocationNone : PropertyTypeGetLocation
	{
		public static PropertyGetLocation Create => new PropertyGetLocation(new GetLocationNone());

		public override string String => "(none)";

		public override Location Get(Args args)
		{
			return Location.None;
		}

		public override Location Get(GameObject gameObject)
		{
			return Location.None;
		}
	}
}
