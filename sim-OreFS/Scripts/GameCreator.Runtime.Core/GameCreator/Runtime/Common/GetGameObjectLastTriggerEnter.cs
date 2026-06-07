using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Last Trigger Enter")]
	[Category("Physics/Last Trigger Enter")]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Description("Reference to the last object that entered a Trigger collider with isTrigger")]
	public class GetGameObjectLastTriggerEnter : PropertyTypeGetGameObject
	{
		public static GameObject Instance;

		public override string String => "Last Trigger Enter";

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
			return new PropertyGetGameObject(new GetGameObjectLastTriggerEnter());
		}
	}
}
