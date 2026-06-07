using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class InteractionMode
	{
		[SerializeReference]
		private TInteractionMode m_InteractionMode;

		public InteractionMode()
		{
			m_InteractionMode = new InteractionModeNearCharacter();
		}

		public float CalculatePriority(Character character, IInteractive interactive)
		{
			return m_InteractionMode?.CalculatePriority(character, interactive) ?? float.MaxValue;
		}

		public void DrawGizmos(Character character)
		{
			m_InteractionMode?.DrawGizmos(character);
		}
	}
}
