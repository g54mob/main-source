using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Last Collided Enter")]
	[Category("Physics/Last Collided Enter")]
	[Image(typeof(IconPhysics), ColorTheme.Type.Red, typeof(OverlayArrowLeft))]
	[Description("Reference to the last object that collided with a Trigger")]
	public class GetGameObjectLastCollidedEnter : PropertyTypeGetGameObject
	{
		public static GameObject Instance;

		public override string String => "Last Collided";

		public override GameObject Get(Args args)
		{
			return Instance;
		}

		public override GameObject Get(GameObject gameObject)
		{
			return Instance;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectLastCollidedEnter());
		}
	}
}
