using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Self Name")]
	[Category("Game Objects/Self Name")]
	[Image(typeof(IconSelf), ColorTheme.Type.Yellow)]
	[Description("Returns the name of the game object which made the call")]
	public class GetStringSelfName : PropertyTypeGetString
	{
		public static PropertyGetString Create => new PropertyGetString(new GetStringSelfName());

		public override string String => "Self Name";

		public override string Get(Args args)
		{
			if (!(args.Self != null))
			{
				return string.Empty;
			}
			return args.Self.name;
		}

		public override string Get(GameObject gameObject)
		{
			if (!(gameObject != null))
			{
				return string.Empty;
			}
			return gameObject.name;
		}
	}
}
