using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Unique ID")]
	[Category("Random/Unique ID")]
	[Image(typeof(IconID), ColorTheme.Type.Yellow)]
	[Description("Returns a new globally unique ID string value")]
	public class GetStringGuid : PropertyTypeGetString
	{
		public static PropertyGetString Create => new PropertyGetString(new GetStringGuid());

		public override string String => "UID";

		public override string Get(Args args)
		{
			return UniqueID.GenerateID();
		}

		public override string Get(GameObject gameObject)
		{
			return UniqueID.GenerateID();
		}
	}
}
