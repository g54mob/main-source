using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Last Trigger Exit")]
	[Category("Physics/Last Trigger Exit")]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Description("Reference to the last object that exited a Trigger collider with isTrigger")]
	public class GetGameObjectLastTriggerExit : PropertyTypeGetGameObject
	{
		public static GameObject Instance;

		public override string String => "Last Trigger Exit";

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
			return new PropertyGetGameObject(new GetGameObjectLastTriggerExit());
		}
	}
}
