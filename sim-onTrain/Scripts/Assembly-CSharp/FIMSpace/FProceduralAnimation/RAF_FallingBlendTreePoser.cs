using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_FallingBlendTreePoser : RagdollAnimatorFeatureUpdate
	{
		private float fallingModeDuration;

		private float stuckDetectTimer;

		private float unstuckPerformTimer;

		private float unstuckVeloPushTimer;

		private int unstuckStage;

		private float groundAngle;

		private Vector3 safeUpRaycastOffset = Vector3.zero;

		private Vector3 lastAppliedImpact = Vector3.zero;

		internal float velocityMagnitude;

		private RaycastHit lastHit;

		private int _hash_FallX = -1;

		private int _hash_FallZ = -1;

		private int _hash_FallG = -1;

		private int _additiveLayer;

		private float smoothDampDuration = 0.1f;

		private float sd_FallX;

		private float sd_FallZ;

		private float sd_FallG;

		private float sd_layer;

		internal Vector3 localVelocity;

		internal ERagdollGetUpType backLay;

		internal ERagdollGetUpType sideLay;

		private FUniversalVariable groundMaskV;

		private FUniversalVariable transitionSpeedV;

		private FUniversalVariable unstuckSensitivityV;

		private FUniversalVariable additiveLayerMaxVelocityV;

		private FUniversalVariable averageBodyVelocityV;

		private FUniversalVariable nearToGroundHeightV;

		private RagdollBonesChain coreChain;

		public override bool UseUpdate => true;

		public Animator Mecanim => base.ParentRagdollHandler.Mecanim;

		public float FallX
		{
			get
			{
				return Mecanim.GetFloat(_hash_FallX);
			}
			protected set
			{
				Mecanim.SetFloat(_hash_FallX, value);
			}
		}

		public float FallZ
		{
			get
			{
				return Mecanim.GetFloat(_hash_FallZ);
			}
			protected set
			{
				Mecanim.SetFloat(_hash_FallZ, value);
			}
		}

		public float FallG
		{
			get
			{
				return Mecanim.GetFloat(_hash_FallG);
			}
			protected set
			{
				Mecanim.SetFloat(_hash_FallG, value);
			}
		}

		private float SetFallX
		{
			set
			{
				FallX = Mathf.SmoothDamp(FallX, value, ref sd_FallX, smoothDampDuration);
			}
		}

		private float SetFallZ
		{
			set
			{
				FallZ = Mathf.SmoothDamp(FallZ, value, ref sd_FallZ, smoothDampDuration);
			}
		}

		private float SetFallG
		{
			set
			{
				FallG = Mathf.SmoothDamp(FallG, value, ref sd_FallG, smoothDampDuration * 1.25f);
			}
		}

		private float GetAdditiveLayerWeight => Mecanim.GetLayerWeight(_additiveLayer);

		private float SmoothSetAdditiveLayer
		{
			set
			{
				SetAdditiveLayerWeight = Mathf.SmoothDamp(GetAdditiveLayerWeight, value, ref sd_layer, 0.15f);
			}
		}

		private float SetAdditiveLayerWeight
		{
			set
			{
				Mecanim.SetLayerWeight(_additiveLayer, value);
			}
		}

		public void PrepareHashesAndLayer()
		{
			_hash_FallX = Animator.StringToHash(base.InitializedWith.RequestVariable("Fall X", "Fall X").GetString());
			_hash_FallZ = Animator.StringToHash(base.InitializedWith.RequestVariable("Fall Z", "Fall Z").GetString());
			_hash_FallG = Animator.StringToHash(base.InitializedWith.RequestVariable("Fall Ground", "Fall Ground").GetString());
			string text = base.InitializedWith.RequestVariable("Additive Body Layer:", "").GetString();
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			for (int i = 0; i < Mecanim.layerCount; i++)
			{
				if (Mecanim.GetLayerName(i) == text)
				{
					_additiveLayer = i;
				}
			}
		}

		public override bool OnInit()
		{
			if (base.ParentRagdollHandler.Mecanim == null)
			{
				return false;
			}
			groundMaskV = base.Helper.RequestVariable("Ground Mask:", 0);
			transitionSpeedV = base.Helper.RequestVariable("Transitioning Duration:", 0.25f);
			unstuckSensitivityV = base.Helper.RequestVariable("Unstuck Sensitivity:", 0f);
			additiveLayerMaxVelocityV = base.Helper.RequestVariable("Additive Layer Max Velocity:", 5f);
			averageBodyVelocityV = base.Helper.RequestVariable("Average Fall Velocity:", 2f);
			nearToGroundHeightV = base.Helper.RequestVariable("Near To Ground Height:", 2f);
			coreChain = base.ParentRagdollHandler.GetChain(ERagdollChainType.Core);
			PrepareHashesAndLayer();
			return base.OnInit();
		}

		public override void Update()
		{
			if (!base.ParentRagdollHandler.IsFallingOrSleep || !base.Helper.Enabled)
			{
				if (_additiveLayer != 0)
				{
					SmoothSetAdditiveLayer = Mathf.Max(GetAdditiveLayerWeight - Time.deltaTime * (base.Helper.Enabled ? 18f : 30f), 0f);
				}
				return;
			}
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			RagdollChainBone getAnchorBoneController = parentRagdollHandler.GetAnchorBoneController;
			safeUpRaycastOffset = Vector3.up * coreChain.ChainBonesLength * 0.1f;
			Physics.Raycast(base.ParentRagdollHandler.User_GetPosition_AnchorCenter() + safeUpRaycastOffset, Vector3.down, out lastHit, 100f, groundMaskV.GetInt(), QueryTriggerInteraction.Ignore);
			Vector3 velocity = getAnchorBoneController.GameRigidbody.velocity;
			Matrix4x4 inverse = Matrix4x4.TRS(q: parentRagdollHandler.User_GetRotation_Mapped(Vector3.up), pos: getAnchorBoneController.GameRigidbody.position, s: Vector3.one).inverse;
			velocityMagnitude = velocity.magnitude;
			if (fallingModeDuration < 0.3f && lastAppliedImpact != Vector3.zero)
			{
				localVelocity = inverse.MultiplyVector(lastAppliedImpact);
				velocityMagnitude = lastAppliedImpact.magnitude;
			}
			else
			{
				localVelocity = inverse.MultiplyVector(velocity);
				lastAppliedImpact = Vector3.zero;
			}
			backLay = parentRagdollHandler.User_CanGetUpByRotation(canBeNone: true, Vector3.up, includeLeftRightSide: false, 0.35f, !base.ParentRagdollHandler.IsHumanoid);
			sideLay = parentRagdollHandler.User_LayingOnSide(Vector3.up);
			smoothDampDuration = transitionSpeedV.GetFloat();
			bool flag = false;
			if ((bool)lastHit.transform && lastHit.distance < nearToGroundHeightV.GetFloat())
			{
				flag = true;
				groundAngle = Vector3.Angle(lastHit.normal, Vector3.up);
			}
			fallingModeDuration += Time.deltaTime;
			if (unstuckSensitivityV.GetFloat() > 0f && unstuckPerformTimer > 0f)
			{
				smoothDampDuration = 0.1f;
				unstuckPerformTimer -= Time.deltaTime * 0.1f;
				if (unstuckPerformTimer > 0.8f)
				{
					UnstuckHelperPush(0);
					SetFallZ = Mathf.Sin(Time.time * 1.5f) * 2f;
					SetFallX = 0f;
					if (fallingModeDuration > 0.3f)
					{
						SetFallG = -1f;
					}
				}
				else if (unstuckPerformTimer > 0.6f)
				{
					UnstuckHelperPush(1, 1f + unstuckSensitivityV.GetFloat());
					SetFallZ = Mathf.Sin(Time.time * 1.9f) * 2f;
					SetFallX = Mathf.Cos(Time.time * 1.9f) * 2f;
					SetFallG = 1f;
				}
				else if (unstuckPerformTimer > 0.4f)
				{
					UnstuckHelperPush(0, 1.25f + unstuckSensitivityV.GetFloat());
					SetFallZ = Mathf.Sin(Time.time * 1.9f) * 0.5f;
					SetFallX = Mathf.Cos(Time.time * 1.9f) * 2f;
					SetFallG = 1f;
				}
				else if (unstuckPerformTimer > 0.2f)
				{
					UnstuckHelperPush(1, 1.75f + unstuckSensitivityV.GetFloat());
					SetFallZ = Mathf.Sin(Time.time * 1.9f) * 2f;
					SetFallX = Mathf.Cos(Time.time * 1.9f) * 2f;
					SetFallG = 0f;
				}
				else
				{
					UnstuckHelperPush(0, 2f + unstuckSensitivityV.GetFloat());
					SetFallZ = Mathf.Sin(Time.time * 1.7f) * 2f;
					SetFallX = Mathf.Cos(Time.time * 1.9f) * 2f;
					if (fallingModeDuration > 0.3f)
					{
						SetFallG = -1f;
					}
				}
				unstuckVeloPushTimer -= Time.deltaTime * (1f + unstuckSensitivityV.GetFloat() * 0.25f);
				if (unstuckVeloPushTimer <= 0f)
				{
					if (groundAngle < 20f)
					{
						DoExtraRaycasts(ref groundAngle);
					}
					if (velocityMagnitude > averageBodyVelocityV.GetFloat() * 0.75f || groundAngle < 20f)
					{
						unstuckPerformTimer = 0f;
					}
				}
				return;
			}
			bool flag2 = false;
			if (velocityMagnitude < averageBodyVelocityV.GetFloat() && flag)
			{
				smoothDampDuration = transitionSpeedV.GetFloat() * 1.1f;
				if (groundAngle > 26f)
				{
					DoExtraRaycasts(ref groundAngle);
				}
				if (groundAngle < 26f && velocityMagnitude < averageBodyVelocityV.GetFloat() * 0.6f)
				{
					SetFallG = 0f;
					if (backLay == ERagdollGetUpType.FromBack)
					{
						SetFallX = 0f;
						SetFallZ = -1f;
					}
					else if (backLay == ERagdollGetUpType.FromFacedown)
					{
						SetFallX = 0f;
						SetFallZ = 1f;
					}
					else if (sideLay == ERagdollGetUpType.FromLeftSide)
					{
						smoothDampDuration = transitionSpeedV.GetFloat() * 1.15f;
						SetFallX = -0.5f;
						SetFallZ = 0f;
						if (velocityMagnitude < averageBodyVelocityV.GetFloat() * 0.2f)
						{
							SetFallX = -1.25f;
							SmoothSetAdditiveLayer = 0.5f;
							flag2 = true;
						}
					}
					else if (sideLay == ERagdollGetUpType.FromRightSide)
					{
						smoothDampDuration = transitionSpeedV.GetFloat() * 1.15f;
						SetFallX = 0.5f;
						SetFallZ = 0f;
						if (velocityMagnitude < averageBodyVelocityV.GetFloat() * 0.2f)
						{
							SetFallX = 1.25f;
							SmoothSetAdditiveLayer = 0.5f;
							flag2 = true;
						}
					}
					else
					{
						smoothDampDuration = transitionSpeedV.GetFloat() * 1.3f;
						SetFallX = 0f;
						SetFallZ = 0f;
					}
				}
				else
				{
					float setFallX = 0f;
					if (fallingModeDuration > 0.3f)
					{
						SetFallG = -1f;
					}
					if (backLay == ERagdollGetUpType.FromBack)
					{
						SetFallZ = -1f;
					}
					else if (backLay == ERagdollGetUpType.FromFacedown)
					{
						SetFallZ = 1f;
					}
					if (sideLay == ERagdollGetUpType.FromLeftSide || sideLay == ERagdollGetUpType.FromRightSide)
					{
						SmoothSetAdditiveLayer = 0.4f;
						flag2 = true;
						if (velocityMagnitude < averageBodyVelocityV.GetFloat() * 0.5f)
						{
							if (sideLay == ERagdollGetUpType.FromLeftSide)
							{
								setFallX = 1f;
							}
							else if (sideLay == ERagdollGetUpType.FromRightSide)
							{
								setFallX = -1f;
							}
						}
					}
					else
					{
						SmoothSetAdditiveLayer = 0.25f;
						flag2 = true;
					}
					SetFallX = setFallX;
				}
				if (unstuckSensitivityV.GetFloat() > 0f)
				{
					if (velocityMagnitude < averageBodyVelocityV.GetFloat() * 0.1f)
					{
						bool flag3 = backLay == ERagdollGetUpType.None;
						if (flag3)
						{
							flag3 = sideLay != ERagdollGetUpType.None;
						}
						if (groundAngle > 15f || flag3)
						{
							stuckDetectTimer += Time.deltaTime;
						}
						if (stuckDetectTimer > 0.8f)
						{
							unstuckPerformTimer = 1f;
							unstuckStage = 0;
						}
					}
					else if (stuckDetectTimer < 0f)
					{
						stuckDetectTimer = 0f;
					}
					else
					{
						stuckDetectTimer -= Time.deltaTime * 2f;
					}
				}
			}
			else
			{
				Vector3 vector = new Vector3(Mathf.Abs(localVelocity.x), Mathf.Abs(localVelocity.y), Mathf.Abs(localVelocity.z));
				smoothDampDuration = transitionSpeedV.GetFloat() * 1.35f;
				SetFallG = 1f;
				if (vector.y * 0.5f > vector.x && vector.y * 0.5f > vector.z)
				{
					smoothDampDuration = transitionSpeedV.GetFloat() * 1.5f;
					if (localVelocity.y > 0f)
					{
						SetFallZ = 1f;
						SetFallX = 0f;
					}
					else
					{
						SetFallZ = -1f;
						SetFallX = 0f;
					}
				}
				else
				{
					if (fallingModeDuration < 0.4f && velocityMagnitude > averageBodyVelocityV.GetFloat() * 1.15f)
					{
						smoothDampDuration = transitionSpeedV.GetFloat() * 0.2f;
					}
					float num = ((!(velocityMagnitude > averageBodyVelocityV.GetFloat())) ? 1.2f : VelocityLimiter(velocityMagnitude));
					if (vector.x > vector.z)
					{
						if (localVelocity.x < 0f)
						{
							SetFallX = 0f - num;
						}
						else
						{
							SetFallX = num;
						}
						SetFallZ = Mathf.Clamp(localVelocity.z * 0.5f, -1f, 1f);
					}
					else
					{
						if (localVelocity.z < 0f)
						{
							SetFallZ = 0f - num;
						}
						else
						{
							SetFallZ = num;
						}
						SetFallX = Mathf.Clamp(localVelocity.x * 0.5f, -1f, 1f);
					}
				}
			}
			if (!flag2 && _additiveLayer > 0)
			{
				float num2 = Mathf.InverseLerp(0f, additiveLayerMaxVelocityV.GetFloat(), velocityMagnitude);
				if (velocityMagnitude > averageBodyVelocityV.GetFloat())
				{
					SmoothSetAdditiveLayer = num2;
				}
				else if (lastHit.distance > 2.5f)
				{
					SmoothSetAdditiveLayer = 0.25f + num2 * 0.5f;
				}
				else
				{
					SmoothSetAdditiveLayer = num2;
				}
			}
		}

		private void DoExtraRaycasts(ref float groundAngle)
		{
			Physics.Raycast(base.ParentRagdollHandler.GetChain(ERagdollChainType.Core).GetBone(1000).SourceBone.position + safeUpRaycastOffset, Vector3.down, out var hitInfo, 2f, groundMaskV.GetInt(), QueryTriggerInteraction.Ignore);
			if ((bool)hitInfo.transform)
			{
				groundAngle = Mathf.LerpUnclamped(groundAngle, Vector3.Angle(hitInfo.normal, Vector3.up), 0.35f);
			}
			Physics.Raycast(base.ParentRagdollHandler.User_GetPosition_FeetMiddle() + safeUpRaycastOffset, Vector3.down, out hitInfo, 2f, groundMaskV.GetInt(), QueryTriggerInteraction.Ignore);
			if ((bool)hitInfo.transform)
			{
				groundAngle = Mathf.LerpUnclamped(groundAngle, Vector3.Angle(hitInfo.normal, Vector3.up), 0.35f);
			}
		}

		private float VelocityLimiter(float magnitude)
		{
			return Mathf.Lerp(1.3f, 2f, Mathf.InverseLerp(2.2f, 7f, magnitude));
		}

		private void UnstuckHelperPush(int stage, float powerMul = 1f)
		{
			if (unstuckStage == stage)
			{
				if (stage == 0)
				{
					unstuckStage = 1;
				}
				else
				{
					unstuckStage = 0;
				}
				unstuckVeloPushTimer = 1f;
				base.ParentRagdollHandler.User_AddAllBonesImpact(safeUpRaycastOffset * 2.5f * powerMul, 0f, ForceMode.VelocityChange);
				base.ParentRagdollHandler.User_AddAllBonesImpact(safeUpRaycastOffset * 7f * powerMul, 0.125f + 0.03f * powerMul);
			}
		}
	}
}
