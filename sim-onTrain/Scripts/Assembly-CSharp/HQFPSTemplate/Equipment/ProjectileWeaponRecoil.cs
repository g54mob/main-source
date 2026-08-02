using System.Collections;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[RequireComponent(typeof(ProjectileWeapon))]
	public class ProjectileWeaponRecoil : PlayerComponent, IEquipmentComponent
	{
		[SerializeField]
		private ProjectileWeaponRecoilInfo m_RecoilInfo;

		private ProjectileWeapon m_Weapon;

		private bool m_AdditiveRecoilActive;

		private bool m_RecoilControlActive;

		private float m_RecoilStartTime;

		private Vector2 m_RecoilToAdd;

		private Vector2 m_RecoilToAddStart;

		private float m_RecoilFrameRemove;

		private Coroutine m_RecoilControlCoroutine;

		public void Initialize(EquipmentItem equipmentItem)
		{
			m_Weapon = equipmentItem as ProjectileWeapon;
		}

		public void OnSelected()
		{
			m_Weapon.EHandler.EPhysicsHandler.AdjustRecoilSprings(m_RecoilInfo.ViewModelRecoil.SpringData);
			base.Player.Camera.Physics.AdjustRecoilSprings(m_RecoilInfo.CameraRecoil.SpringData);
			m_Weapon.EHandler.UsingItem.AddStartListener(StartRecoil);
			m_Weapon.EHandler.UsingItem.AddStopListener(StopRecoil);
			m_Weapon.FireHitPoints.AddListener(AddImpulseRecoil);
			m_Weapon.DryFire.AddListener(AddDryFireForce);
			base.Player.ChangeUseMode.AddListener(ChangeFireModeForce);
		}

		private void OnDisable()
		{
			m_Weapon.EHandler.UsingItem.RemoveStartListener(StartRecoil);
			m_Weapon.EHandler.UsingItem.RemoveStopListener(StopRecoil);
			m_Weapon.FireHitPoints.RemoveListener(AddImpulseRecoil);
			m_Weapon.DryFire.RemoveListener(AddDryFireForce);
			base.Player.ChangeUseMode.RemoveListener(ChangeFireModeForce);
		}

		private void AddImpulseRecoil(Vector3[] impactPoints)
		{
			float forceMultiplier = m_RecoilInfo.ViewModelRecoil.RecoilOverTime.Evaluate((float)m_Weapon.EHandler.ContinuouslyUsedTimes / (float)m_Weapon.MagazineSize);
			for (int i = 0; i < impactPoints.Length; i++)
			{
				ApplyModelRecoilForce(base.Player.Aim.Active ? m_RecoilInfo.ViewModelRecoil.AimShootForce : m_RecoilInfo.ViewModelRecoil.ShootForce, forceMultiplier);
				ApplyCamRecoilForce(m_RecoilInfo.CameraRecoil.ShootForce, base.Player.Aim.Active ? m_RecoilInfo.CameraRecoil.AimMultiplier : 1f);
			}
			if (m_RecoilInfo.CameraRecoil.ShootShake.PositionAmplitude != Vector3.zero || m_RecoilInfo.CameraRecoil.ShootShake.RotationAmplitude != Vector3.zero)
			{
				base.Player.Camera.Physics.DoShake(m_RecoilInfo.CameraRecoil.ShootShake, 1f);
			}
		}

		private void AddDryFireForce()
		{
			ApplyModelRecoilForce(m_RecoilInfo.ViewModelRecoil.DryFireForce);
		}

		private void StartRecoil()
		{
			m_RecoilStartTime = Time.time;
			m_AdditiveRecoilActive = true;
			m_RecoilControlActive = false;
			m_RecoilToAdd = Vector2.zero;
			if (m_RecoilControlCoroutine != null)
			{
				StopCoroutine(m_RecoilControlCoroutine);
			}
		}

		private void Update()
		{
			if (m_RecoilInfo.CameraRecoil.RecoilPattern.Length == 0)
			{
				return;
			}
			if (m_AdditiveRecoilActive)
			{
				int num = Mathf.Clamp(m_Weapon.EHandler.ContinuouslyUsedTimes - 1, 0, m_RecoilInfo.CameraRecoil.RecoilPattern.Length - 1);
				Vector2 vector = new Vector2(m_RecoilInfo.CameraRecoil.RecoilPattern[num].x * m_RecoilInfo.CameraRecoil.RecoilPatternMultiplier * Time.deltaTime, m_RecoilInfo.CameraRecoil.RecoilPattern[num].y * m_RecoilInfo.CameraRecoil.RecoilPatternMultiplier * Time.deltaTime);
				if (base.Player.Aim.Active)
				{
					vector *= m_RecoilInfo.CameraRecoil.AimMultiplier;
				}
				base.Player.Camera.MoveCamera(vector.x, vector.y);
				Vector2 vector2 = -base.Player.Camera.LastMovement;
				m_RecoilToAdd -= vector;
				if (m_RecoilToAdd.x != 0f && Mathf.Sign(vector2.x) != Mathf.Sign(m_RecoilToAdd.x))
				{
					m_RecoilToAdd.x = Mathf.Max(m_RecoilToAdd.x + vector2.x, 0f);
				}
				if (m_RecoilToAdd.y != 0f && Mathf.Sign(vector2.y) != Mathf.Sign(m_RecoilToAdd.y))
				{
					m_RecoilToAdd.y = Mathf.Max(m_RecoilToAdd.y + vector2.y, 0f);
				}
			}
			else if (m_RecoilInfo.CameraRecoil.HasRecoilControl && m_RecoilControlActive)
			{
				Vector2 lastMovement = base.Player.Camera.LastMovement;
				if (m_RecoilToAdd.x != 0f && Mathf.Sign(lastMovement.x) != Mathf.Sign(m_RecoilToAdd.x))
				{
					m_RecoilToAdd.x = Mathf.Max(m_RecoilToAdd.x + lastMovement.x, 0f);
				}
				if (m_RecoilToAdd.y != 0f && Mathf.Sign(lastMovement.y) != Mathf.Sign(m_RecoilToAdd.y))
				{
					m_RecoilToAdd.y = Mathf.Max(m_RecoilToAdd.y + lastMovement.y, 0f);
				}
				Vector2 recoilToAdd = m_RecoilToAdd;
				float num2 = Mathf.Clamp01(1f - (0f - m_RecoilToAdd.x) / (0f - m_RecoilToAddStart.x));
				float num3 = m_RecoilInfo.CameraRecoil.RecoilControlCurve.Evaluate(float.IsNaN(num2) ? 0f : num2);
				RemoveRecoil(ref m_RecoilToAdd, Time.deltaTime * m_RecoilFrameRemove * num3);
				Vector2 vector3 = m_RecoilToAdd - recoilToAdd;
				base.Player.Camera.LookAngles -= vector3;
				if (m_RecoilToAdd.sqrMagnitude < 0.15f)
				{
					m_RecoilControlActive = false;
				}
			}
		}

		private void StopRecoil()
		{
			m_AdditiveRecoilActive = false;
			if (m_RecoilControlCoroutine != null)
			{
				StopCoroutine(m_RecoilControlCoroutine);
			}
			m_RecoilControlCoroutine = StartCoroutine(C_StartRecoilControl());
		}

		private void RemoveRecoil(ref Vector2 recoil, float amount)
		{
			float num = Mathf.Sign(recoil.x);
			float num2 = Mathf.Sign(recoil.y);
			recoil.x -= recoil.x * amount;
			recoil.y -= recoil.y * amount;
			if (Mathf.Sign(recoil.x) != num)
			{
				recoil.x = 0f;
			}
			if (Mathf.Sign(recoil.y) != num2)
			{
				recoil.y = 0f;
			}
		}

		private void ChangeFireModeForce()
		{
			ApplyModelRecoilForce(m_RecoilInfo.ViewModelRecoil.ChangeFireModeForce);
		}

		private void ApplyCamRecoilForce(RecoilForce force, float forceMultiplier = 1f)
		{
			base.Player.Camera.Physics.AddPositionForce(force.PositionForce * forceMultiplier, force.Distribution);
			base.Player.Camera.Physics.AddRotationForce(force.RotationForce * forceMultiplier, force.Distribution);
		}

		private void ApplyModelRecoilForce(RecoilForce force, float forceMultiplier = 1f)
		{
			m_Weapon.EHandler.EPhysicsHandler.ApplyPositionRecoil(force.PositionForce * forceMultiplier);
			m_Weapon.EHandler.EPhysicsHandler.ApplyRotationRecoil(force.RotationForce * forceMultiplier);
		}

		private IEnumerator C_StartRecoilControl()
		{
			yield return new WaitForSeconds(m_RecoilInfo.CameraRecoil.RecoilControlDelay);
			if (!m_Weapon.EHandler.UsingItem.Active)
			{
				m_RecoilFrameRemove = Mathf.Clamp(m_RecoilToAdd.x * Mathf.Max(1f, 1f - 1f / (m_RecoilInfo.CameraRecoil.RecoilControlSpeedMod * (Time.time - m_RecoilStartTime))), m_RecoilInfo.CameraRecoil.RecoilControlSpeedRange.x, m_RecoilInfo.CameraRecoil.RecoilControlSpeedRange.y);
				m_RecoilToAddStart = m_RecoilToAdd;
				m_RecoilControlActive = true;
			}
		}
	}
}
