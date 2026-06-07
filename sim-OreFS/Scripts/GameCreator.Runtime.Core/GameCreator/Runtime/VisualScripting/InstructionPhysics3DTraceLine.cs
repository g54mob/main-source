using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Trace Line 3D")]
	[Category("Physics 3D/Trace Line 3D")]
	[Description("Captures all colliders caught inside a line between A and B")]
	[Image(typeof(IconLineStartEnd), ColorTheme.Type.Green, typeof(OverlayPhysics))]
	[Parameter("Point A", "The position of the first point")]
	[Parameter("Point B", "The position of the second point")]
	[Keywords(new string[] { "Line", "Trace", "Raycast" })]
	public class InstructionPhysics3DTraceLine : TInstructionPhysics3DOverlap
	{
		private static readonly RaycastHit[] HITS = new RaycastHit[30];

		[SerializeField]
		private PropertyGetPosition m_PointA = GetPositionCharacter.Create;

		[SerializeField]
		private PropertyGetPosition m_PointB = GetPositionCharacter.CreateWith(null);

		public override string Title => $"Trace between {m_PointA} and {m_PointB}";

		protected override int GetColliders(Collider[] colliders, Args args)
		{
			Vector3 vector = m_PointA.Get(args);
			Vector3 vector2 = m_PointB.Get(args);
			int num = Physics.RaycastNonAlloc(vector, vector2 - vector, HITS, Vector3.Distance(vector, vector2), m_LayerMask, QueryTriggerInteraction.Ignore);
			for (int i = 0; i < num; i++)
			{
				colliders[i] = HITS[i].collider;
			}
			return num;
		}
	}
}
