using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class LocomotionProperties
	{
		[SerializeField]
		private EnablerBool m_IsControllable = new EnablerBool(isEnabled: false, value: true);

		[SerializeField]
		private EnablerFloat m_Speed = new EnablerFloat(4f);

		[SerializeField]
		private EnablerFloat m_Rotation = new EnablerFloat(1800f);

		[SerializeField]
		private EnablerFloat m_Mass = new EnablerFloat(80f);

		[SerializeField]
		private EnablerFloat m_Height = new EnablerFloat(2f);

		[SerializeField]
		private EnablerFloat m_Radius = new EnablerFloat(0.2f);

		[SerializeField]
		private EnablerFloat m_GravityUpwards = new EnablerFloat(-9.81f);

		[SerializeField]
		private EnablerFloat m_GravityDownwards = new EnablerFloat(-9.81f);

		[SerializeField]
		private EnablerFloat m_TerminalVelocity = new EnablerFloat(-53f);

		[SerializeField]
		private EnablerBool m_UseAcceleration = new EnablerBool(value: true);

		[SerializeField]
		private EnablerFloat m_Acceleration = new EnablerFloat(10f);

		[SerializeField]
		private EnablerFloat m_Deceleration = new EnablerFloat(4f);

		[SerializeField]
		private EnablerBool m_CanJump = new EnablerBool(value: true);

		[SerializeField]
		private EnablerInt m_AirJumps = new EnablerInt(0);

		[SerializeField]
		private EnablerFloat m_JumpForce = new EnablerFloat(5f);

		[SerializeField]
		private EnablerFloat m_JumpCooldown = new EnablerFloat(0.5f);

		[SerializeField]
		private EnablerInt m_DashInSuccession = new EnablerInt(0);

		[SerializeField]
		private EnablerBool m_DashInAir = new EnablerBool(value: false);

		[SerializeField]
		private EnablerFloat m_DashCooldown = new EnablerFloat(1f);

		public void Update(Character character, float t)
		{
			if (m_IsControllable.IsEnabled)
			{
				character.Player.IsControllable = m_IsControllable.Value;
			}
			if (m_Speed.IsEnabled)
			{
				character.Motion.LinearSpeed = Mathf.Lerp(character.Motion.LinearSpeed, m_Speed.Value, t);
			}
			if (m_Rotation.IsEnabled)
			{
				character.Motion.AngularSpeed = Mathf.Lerp(Mathf.Max(character.Motion.AngularSpeed, 0f), m_Rotation.Value, t);
			}
			if (m_Mass.IsEnabled)
			{
				character.Motion.Mass = Mathf.Lerp(character.Motion.Mass, m_Mass.Value, t);
			}
			if (m_Height.IsEnabled)
			{
				character.Motion.Height = Mathf.Lerp(character.Motion.Height, m_Height.Value, t);
			}
			if (m_Radius.IsEnabled)
			{
				character.Motion.Radius = Mathf.Lerp(character.Motion.Radius, m_Radius.Value, t);
			}
			if (m_GravityUpwards.IsEnabled)
			{
				character.Motion.GravityUpwards = Mathf.Lerp(character.Motion.GravityUpwards, m_GravityUpwards.Value, t);
			}
			if (m_GravityDownwards.IsEnabled)
			{
				character.Motion.GravityDownwards = Mathf.Lerp(character.Motion.GravityDownwards, m_GravityDownwards.Value, t);
			}
			if (m_TerminalVelocity.IsEnabled)
			{
				character.Motion.TerminalVelocity = Mathf.Lerp(character.Motion.TerminalVelocity, m_TerminalVelocity.Value, t);
			}
			if (m_UseAcceleration.IsEnabled)
			{
				character.Motion.UseAcceleration = m_UseAcceleration.Value;
			}
			if (m_Acceleration.IsEnabled)
			{
				character.Motion.Acceleration = Mathf.Lerp(character.Motion.Acceleration, m_Acceleration.Value, t);
			}
			if (m_Deceleration.IsEnabled)
			{
				character.Motion.Deceleration = Mathf.Lerp(character.Motion.Deceleration, m_Deceleration.Value, t);
			}
			if (m_CanJump.IsEnabled)
			{
				character.Motion.CanJump = m_CanJump.Value;
			}
			if (m_AirJumps.IsEnabled)
			{
				character.Motion.AirJumps = m_AirJumps.Value;
			}
			if (m_JumpForce.IsEnabled)
			{
				character.Motion.JumpForce = Mathf.Lerp(character.Motion.JumpForce, m_JumpForce.Value, t);
			}
			if (m_JumpCooldown.IsEnabled)
			{
				character.Motion.JumpCooldown = Mathf.Lerp(character.Motion.JumpCooldown, m_JumpCooldown.Value, t);
			}
			if (m_DashInSuccession.IsEnabled)
			{
				character.Motion.DashInSuccession = m_DashInSuccession.Value;
			}
			if (m_DashInAir.IsEnabled)
			{
				character.Motion.DashInAir = m_DashInAir.Value;
			}
			if (m_DashCooldown.IsEnabled)
			{
				character.Motion.DashCooldown = Mathf.Lerp(character.Motion.DashCooldown, m_DashCooldown.Value, t);
			}
		}
	}
}
