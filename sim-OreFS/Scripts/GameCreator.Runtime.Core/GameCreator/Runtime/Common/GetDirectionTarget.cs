using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Target Direction")]
	[Category("Game Objects/Target Direction")]
	[Image(typeof(IconTarget), ColorTheme.Type.Yellow)]
	[Description("The forward direction of the target game object in World Space")]
	public class GetDirectionTarget : PropertyTypeGetDirection
	{
		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionTarget());

		public override string String => "Target Direction";

		public override Vector3 Get(Args args)
		{
			GameObject target = args.Target;
			if (!(target != null))
			{
				return default(Vector3);
			}
			return target.transform.forward;
		}
	}
}
