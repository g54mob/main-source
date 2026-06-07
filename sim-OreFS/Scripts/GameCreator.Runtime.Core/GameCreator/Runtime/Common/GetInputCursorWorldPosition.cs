using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Cursor World Position")]
	[Category("Input/Cursor World Position")]
	[Image(typeof(IconCursor), ColorTheme.Type.Green)]
	[Description("Returns the raw position of the Cursor in World-space")]
	public class GetInputCursorWorldPosition : PropertyTypeGetPosition
	{
		public static PropertyGetPosition Create => new PropertyGetPosition(new GetInputCursorWorldPosition());

		public override string String => "Cursor";

		public override Vector3 Get(Args args)
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			Camera camera = ShortcutMainCamera.Get<Camera>();
			if (!(camera != null))
			{
				return default(Vector3);
			}
			return camera.ScreenToWorldPoint(vector);
		}

		public override Vector3 Get(GameObject gameObject)
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			Camera camera = ShortcutMainCamera.Get<Camera>();
			if (!(camera != null))
			{
				return default(Vector3);
			}
			return camera.ScreenToWorldPoint(vector);
		}
	}
}
