using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using Mirror;
using Mirror.RemoteCalls;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerWeaponVisuals : NetworkBehaviour
{
	private PlayerLeftHandIKController player;

	[SerializeField]
	private Animator anim;

	public bool isEquipingWeapon;

	[SerializeField]
	public WeaponModel[] weaponModels;

	[SerializeField]
	private BackupWeaponModel[] backupWeaponModels;

	[Header("Rig")]
	[SerializeField]
	private float rigWeightIncreaseRate = 4f;

	private bool shouldIncrease_RighWeight;

	private Rig rig;

	[SyncVar(hook = "OnRigWeightChanged")]
	private float syncRigWeight;

	[SyncVar(hook = "OnSpineRigWeightChanged")]
	private float syncSpineRigWeight;

	[SyncVar(hook = "OnSpine2RigWeightChanged")]
	private float syncSpine2RigWeight;

	[SyncVar(hook = "OnHeadRigWeightChanged")]
	private float syncHeadRigWeight;

	[SyncVar(hook = "OnLeftShoulderRigWeightChanged")]
	private float syncLeftShoulderRigWeight;

	[SyncVar(hook = "OnRightShoulderRigWeightChanged")]
	private float syncRightShoulderRigWeight;

	[SyncVar(hook = "OnLeftHandIKWeightChanged")]
	private float syncLeftHandIKWeight;

	[SyncVar(hook = "OnAnimationLayerChanged")]
	private int syncAnimationLayer;

	[SyncVar(hook = "OnEquipTypeChanged")]
	private float syncEquipType;

	public float armRigDeafultWeight;

	public float spineRigDeafultWeight;

	public float spine2RigDefaultWeight;

	public float headRigDefaultWeight;

	public float leftShoulderRigDefaultWeight;

	public float rightShoulderRigDefaultWeight;

	[SerializeField]
	private Rig spineRig;

	[SerializeField]
	private Rig spine2Rig;

	[SerializeField]
	private Rig headRig;

	[SerializeField]
	private Rig leftShoulderRig;

	[SerializeField]
	private Rig rightShoulderRig;

	private bool shouldIncrease_SpineRigWeight;

	private bool shouldIncrease_Spine2RigWeight;

	private bool shouldIncrease_HeadRigWeight;

	private bool shouldIncrease_LeftShoulderRigWeight;

	private bool shouldIncrease_RightShoulderRigWeight;

	private float targetSpineWeight;

	private float targetSpine2Weight;

	private float targetHeadWeight;

	private float targetLeftShoulderWeight;

	private float targetRightShoulderWeight;

	[Header("Left hand IK")]
	[SerializeField]
	private TwoBoneIKConstraint leftHandIK;

	[SerializeField]
	private Transform leftHandIK_Target;

	[SerializeField]
	private float leftHandIKWeightIncreaseRate = 6f;

	private bool shouldIncrease_LeftHandIKWeight;

	[Header("Unarmed Holdable TPS (Oil Lamp)")]
	[SerializeField]
	private GameObject tpsOilLampModel;

	[SerializeField]
	private int oilLampLayerIndex = 12;

	[SyncVar(hook = "OnOilLampStateChanged")]
	private bool syncOilLampActive;

	private bool localOilLampActive;

	[Header("Stationary Action Profiles (Axe, Pickaxe vb.)")]
	[SerializeField]
	private List<StationaryActionProfile> stationaryProfiles = new List<StationaryActionProfile>();

	[SerializeField]
	private InputReader inputReader;

	private bool lastMoving;

	private bool isStationaryActionPlaying;

	private StationaryActionProfile? activeProfileCache;

	[SerializeField]
	private bool freezeStationaryWhileEquipping = true;

	private bool freezeStationary;

	private PlayerWeaponController weaponController;

	private NetworkAnimator networkAnim;

	private bool isDead;

	private bool suspendedForCPR;

	private TsPlayerAnimationController animController;

	[SyncVar(hook = "OnCPRStateChanged")]
	private bool syncCPRActive;

	public NetworkAnimator NetworkAnim
	{
		get
		{
			if (!(networkAnim == null))
			{
				return networkAnim;
			}
			return GetComponent<NetworkAnimator>();
		}
	}

	public float NetworksyncRigWeight
	{
		get
		{
			return syncRigWeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncRigWeight, 1uL, OnRigWeightChanged);
		}
	}

	public float NetworksyncSpineRigWeight
	{
		get
		{
			return syncSpineRigWeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncSpineRigWeight, 2uL, OnSpineRigWeightChanged);
		}
	}

	public float NetworksyncSpine2RigWeight
	{
		get
		{
			return syncSpine2RigWeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncSpine2RigWeight, 4uL, OnSpine2RigWeightChanged);
		}
	}

	public float NetworksyncHeadRigWeight
	{
		get
		{
			return syncHeadRigWeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncHeadRigWeight, 8uL, OnHeadRigWeightChanged);
		}
	}

	public float NetworksyncLeftShoulderRigWeight
	{
		get
		{
			return syncLeftShoulderRigWeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncLeftShoulderRigWeight, 16uL, OnLeftShoulderRigWeightChanged);
		}
	}

	public float NetworksyncRightShoulderRigWeight
	{
		get
		{
			return syncRightShoulderRigWeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncRightShoulderRigWeight, 32uL, OnRightShoulderRigWeightChanged);
		}
	}

	public float NetworksyncLeftHandIKWeight
	{
		get
		{
			return syncLeftHandIKWeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncLeftHandIKWeight, 64uL, OnLeftHandIKWeightChanged);
		}
	}

	public int NetworksyncAnimationLayer
	{
		get
		{
			return syncAnimationLayer;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncAnimationLayer, 128uL, OnAnimationLayerChanged);
		}
	}

	public float NetworksyncEquipType
	{
		get
		{
			return syncEquipType;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncEquipType, 256uL, OnEquipTypeChanged);
		}
	}

	public bool NetworksyncOilLampActive
	{
		get
		{
			return syncOilLampActive;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncOilLampActive, 512uL, OnOilLampStateChanged);
		}
	}

	public bool NetworksyncCPRActive
	{
		get
		{
			return syncCPRActive;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncCPRActive, 1024uL, OnCPRStateChanged);
		}
	}

	private void Start()
	{
		weaponController = GetComponent<PlayerWeaponController>();
		player = GetComponent<PlayerLeftHandIKController>();
		animController = GetComponent<TsPlayerAnimationController>();
		rig = GetComponentInChildren<Rig>();
		backupWeaponModels = GetComponentsInChildren<BackupWeaponModel>(includeInactive: true);
		if (anim != null)
		{
			int layerIndex = anim.GetLayerIndex("LeftArmLayer");
			if (layerIndex >= 0)
			{
				oilLampLayerIndex = layerIndex;
			}
		}
		else
		{
			Debug.LogWarning("[OilLamp] Start - anim is NULL!");
		}
		PlayWeaponEquipAnimation(0);
		if (inputReader == null)
		{
			inputReader = GetComponentInParent<InputReader>();
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isLocalPlayer)
		{
			StartCoroutine(SyncStateOnJoin());
		}
	}

	private IEnumerator SyncStateOnJoin()
	{
		yield return new WaitForSeconds(0.5f);
		if (rig != null)
		{
			rig.weight = syncRigWeight;
		}
		if (spineRig != null)
		{
			spineRig.weight = syncSpineRigWeight;
		}
		if (spine2Rig != null)
		{
			spine2Rig.weight = syncSpine2RigWeight;
		}
		if (headRig != null)
		{
			headRig.weight = syncHeadRigWeight;
		}
		if (leftShoulderRig != null)
		{
			leftShoulderRig.weight = syncLeftShoulderRigWeight;
		}
		if (rightShoulderRig != null)
		{
			rightShoulderRig.weight = syncRightShoulderRigWeight;
		}
		if (leftHandIK != null)
		{
			leftHandIK.weight = syncLeftHandIKWeight;
		}
		if (syncAnimationLayer > 0)
		{
			SwitchAnimationLayer(syncAnimationLayer);
		}
		if (syncEquipType >= 0f && anim != null)
		{
			anim.SetFloat("EquipType", syncEquipType);
		}
		EastupWeapon eastupWeapon = weaponController.CurrentWeapon();
		Debug.Log($"SyncStateOnJoin: CurrentWeapon is {eastupWeapon?.weaponType}, weaponData is {eastupWeapon?.weaponData}");
		SwitchOffWeaponModels();
		if (eastupWeapon != null && eastupWeapon.weaponData != null)
		{
			WeaponModel weaponModelByType = GetWeaponModelByType(eastupWeapon.weaponType);
			if (weaponModelByType != null)
			{
				weaponModelByType.gameObject.SetActive(value: true);
				Debug.Log($"SyncStateOnJoin: Activated weapon model for type: {eastupWeapon.weaponType}");
			}
			else
			{
				Debug.LogWarning($"SyncStateOnJoin: Could not find model for weapon type: {eastupWeapon.weaponType}");
			}
		}
		else
		{
			Debug.Log("SyncStateOnJoin: No weapon equipped or weaponData is null");
		}
		if (!player.weapon.HasOnlyOneWeapon())
		{
			Debug.Log("SyncStateOnJoin: Activating backup weapon model");
			SwitchOnBackupWeaponModel();
		}
		if (eastupWeapon != null && ShouldUseLeftHandIK())
		{
			WeaponModel weaponModelByType2 = GetWeaponModelByType(eastupWeapon.weaponType);
			if (weaponModelByType2 != null && weaponModelByType2.holdPoint != null)
			{
				leftHandIK_Target.localPosition = weaponModelByType2.holdPoint.localPosition;
				leftHandIK_Target.localRotation = weaponModelByType2.holdPoint.localRotation;
			}
		}
		if (syncOilLampActive)
		{
			localOilLampActive = true;
			ApplyOilLampVisual(active: true);
		}
	}

	private void Update()
	{
		if (!isDead)
		{
			base.transform.localEulerAngles = Vector3.zero;
			if (!suspendedForCPR && base.isLocalPlayer)
			{
				UpdateRighWeight();
				UpdateSpineRigWeights();
				UpdateLeftHandIKWeight();
			}
		}
	}

	private void LateUpdate()
	{
		if (suspendedForCPR && !isDead)
		{
			ForceCPRAnimation(active: true);
		}
		if (localOilLampActive && !isDead && anim != null)
		{
			anim.SetLayerWeight(oilLampLayerIndex, 1f);
			anim.SetBool("HoldOilLamp", value: true);
		}
	}

	private void OnRigWeightChanged(float oldWeight, float newWeight)
	{
		if (!base.isLocalPlayer && rig != null)
		{
			rig.weight = newWeight;
		}
	}

	private void OnSpineRigWeightChanged(float oldWeight, float newWeight)
	{
		if (!base.isLocalPlayer && spineRig != null)
		{
			spineRig.weight = newWeight;
		}
	}

	private void OnSpine2RigWeightChanged(float oldWeight, float newWeight)
	{
		if (!base.isLocalPlayer && spine2Rig != null)
		{
			spine2Rig.weight = newWeight;
		}
	}

	private void OnHeadRigWeightChanged(float oldWeight, float newWeight)
	{
		if (!base.isLocalPlayer && headRig != null)
		{
			headRig.weight = newWeight;
		}
	}

	private void OnLeftShoulderRigWeightChanged(float oldWeight, float newWeight)
	{
		if (!base.isLocalPlayer && leftShoulderRig != null)
		{
			leftShoulderRig.weight = newWeight;
		}
	}

	private void OnRightShoulderRigWeightChanged(float oldWeight, float newWeight)
	{
		if (!base.isLocalPlayer && rightShoulderRig != null)
		{
			rightShoulderRig.weight = newWeight;
		}
	}

	private void OnLeftHandIKWeightChanged(float oldWeight, float newWeight)
	{
		if (!base.isLocalPlayer && leftHandIK != null)
		{
			leftHandIK.weight = newWeight;
		}
	}

	private void OnAnimationLayerChanged(int oldLayer, int newLayer)
	{
		if (!base.isLocalPlayer && anim != null && newLayer >= 0)
		{
			SwitchAnimationLayer(newLayer);
		}
	}

	private void OnEquipTypeChanged(float oldType, float newType)
	{
		if (!base.isLocalPlayer && anim != null)
		{
			anim.SetFloat("EquipType", newType);
		}
	}

	private void OnOilLampStateChanged(bool oldVal, bool newVal)
	{
		Debug.Log($"[OilLamp] OnOilLampStateChanged({oldVal} → {newVal}) - isLocal: {base.isLocalPlayer}");
		if (!base.isLocalPlayer)
		{
			localOilLampActive = newVal;
			ApplyOilLampVisual(newVal);
		}
	}

	[Command]
	private void CmdUpdateEquipType(float equipType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(equipType);
		SendCommandInternal("System.Void PlayerWeaponVisuals::CmdUpdateEquipType(System.Single)", 331423057, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void SetOilLampActive(bool active)
	{
		localOilLampActive = active;
		Debug.Log($"[OilLamp] SetOilLampActive({active}) - isLocal: {base.isLocalPlayer}");
		ApplyOilLampVisual(active);
		if (base.isLocalPlayer)
		{
			CmdSetOilLampActive(active);
		}
	}

	[Command]
	private void CmdSetOilLampActive(bool active)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(active);
		SendCommandInternal("System.Void PlayerWeaponVisuals::CmdSetOilLampActive(System.Boolean)", -1220364850, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void ApplyOilLampVisual(bool active)
	{
		Debug.Log($"[OilLamp] ApplyOilLampVisual({active}) - isLocal: {base.isLocalPlayer}, layerIndex: {oilLampLayerIndex}");
		if (!base.isLocalPlayer && tpsOilLampModel != null)
		{
			tpsOilLampModel.SetActive(active);
		}
		if (anim != null)
		{
			anim.SetLayerWeight(oilLampLayerIndex, active ? 1f : 0f);
			anim.SetBool("HoldOilLamp", active);
		}
	}

	[Command]
	private void CmdUpdateRigWeights(float rigW, float spineW, float spine2W, float headW, float leftShoulderW, float rightShoulderW, float leftHandW)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(rigW);
		writer.WriteFloat(spineW);
		writer.WriteFloat(spine2W);
		writer.WriteFloat(headW);
		writer.WriteFloat(leftShoulderW);
		writer.WriteFloat(rightShoulderW);
		writer.WriteFloat(leftHandW);
		SendCommandInternal("System.Void PlayerWeaponVisuals::CmdUpdateRigWeights(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)", -27951476, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void PlayWeaponEquipAnimation(int weaponIndex)
	{
		EastupWeapon eastupWeapon = weaponController.weaponSlots[weaponIndex];
		isEquipingWeapon = false;
		if (isEquipingWeapon)
		{
			return;
		}
		if (freezeStationaryWhileEquipping)
		{
			freezeStationary = true;
		}
		isStationaryActionPlaying = false;
		inputReader?.SetMovementSuppressed(value: false);
		if (eastupWeapon.weaponData != null)
		{
			WeaponModel weaponModel = CurrentWeaponModel();
			anim.SetFloat("EquipType", (float)weaponModel.equipAnimationType);
			if (base.isLocalPlayer)
			{
				CmdUpdateEquipType((float)weaponModel.equipAnimationType);
			}
		}
		else
		{
			anim.SetFloat("EquipType", 1f);
			if (base.isLocalPlayer)
			{
				CmdUpdateEquipType(1f);
			}
			isEquipingWeapon = true;
		}
		float equipmentSpeed = player.weapon.CurrentWeapon().equipmentSpeed;
		leftHandIK.weight = 0f;
		ReduceRighWeight();
		anim.SetFloat("EquipSpeed", equipmentSpeed * 5f);
		DOVirtual.DelayedCall(equipmentSpeed / 4f, delegate
		{
			SwitchOnCurrentWeaponModel();
		});
		if (base.isLocalPlayer)
		{
			if (weaponIndex == 0 || !CurrentModelUsesRig())
			{
				shouldIncrease_RighWeight = false;
				targetSpineWeight = 0f;
				targetSpine2Weight = 0f;
				targetHeadWeight = 0f;
				targetLeftShoulderWeight = 0f;
				targetRightShoulderWeight = 0f;
				if (spineRig != null)
				{
					spineRig.weight = 0f;
				}
				if (spine2Rig != null)
				{
					spine2Rig.weight = 0f;
				}
				if (headRig != null)
				{
					headRig.weight = 0f;
				}
				if (leftShoulderRig != null)
				{
					leftShoulderRig.weight = 0f;
				}
				if (rightShoulderRig != null)
				{
					rightShoulderRig.weight = 0f;
				}
				CmdSetRigTargets(0f, 0f, 0f, 0f, 0f);
			}
			else
			{
				CmdSetRigTargets(spineRigDeafultWeight, spine2RigDefaultWeight, headRigDefaultWeight, leftShoulderRigDefaultWeight, rightShoulderRigDefaultWeight);
			}
			CmdSetWeaponVisibility(weaponIndex);
			NetworkAnim.SetTrigger("EquipWeapon");
		}
		else
		{
			SwitchOffWeaponModels();
			if (weaponIndex > 0 && weaponIndex < weaponController.weaponSlots.Count)
			{
				WeaponModel weaponModelByType = GetWeaponModelByType(eastupWeapon.weaponType);
				if (weaponModelByType != null)
				{
					weaponModelByType.gameObject.SetActive(value: true);
				}
			}
			if (!player.weapon.HasOnlyOneWeapon())
			{
				SwitchOnBackupWeaponModel();
			}
		}
		SetBusyEquipingWeaponTo(busy: true);
	}

	public WeaponModel GetWeaponModelByType(EasyUpWeaponType weaponType)
	{
		WeaponModel[] array = weaponModels;
		foreach (WeaponModel weaponModel in array)
		{
			if (weaponModel.weaponType == weaponType)
			{
				return weaponModel;
			}
		}
		return null;
	}

	[Command]
	private void CmdSetWeaponVisibility(int weaponIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(weaponIndex);
		SendCommandInternal("System.Void PlayerWeaponVisuals::CmdSetWeaponVisibility(System.Int32)", -1353353030, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdSetRigTargets(float spineTarget, float spine2Target, float headTarget, float leftShoulderTarget, float rightShoulderTarget)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(spineTarget);
		writer.WriteFloat(spine2Target);
		writer.WriteFloat(headTarget);
		writer.WriteFloat(leftShoulderTarget);
		writer.WriteFloat(rightShoulderTarget);
		SendCommandInternal("System.Void PlayerWeaponVisuals::CmdSetRigTargets(System.Single,System.Single,System.Single,System.Single,System.Single)", -2132491022, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSetRigTargets(float spineTarget, float spine2Target, float headTarget, float leftShoulderTarget, float rightShoulderTarget)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(spineTarget);
		writer.WriteFloat(spine2Target);
		writer.WriteFloat(headTarget);
		writer.WriteFloat(leftShoulderTarget);
		writer.WriteFloat(rightShoulderTarget);
		SendRPCInternal("System.Void PlayerWeaponVisuals::RpcSetRigTargets(System.Single,System.Single,System.Single,System.Single,System.Single)", 331751965, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PlayerReloadAnimation()
	{
		if (!isEquipingWeapon)
		{
			float reloadSpeed = player.weapon.CurrentWeapon().reloadSpeed;
			anim.SetFloat("ReloadSpeed", reloadSpeed);
			NetworkAnim.SetTrigger("Reload");
			ReduceAllRigWeights();
			DOVirtual.DelayedCall(reloadSpeed, delegate
			{
				OnReloadAnimationFinished();
			});
		}
	}

	public void OnReloadAnimationFinished()
	{
		MaximizeAllRigWeights();
		MaximizeLeftWeight();
	}

	[ClientRpc]
	private void RpcSetWeaponVisibility(int weaponIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(weaponIndex);
		SendRPCInternal("System.Void PlayerWeaponVisuals::RpcSetWeaponVisibility(System.Int32)", 1987330415, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SetBusyEquipingWeaponTo(bool busy)
	{
		isEquipingWeapon = busy;
	}

	public void SwitchOnCurrentWeaponModel()
	{
		if (CurrentWeaponModel() == null)
		{
			int layerIndex = 0;
			SwitchOffWeaponModels();
			SwitchOffBackupWeaponModels();
			SwitchAnimationLayer(layerIndex);
			leftHandIK.weight = 0f;
			rig.weight = 0f;
			shouldIncrease_RighWeight = false;
			shouldIncrease_LeftHandIKWeight = false;
			ApplyLeftHandIKPolicy();
			if (spineRig != null)
			{
				spineRig.weight = 0f;
			}
			if (spine2Rig != null)
			{
				spine2Rig.weight = 0f;
			}
			if (headRig != null)
			{
				headRig.weight = 0f;
			}
			if (leftShoulderRig != null)
			{
				leftShoulderRig.weight = 0f;
			}
			if (rightShoulderRig != null)
			{
				rightShoulderRig.weight = 0f;
			}
			targetSpineWeight = 0f;
			targetSpine2Weight = 0f;
			targetHeadWeight = 0f;
			targetLeftShoulderWeight = 0f;
			targetRightShoulderWeight = 0f;
			shouldIncrease_SpineRigWeight = false;
			shouldIncrease_Spine2RigWeight = false;
			shouldIncrease_HeadRigWeight = false;
			shouldIncrease_LeftShoulderRigWeight = false;
			shouldIncrease_RightShoulderRigWeight = false;
			if (localOilLampActive)
			{
				anim.SetLayerWeight(oilLampLayerIndex, 1f);
				anim.SetBool("HoldOilLamp", value: true);
			}
			if (base.isLocalPlayer)
			{
				CmdUpdateRigWeights(0f, 0f, 0f, 0f, 0f, 0f, 0f);
			}
		}
		else
		{
			StationaryActionProfile profile;
			int layerIndex = ((!HasStationaryProfile(out profile)) ? ((int)(CurrentWeaponModel().holdType + 4)) : profile.movingLayerIndex);
			SwitchOffWeaponModels();
			SwitchOffBackupWeaponModels();
			CurrentWeaponModel().gameObject.SetActive(value: true);
			if (!player.weapon.HasOnlyOneWeapon() && !base.isLocalPlayer)
			{
				SwitchOnBackupWeaponModel();
			}
			SwitchAnimationLayer(layerIndex);
			AttachLeftHand();
			ApplyLeftHandIKPolicy();
		}
	}

	public void OnStationaryActionEnded()
	{
		MaximizeAllRigWeights();
		MaximizeLeftWeight();
		isStationaryActionPlaying = false;
		if (HasStationaryProfile(out var profile))
		{
			SwitchAnimationLayer(profile.movingLayerIndex);
			anim.ResetTrigger(profile.hitTrigger);
		}
	}

	private void SetRigTargets(float spineTarget, float spine2Target, float headTarget, float leftShoulderTarget, float rightShoulderTarget)
	{
		targetSpineWeight = spineTarget;
		targetSpine2Weight = spine2Target;
		targetHeadWeight = headTarget;
		targetLeftShoulderWeight = leftShoulderTarget;
		targetRightShoulderWeight = rightShoulderTarget;
		shouldIncrease_SpineRigWeight = true;
		shouldIncrease_Spine2RigWeight = true;
		shouldIncrease_HeadRigWeight = true;
		shouldIncrease_LeftShoulderRigWeight = true;
		shouldIncrease_RightShoulderRigWeight = true;
		spineRig.weight = targetSpineWeight;
		spine2Rig.weight = targetSpine2Weight;
		headRig.weight = targetHeadWeight;
		if (leftShoulderRig != null)
		{
			leftShoulderRig.weight = targetLeftShoulderWeight;
		}
		if (rightShoulderRig != null)
		{
			rightShoulderRig.weight = targetRightShoulderWeight;
		}
		if (base.isLocalPlayer)
		{
			CmdUpdateRigWeights(rig.weight, targetSpineWeight, targetSpine2Weight, targetHeadWeight, targetLeftShoulderWeight, targetRightShoulderWeight, leftHandIK.weight);
		}
	}

	private void AttachLeftHand()
	{
		if (ShouldUseLeftHandIK())
		{
			Transform holdPoint = CurrentWeaponModel().holdPoint;
			leftHandIK_Target.localPosition = holdPoint.localPosition;
			leftHandIK_Target.localRotation = holdPoint.localRotation;
		}
	}

	private void UpdateRighWeight()
	{
		if (shouldIncrease_RighWeight)
		{
			rig.weight += rigWeightIncreaseRate * Time.deltaTime;
			if (rig.weight >= 1f)
			{
				rig.weight = 1f;
				shouldIncrease_RighWeight = false;
			}
			if (base.isLocalPlayer)
			{
				CmdUpdateRigWeights(rig.weight, spineRig.weight, spine2Rig.weight, headRig.weight, GetLeftShoulderWeight(), GetRightShoulderWeight(), leftHandIK.weight);
			}
		}
	}

	private float GetLeftShoulderWeight()
	{
		if (!(leftShoulderRig != null))
		{
			return 0f;
		}
		return leftShoulderRig.weight;
	}

	private float GetRightShoulderWeight()
	{
		if (!(rightShoulderRig != null))
		{
			return 0f;
		}
		return rightShoulderRig.weight;
	}

	private void UpdateSpineRigWeights()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		bool flag = false;
		if (shouldIncrease_SpineRigWeight)
		{
			if (Mathf.Abs(spineRig.weight - targetSpineWeight) > 0.01f)
			{
				spineRig.weight = Mathf.Lerp(spineRig.weight, targetSpineWeight, rigWeightIncreaseRate * Time.deltaTime);
				flag = true;
			}
			else
			{
				spineRig.weight = targetSpineWeight;
				shouldIncrease_SpineRigWeight = false;
			}
		}
		if (shouldIncrease_Spine2RigWeight)
		{
			if (Mathf.Abs(spine2Rig.weight - targetSpine2Weight) > 0.01f)
			{
				spine2Rig.weight = Mathf.Lerp(spine2Rig.weight, targetSpine2Weight, rigWeightIncreaseRate * Time.deltaTime);
				flag = true;
			}
			else
			{
				spine2Rig.weight = targetSpine2Weight;
				shouldIncrease_Spine2RigWeight = false;
			}
		}
		if (shouldIncrease_HeadRigWeight)
		{
			if (Mathf.Abs(headRig.weight - targetHeadWeight) > 0.01f)
			{
				headRig.weight = Mathf.Lerp(headRig.weight, targetHeadWeight, rigWeightIncreaseRate * Time.deltaTime);
				flag = true;
			}
			else
			{
				headRig.weight = targetHeadWeight;
				shouldIncrease_HeadRigWeight = false;
			}
		}
		if (shouldIncrease_LeftShoulderRigWeight && leftShoulderRig != null)
		{
			if (Mathf.Abs(leftShoulderRig.weight - targetLeftShoulderWeight) > 0.01f)
			{
				leftShoulderRig.weight = Mathf.Lerp(leftShoulderRig.weight, targetLeftShoulderWeight, rigWeightIncreaseRate * Time.deltaTime);
				flag = true;
			}
			else
			{
				leftShoulderRig.weight = targetLeftShoulderWeight;
				shouldIncrease_LeftShoulderRigWeight = false;
			}
		}
		if (shouldIncrease_RightShoulderRigWeight && rightShoulderRig != null)
		{
			if (Mathf.Abs(rightShoulderRig.weight - targetRightShoulderWeight) > 0.01f)
			{
				rightShoulderRig.weight = Mathf.Lerp(rightShoulderRig.weight, targetRightShoulderWeight, rigWeightIncreaseRate * Time.deltaTime);
				flag = true;
			}
			else
			{
				rightShoulderRig.weight = targetRightShoulderWeight;
				shouldIncrease_RightShoulderRigWeight = false;
			}
		}
		if (flag)
		{
			CmdUpdateRigWeights(rig.weight, spineRig.weight, spine2Rig.weight, headRig.weight, GetLeftShoulderWeight(), GetRightShoulderWeight(), leftHandIK.weight);
		}
	}

	private void UpdateLeftHandIKWeight()
	{
		if (!ShouldUseLeftHandIK())
		{
			leftHandIK.weight = 0f;
			shouldIncrease_LeftHandIKWeight = false;
			if (base.isLocalPlayer)
			{
				CmdUpdateRigWeights(rig.weight, spineRig.weight, spine2Rig.weight, headRig.weight, GetLeftShoulderWeight(), GetRightShoulderWeight(), 0f);
			}
		}
		else if (shouldIncrease_LeftHandIKWeight)
		{
			leftHandIK.weight += leftHandIKWeightIncreaseRate * Time.deltaTime;
			if (leftHandIK.weight >= 1f)
			{
				leftHandIK.weight = 1f;
				shouldIncrease_LeftHandIKWeight = false;
			}
			if (base.isLocalPlayer)
			{
				CmdUpdateRigWeights(rig.weight, spineRig.weight, spine2Rig.weight, headRig.weight, GetLeftShoulderWeight(), GetRightShoulderWeight(), leftHandIK.weight);
			}
		}
	}

	private bool ShouldUseLeftHandIK()
	{
		WeaponModel weaponModel = CurrentWeaponModel();
		if (weaponModel != null && weaponModel.useLeftHandIK)
		{
			return weaponModel.useTpsRig;
		}
		return false;
	}

	private bool CurrentModelUsesRig()
	{
		WeaponModel weaponModel = CurrentWeaponModel();
		if (weaponModel != null)
		{
			return weaponModel.useTpsRig;
		}
		return false;
	}

	private void ApplyLeftHandIKPolicy()
	{
		if (ShouldUseLeftHandIK())
		{
			shouldIncrease_LeftHandIKWeight = true;
			return;
		}
		shouldIncrease_LeftHandIKWeight = false;
		leftHandIK.weight = 0f;
	}

	private void ReduceRighWeight()
	{
		rig.weight = 0.15f;
		CmdUpdateRigWeights(0.15f, spineRig.weight, spine2Rig.weight, headRig.weight, GetLeftShoulderWeight(), GetRightShoulderWeight(), leftHandIK.weight);
	}

	private void ReduceAllRigWeights()
	{
		rig.weight = 0.15f;
		SetRigTargets(0f, 0f, 0f, 0f, 0f);
		CmdUpdateRigWeights(0.15f, 0f, 0f, 0f, 0f, 0f, leftHandIK.weight);
	}

	public void MaximizeRigWeight()
	{
		if (!CurrentModelUsesRig())
		{
			shouldIncrease_RighWeight = false;
			if (rig != null)
			{
				rig.weight = 0f;
			}
		}
		else
		{
			shouldIncrease_RighWeight = true;
		}
	}

	public void MaximizeAllRigWeights()
	{
		if (weaponController.CurrentWeapon().weaponData != null && CurrentModelUsesRig())
		{
			shouldIncrease_RighWeight = true;
			SetRigTargets(spineRigDeafultWeight, spine2RigDefaultWeight, headRigDefaultWeight, leftShoulderRigDefaultWeight, rightShoulderRigDefaultWeight);
			return;
		}
		shouldIncrease_RighWeight = false;
		rig.weight = 0f;
		leftHandIK.weight = 0f;
		shouldIncrease_LeftHandIKWeight = false;
		if (spineRig != null)
		{
			spineRig.weight = 0f;
		}
		if (spine2Rig != null)
		{
			spine2Rig.weight = 0f;
		}
		if (headRig != null)
		{
			headRig.weight = 0f;
		}
		if (leftShoulderRig != null)
		{
			leftShoulderRig.weight = 0f;
		}
		if (rightShoulderRig != null)
		{
			rightShoulderRig.weight = 0f;
		}
		targetSpineWeight = 0f;
		targetSpine2Weight = 0f;
		targetHeadWeight = 0f;
		targetLeftShoulderWeight = 0f;
		targetRightShoulderWeight = 0f;
		shouldIncrease_SpineRigWeight = false;
		shouldIncrease_Spine2RigWeight = false;
		shouldIncrease_HeadRigWeight = false;
		shouldIncrease_LeftShoulderRigWeight = false;
		shouldIncrease_RightShoulderRigWeight = false;
		if (base.isLocalPlayer)
		{
			CmdUpdateRigWeights(0f, 0f, 0f, 0f, 0f, 0f, 0f);
		}
	}

	public void MaximizeLeftWeight()
	{
		if (ShouldUseLeftHandIK())
		{
			shouldIncrease_LeftHandIKWeight = true;
			return;
		}
		shouldIncrease_LeftHandIKWeight = false;
		leftHandIK.weight = 0f;
	}

	private void SwitchAnimationLayer(int layerIndex)
	{
		for (int i = 0; i < anim.layerCount; i++)
		{
			anim.SetLayerWeight(i, 0f);
		}
		anim.SetLayerWeight(layerIndex, 1f);
		if (localOilLampActive && oilLampLayerIndex != layerIndex)
		{
			anim.SetLayerWeight(oilLampLayerIndex, 1f);
			anim.SetBool("HoldOilLamp", value: true);
		}
		if (base.isLocalPlayer)
		{
			CmdUpdateAnimationLayer(layerIndex);
		}
	}

	[Command]
	private void CmdUpdateAnimationLayer(int layerIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(layerIndex);
		SendCommandInternal("System.Void PlayerWeaponVisuals::CmdUpdateAnimationLayer(System.Int32)", -691418736, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public WeaponModel CurrentWeaponModel()
	{
		WeaponModel result = null;
		EasyUpWeaponType weaponType = player.weapon.CurrentWeapon().weaponType;
		for (int i = 0; i < weaponModels.Length; i++)
		{
			if (weaponModels[i].weaponType == weaponType)
			{
				result = weaponModels[i];
			}
		}
		return result;
	}

	private bool IsMoving()
	{
		if (inputReader != null)
		{
			return inputReader._movementInputDetected;
		}
		return anim.GetFloat("Speed") > 0.05f;
	}

	private bool HasStationaryProfile(out StationaryActionProfile profile)
	{
		profile = default(StationaryActionProfile);
		EastupWeapon eastupWeapon = player.weapon.CurrentWeapon();
		if (eastupWeapon == null)
		{
			return false;
		}
		if (activeProfileCache.HasValue && activeProfileCache.Value.weaponType == eastupWeapon.weaponType)
		{
			profile = activeProfileCache.Value;
			return true;
		}
		for (int i = 0; i < stationaryProfiles.Count; i++)
		{
			if (stationaryProfiles[i].weaponType == eastupWeapon.weaponType)
			{
				profile = stationaryProfiles[i];
				activeProfileCache = profile;
				return true;
			}
		}
		return false;
	}

	public void OnEquipAnimationFinished()
	{
		SetBusyEquipingWeaponTo(busy: false);
		if (HasStationaryProfile(out var profile))
		{
			SwitchAnimationLayer(profile.movingLayerIndex);
		}
		MaximizeAllRigWeights();
		MaximizeLeftWeight();
	}

	private void UpdateStationaryLayer()
	{
		if (HasStationaryProfile(out var profile))
		{
			bool flag = IsMoving();
			if (flag != lastMoving)
			{
				SwitchAnimationLayer(flag ? profile.movingLayerIndex : profile.stationaryLayerIndex);
				lastMoving = flag;
			}
		}
	}

	public void SwitchOffWeaponModels()
	{
		for (int i = 0; i < weaponModels.Length; i++)
		{
			weaponModels[i].gameObject.SetActive(value: false);
		}
	}

	private void SwitchOffBackupWeaponModels()
	{
		BackupWeaponModel[] array = backupWeaponModels;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
	}

	public void SwitchOnBackupWeaponModel()
	{
		if (base.isLocalPlayer)
		{
			return;
		}
		EastupWeapon eastupWeapon = player.weapon.BackupWeapon();
		if (eastupWeapon == null)
		{
			return;
		}
		BackupWeaponModel[] array = backupWeaponModels;
		foreach (BackupWeaponModel backupWeaponModel in array)
		{
			if (backupWeaponModel.weaponType == eastupWeapon.weaponType)
			{
				backupWeaponModel.gameObject.SetActive(value: true);
				break;
			}
		}
	}

	public void ResetOnDeath()
	{
		Debug.Log("[PlayerWeaponVisuals] ResetOnDeath called");
		isDead = true;
		suspendedForCPR = false;
		if (anim != null)
		{
			anim.SetBool(AnimationKeys.CPRAnimation, value: false);
		}
		shouldIncrease_RighWeight = false;
		shouldIncrease_SpineRigWeight = false;
		shouldIncrease_Spine2RigWeight = false;
		shouldIncrease_HeadRigWeight = false;
		shouldIncrease_LeftShoulderRigWeight = false;
		shouldIncrease_RightShoulderRigWeight = false;
		shouldIncrease_LeftHandIKWeight = false;
		isStationaryActionPlaying = false;
		isEquipingWeapon = false;
		if (rig != null)
		{
			rig.weight = 0f;
		}
		if (spineRig != null)
		{
			spineRig.weight = 0f;
		}
		if (spine2Rig != null)
		{
			spine2Rig.weight = 0f;
		}
		if (headRig != null)
		{
			headRig.weight = 0f;
		}
		if (leftShoulderRig != null)
		{
			leftShoulderRig.weight = 0f;
		}
		if (rightShoulderRig != null)
		{
			rightShoulderRig.weight = 0f;
		}
		if (leftHandIK != null)
		{
			leftHandIK.weight = 0f;
		}
		targetSpineWeight = 0f;
		targetSpine2Weight = 0f;
		targetHeadWeight = 0f;
		targetLeftShoulderWeight = 0f;
		targetRightShoulderWeight = 0f;
		SwitchOffWeaponModels();
		SwitchOffBackupWeaponModels();
		localOilLampActive = false;
		ApplyOilLampVisual(active: false);
		if (base.isLocalPlayer)
		{
			CmdUpdateRigWeights(0f, 0f, 0f, 0f, 0f, 0f, 0f);
			if (syncCPRActive)
			{
				CmdSetCPRActive(active: false);
			}
		}
	}

	public void ResetOnRevive()
	{
		Debug.Log("[PlayerWeaponVisuals] ResetOnRevive called");
		isDead = false;
		suspendedForCPR = false;
		shouldIncrease_RighWeight = false;
		shouldIncrease_SpineRigWeight = false;
		shouldIncrease_Spine2RigWeight = false;
		shouldIncrease_HeadRigWeight = false;
		shouldIncrease_LeftShoulderRigWeight = false;
		shouldIncrease_RightShoulderRigWeight = false;
		shouldIncrease_LeftHandIKWeight = false;
		isStationaryActionPlaying = false;
		isEquipingWeapon = false;
		if (rig != null)
		{
			rig.weight = 0f;
		}
		if (spineRig != null)
		{
			spineRig.weight = 0f;
		}
		if (spine2Rig != null)
		{
			spine2Rig.weight = 0f;
		}
		if (headRig != null)
		{
			headRig.weight = 0f;
		}
		if (leftShoulderRig != null)
		{
			leftShoulderRig.weight = 0f;
		}
		if (rightShoulderRig != null)
		{
			rightShoulderRig.weight = 0f;
		}
		if (leftHandIK != null)
		{
			leftHandIK.weight = 0f;
		}
		targetSpineWeight = 0f;
		targetSpine2Weight = 0f;
		targetHeadWeight = 0f;
		targetLeftShoulderWeight = 0f;
		targetRightShoulderWeight = 0f;
		SwitchOffWeaponModels();
		SwitchOffBackupWeaponModels();
		localOilLampActive = false;
		ApplyOilLampVisual(active: false);
		activeProfileCache = null;
		if (base.isLocalPlayer)
		{
			CmdUpdateRigWeights(0f, 0f, 0f, 0f, 0f, 0f, 0f);
		}
		SwitchOnCurrentWeaponModel();
		if (syncOilLampActive)
		{
			localOilLampActive = true;
			ApplyOilLampVisual(active: true);
		}
		Debug.Log("[PlayerWeaponVisuals] ResetOnRevive completed - weapon system reset to default state");
	}

	public void SuspendRigForCPR()
	{
		Debug.Log("[PlayerWeaponVisuals] SuspendRigForCPR called");
		ApplyCPRState(active: true);
		if (base.isLocalPlayer)
		{
			CmdSetCPRActive(active: true);
		}
	}

	public void RestoreRigAfterCPR()
	{
		Debug.Log("[PlayerWeaponVisuals] RestoreRigAfterCPR called");
		ApplyCPRState(active: false);
		if (base.isLocalPlayer)
		{
			CmdSetCPRActive(active: false);
		}
	}

	[Command]
	private void CmdSetCPRActive(bool active)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(active);
		SendCommandInternal("System.Void PlayerWeaponVisuals::CmdSetCPRActive(System.Boolean)", -1445358231, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnCPRStateChanged(bool oldVal, bool newVal)
	{
		if (!base.isLocalPlayer)
		{
			ApplyCPRState(newVal);
		}
	}

	private void ApplyCPRState(bool active)
	{
		if (active)
		{
			suspendedForCPR = true;
			shouldIncrease_RighWeight = false;
			shouldIncrease_SpineRigWeight = false;
			shouldIncrease_Spine2RigWeight = false;
			shouldIncrease_HeadRigWeight = false;
			shouldIncrease_LeftShoulderRigWeight = false;
			shouldIncrease_RightShoulderRigWeight = false;
			shouldIncrease_LeftHandIKWeight = false;
			if (rig != null)
			{
				rig.weight = 0f;
			}
			if (spineRig != null)
			{
				spineRig.weight = 0f;
			}
			if (spine2Rig != null)
			{
				spine2Rig.weight = 0f;
			}
			if (headRig != null)
			{
				headRig.weight = 0f;
			}
			if (leftShoulderRig != null)
			{
				leftShoulderRig.weight = 0f;
			}
			if (rightShoulderRig != null)
			{
				rightShoulderRig.weight = 0f;
			}
			if (leftHandIK != null)
			{
				leftHandIK.weight = 0f;
			}
			targetSpineWeight = 0f;
			targetSpine2Weight = 0f;
			targetHeadWeight = 0f;
			targetLeftShoulderWeight = 0f;
			targetRightShoulderWeight = 0f;
			SwitchOffWeaponModels();
			SwitchOffBackupWeaponModels();
			ForceCPRAnimation(active: true);
			if (base.isLocalPlayer)
			{
				CmdUpdateRigWeights(0f, 0f, 0f, 0f, 0f, 0f, 0f);
			}
		}
		else if (suspendedForCPR)
		{
			suspendedForCPR = false;
			ForceCPRAnimation(active: false);
			if (!isDead)
			{
				SwitchOnCurrentWeaponModel();
				MaximizeAllRigWeights();
				MaximizeLeftWeight();
			}
		}
	}

	private void ForceCPRAnimation(bool active)
	{
		if (anim == null)
		{
			return;
		}
		if (animController == null)
		{
			animController = GetComponent<TsPlayerAnimationController>();
		}
		if (!(animController == null))
		{
			if (active)
			{
				anim.SetLayerWeight(animController.fullBodyLayerIndex, 1f);
				anim.SetBool(AnimationKeys.CPRAnimation, value: true);
			}
			else
			{
				anim.SetBool(AnimationKeys.CPRAnimation, value: false);
				anim.SetLayerWeight(animController.fullBodyLayerIndex, 0f);
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdUpdateEquipType__Single(float equipType)
	{
		NetworksyncEquipType = equipType;
	}

	protected static void InvokeUserCode_CmdUpdateEquipType__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateEquipType called on client.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_CmdUpdateEquipType__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_CmdSetOilLampActive__Boolean(bool active)
	{
		Debug.Log($"[OilLamp] CmdSetOilLampActive({active}) on server");
		NetworksyncOilLampActive = active;
	}

	protected static void InvokeUserCode_CmdSetOilLampActive__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetOilLampActive called on client.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_CmdSetOilLampActive__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdUpdateRigWeights__Single__Single__Single__Single__Single__Single__Single(float rigW, float spineW, float spine2W, float headW, float leftShoulderW, float rightShoulderW, float leftHandW)
	{
		NetworksyncRigWeight = rigW;
		NetworksyncSpineRigWeight = spineW;
		NetworksyncSpine2RigWeight = spine2W;
		NetworksyncHeadRigWeight = headW;
		NetworksyncLeftShoulderRigWeight = leftShoulderW;
		NetworksyncRightShoulderRigWeight = rightShoulderW;
		NetworksyncLeftHandIKWeight = leftHandW;
	}

	protected static void InvokeUserCode_CmdUpdateRigWeights__Single__Single__Single__Single__Single__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateRigWeights called on client.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_CmdUpdateRigWeights__Single__Single__Single__Single__Single__Single__Single(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat());
		}
	}

	protected void UserCode_CmdSetWeaponVisibility__Int32(int weaponIndex)
	{
		RpcSetWeaponVisibility(weaponIndex);
	}

	protected static void InvokeUserCode_CmdSetWeaponVisibility__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetWeaponVisibility called on client.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_CmdSetWeaponVisibility__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdSetRigTargets__Single__Single__Single__Single__Single(float spineTarget, float spine2Target, float headTarget, float leftShoulderTarget, float rightShoulderTarget)
	{
		targetSpineWeight = spineTarget;
		targetSpine2Weight = spine2Target;
		targetHeadWeight = headTarget;
		targetLeftShoulderWeight = leftShoulderTarget;
		targetRightShoulderWeight = rightShoulderTarget;
		shouldIncrease_SpineRigWeight = true;
		shouldIncrease_Spine2RigWeight = true;
		shouldIncrease_HeadRigWeight = true;
		shouldIncrease_LeftShoulderRigWeight = true;
		shouldIncrease_RightShoulderRigWeight = true;
		spineRig.weight = targetSpineWeight;
		spine2Rig.weight = targetSpine2Weight;
		headRig.weight = targetHeadWeight;
		if (leftShoulderRig != null)
		{
			leftShoulderRig.weight = targetLeftShoulderWeight;
		}
		if (rightShoulderRig != null)
		{
			rightShoulderRig.weight = targetRightShoulderWeight;
		}
		NetworksyncSpineRigWeight = targetSpineWeight;
		NetworksyncSpine2RigWeight = spine2Target;
		NetworksyncHeadRigWeight = headTarget;
		NetworksyncLeftShoulderRigWeight = leftShoulderTarget;
		NetworksyncRightShoulderRigWeight = rightShoulderTarget;
		RpcSetRigTargets(spineTarget, spine2Target, headTarget, leftShoulderTarget, rightShoulderTarget);
	}

	protected static void InvokeUserCode_CmdSetRigTargets__Single__Single__Single__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetRigTargets called on client.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_CmdSetRigTargets__Single__Single__Single__Single__Single(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat());
		}
	}

	protected void UserCode_RpcSetRigTargets__Single__Single__Single__Single__Single(float spineTarget, float spine2Target, float headTarget, float leftShoulderTarget, float rightShoulderTarget)
	{
		if (!base.isLocalPlayer)
		{
			targetSpineWeight = spineTarget;
			targetSpine2Weight = spine2Target;
			targetHeadWeight = headTarget;
			targetLeftShoulderWeight = leftShoulderTarget;
			targetRightShoulderWeight = rightShoulderTarget;
			shouldIncrease_SpineRigWeight = true;
			shouldIncrease_Spine2RigWeight = true;
			shouldIncrease_HeadRigWeight = true;
			shouldIncrease_LeftShoulderRigWeight = true;
			shouldIncrease_RightShoulderRigWeight = true;
			spineRig.weight = targetSpineWeight;
			spine2Rig.weight = targetSpine2Weight;
			headRig.weight = targetHeadWeight;
			if (leftShoulderRig != null)
			{
				leftShoulderRig.weight = targetLeftShoulderWeight;
			}
			if (rightShoulderRig != null)
			{
				rightShoulderRig.weight = targetRightShoulderWeight;
			}
		}
	}

	protected static void InvokeUserCode_RpcSetRigTargets__Single__Single__Single__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetRigTargets called on server.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_RpcSetRigTargets__Single__Single__Single__Single__Single(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat());
		}
	}

	protected void UserCode_RpcSetWeaponVisibility__Int32(int weaponIndex)
	{
		if (base.isLocalPlayer)
		{
			return;
		}
		SwitchOffWeaponModels();
		if (weaponIndex > 0 && weaponIndex < weaponController.weaponSlots.Count)
		{
			EastupWeapon eastupWeapon = weaponController.weaponSlots[weaponIndex];
			WeaponModel weaponModelByType = GetWeaponModelByType(eastupWeapon.weaponType);
			if (weaponModelByType != null)
			{
				weaponModelByType.gameObject.SetActive(value: true);
			}
			else
			{
				Debug.LogWarning($"RPC: Could not find weapon model for type: {eastupWeapon.weaponType}");
			}
		}
		if (!player.weapon.HasOnlyOneWeapon())
		{
			SwitchOnBackupWeaponModel();
		}
	}

	protected static void InvokeUserCode_RpcSetWeaponVisibility__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetWeaponVisibility called on server.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_RpcSetWeaponVisibility__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdUpdateAnimationLayer__Int32(int layerIndex)
	{
		NetworksyncAnimationLayer = layerIndex;
	}

	protected static void InvokeUserCode_CmdUpdateAnimationLayer__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateAnimationLayer called on client.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_CmdUpdateAnimationLayer__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdSetCPRActive__Boolean(bool active)
	{
		NetworksyncCPRActive = active;
	}

	protected static void InvokeUserCode_CmdSetCPRActive__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetCPRActive called on client.");
		}
		else
		{
			((PlayerWeaponVisuals)obj).UserCode_CmdSetCPRActive__Boolean(reader.ReadBool());
		}
	}

	static PlayerWeaponVisuals()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::CmdUpdateEquipType(System.Single)", InvokeUserCode_CmdUpdateEquipType__Single, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::CmdSetOilLampActive(System.Boolean)", InvokeUserCode_CmdSetOilLampActive__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::CmdUpdateRigWeights(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)", InvokeUserCode_CmdUpdateRigWeights__Single__Single__Single__Single__Single__Single__Single, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::CmdSetWeaponVisibility(System.Int32)", InvokeUserCode_CmdSetWeaponVisibility__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::CmdSetRigTargets(System.Single,System.Single,System.Single,System.Single,System.Single)", InvokeUserCode_CmdSetRigTargets__Single__Single__Single__Single__Single, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::CmdUpdateAnimationLayer(System.Int32)", InvokeUserCode_CmdUpdateAnimationLayer__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::CmdSetCPRActive(System.Boolean)", InvokeUserCode_CmdSetCPRActive__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::RpcSetRigTargets(System.Single,System.Single,System.Single,System.Single,System.Single)", InvokeUserCode_RpcSetRigTargets__Single__Single__Single__Single__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerWeaponVisuals), "System.Void PlayerWeaponVisuals::RpcSetWeaponVisibility(System.Int32)", InvokeUserCode_RpcSetWeaponVisibility__Int32);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(syncRigWeight);
			writer.WriteFloat(syncSpineRigWeight);
			writer.WriteFloat(syncSpine2RigWeight);
			writer.WriteFloat(syncHeadRigWeight);
			writer.WriteFloat(syncLeftShoulderRigWeight);
			writer.WriteFloat(syncRightShoulderRigWeight);
			writer.WriteFloat(syncLeftHandIKWeight);
			writer.WriteInt(syncAnimationLayer);
			writer.WriteFloat(syncEquipType);
			writer.WriteBool(syncOilLampActive);
			writer.WriteBool(syncCPRActive);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(syncRigWeight);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(syncSpineRigWeight);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteFloat(syncSpine2RigWeight);
		}
		if ((base.syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteFloat(syncHeadRigWeight);
		}
		if ((base.syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteFloat(syncLeftShoulderRigWeight);
		}
		if ((base.syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteFloat(syncRightShoulderRigWeight);
		}
		if ((base.syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteFloat(syncLeftHandIKWeight);
		}
		if ((base.syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteInt(syncAnimationLayer);
		}
		if ((base.syncVarDirtyBits & 0x100L) != 0L)
		{
			writer.WriteFloat(syncEquipType);
		}
		if ((base.syncVarDirtyBits & 0x200L) != 0L)
		{
			writer.WriteBool(syncOilLampActive);
		}
		if ((base.syncVarDirtyBits & 0x400L) != 0L)
		{
			writer.WriteBool(syncCPRActive);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref syncRigWeight, OnRigWeightChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncSpineRigWeight, OnSpineRigWeightChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncSpine2RigWeight, OnSpine2RigWeightChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncHeadRigWeight, OnHeadRigWeightChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncLeftShoulderRigWeight, OnLeftShoulderRigWeightChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncRightShoulderRigWeight, OnRightShoulderRigWeightChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncLeftHandIKWeight, OnLeftHandIKWeightChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncAnimationLayer, OnAnimationLayerChanged, reader.ReadInt());
			GeneratedSyncVarDeserialize(ref syncEquipType, OnEquipTypeChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncOilLampActive, OnOilLampStateChanged, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref syncCPRActive, OnCPRStateChanged, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncRigWeight, OnRigWeightChanged, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncSpineRigWeight, OnSpineRigWeightChanged, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncSpine2RigWeight, OnSpine2RigWeightChanged, reader.ReadFloat());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncHeadRigWeight, OnHeadRigWeightChanged, reader.ReadFloat());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncLeftShoulderRigWeight, OnLeftShoulderRigWeightChanged, reader.ReadFloat());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncRightShoulderRigWeight, OnRightShoulderRigWeightChanged, reader.ReadFloat());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncLeftHandIKWeight, OnLeftHandIKWeightChanged, reader.ReadFloat());
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncAnimationLayer, OnAnimationLayerChanged, reader.ReadInt());
		}
		if ((num & 0x100L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncEquipType, OnEquipTypeChanged, reader.ReadFloat());
		}
		if ((num & 0x200L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncOilLampActive, OnOilLampStateChanged, reader.ReadBool());
		}
		if ((num & 0x400L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncCPRActive, OnCPRStateChanged, reader.ReadBool());
		}
	}
}
