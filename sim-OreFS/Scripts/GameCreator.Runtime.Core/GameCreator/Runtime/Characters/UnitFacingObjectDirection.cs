using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Object Direction")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Category("Direction/Object Direction")]
	[Description("Looks at the same direction as another game object")]
	public class UnitFacingObjectDirection : TUnitFacing
	{
		[SerializeField]
		private PropertyGetGameObject m_DirectionOf = GetGameObjectCameraMain.Create;

		public override Axonometry Axonometry
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override Vector3 GetDefaultDirection()
		{
			GameObject gameObject = m_DirectionOf.Get(base.Character.gameObject);
			Vector3 driverDirection = ((gameObject != null) ? Vector3.Scale(gameObject.transform.forward, Vector3Plane.NormalUp) : Vector3.zero);
			return DecideDirection(driverDirection);
		}

		public override string ToString()
		{
			return "Object Direction";
		}
	}
}
