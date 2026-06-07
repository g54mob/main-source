using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Look at Target")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Category("Targets/Look at Target")]
	[Description("Rotates the Character towards a specific game object target")]
	public class UnitFacingTarget : TUnitFacing
	{
		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		[NonSerialized]
		private Args m_Args;

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
			if (m_Args == null)
			{
				m_Args = new Args(base.Character);
			}
			GameObject gameObject = m_Target.Get(m_Args);
			Vector3 driverDirection = Vector3.Scale((gameObject != null) ? (gameObject.transform.position - base.Transform.position) : base.Character.Driver.WorldMoveDirection, Vector3Plane.NormalUp);
			return DecideDirection(driverDirection);
		}

		public override string ToString()
		{
			return "Look at Target";
		}
	}
}
