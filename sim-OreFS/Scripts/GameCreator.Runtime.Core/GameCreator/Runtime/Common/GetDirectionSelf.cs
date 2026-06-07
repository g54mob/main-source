using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Self Direction")]
	[Category("Game Objects/Self Direction")]
	[Image(typeof(IconSelf), ColorTheme.Type.Yellow)]
	[Description("The forward direction of the caller game object in World Space")]
	public class GetDirectionSelf : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionSelf());

		public override string String => "Self Direction";

		public override Vector3 Get(Args args)
		{
			GameObject self = args.Self;
			if (!(self != null))
			{
				return default(Vector3);
			}
			return self.transform.forward;
		}
	}
}
