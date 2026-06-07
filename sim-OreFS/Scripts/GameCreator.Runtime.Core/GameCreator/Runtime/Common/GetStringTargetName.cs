using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Target Name")]
	[Category("Game Objects/Target Name")]
	[Image(typeof(IconTarget), ColorTheme.Type.Yellow)]
	[Description("Returns the name of the targeted game object")]
	public class GetStringTargetName : PropertyTypeGetString
	{
		public static PropertyGetString Create => new PropertyGetString(new GetStringTargetName());

		public override string String => "Target Name";

		public override string Get(Args args)
		{
			if (!(args.Target != null))
			{
				return string.Empty;
			}
			return args.Target.name;
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
