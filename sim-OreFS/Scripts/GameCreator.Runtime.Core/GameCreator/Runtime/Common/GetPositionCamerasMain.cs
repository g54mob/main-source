using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Main Camera")]
	[Category("Cameras/Main Camera")]
	[Image(typeof(IconCamera), ColorTheme.Type.Green)]
	[Description("Returns the position of the Main Camera object")]
	public class GetPositionCamerasMain : PropertyTypeGetPosition
	{
		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionCamerasMain());

		public override string String => "Main Camera";

		public override Vector3 Get(Args args)
		{
			Transform transform = ShortcutMainCamera.Transform;
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.position;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			Transform transform = ShortcutMainCamera.Transform;
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.position;
		}
	}
}
