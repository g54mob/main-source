using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Main Shot")]
	[Category("Cameras/Main Shot")]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Yellow, typeof(OverlayDot))]
	[Description("Reference to the current Main Camera Shot")]
	public class GetGameObjectShotMain : PropertyTypeGetGameObject
	{
		public static PropertyGetGameObject Create => new PropertyGetGameObject(new GetGameObjectShotMain());

		public override string String => "Main Shot";

		public override GameObject Get(Args args)
		{
			return ShortcutMainShot.Instance;
		}
	}
}
