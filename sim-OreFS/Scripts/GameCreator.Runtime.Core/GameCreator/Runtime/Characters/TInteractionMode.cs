using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Interaction Mode")]
	public abstract class TInteractionMode
	{
		protected static readonly Color COLOR_GIZMOS = new Color(0f, 1f, 0f, 0.5f);

		public abstract float CalculatePriority(Character character, IInteractive interactive);

		public virtual void DrawGizmos(Character character)
		{
		}
	}
}
