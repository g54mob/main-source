using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Overlap Sphere 3D")]
	[Category("Physics 3D/Overlap Sphere 3D")]
	[Description("Captures all colliders caught inside a sphere defined by a point and radius")]
	[Image(typeof(IconSphereOutline), ColorTheme.Type.Green, typeof(OverlayPhysics))]
	[Parameter("Center", "The center of the sphere")]
	[Parameter("Radius", "The radius of the sphere")]
	[Keywords(new string[] { "Circle" })]
	public class InstructionPhysics3DOverlapSphere : TInstructionPhysics3DOverlap
	{
		[SerializeField]
		private PropertyGetPosition m_Center = GetPositionCharacter.Create;

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalDecimal.Create(5f);

		public override string Title => $"Overlap Sphere at {m_Center}";

		protected override int GetColliders(Collider[] colliders, Args args)
		{
			Vector3 position = m_Center.Get(args);
			float radius = (float)m_Radius.Get(args);
			return Physics.OverlapSphereNonAlloc(position, radius, colliders, m_LayerMask, QueryTriggerInteraction.Ignore);
		}
	}
}
