using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Near Character")]
	[Category("Near Character")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Green)]
	[Description("Selects the closest interactive element to the Character")]
	public class InteractionModeNearCharacter : TInteractionMode
	{
		private static readonly Vector3 GIZMO_SIZE = Vector3.one * 0.05f;

		[SerializeField]
		private Vector3 m_Offset = new Vector3(0f, 0f, 1f);

		public override float CalculatePriority(Character character, IInteractive interactive)
		{
			if (character == null)
			{
				return float.MaxValue;
			}
			return Vector3.Distance(character.transform.TransformPoint(m_Offset), interactive.Position);
		}

		public override void DrawGizmos(Character character)
		{
			base.DrawGizmos(character);
			Vector3 center = character.transform.TransformPoint(m_Offset);
			Gizmos.color = TInteractionMode.COLOR_GIZMOS;
			Gizmos.DrawCube(center, GIZMO_SIZE);
		}
	}
}
