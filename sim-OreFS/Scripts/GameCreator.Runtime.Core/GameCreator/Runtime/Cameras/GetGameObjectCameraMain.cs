using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Main Camera")]
	[Category("Cameras/Main Camera")]
	[Image(typeof(IconCamera), ColorTheme.Type.Green, typeof(OverlayDot))]
	[Description("Camera that represents the Main Camera")]
	public class GetGameObjectCameraMain : PropertyTypeGetGameObject
	{
		public static PropertyGetGameObject Create => new PropertyGetGameObject(new GetGameObjectCameraMain());

		public override string String => "Main Camera";

		public override GameObject Get(Args args)
		{
			if (!(ShortcutMainCamera.Instance != null))
			{
				return null;
			}
			return ShortcutMainCamera.Instance;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(ShortcutMainCamera.Instance != null))
			{
				return null;
			}
			return ShortcutMainCamera.Instance;
		}
	}
}
