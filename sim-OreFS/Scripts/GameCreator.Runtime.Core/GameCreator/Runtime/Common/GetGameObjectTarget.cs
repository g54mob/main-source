using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Target")]
	[Category("Target")]
	[Image(typeof(IconTarget), ColorTheme.Type.Yellow)]
	[Description("Reference to the targeted game object")]
	public class GetGameObjectTarget : PropertyTypeGetGameObject
	{
		public override string String => "Target";

		public override GameObject Get(Args args)
		{
			return args.Target;
		}

		public override GameObject Get(GameObject gameObject)
		{
			return gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectTarget());
		}
	}
}
