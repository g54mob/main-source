using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Motion Controller")]
	[Image(typeof(IconChip), ColorTheme.Type.Blue)]
	[Category("Motion Controller")]
	[Description("Motion system that defines how the Character responds to external stimulus")]
	public class UnitMotionController : TUnitMotion
	{
		[SerializeField]
		private float m_Speed = 4f;

		[SerializeField]
		private EnablerFloat m_Rotation = new EnablerFloat(isEnabled: true, 1800f);

		[SerializeField]
		private float m_Mass = 80f;

		[SerializeField]
		private float m_Height = 2f;

		[SerializeField]
		private float m_Radius = 0.2f;

		[SerializeField]
		private float m_GravityUpwards = -9.81f;

		[SerializeField]
		private float m_GravityDownwards = -9.81f;

		[SerializeField]
		private float m_TerminalVelocity = -53f;

		[SerializeField]
		private MotionAcceleration m_Acceleration;

		[SerializeField]
		private MotionJump m_Jump;

		[SerializeField]
		private MotionDash m_Dash;

		public override float JumpForce
		{
			get
			{
				return m_Jump.JumpForce;
			}
			set
			{
				m_Jump.JumpForce = value;
			}
		}

		public override float LinearSpeed
		{
			get
			{
				return m_Speed;
			}
			set
			{
				m_Speed = value;
			}
		}

		public override float AngularSpeed
		{
			get
			{
				if (!m_Rotation.IsEnabled)
				{
					return -1f;
				}
				return m_Rotation.Value;
			}
			set
			{
				if (value < 0f)
				{
					m_Rotation.IsEnabled = false;
					m_Rotation.Value = -1f;
				}
				else
				{
					m_Rotation.IsEnabled = true;
					m_Rotation.Value = value;
				}
			}
		}

		public override float Mass
		{
			get
			{
				return m_Mass;
			}
			set
			{
				m_Mass = value;
			}
		}

		public override float Height
		{
			get
			{
				return m_Height;
			}
			set
			{
				m_Height = value;
			}
		}

		public override float Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public override bool CanJump
		{
			get
			{
				if (m_Jump.CanJump)
				{
					return !base.Character.Busy.AreLegsBusy;
				}
				return false;
			}
			set
			{
				m_Jump.CanJump = value;
			}
		}

		public override int AirJumps
		{
			get
			{
				return m_Jump.AirJumps;
			}
			set
			{
				m_Jump.AirJumps = value;
			}
		}

		public override int DashInSuccession
		{
			get
			{
				return m_Dash.InSuccession;
			}
			set
			{
				m_Dash.InSuccession = value;
			}
		}

		public override bool DashInAir
		{
			get
			{
				return m_Dash.DashInAir;
			}
			set
			{
				m_Dash.DashInAir = value;
			}
		}

		public override float DashCooldown
		{
			get
			{
				return m_Dash.Cooldown;
			}
			set
			{
				m_Dash.Cooldown = value;
			}
		}

		public override float GravityUpwards
		{
			get
			{
				return m_GravityUpwards;
			}
			set
			{
				m_GravityUpwards = value;
			}
		}

		public override float GravityDownwards
		{
			get
			{
				return m_GravityDownwards;
			}
			set
			{
				m_GravityDownwards = value;
			}
		}

		public override float TerminalVelocity
		{
			get
			{
				return m_TerminalVelocity;
			}
			set
			{
				m_TerminalVelocity = value;
			}
		}

		public override float JumpCooldown
		{
			get
			{
				return m_Jump.JumpCooldown;
			}
			set
			{
				m_Jump.JumpCooldown = value;
			}
		}

		public override bool UseAcceleration
		{
			get
			{
				return m_Acceleration.UseAcceleration;
			}
			set
			{
				m_Acceleration.UseAcceleration = value;
			}
		}

		public override float Acceleration
		{
			get
			{
				return m_Acceleration.Acceleration;
			}
			set
			{
				m_Acceleration.Acceleration = value;
			}
		}

		public override float Deceleration
		{
			get
			{
				return m_Acceleration.Deceleration;
			}
			set
			{
				m_Acceleration.Deceleration = value;
			}
		}

		public UnitMotionController()
		{
			m_Acceleration = new MotionAcceleration();
			m_Jump = new MotionJump();
		}
	}
}
