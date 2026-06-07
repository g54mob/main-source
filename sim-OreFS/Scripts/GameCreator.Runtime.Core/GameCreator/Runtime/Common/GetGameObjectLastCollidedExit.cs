using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Last Collided Exit")]
	[Category("Physics/Last Collided Exit")]
	[Image(typeof(IconPhysics), ColorTheme.Type.Red, typeof(OverlayArrowRight))]
	[Description("Reference to the last object that exited the collision with a Trigger")]
	public class GetGameObjectLastCollidedExit : PropertyTypeGetGameObject
	{
		public static GameObject Instance;

		public override string String => "Last Collided Exit";

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
			return new PropertyGetGameObject(new GetGameObjectLastCollidedExit());
		}
	}
}
