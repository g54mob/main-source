using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Overlap Box 2D")]
	[Category("Physics 3D/Overlap Box 2D")]
	[Description("Captures all colliders caught inside a box")]
	[Image(typeof(IconSquareOutline), ColorTheme.Type.Green, typeof(OverlayPhysics))]
	[Parameter("Center", "The center of the box")]
	[Parameter("Size", "The size of the box in each axis")]
	[Parameter("Angle", "The rotation of the box in world space")]
	[Keywords(new string[] { "Cube" })]
	public class InstructionPhysics2DOverlapBox : TInstructionPhysics2DOverlap
	{
		private static readonly RaycastHit2D[] HITS = new RaycastHit2D[30];

		[SerializeField]
		private PropertyGetPosition m_Center = GetPositionCharacter.Create;

		[SerializeField]
		private PropertyGetDirection m_Size = GetDirectionVector3Zero.Create();

		[SerializeField]
		private PropertyGetDecimal m_Angle = GetDecimalDecimal.Create(0f);

		public override string Title => $"Overlap Box at {m_Center}";

		protected override int GetColliders(Collider2D[] colliders, Args args)
		{
			Vector3 vector = m_Center.Get(args);
			Vector3 vector2 = m_Size.Get(args);
			float num = (float)m_Angle.Get(args);
			int num2 = Physics2D.BoxCast(vector, vector2, num, Vector2.up, new ContactFilter2D
			{
				useLayerMask = true,
				layerMask = m_LayerMask
			}, HITS, num);
			for (int i = 0; i < num2; i++)
			{
				colliders[i] = HITS[i].collider;
			}
			return num2;
		}
	}
}
