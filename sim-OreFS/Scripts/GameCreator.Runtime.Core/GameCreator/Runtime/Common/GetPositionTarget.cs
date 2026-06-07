using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Target Position")]
	[Category("Game Objects/Target Position")]
	[Image(typeof(IconTarget), ColorTheme.Type.Yellow)]
	[Description("Returns the position of the targeted object")]
	public class GetPositionTarget : PropertyTypeGetPosition
	{
		public override string String => "Target";

		public override Vector3 Get(Args args)
		{
			if (!(args.Target != null))
			{
				return default(Vector3);
			}
			return args.Target.transform.position;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionTarget());
		}
	}
}
