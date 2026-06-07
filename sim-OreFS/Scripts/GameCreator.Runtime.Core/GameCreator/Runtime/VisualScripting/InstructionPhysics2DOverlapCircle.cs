using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Overlap Circle 2D")]
	[Category("Physics 3D/Overlap Circle 3D")]
	[Description("Captures all colliders caught inside a Circle defined by a point and radius")]
	[Image(typeof(IconCircleOutline), ColorTheme.Type.Green, typeof(OverlayPhysics))]
	[Parameter("Center", "The center of the circle")]
	[Parameter("Radius", "The radius of the circle")]
	public class InstructionPhysics2DOverlapCircle : TInstructionPhysics2DOverlap
	{
		[SerializeField]
		private PropertyGetPosition m_Center = GetPositionCharacter.Create;

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalDecimal.Create(5f);

		public override string Title => $"Overlap Circle at {m_Center}";

		protected override int GetColliders(Collider2D[] colliders, Args args)
		{
			Vector3 vector = m_Center.Get(args);
			return Physics2D.OverlapCircle(radius: (float)m_Radius.Get(args), point: vector, contactFilter: new ContactFilter2D
			{
				useLayerMask = true,
				layerMask = m_LayerMask
			}, results: colliders);
		}
	}
}
