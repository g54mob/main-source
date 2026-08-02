using System;
using System.Collections.Generic;
using HQFPSTemplate.Equipment;
using UnityEngine;

namespace HQFPSTemplate
{
	public class CameraPhysicsHandler : PlayerComponent
	{
		[SerializeField]
		[Group(order = 3)]
		private SpringControlInfo m_SpringController;

		[SerializeField]
		private CameraPhysicsPreset m_CameraPhysicsPreset;

		private Spring m_PositionSpring;

		private Spring m_RotationSpring;

		private Spring m_PositionSpring_Force;

		private Spring m_RotationSpring_Force;

		private Spring m_PositionSpring_Recoil;

		private Spring m_RotationSpring_Recoil;

		private Spring m_PositionShakeSpring;

		private Spring m_RotationShakeSpring;

		private CameraMotionState m_CurrentState;

		private Vector3 m_StatePosition;

		private Vector3 m_StateRotation;

		private int m_LastFootDown;

		private float m_CurrentMovingBobParam;

		private float m_CurrentStaticBobParam;

		private List<CameraShake> m_Shakes = new List<CameraShake>();

		private CameraMotionState m_StateToVisualize;

		private float m_VisualizationSpeed = 4f;

		private bool m_FirstStepTriggered;

		private List<QueuedCameraForce> m_QueuedCamForces = new List<QueuedCameraForce>();

		public float AimHeadbobMod { get; set; }

		public bool PhysicsEnabled { get; private set; }

		public void PlayDelayedCameraForces(DelayedCameraForce[] delayedCamForces)
		{
			for (int i = 0; i < delayedCamForces.Length; i++)
			{
				PlayDelayedCameraForce(delayedCamForces[i]);
			}
		}

		public void PlayDelayedCameraForce(DelayedCameraForce delayedCamForces)
		{
			m_QueuedCamForces.Add(new QueuedCameraForce(delayedCamForces, Time.time + delayedCamForces.Delay));
		}

		public void ClearQueuedCamForces()
		{
			m_QueuedCamForces.Clear();
		}

		public void DoShake(CameraShakeSettings shake, float scale)
		{
			m_Shakes.Add(new CameraShake(shake, m_PositionShakeSpring, m_RotationShakeSpring, scale));
		}

		public void AddExplosionShake(float scale)
		{
			m_Shakes.Add(new CameraShake(m_CameraPhysicsPreset.CameraShakes.ExplosionShake, m_PositionShakeSpring, m_RotationShakeSpring, scale));
		}

		private void OnShakeEvent(ShakeEventData shake)
		{
			if (shake.ShakeType == ShakeType.Explosion)
			{
				float sqrMagnitude = (base.transform.position - shake.Position).sqrMagnitude;
				float num = shake.Radius * shake.Radius;
				if (num - sqrMagnitude > 0f)
				{
					float num2 = 1f - Mathf.Clamp01(sqrMagnitude / num);
					AddExplosionShake(num2 * shake.Scale);
				}
			}
		}

		private void UpdateShakes()
		{
			if (m_Shakes.Count == 0)
			{
				return;
			}
			int num = 0;
			do
			{
				if (m_Shakes[num].IsDone)
				{
					m_Shakes.RemoveAt(num);
					continue;
				}
				m_Shakes[num].Update();
				num++;
			}
			while (num < m_Shakes.Count);
		}

		public void SetStateToVisualize(CameraMotionState state, float speed = 4f)
		{
			m_StateToVisualize = state;
			m_VisualizationSpeed = speed;
			m_CurrentMovingBobParam = 0f;
		}

		public void AdjustRecoilSprings(SpringSettings springSettings)
		{
			m_PositionSpring_Recoil.Adjust(springSettings.Position);
			m_RotationSpring_Recoil.Adjust(springSettings.Rotation);
		}

		public void AddPositionForce(Vector3 positionForce, int distribution = 1)
		{
			if (distribution <= 1)
			{
				m_PositionSpring_Force.AddForce(positionForce);
			}
			else
			{
				m_PositionSpring_Force.AddDistributedForce(positionForce, distribution);
			}
		}

		public void AddRotationForce(Vector3 rotationForce, int distribution = 1)
		{
			if (distribution <= 1)
			{
				m_RotationSpring_Force.AddForce(rotationForce);
			}
			else
			{
				m_RotationSpring_Force.AddDistributedForce(rotationForce, distribution);
			}
		}

		private void Awake()
		{
			PhysicsEnabled = true;
			Spring.Data data = new Spring.Data(new Vector3(0.1f, 0.1f, 0.1f), new Vector3(0.25f, 0.25f, 0.25f));
			m_PositionSpring = new Spring(Spring.Type.OverrideLocalPosition, base.transform, Vector3.zero);
			m_PositionSpring.Adjust(data);
			m_RotationSpring = new Spring(Spring.Type.OverrideLocalRotation, base.transform, Vector3.zero);
			m_PositionSpring.Adjust(data);
			m_PositionSpring_Force = new Spring(Spring.Type.AddToLocalPosition, base.transform, Vector3.zero);
			m_PositionSpring_Force.Adjust(data);
			m_RotationSpring_Force = new Spring(Spring.Type.AddToLocalRotation, base.transform, Vector3.zero);
			m_RotationSpring_Force.Adjust(data);
			m_PositionSpring_Recoil = new Spring(Spring.Type.AddToLocalPosition, base.transform, Vector3.zero, m_SpringController.SpringLerpSpeed);
			m_PositionSpring_Recoil.Adjust(data);
			m_RotationSpring_Recoil = new Spring(Spring.Type.AddToLocalRotation, base.transform, Vector3.zero, m_SpringController.SpringLerpSpeed);
			m_RotationSpring_Recoil.Adjust(data);
			m_PositionShakeSpring = new Spring(Spring.Type.AddToLocalPosition, base.transform, Vector3.zero);
			m_PositionShakeSpring.Adjust(m_CameraPhysicsPreset.CameraShakes.ShakeSpringSettings.Position);
			m_RotationShakeSpring = new Spring(Spring.Type.AddToLocalRotation, base.transform, Vector3.zero);
			m_RotationShakeSpring.Adjust(m_CameraPhysicsPreset.CameraShakes.ShakeSpringSettings.Rotation);
			base.Player.FallImpact.AddListener(OnFallImpact);
			base.Player.Jump.AddStartListener(On_Jump);
			base.Player.MoveCycleEnded.AddListener(On_StepTaken);
			base.Player.ChangeHealth.AddListener(OnPlayerHealthChanged);
			base.Player.Death.AddListener(delegate
			{
				PhysicsEnabled = false;
			});
			base.Player.Respawn.AddListener(OnPlayerRespawn);
			ShakeManager.ShakeEvent.AddListener(OnShakeEvent);
		}

		private void OnPlayerRespawn()
		{
			PhysicsEnabled = true;
			m_PositionSpring.Reset();
			m_RotationSpring.Reset();
			m_PositionSpring_Force.Reset();
			m_RotationSpring_Force.Reset();
			m_PositionSpring_Recoil.Reset();
			m_RotationSpring_Recoil.Reset();
			m_PositionShakeSpring.Reset();
			m_RotationShakeSpring.Reset();
		}

		private void OnDestroy()
		{
			ShakeManager.ShakeEvent.RemoveListener(OnShakeEvent);
		}

		public void DisableCameraPhysics()
		{
			PhysicsEnabled = false;
		}

		public void EnableCameraPhysics()
		{
			PhysicsEnabled = true;
		}

		private void FixedUpdate()
		{
			if (PhysicsEnabled)
			{
				if (m_CameraPhysicsPreset != null)
				{
					m_StatePosition = Vector3.zero;
					m_StateRotation = Vector3.zero;
					UpdateState();
					UpdateOffset();
					UpdateMovementBob(Time.fixedDeltaTime);
					UpdateStationaryBob(Time.fixedDeltaTime);
					UpdateSway();
					UpdateNoise();
					m_StatePosition *= m_SpringController.SpringForceMultiplier;
					m_StateRotation *= m_SpringController.SpringForceMultiplier;
					m_PositionSpring.AddForce(m_StatePosition);
					m_RotationSpring.AddForce(m_StateRotation);
				}
				m_PositionSpring.FixedUpdate();
				m_RotationSpring.FixedUpdate();
				m_PositionSpring_Force.FixedUpdate();
				m_RotationSpring_Force.FixedUpdate();
				m_PositionSpring_Recoil.FixedUpdate();
				m_RotationSpring_Recoil.FixedUpdate();
				m_PositionShakeSpring.FixedUpdate();
				m_RotationShakeSpring.FixedUpdate();
				UpdateShakes();
			}
		}

		private void LateUpdate()
		{
			if (PhysicsEnabled)
			{
				m_PositionSpring.Update();
				m_RotationSpring.Update();
				m_PositionSpring_Force.Update();
				m_RotationSpring_Force.Update();
				m_PositionSpring_Recoil.Update();
				m_RotationSpring_Recoil.Update();
				m_PositionShakeSpring.Update();
				m_RotationShakeSpring.Update();
				UpdateQueuedCamForces();
			}
		}

		private void UpdateState()
		{
			if (m_StateToVisualize != null)
			{
				TrySetState(m_StateToVisualize);
			}
			else if (base.Player.Run.Active && base.Player.Velocity.Val.sqrMagnitude > 0.2f)
			{
				TrySetState(m_CameraPhysicsPreset.RunState);
			}
			else if (base.Player.Crouch.Active)
			{
				TrySetState(m_CameraPhysicsPreset.CrouchState);
			}
			else if (base.Player.Prone.Active)
			{
				TrySetState(m_CameraPhysicsPreset.ProneState);
			}
			else if (base.Player.Walk.Active && base.Player.Velocity.Val.sqrMagnitude > 0.2f)
			{
				TrySetState(m_CameraPhysicsPreset.WalkState);
			}
			else
			{
				TrySetState(m_CameraPhysicsPreset.IdleState);
			}
		}

		private void TrySetState(CameraMotionState state)
		{
			if (m_CurrentState != state)
			{
				if (m_CurrentState != null && m_CurrentState.ExitForces != null)
				{
					PlayDelayedCameraForces(m_CurrentState.ExitForces);
				}
				m_PositionSpring.Adjust(state.SpringSettings.Position);
				m_RotationSpring.Adjust(state.SpringSettings.Rotation);
				if (state.EnterForces != null)
				{
					PlayDelayedCameraForces(state.EnterForces);
				}
				m_CurrentState = state;
			}
		}

		private void UpdateStationaryBob(float deltaTime)
		{
			if (base.Player.Aim.Active)
			{
				m_CurrentStaticBobParam += deltaTime * m_CameraPhysicsPreset.AimState.Bob.BobSpeed;
				if (m_CurrentStaticBobParam >= MathF.PI * 2f)
				{
					m_CurrentStaticBobParam -= MathF.PI * 2f;
				}
				UpdateBob(m_CurrentStaticBobParam, m_CameraPhysicsPreset.AimState.Bob, AimHeadbobMod);
			}
		}

		private void UpdateMovementBob(float deltaTime)
		{
			if (!m_CurrentState.Bob.Enabled)
			{
				return;
			}
			if (m_StateToVisualize != null)
			{
				m_CurrentMovingBobParam += deltaTime * m_VisualizationSpeed * 2f;
				if (!m_FirstStepTriggered && m_CurrentMovingBobParam >= MathF.PI)
				{
					m_FirstStepTriggered = true;
					ApplyStepForce();
				}
				if (m_CurrentMovingBobParam >= MathF.PI * 2f)
				{
					m_CurrentMovingBobParam -= MathF.PI * 2f;
					m_FirstStepTriggered = false;
					ApplyStepForce();
				}
			}
			else
			{
				m_CurrentMovingBobParam = base.Player.MoveCycle.Get() * MathF.PI;
				if (m_LastFootDown != 0)
				{
					m_CurrentMovingBobParam += MathF.PI;
				}
			}
			UpdateBob(m_CurrentMovingBobParam, m_CurrentState.Bob);
		}

		private void UpdateBob(float currentBobParam, EquipmentMotionState.BobModule bob, float mod = 1f)
		{
			Vector3 vector = bob.PositionAmplitude * 0.0001f;
			vector.x *= -1f;
			m_StatePosition.x += Mathf.Cos(currentBobParam + m_SpringController.PositionBobOffset) * vector.x * mod;
			m_StatePosition.y += Mathf.Cos(currentBobParam * 2f + m_SpringController.PositionBobOffset) * vector.y * mod;
			m_StatePosition.z += Mathf.Cos(currentBobParam + m_SpringController.PositionBobOffset) * vector.z * mod;
			Vector3 vector2 = bob.RotationAmplitude * 0.001f;
			m_StateRotation.x += Mathf.Cos(currentBobParam * 2f + m_SpringController.RotationBobOffset) * vector2.x * mod;
			m_StateRotation.y += Mathf.Cos(currentBobParam + m_SpringController.RotationBobOffset) * vector2.y * mod;
			m_StateRotation.z += Mathf.Cos(currentBobParam + m_SpringController.RotationBobOffset) * vector2.z * mod;
		}

		private void UpdateOffset()
		{
			if (m_CurrentState.Offset.Enabled && !base.Player.Reload.Active)
			{
				m_StatePosition += m_CurrentState.Offset.PositionOffset * 0.0001f;
				m_StateRotation += m_CurrentState.Offset.RotationOffset * 0.02f;
			}
		}

		private void UpdateSway()
		{
			float num = (base.Player.Aim.Active ? m_CameraPhysicsPreset.Sway.AimMultiplier : 1f);
			num *= Time.fixedDeltaTime;
			Vector2 vector = base.Player.LookInput.Get();
			vector *= m_CameraPhysicsPreset.Sway.LookInputMultiplier;
			vector = Vector2.ClampMagnitude(vector, m_CameraPhysicsPreset.Sway.MaxLookInput);
			Vector2 vector2 = base.Player.Velocity.Get();
			if (Mathf.Abs(vector2.y) < 1.5f)
			{
				vector2.y = 0f;
			}
			Vector3 vector3 = base.transform.InverseTransformDirection(vector2 / 60f);
			m_PositionSpring.AddForce(new Vector3(vector.x * m_CameraPhysicsPreset.Sway.LookPositionSway.x * 0.125f, vector.y * m_CameraPhysicsPreset.Sway.LookPositionSway.y * -0.125f, vector.y * m_CameraPhysicsPreset.Sway.LookPositionSway.z * -0.125f) * num);
			m_RotationSpring.AddForce(new Vector3(vector.y * m_CameraPhysicsPreset.Sway.LookRotationSway.x * 1.25f, vector.x * m_CameraPhysicsPreset.Sway.LookRotationSway.y * -1.25f, vector.x * m_CameraPhysicsPreset.Sway.LookRotationSway.z * -1.25f) * num);
			Vector3 forceVector = m_CameraPhysicsPreset.Sway.FallSway * vector2.y * 0.2f * num;
			if (base.Player.IsGrounded.Get())
			{
				forceVector *= 15f * num;
			}
			forceVector.z = Mathf.Max(0f, m_CameraPhysicsPreset.Sway.FallSway.z);
			m_RotationSpring.AddForce(forceVector);
			m_PositionSpring.AddForce(new Vector3(vector3.x * m_CameraPhysicsPreset.Sway.StrafePositionSway.x * 0.08f, 0f - Mathf.Abs(vector3.x * m_CameraPhysicsPreset.Sway.StrafePositionSway.y * 0.08f), (0f - vector3.z) * m_CameraPhysicsPreset.Sway.StrafePositionSway.z * 0.08f) * num);
			m_RotationSpring.AddForce(new Vector3(0f - Mathf.Abs(vector3.x * m_CameraPhysicsPreset.Sway.StrafeRotationSway.x * 8f), (0f - vector3.x) * m_CameraPhysicsPreset.Sway.StrafeRotationSway.y * 8f, vector3.x * m_CameraPhysicsPreset.Sway.StrafeRotationSway.z * 8f) * num);
		}

		private void UpdateNoise()
		{
			if (m_CurrentState.Noise.Enabled)
			{
				EquipmentMotionState.NoiseModule noiseModule = (base.Player.Aim.Active ? m_CameraPhysicsPreset.AimState.Noise : m_CurrentState.Noise);
				float num = UnityEngine.Random.Range(0f, m_CurrentState.Noise.MaxJitter);
				float y = Time.time * m_CurrentState.Noise.NoiseSpeed;
				m_StatePosition.x += (Mathf.PerlinNoise(num, y) - 0.5f) * noiseModule.PosNoiseAmplitude.x / 1000f;
				m_StatePosition.y += (Mathf.PerlinNoise(num + 1f, y) - 0.5f) * noiseModule.PosNoiseAmplitude.y / 1000f;
				m_StatePosition.z += (Mathf.PerlinNoise(num + 2f, y) - 0.5f) * noiseModule.PosNoiseAmplitude.z / 1000f;
				m_StateRotation.x += (Mathf.PerlinNoise(num, y) - 0.5f) * noiseModule.RotNoiseAmplitude.x / 10f;
				m_StateRotation.y += (Mathf.PerlinNoise(num + 1f, y) - 0.5f) * noiseModule.RotNoiseAmplitude.y / 10f;
				m_StateRotation.z += (Mathf.PerlinNoise(num + 2f, y) - 0.5f) * noiseModule.RotNoiseAmplitude.z / 10f;
			}
		}

		private void On_StepTaken()
		{
			if (base.Player.Velocity.Val.sqrMagnitude > 0.2f && m_CameraPhysicsPreset != null)
			{
				ApplyStepForce();
			}
			m_LastFootDown = ((m_LastFootDown == 0) ? 1 : 0);
		}

		private void ApplyStepForce()
		{
			EquipmentPhysics.StepForceModule stepForceModule = null;
			stepForceModule = m_CurrentState.StepForce;
			if (stepForceModule != null && stepForceModule.Enabled && !base.Player.Aim.Active)
			{
				m_PositionSpring.AddForce(stepForceModule.PositionForce.Force * 0.0001f, stepForceModule.PositionForce.Distribution);
				m_RotationSpring.AddForce(stepForceModule.RotationForce.Force * 0.01f, stepForceModule.RotationForce.Distribution);
			}
		}

		private void OnPlayerHealthChanged(DamageInfo healthEventData)
		{
			if (healthEventData.Delta < -8f)
			{
				Vector3 vector = ((healthEventData.HitDirection == Vector3.zero) ? UnityEngine.Random.onUnitSphere : healthEventData.HitDirection.normalized);
				vector *= Mathf.Abs(healthEventData.Delta / 80f);
				Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
				AddPositionForce(base.transform.InverseTransformVector(vector) * m_CameraPhysicsPreset.GetHitForce.PosForce);
				AddRotationForce(onUnitSphere * m_CameraPhysicsPreset.GetHitForce.RotForce);
			}
		}

		private void OnFallImpact(float impactVelocity)
		{
			float num = Mathf.Abs(impactVelocity);
			if (num > m_CameraPhysicsPreset.FallImpact.FallImpactRange.x)
			{
				float num2 = Mathf.Clamp01(num / m_CameraPhysicsPreset.FallImpact.FallImpactRange.y);
				AddPositionForce(base.transform.InverseTransformVector(m_CameraPhysicsPreset.FallImpact.PosForce.Force) * num2, m_CameraPhysicsPreset.FallImpact.PosForce.Distribution);
				AddRotationForce(m_CameraPhysicsPreset.FallImpact.RotForce.Force * num2, m_CameraPhysicsPreset.FallImpact.RotForce.Distribution);
			}
		}

		private void On_Jump()
		{
			if (!(m_CameraPhysicsPreset == null) && m_CameraPhysicsPreset.Jump.Enabled)
			{
				m_PositionSpring.AddDistributedForce(m_CameraPhysicsPreset.Jump.PositionForce.Force / 100f, m_CameraPhysicsPreset.Jump.PositionForce.Distribution);
				m_RotationSpring.AddDistributedForce(m_CameraPhysicsPreset.Jump.RotationForce.Force / 10f, m_CameraPhysicsPreset.Jump.RotationForce.Distribution);
			}
		}

		private void UpdateQueuedCamForces()
		{
			for (int i = 0; i < m_QueuedCamForces.Count; i++)
			{
				if (Time.time >= m_QueuedCamForces[i].PlayTime)
				{
					SpringForce force = m_QueuedCamForces[i].DelayedForce.Force;
					base.Player.Camera.Physics.AddRotationForce(force.Force, force.Distribution);
					m_QueuedCamForces.RemoveAt(i);
				}
			}
		}
	}
}
