using System;
using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[RequireComponent(typeof(EquipmentHandler))]
	public class EquipmentPhysicsHandler : PlayerComponent
	{
		[SerializeField]
		[Group]
		private SpringControlInfo m_SpringController;

		private EquipmentHandler m_FPHandler;

		private EquipmentPhysicsInfo m_Physics;

		private Transform m_Pivot;

		private Vector3 m_ModelOffset;

		private Vector3 m_OriginalRootPosition;

		private Quaternion m_OriginalRootRotation;

		private Spring m_PositionSpring;

		private Spring m_RotationSpring;

		private Spring m_PosRecoilSpring;

		private Spring m_RotRecoilSpring;

		private EquipmentMotionState m_CurrentState;

		private Vector3 m_StatePosition;

		private Vector3 m_StateRotation;

		private float m_ChangeToDefaultOffestTime;

		private float m_LerpedOffset;

		private int m_LastFootDown;

		private float m_CurrentBobParam;

		private EquipmentMotionState m_StateToVisualize;

		private float m_VisualizationSpeed = 4f;

		private bool m_FirstStepTriggered;

		private List<Transform> m_PivotChildren = new List<Transform>();

		public void AdjustRecoilSprings(SpringSettings springSettings)
		{
			m_PosRecoilSpring.Adjust(springSettings.Position);
			m_RotRecoilSpring.Adjust(springSettings.Rotation);
		}

		public void ApplyPositionRecoil(Vector3 force, int distribution = 1)
		{
			if (distribution <= 1)
			{
				m_PosRecoilSpring.AddForce(force);
			}
			else
			{
				m_PosRecoilSpring.AddDistributedForce(force, distribution);
			}
		}

		public void ApplyRotationRecoil(Vector3 force, int distribution = 1)
		{
			if (distribution <= 1)
			{
				m_RotRecoilSpring.AddForce(force);
			}
			else
			{
				m_RotRecoilSpring.AddDistributedForce(force, distribution);
			}
		}

		public void SetStateToVisualize(EquipmentMotionState state, float speed)
		{
			m_StateToVisualize = state;
			m_VisualizationSpeed = speed;
			m_CurrentBobParam = 0f;
		}

		public void ReadjustSprings()
		{
			m_PositionSpring.Adjust(m_CurrentState.SpringSettings.Position);
			m_RotationSpring.Adjust(m_CurrentState.SpringSettings.Rotation);
		}

		public void SetOffset()
		{
			base.transform.localPosition = m_OriginalRootPosition + m_Physics.GeneralSettings.BasePosOffset;
			base.transform.localRotation = Quaternion.Euler(m_Physics.GeneralSettings.BaseRotOffset + m_OriginalRootRotation.eulerAngles);
		}

		private void Start()
		{
			base.Player.FallImpact.AddListener(On_FallImpact);
			base.Player.MoveCycleEnded.AddListener(On_StepTaken);
			base.Player.Death.AddListener(ClearCurrentState);
			base.Player.Jump.AddStartListener(On_Jump);
			m_FPHandler = GetComponent<EquipmentHandler>();
			m_FPHandler.OnChangeItem.AddListener(On_ChangeItem);
			base.transform.ResetLocal();
			foreach (Transform item in base.transform)
			{
				Transform transform2 = (item.parent = base.transform);
				if ((bool)transform2)
				{
					m_PivotChildren.Add(item);
				}
			}
			m_ModelOffset = m_PivotChildren[0].localPosition;
			GameObject gameObject = new GameObject("Pivot");
			m_Pivot = gameObject.transform;
			m_Pivot.SetParent(base.transform, worldPositionStays: true);
			m_Pivot.ResetLocal();
			m_PositionSpring = new Spring(Spring.Type.OverrideLocalPosition, m_Pivot, Vector3.zero, m_SpringController.SpringLerpSpeed);
			m_RotationSpring = new Spring(Spring.Type.OverrideLocalRotation, m_Pivot, Vector3.zero, m_SpringController.SpringLerpSpeed);
			m_PosRecoilSpring = new Spring(Spring.Type.AddToLocalPosition, m_Pivot, Vector3.zero);
			m_RotRecoilSpring = new Spring(Spring.Type.AddToLocalRotation, m_Pivot, Vector3.zero);
		}

		private void FixedUpdate()
		{
			if (m_Physics != null)
			{
				m_StatePosition = Vector3.zero;
				m_StateRotation = Vector3.zero;
				UpdateState();
				UpdateOffset();
				UpdateBob(Time.fixedDeltaTime);
				UpdateSway();
				UpdateNoise();
				m_StatePosition *= m_SpringController.SpringForceMultiplier;
				m_StateRotation *= m_SpringController.SpringForceMultiplier;
				m_PositionSpring.AddForce(m_StatePosition);
				m_RotationSpring.AddForce(m_StateRotation);
				m_RotationSpring.FixedUpdate();
				m_PositionSpring.FixedUpdate();
				m_PosRecoilSpring.FixedUpdate();
				m_RotRecoilSpring.FixedUpdate();
			}
		}

		private void Update()
		{
			if (m_Physics != null)
			{
				m_RotationSpring.Update();
				m_PositionSpring.Update();
				m_PosRecoilSpring.Update();
				m_RotRecoilSpring.Update();
			}
		}

		private void On_ChangeItem()
		{
			m_Physics = m_FPHandler.EquipmentItem.EPhysics;
			if (m_Physics != null)
			{
				ClearCurrentState();
			}
			foreach (Transform pivotChild in m_PivotChildren)
			{
				pivotChild.SetParent(base.transform.parent);
				pivotChild.localPosition = m_ModelOffset;
				pivotChild.localRotation = Quaternion.identity;
			}
			m_Pivot.SetParent(base.transform.parent);
			m_Pivot.position = ((m_FPHandler.EquipmentItem.PhysicsPivot != null) ? m_FPHandler.EquipmentItem.PhysicsPivot.position : m_Pivot.position);
			m_Pivot.localRotation = Quaternion.identity;
			base.transform.position = m_Pivot.position;
			base.transform.rotation = m_Pivot.rotation;
			m_OriginalRootPosition = base.transform.localPosition;
			m_OriginalRootRotation = base.transform.localRotation;
			m_Pivot.SetParent(base.transform, worldPositionStays: true);
			foreach (Transform pivotChild2 in m_PivotChildren)
			{
				pivotChild2.SetParent(m_Pivot, worldPositionStays: true);
			}
			SetOffset();
		}

		private void UpdateState()
		{
			if (m_StateToVisualize != null)
			{
				TrySetState(m_StateToVisualize);
			}
			else if (base.Player.Run.Active && base.Player.Velocity.Val.sqrMagnitude > 0.2f && base.Player.UseItem.LastExecutionTime + 0.3f < Time.time)
			{
				TrySetState(m_Physics.RunState);
			}
			else if (base.Player.Aim.Active)
			{
				TrySetState(m_Physics.AimState);
			}
			else if (base.Player.Crouch.Active)
			{
				TrySetState(m_Physics.CrouchState);
			}
			else if (base.Player.Prone.Active)
			{
				TrySetState(m_Physics.ProneState);
			}
			else if (base.Player.Walk.Active && base.Player.Velocity.Val.sqrMagnitude > 0.2f)
			{
				TrySetState(m_Physics.WalkState);
			}
			else
			{
				TrySetState(m_Physics.IdleState);
			}
		}

		private void TrySetState(EquipmentMotionState state)
		{
			if (m_CurrentState == state)
			{
				return;
			}
			if (m_CurrentState != null && ((m_CurrentState.EntryOffset.Enabled && m_ChangeToDefaultOffestTime < Time.time) || !m_CurrentState.EntryOffset.Enabled) && (m_CurrentState != m_Physics.CrouchState || state != m_Physics.AimState))
			{
				float num = ((state == m_Physics.AimState) ? 0.15f : 1f);
				m_RotationSpring.AddForce(m_CurrentState.ExitForce * num);
				m_PositionSpring.AddForce(m_CurrentState.PosExitForce * num);
			}
			float num2 = ((m_CurrentState == m_Physics.AimState) ? 0.15f : 1f);
			m_CurrentState = state;
			ReadjustSprings();
			if (m_CurrentState != null)
			{
				if (m_CurrentState.EntryOffset.Enabled)
				{
					m_ChangeToDefaultOffestTime = Time.time + m_CurrentState.EntryOffset.EntryOffsetDuration;
				}
				m_LerpedOffset = 0f;
				m_RotationSpring.AddForce(m_CurrentState.EnterForce * num2);
				m_PositionSpring.AddForce(m_CurrentState.PosEnterForce * num2);
			}
		}

		private void ClearCurrentState()
		{
			m_PositionSpring.Reset();
			m_RotationSpring.Reset();
			m_Pivot.ResetLocal();
			m_StatePosition = (m_StateRotation = Vector3.zero);
			m_CurrentState = null;
		}

		private void UpdateOffset()
		{
			if (!m_CurrentState.Offset.Enabled || base.Player.Reload.Active)
			{
				return;
			}
			if (m_CurrentState.EntryOffset.Enabled)
			{
				if (m_ChangeToDefaultOffestTime > Time.time)
				{
					m_StatePosition += m_CurrentState.EntryOffset.Offset.PositionOffset * 0.0001f;
					m_StateRotation += m_CurrentState.EntryOffset.Offset.RotationOffset * 0.02f;
				}
				else
				{
					m_LerpedOffset = Mathf.Lerp(m_LerpedOffset, 1f, Time.deltaTime * m_CurrentState.EntryOffset.LerpToOffsetSpeed);
					m_StatePosition += m_CurrentState.Offset.PositionOffset * 0.0001f * m_LerpedOffset;
					m_StateRotation += m_CurrentState.Offset.RotationOffset * 0.02f * m_LerpedOffset;
				}
			}
			else
			{
				m_StatePosition += m_CurrentState.Offset.PositionOffset * 0.0001f;
				m_StateRotation += m_CurrentState.Offset.RotationOffset * 0.02f;
			}
		}

		private void UpdateBob(float deltaTime)
		{
			if (!m_CurrentState.Bob.Enabled || (base.Player.Velocity.Get().sqrMagnitude < 0.1f && base.Player.Aim.Active))
			{
				return;
			}
			if (m_StateToVisualize != null)
			{
				m_CurrentBobParam += deltaTime * m_VisualizationSpeed * 2f;
				if (!m_FirstStepTriggered && m_CurrentBobParam >= MathF.PI)
				{
					m_FirstStepTriggered = true;
					ApplyStepForce();
				}
				if (m_CurrentBobParam >= MathF.PI * 2f)
				{
					m_CurrentBobParam -= MathF.PI * 2f;
					m_FirstStepTriggered = false;
					ApplyStepForce();
				}
			}
			else
			{
				m_CurrentBobParam = base.Player.MoveCycle.Get() * MathF.PI;
				if (m_LastFootDown != 0)
				{
					m_CurrentBobParam += MathF.PI;
				}
			}
			Vector3 zero = Vector3.zero;
			zero.x = m_CurrentState.Bob.PositionAmplitude.x * -1E-05f;
			zero.y = m_CurrentState.Bob.PositionAmplitude.y * 1E-05f;
			zero.z = m_CurrentState.Bob.PositionAmplitude.z * 1E-05f;
			m_StatePosition.x += Mathf.Cos(m_CurrentBobParam + m_SpringController.PositionBobOffset) * zero.x;
			m_StatePosition.y += Mathf.Cos(m_CurrentBobParam * 2f + m_SpringController.PositionBobOffset) * zero.y;
			m_StatePosition.z += Mathf.Cos(m_CurrentBobParam + m_SpringController.PositionBobOffset) * zero.z;
			Vector3 vector = m_CurrentState.Bob.RotationAmplitude * 0.001f;
			m_StateRotation.x += Mathf.Cos(m_CurrentBobParam * 2f + m_SpringController.RotationBobOffset) * vector.x;
			m_StateRotation.y += Mathf.Cos(m_CurrentBobParam + m_SpringController.RotationBobOffset) * vector.y;
			m_StateRotation.z += Mathf.Cos(m_CurrentBobParam + m_SpringController.RotationBobOffset) * vector.z;
		}

		private void UpdateSway()
		{
			float fixedDeltaTime = Time.fixedDeltaTime;
			float num = fixedDeltaTime * (base.Player.Aim.Active ? m_Physics.Sway.AimMultiplier : 1f);
			Vector2 vector = base.Player.LookInput.Get();
			vector *= m_Physics.Sway.LookInputMultiplier;
			vector = Vector2.ClampMagnitude(vector, m_Physics.Sway.MaxLookInput);
			Vector3 vector2 = base.Player.Velocity.Get();
			Vector3 vector3 = base.transform.InverseTransformVector(vector2 / 60f);
			if (Mathf.Abs(vector2.y) < 1.5f)
			{
				vector2.y = 0f;
			}
			m_PositionSpring.AddForce(new Vector3(vector.x * m_Physics.Sway.LookPositionSway.x * 0.125f, vector.y * m_Physics.Sway.LookPositionSway.y * -0.125f, vector.y * m_Physics.Sway.LookPositionSway.z * -0.125f) * num);
			m_RotationSpring.AddForce(new Vector3(vector.y * m_Physics.Sway.LookRotationSway.x * 1.25f, vector.x * m_Physics.Sway.LookRotationSway.y * -1.25f, vector.x * m_Physics.Sway.LookRotationSway.z * -1.25f) * num);
			Vector3 forceVector = m_Physics.Sway.FallSway * vector2.y * 0.2f * fixedDeltaTime;
			if (base.Player.IsGrounded.Get())
			{
				forceVector *= 30f * fixedDeltaTime;
			}
			forceVector.z = Mathf.Max(0f, m_Physics.Sway.FallSway.z);
			m_RotationSpring.AddForce(forceVector);
			m_PositionSpring.AddForce(new Vector3(vector3.x * m_Physics.Sway.StrafePositionSway.x * 0.08f, 0f - Mathf.Abs(vector3.x * m_Physics.Sway.StrafePositionSway.y * 0.08f), (0f - vector3.z) * m_Physics.Sway.StrafePositionSway.z * 0.08f) * num);
			m_RotationSpring.AddForce(new Vector3(0f - Mathf.Abs(vector3.x * m_Physics.Sway.StrafeRotationSway.x * 8f), (0f - vector3.x) * m_Physics.Sway.StrafeRotationSway.y * 8f, vector3.x * m_Physics.Sway.StrafeRotationSway.z * 8f) * num);
		}

		private void UpdateNoise()
		{
			if (m_CurrentState.Noise.Enabled)
			{
				float num = UnityEngine.Random.Range(0f, m_CurrentState.Noise.MaxJitter);
				float y = Time.time * m_CurrentState.Noise.NoiseSpeed;
				m_StatePosition.x += (Mathf.PerlinNoise(num, y) - 0.5f) * m_CurrentState.Noise.PosNoiseAmplitude.x / 1000f;
				m_StatePosition.y += (Mathf.PerlinNoise(num + 1f, y) - 0.5f) * m_CurrentState.Noise.PosNoiseAmplitude.y / 1000f;
				m_StatePosition.z += (Mathf.PerlinNoise(num + 2f, y) - 0.5f) * m_CurrentState.Noise.PosNoiseAmplitude.z / 1000f;
				m_StateRotation.x += (Mathf.PerlinNoise(num, y) - 0.5f) * m_CurrentState.Noise.RotNoiseAmplitude.x / 10f;
				m_StateRotation.y += (Mathf.PerlinNoise(num + 1f, y) - 0.5f) * m_CurrentState.Noise.RotNoiseAmplitude.y / 10f;
				m_StateRotation.z += (Mathf.PerlinNoise(num + 2f, y) - 0.5f) * m_CurrentState.Noise.RotNoiseAmplitude.z / 10f;
			}
		}

		private void On_StepTaken()
		{
			if (base.Player.Velocity.Val.sqrMagnitude > 0.2f && m_Physics != null)
			{
				ApplyStepForce();
			}
			m_LastFootDown = ((m_LastFootDown == 0) ? 1 : 0);
		}

		private void ApplyStepForce()
		{
			EquipmentPhysicsInfo.StepForceModule stepForceModule = null;
			if (base.Player.Walk.Active || m_StateToVisualize == m_Physics.ProneState)
			{
				stepForceModule = m_Physics.WalkStepForce;
			}
			else if (base.Player.Crouch.Active || m_StateToVisualize == m_Physics.ProneState)
			{
				stepForceModule = m_Physics.CrouchStepForce;
			}
			else if (base.Player.Run.Active || m_StateToVisualize == m_Physics.ProneState)
			{
				stepForceModule = m_Physics.RunStepForce;
			}
			if (stepForceModule != null && stepForceModule.Enabled && !base.Player.Aim.Active)
			{
				m_PositionSpring.AddForce(stepForceModule.PositionForce.Force * 0.0001f, stepForceModule.PositionForce.Distribution);
				m_RotationSpring.AddForce(stepForceModule.RotationForce.Force * 0.01f, stepForceModule.RotationForce.Distribution);
			}
		}

		private void On_Jump()
		{
			if (!(m_Physics == null) && m_Physics.Jump.Enabled)
			{
				m_PositionSpring.AddDistributedForce(m_Physics.Jump.PositionForce.Force / 100f, m_Physics.Jump.PositionForce.Distribution);
				m_RotationSpring.AddDistributedForce(m_Physics.Jump.RotationForce.Force / 10f, m_Physics.Jump.RotationForce.Distribution);
			}
		}

		private void On_FallImpact(float impactSpeed)
		{
			if (!(m_Physics == null))
			{
				impactSpeed *= (base.Player.Aim.Active ? 0.5f : 1f);
				m_PositionSpring.AddDistributedForce(m_Physics.FallImpact.PositionForce.Force * impactSpeed * 0.0001f, m_Physics.FallImpact.PositionForce.Distribution);
				m_RotationSpring.AddDistributedForce(m_Physics.FallImpact.RotationForce.Force * impactSpeed, m_Physics.FallImpact.RotationForce.Distribution);
			}
		}
	}
}
