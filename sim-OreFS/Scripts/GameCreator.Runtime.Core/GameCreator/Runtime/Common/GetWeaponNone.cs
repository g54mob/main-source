using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Returns a null Weapon reference")]
	public class GetWeaponNone : PropertyTypeGetWeapon
	{
		public override string String => "None";

		public override IWeapon Get(Args args)
		{
			return null;
		}

		public override IWeapon Get(GameObject gameObject)
		{
			return null;
		}

		public static PropertyGetWeapon Create()
		{
			return new PropertyGetWeapon(new GetWeaponNone());
		}
	}
}
