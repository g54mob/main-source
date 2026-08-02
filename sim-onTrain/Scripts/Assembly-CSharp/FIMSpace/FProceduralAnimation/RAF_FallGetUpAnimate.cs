using System;
using System.Collections.Generic;
using FIMSpace.FGenerating;
using UnityEngine;
using UnityEngine.Events;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_FallGetUpAnimate : RagdollAnimatorFeatureBase
	{
		protected FUniversalVariable springPowerOnFallV;

		protected FUniversalVariable durationV;

		protected FUniversalVariable fallClipNameV;

		protected FUniversalVariable fallTransitionV;

		protected FUniversalVariable fallStateLayerV;

		protected FUniversalVariable onFallEventV;

		protected FUniversalVariable getUpFacedownClipNameV;

		protected FUniversalVariable getUpFromBackClipNameV;

		protected FUniversalVariable getUpCrossfadeV;

		protected FUniversalVariable getUpAnimatorLayer;

		protected FUniversalVariable getUpEventV;

		protected FUniversalVariable ragdolledPropertyV;

		protected FUniversalVariable repositionBaseTransformV;

		protected FUniversalVariable findRigidbodyV;

		protected FUniversalVariable bodyVelocityV;

		protected FUniversalVariable supportGetupRestoreV;

		protected FUniversalVariable getupRestoreClipStateV;

		protected FUniversalVariable getupRestoreReposeV;

		protected FUniversalVariable modeV;

		protected int _ragProperty = -1;

		protected int _fallClipState = -1;

		protected int _getupFaceState = -1;

		protected int _getupBackState = -1;

		protected int _h_velocity = -1;

		protected int _restoreState = -1;

		[NonSerialized]
		public float ClipTimePlayOffset;

		public RaycastHit groundHit;

		protected Rigidbody characterRigidbody;

		protected ERagdollGetUpType getupType;

		private float _sd;

		private float _sdVelo;

		public override bool OnInit()
		{
			springPowerOnFallV = base.InitializedWith.RequestVariable("Springs On Fall:", 250f);
			durationV = base.InitializedWith.RequestVariable("Change Duration:", 0.15f);
			fallClipNameV = base.InitializedWith.RequestVariable("Fall Animation:", "Animator State Name");
			fallTransitionV = base.InitializedWith.RequestVariable("Fall Crossfade Duration:", 0.2f);
			fallStateLayerV = base.InitializedWith.RequestVariable("Layer:", 0);
			onFallEventV = base.InitializedWith.RequestVariable("Use On Fall Event:", false);
			getUpFacedownClipNameV = base.InitializedWith.RequestVariable("Get Up Face Down:", "Get Up Face Down");
			getUpFromBackClipNameV = base.InitializedWith.RequestVariable("Get Up From Back:", "Get Up From Back");
			getUpCrossfadeV = base.InitializedWith.RequestVariable("Get Up Crossfade:", 0f);
			getUpAnimatorLayer = base.InitializedWith.RequestVariable("GetUpLayer", 0);
			getUpEventV = base.InitializedWith.RequestVariable("Use Get Up Event:", false);
			ragdolledPropertyV = base.InitializedWith.RequestVariable("Set Bool Property On Fall:", "Ragdolled");
			supportGetupRestoreV = base.InitializedWith.RequestVariable("Support Standing Restore:", false);
			getupRestoreClipStateV = base.InitializedWith.RequestVariable("On Restore Animation:", "");
			getupRestoreReposeV = base.InitializedWith.RequestVariable("On Restore Repose:", -1);
			repositionBaseTransformV = base.InitializedWith.RequestVariable("Reposition Base Transform:", true);
			findRigidbodyV = base.InitializedWith.RequestVariable("Find Character Rigidbody:", false);
			bodyVelocityV = base.InitializedWith.RequestVariable("Body Velocity Property:", "");
			modeV = base.InitializedWith.RequestVariable("Reposition Mode:", 0);
			base.ParentRagdollHandler.AddToOnFallModeSwitchActions(OnFallStateChange);
			base.ParentRagdollHandler.AddToLateUpdateLoop(UpdateFeature);
			RefreshHashes();
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.AddToOnFallModeSwitchActions(OnFallStateChange);
			base.ParentRagdollHandler.RemoveFromLateUpdateLoop(UpdateFeature);
		}

		private void OnFallStateChange()
		{
			if (!base.InitializedWith.Enabled)
			{
				return;
			}
			if (base.ParentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
			{
				ApplyOnGetUpSwitches();
				if (getUpEventV.GetBool())
				{
					base.Helper.customEventsList[1].Invoke();
				}
			}
			else if (base.ParentRagdollHandler.IsFallingOrSleep)
			{
				ApplyOnFallSwitches();
				if (onFallEventV.GetBool())
				{
					base.Helper.customEventsList[0].Invoke();
				}
			}
		}

		public void RefreshHashes()
		{
			CalculateHash(fallClipNameV, ref _fallClipState);
			CalculateHash(ragdolledPropertyV, ref _ragProperty);
			CalculateHash(getUpFacedownClipNameV, ref _getupFaceState);
			CalculateHash(getUpFromBackClipNameV, ref _getupBackState);
			CalculateHash(bodyVelocityV, ref _h_velocity);
			CalculateHash(getupRestoreClipStateV, ref _restoreState);
		}

		private void CalculateHash(FUniversalVariable variable, ref int hash)
		{
			if (string.IsNullOrWhiteSpace(variable.GetString()))
			{
				hash = -1;
			}
			else
			{
				hash = Animator.StringToHash(variable.GetString());
			}
		}

		public void ApplyOnFallSwitches()
		{
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			getupType = ERagdollGetUpType.None;
			groundHit = default(RaycastHit);
			PlayOnFallAnimation(parentRagdollHandler);
		}

		public void ApplyOnGetUpSwitches()
		{
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			Transform baseTransform = parentRagdollHandler.GetBaseTransform();
			if (repositionBaseTransformV.GetBool())
			{
				if (findRigidbodyV.GetBool() && characterRigidbody == null)
				{
					characterRigidbody = baseTransform.GetComponent<Rigidbody>();
					if (characterRigidbody == null)
					{
						characterRigidbody = baseTransform.GetComponentInParent<Rigidbody>();
					}
					if (characterRigidbody == null)
					{
						characterRigidbody = baseTransform.GetComponentInChildren<Rigidbody>();
					}
				}
				bool flag = false;
				if (supportGetupRestoreV.GetBool() && parentRagdollHandler.GetUpCall_StandingRestore)
				{
					int num = getupRestoreReposeV.GetInt();
					if (num < 0)
					{
						num = modeV.GetInt();
					}
					RAF_ReposeOnFall.EBaseTransformRepose reposeMode = (RAF_ReposeOnFall.EBaseTransformRepose)num;
					if (groundHit.transform == null)
					{
						groundHit = default(RaycastHit);
						Vector3 reposePosition = RAF_ReposeOnFall.GetReposePosition(parentRagdollHandler, reposeMode);
						groundHit.point = reposePosition;
					}
					baseTransform.position = groundHit.point;
					RagdollChainBone getAnchorBoneController = parentRagdollHandler.GetAnchorBoneController;
					baseTransform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(getAnchorBoneController.PhysicalDummyBone.rotation * getAnchorBoneController.LocalForward, Vector3.up), Vector3.up);
					if ((bool)characterRigidbody)
					{
						characterRigidbody.position = baseTransform.position;
						characterRigidbody.rotation = baseTransform.rotation;
					}
					flag = true;
				}
				if (!flag)
				{
					RAF_ReposeOnFall.EBaseTransformRepose reposeMode2 = (RAF_ReposeOnFall.EBaseTransformRepose)modeV.GetInt();
					if (groundHit.transform == null)
					{
						groundHit = default(RaycastHit);
						Vector3 reposePosition2 = RAF_ReposeOnFall.GetReposePosition(parentRagdollHandler, reposeMode2);
						groundHit.point = reposePosition2;
					}
					baseTransform.position = groundHit.point;
					baseTransform.rotation = parentRagdollHandler.User_GetMappedRotationHipsToLegsMiddle();
					if ((bool)characterRigidbody)
					{
						characterRigidbody.position = baseTransform.position;
						characterRigidbody.rotation = baseTransform.rotation;
					}
				}
			}
			if ((bool)parentRagdollHandler.Mecanim)
			{
				if (_ragProperty != -1)
				{
					parentRagdollHandler.Mecanim.SetBool(_ragProperty, value: false);
				}
				PlayGetUpAnimation(parentRagdollHandler);
			}
		}

		protected void CallGetUpAnimation(RagdollHandler handler, int getupHash)
		{
			if (getUpCrossfadeV.GetFloat() <= 0f)
			{
				handler.Mecanim.CrossFadeInFixedTime(getupHash, 0f, getUpAnimatorLayer.GetInt(), ClipTimePlayOffset);
			}
			else
			{
				handler.Mecanim.CrossFadeInFixedTime(getupHash, getUpCrossfadeV.GetFloat(), getUpAnimatorLayer.GetInt(), ClipTimePlayOffset);
			}
		}

		protected virtual void PlayGetUpAnimation(RagdollHandler handler)
		{
			if (supportGetupRestoreV.GetBool() && handler.GetUpCall_StandingRestore)
			{
				if (_restoreState != -1)
				{
					CallGetUpAnimation(handler, _restoreState);
				}
			}
			else if (_getupBackState != -1 || _getupFaceState != -1)
			{
				if (getupType == ERagdollGetUpType.None)
				{
					getupType = handler.User_CanGetUpByRotation();
				}
				int num = ((_getupBackState == -1 && _getupFaceState != -1) ? _getupFaceState : ((_getupBackState != -1 && _getupFaceState == -1) ? _getupBackState : ((getupType != ERagdollGetUpType.FromFacedown) ? _getupBackState : _getupFaceState)));
				if (num != -1)
				{
					CallGetUpAnimation(handler, num);
				}
			}
		}

		protected virtual void PlayOnFallAnimation(RagdollHandler handler)
		{
			if (!handler.Mecanim)
			{
				return;
			}
			if (_ragProperty != -1)
			{
				handler.Mecanim.SetBool(_ragProperty, value: true);
			}
			if (_fallClipState != -1)
			{
				if (fallTransitionV.GetFloat() <= 0f)
				{
					handler.Mecanim.Play(_fallClipState, fallStateLayerV.GetInt());
				}
				else
				{
					handler.Mecanim.CrossFadeInFixedTime(_fallClipState, fallTransitionV.GetFloat(), fallStateLayerV.GetInt(), ClipTimePlayOffset);
				}
			}
		}

		public void UpdateFeature()
		{
			if (!base.InitializedWith.Enabled)
			{
				return;
			}
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			float? overrideSpringsValueOnFall = parentRagdollHandler.OverrideSpringsValueOnFall;
			if (parentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
			{
				if (parentRagdollHandler.OverrideSpringsValueOnFall.HasValue)
				{
					SmoothChangeSpringsValueOnFall(parentRagdollHandler.SpringsValue, durationV.GetFloat());
					if (parentRagdollHandler.OverrideSpringsValueOnFall == parentRagdollHandler.SpringsValue)
					{
						parentRagdollHandler.OverrideSpringsValueOnFall = null;
					}
				}
			}
			else if (parentRagdollHandler.IsFallingOrSleep && springPowerOnFallV.GetFloat() > 0f)
			{
				if (!parentRagdollHandler.OverrideSpringsValueOnFall.HasValue)
				{
					parentRagdollHandler.OverrideSpringsValueOnFall = parentRagdollHandler.GetCurrentMainSpringsValue;
				}
				SmoothChangeSpringsValueOnFall(springPowerOnFallV.GetFloat(), durationV.GetFloat());
			}
			if (overrideSpringsValueOnFall != parentRagdollHandler.OverrideSpringsValueOnFall)
			{
				parentRagdollHandler.User_UpdateJointsPlayParameters(reset: false);
			}
			if (_h_velocity != -1 && (bool)parentRagdollHandler.Mecanim)
			{
				float magnitude = base.ParentRagdollHandler.User_GetChainBonesVelocity(ERagdollChainType.Core).magnitude;
				float current = base.ParentRagdollHandler.Mecanim.GetFloat(_h_velocity);
				current = Mathf.SmoothDamp(current, magnitude, ref _sdVelo, 0.125f, 10000f, base.ParentRagdollHandler.Delta);
				base.ParentRagdollHandler.Mecanim.SetFloat(_h_velocity, current);
			}
		}

		private void SmoothChangeSpringsValueOnFall(float to, float duration)
		{
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			parentRagdollHandler.OverrideSpringsValueOnFall = Mathf.SmoothDamp(parentRagdollHandler.OverrideSpringsValueOnFall.Value, to, ref _sd, duration, 10000000f, parentRagdollHandler.Delta);
			if (Mathf.Abs(parentRagdollHandler.OverrideSpringsValueOnFall.Value - to) < 0.1f)
			{
				parentRagdollHandler.OverrideSpringsValueOnFall = to;
			}
		}

		private bool RefreshHelperEvents(RagdollAnimatorFeatureHelper helper)
		{
			bool result = false;
			if (helper.customEventsList == null)
			{
				helper.customEventsList = new List<UnityEvent>();
				result = true;
			}
			while (helper.customEventsList.Count < 2)
			{
				helper.customEventsList.Add(new UnityEvent());
				result = true;
			}
			return result;
		}
	}
}
