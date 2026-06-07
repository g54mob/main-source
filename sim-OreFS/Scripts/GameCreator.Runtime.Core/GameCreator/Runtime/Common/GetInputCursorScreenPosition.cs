using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Cursor Screen Position")]
	[Category("Input/Cursor Screen Position")]
	[Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
	[Description("Returns the raw position of the Cursor in Screen-space")]
	public class GetInputCursorScreenPosition : PropertyTypeGetPosition
	{
		public static PropertyGetPosition Create => new PropertyGetPosition(new GetInputCursorScreenPosition());

		public override string String => "Cursor";

		public override Vector3 Get(Args args)
		{
			return Mouse.current.position.ReadValue();
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return Mouse.current.position.ReadValue();
		}
	}
}
