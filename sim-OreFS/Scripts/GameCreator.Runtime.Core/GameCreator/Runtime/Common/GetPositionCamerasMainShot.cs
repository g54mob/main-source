using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Main Shot")]
	[Category("Cameras/Main Shot")]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Yellow)]
	[Description("Returns the position of the main Camera Shot object")]
	public class GetPositionCamerasMainShot : PropertyTypeGetPosition
	{
		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionCamerasMainShot());

		public override string String => "Main Shot";

		public override Vector3 Get(Args args)
		{
			Transform transform = ShortcutMainShot.Transform;
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.position;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			Transform transform = ShortcutMainShot.Transform;
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.position;
		}
	}
}
