using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Tank")]
	[Image(typeof(IconTank), ColorTheme.Type.Green)]
	[Category("Direction/Tank")]
	[Description("Rotates the Character around itself based on the input")]
	public class UnitFacingTank : TUnitFacing
	{
		[SerializeField]
		private InputPropertyValueVector2 m_InputMove;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		public override Type ForcePlayer => typeof(UnitPlayerTank);

		public override Axonometry Axonometry
		{
			get
			{
				return m_Axonometry;
			}
			set
			{
				m_Axonometry = value;
			}
		}

		public UnitFacingTank()
		{
			m_InputMove = InputValueVector2MotionPrimary.Create();
		}

		public override void OnStartup(Character character)
		{
			base.OnStartup(character);
			m_InputMove.OnStartup();
		}

		public override void OnDispose(Character character)
		{
			base.OnDispose(character);
			m_InputMove.OnDispose();
		}

		protected override Vector3 GetDefaultDirection()
		{
			m_InputMove.OnUpdate();
			if (!base.Character.IsPlayer || !base.Character.Player.IsControllable)
			{
				Vector3 vector = DecideDirection(Vector3.zero);
				return m_Axonometry?.ProcessRotation(this, vector) ?? vector;
			}
			Vector3 direction = m_InputMove.Read();
			Vector3 driverDirection = Vector3.Scale(base.Transform.TransformDirection(direction), Vector3Plane.NormalUp);
			Vector3 vector2 = DecideDirection(driverDirection);
			return m_Axonometry?.ProcessRotation(this, vector2) ?? vector2;
		}

		protected virtual Vector3 GetMoveDirection(Vector3 input)
		{
			Vector3 direction = new Vector3(input.x, 0f, 0f);
			Vector3 vector = base.Transform.TransformDirection(direction);
			vector.Scale(Vector3Plane.NormalUp);
			vector.Normalize();
			return vector * direction.magnitude;
		}

		public override string ToString()
		{
			return "Tank";
		}
	}
}
