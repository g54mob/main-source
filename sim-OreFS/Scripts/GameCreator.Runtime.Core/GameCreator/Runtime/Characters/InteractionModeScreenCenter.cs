using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Screen Center")]
	[Category("Screen Center")]
	[Image(typeof(IconCamera), ColorTheme.Type.Green)]
	[Description("Selects the interactive element that's closest to the center of the screen")]
	public class InteractionModeScreenCenter : TInteractionMode
	{
		[SerializeField]
		private float m_MaxDistance = 0.5f;

		public override float CalculatePriority(Character character, IInteractive interactive)
		{
			Transform transform = ShortcutMainCamera.Transform;
			if (transform == null)
			{
				return float.MaxValue;
			}
			Vector3 lhs = transform.TransformDirection(Vector3.forward);
			Vector3 rhs = interactive.Position - transform.position;
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
