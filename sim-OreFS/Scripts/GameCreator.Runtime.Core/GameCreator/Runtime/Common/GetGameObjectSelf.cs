using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Self")]
	[Category("Self")]
	[Image(typeof(IconSelf), ColorTheme.Type.Yellow)]
	[Description("Reference to the origin game object that made this call")]
	public class GetGameObjectSelf : PropertyTypeGetGameObject
	{
		public override string String => "Self";

		public override GameObject Get(Args args)
		{
			return args.Self;
		}

		public override GameObject Get(GameObject gameObject)
		{
			return gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectSelf());
		}
	}
}
