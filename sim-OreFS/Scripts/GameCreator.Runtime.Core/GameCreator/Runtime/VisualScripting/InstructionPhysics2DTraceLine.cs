using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Trace Line 2D")]
	[Category("Physics 2D/Trace Line 2D")]
	[Description("Captures all 2D colliders caught inside a line between A and B")]
	[Image(typeof(IconLineStartEnd), ColorTheme.Type.Green, typeof(OverlayPhysics))]
	[Parameter("Point A", "The position of the first point")]
	[Parameter("Point B", "The position of the second point")]
	[Keywords(new string[] { "Line", "Trace", "Raycast" })]
	public class InstructionPhysics2DTraceLine : TInstructionPhysics2DOverlap
	{
		private static readonly RaycastHit2D[] HITS = new RaycastHit2D[30];

		[SerializeField]
		private PropertyGetPosition m_PointA = GetPositionCharacter.Create;

		[SerializeField]
		private PropertyGetPosition m_PointB = GetPositionCharacter.CreateWith(null);

		public override string Title => $"Trace between {m_PointA} and {m_PointB}";

		protected override int GetColliders(Collider2D[] colliders, Args args)
		{
			Vector3 vector = m_PointA.Get(args);
			Vector3 vector2 = m_PointB.Get(args);
			int num = Physics2D.RaycastNonAlloc(vector, vector2 - vector, HITS, Vector3.Distance(vector, vector2), m_LayerMask);
			for (int i = 0; i < num; i++)
			{
				colliders[i] = HITS[i].collider;
			}
			return num;
		}
	}
}
