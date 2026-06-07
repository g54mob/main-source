using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Screen Cursor")]
	[Category("Screen Cursor")]
	[Image(typeof(IconCursor), ColorTheme.Type.Green)]
	[Description("Selects the interactive element that's closest to the cursor on the screen")]
	public class InteractionModeScreenCursor : TInteractionMode
	{
		[SerializeField]
		private float m_MaxDistance = 0.5f;

		public override float CalculatePriority(Character character, IInteractive interactive)
		{
			Camera camera = ShortcutMainCamera.Get<Camera>();
			if (camera == null)
			{
				return float.MaxValue;
			}
			Vector3 lhs;
			Vector3 vector;
			if (camera.orthographic)
			{
				lhs = camera.transform.forward;
				vector = camera.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, camera.nearClipPlane));
			}
			else
			{
				lhs = ((Cursor.lockState == CursorLockMode.Locked) ? camera.transform.TransformDirection(Vector3.forward) : camera.ScreenPointToRay(Mouse.current.position.ReadValue()).direction);
				vector = camera.transform.position;
			}
			Vector3 rhs = interactive.Position - vector;
			if (Vector3.Dot(lhs, rhs) < 0f)
			{
				return float.MaxValue;
			}
			float magnitude = Vector3.Cross(lhs, rhs).magnitude;
			if (!(magnitude < m_MaxDistance))
			{
				return float.MaxValue;
			}
			return magnitude;
		}

		public override void DrawGizmos(Character character)
		{
			base.DrawGizmos(character);
			Vector3 vector = character.transform.TransformDirection(Vector3.forward);
			Vector3 position = character.Eyes + vector * 0.5f;
			Gizmos.color = TInteractionMode.COLOR_GIZMOS;
			GizmosExtension.Circle(position, m_MaxDistance, vector);
		}
	}
}
