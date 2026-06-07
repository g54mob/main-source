using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Self Position")]
	[Category("Game Objects/Self Position")]
	[Image(typeof(IconSelf), ColorTheme.Type.Yellow)]
	[Description("Returns the position of the caller")]
	public class GetPositionSelf : PropertyTypeGetPosition
	{
		public override string String => "Self";

		public override Vector3 Get(Args args)
		{
			if (!(args.Self != null))
			{
				return default(Vector3);
			}
			return args.Self.transform.position;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionSelf());
		}
	}
}
