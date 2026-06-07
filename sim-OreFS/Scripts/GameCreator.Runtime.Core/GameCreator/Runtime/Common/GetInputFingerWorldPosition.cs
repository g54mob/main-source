using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Finger World Position")]
	[Category("Input/Finger World Position")]
	[Image(typeof(IconFinger), ColorTheme.Type.Green)]
	[Description("Returns the raw position of the Finger in World-space")]
	public class GetInputFingerWorldPosition : PropertyTypeGetPosition
	{
		public static PropertyGetPosition Create => new PropertyGetPosition(new GetInputFingerWorldPosition());

		public override string String => "Finger";

		public override Vector3 Get(Args args)
		{
			Vector2 vector = Touchscreen.current.position.ReadValue();
			Camera camera = ShortcutMainCamera.Get<Camera>();
			if (!(camera != null))
			{
				return default(Vector3);
			}
			return camera.ScreenToWorldPoint(vector);
		}

		public override Vector3 Get(GameObject gameObject)
		{
			Vector2 vector = Touchscreen.current.position.ReadValue();
			Camera camera = ShortcutMainCamera.Get<Camera>();
			if (!(camera != null))
			{
				return default(Vector3);
			}
			return camera.ScreenToWorldPoint(vector);
		}
	}
}
