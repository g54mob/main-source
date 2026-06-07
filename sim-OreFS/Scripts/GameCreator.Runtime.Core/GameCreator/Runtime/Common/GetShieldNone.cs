using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Returns a null Shield reference")]
	public class GetShieldNone : PropertyTypeGetShield
	{
		public override string String => "None";

		public override IShield Get(Args args)
		{
			return null;
		}

		public override IShield Get(GameObject gameObject)
		{
			return null;
		}

		public static PropertyGetShield Create()
		{
			return new PropertyGetShield(new GetShieldNone());
		}
	}
}
