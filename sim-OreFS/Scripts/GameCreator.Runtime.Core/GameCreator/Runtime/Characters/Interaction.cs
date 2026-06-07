using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Interaction
	{
		private static readonly Color COLOR_GIZMO_TARGET = new Color(0f, 1f, 0f, 1f);

		private const float INFINITY = 9999f;

		[NonSerialized]
		private Character m_Character;

		[field: NonSerialized]
		public IInteractive Target { get; private set; }

		public bool CanInteract => Target != null;

		[field: NonSerialized]
		public List<ISpatialHash> Interactions { get; private set; }

		public event Action<Character, IInteractive> EventFocus;

		public event Action<Character, IInteractive> EventBlur;

		public event Action<Character, IInteractive> EventInteract;

		public Interaction()
		{
			Interactions = new List<ISpatialHash>();
		}

		internal void OnStartup(Character character)
		{
			m_Character = character;
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnDispose(Character character)
		{
			m_Character = character;
		}

		internal void OnEnable()
		{
		}

		internal void OnDisable()
		{
		}

		public bool Interact()
		{
			if (Target == null)
			{
				return false;
			}
			this.EventInteract?.Invoke(m_Character, Target);
			Target.Interact(m_Character);
			return true;
		}

		internal void OnUpdate()
		{
			SpatialHashInteractions.Find(m_Character.transform.position, m_Character.Motion.InteractionRadius, Interactions);
			IInteractive interactive = null;
			float num = float.MaxValue;
			foreach (ISpatialHash interaction in Interactions)
			{
				if (!(interaction is IInteractive interactive2))
				{
					continue;
				}
				float num2 = m_Character.Motion.InteractionMode.CalculatePriority(m_Character, interactive2);
				if (!(num2 > 9999f))
				{
					if (interactive == null)
					{
						interactive = interactive2;
						num = num2;
					}
					else if (num > num2)
					{
						interactive = interactive2;
						num = num2;
					}
				}
			}
			if (Target != interactive)
			{
				this.EventBlur?.Invoke(m_Character, Target);
				Target = interactive;
				this.EventFocus?.Invoke(m_Character, interactive);
			}
		}

		internal void OnDrawGizmos(Character character)
		{
			if (!(character == null) && character.IsPlayer && Application.isPlaying && Target != null)
			{
				Gizmos.color = COLOR_GIZMO_TARGET;
				Gizmos.DrawLine(Target.Position, character.transform.position);
			}
		}
	}
}
