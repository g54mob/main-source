using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMOD.Studio;
using FMODUnity;
using Mirror;
using UnityEngine;

public class NitroController : NetworkEntityBehaviourBase
{
	[Header("Nitro")]
	public float nitroPower = 50f;

	public float maxNitroSpeed = 25f;

	public EventReference nitroLoopRef;

	public EventReference nitroLoopUpgradedRef;

	public EventReference nitroActivateRef;

	public EventReference nitroActivateUpgradedRef;

	[SyncVar]
	public float _nitroSFXSpeedSync;

	public VehicleController vc;

	public PlayerUpgrades playerUpgrades;

	[SyncVar]
	public bool nitroActiveSync;

	private bool _nitroInput;

	public int nitroCharges;

	public float nitroBuildUpLevel;

	public float nitroBurnProgress;

	public int maxNitroCharges = 3;

	public float nitroBuildUpSpeed = 1f;

	public float nitroBuildUpDecaySpeed = 3f;

	public float nitroBuildUpThreshold = 0.7f;

	public float nitroBurnSpeed = 1.5f;

	public float nitroLerpSpeed = 1f;

	public float perChargeMultiplier = 0.2f;

	public EventReference[] nitroChargeUpSfxEvents;

	private EventInstance nitroLoopInstance;

	private EventInstance nitroLoopUpgradedInstance;

	public int nitroUseCount { get; private set; }

	public float Network_nitroSFXSpeedSync
	{
		get
		{
			return _nitroSFXSpeedSync;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _nitroSFXSpeedSync, 1uL, null);
		}
	}

	public bool NetworknitroActiveSync
	{
		get
		{
			return nitroActiveSync;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref nitroActiveSync, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		nitroLoopInstance = RuntimeManager.CreateInstance(nitroLoopRef);
		nitroLoopUpgradedInstance = RuntimeManager.CreateInstance(nitroLoopUpgradedRef);
		AudioManager.CheckResult(nitroLoopInstance.setParameterByName("doppler", 1f));
		AudioManager.CheckResult(nitroLoopUpgradedInstance.setParameterByName("doppler", 1f));
	}

	protected override void OnEntityDestroyed()
	{
		AudioManager.CheckStop(nitroLoopInstance);
		AudioManager.CheckStop(nitroLoopUpgradedInstance);
		nitroLoopInstance.release();
		nitroLoopUpgradedInstance.release();
	}

	public override void OnStartLocalPlayer()
	{
		AudioManager.CheckResult(nitroLoopInstance.setParameterByName("doppler", 0f));
		AudioManager.CheckResult(nitroLoopUpgradedInstance.setParameterByName("doppler", 0f));
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		if (nitroActiveSync)
		{
			nitroBurnProgress += Time.deltaTime * nitroBurnSpeed;
			if (nitroBurnProgress > 1f)
			{
				NetworknitroActiveSync = false;
				nitroBurnProgress = 0f;
			}
		}
		else
		{
			int num = LocalPlayerGetChargeCount();
			if (nitroCharges < num)
			{
				float num2 = 1f + (float)nitroCharges * perChargeMultiplier;
				PlayerEffects obj;
				if (vc.drifting)
				{
					if (base.entity.GetObject<PlayerUpgrades>().HasUpgrade(PlayerUpgrade.NitroChargeUp))
					{
						num2 *= base.entity.GetObject<PlayerEffects>().GetNitroChargeMultiplier();
					}
					nitroBuildUpLevel += num2 * Time.fixedDeltaTime * nitroBuildUpSpeed;
				}
				else if (base.entity.TryGetObject<PlayerEffects>(out obj) && obj.GetNitroChangeRate() > 0f)
				{
					nitroBuildUpLevel += num2 * Time.fixedDeltaTime * obj.GetNitroChangeRate();
				}
				else
				{
					nitroBuildUpLevel += num2 * Time.fixedDeltaTime * (0f - nitroBuildUpDecaySpeed);
				}
			}
			if (nitroBuildUpLevel > nitroBuildUpThreshold)
			{
				nitroBuildUpLevel = 0f;
				nitroCharges++;
				EventReference eventRef = ((nitroCharges != LocalPlayerGetChargeCount()) ? nitroChargeUpSfxEvents[nitroCharges - 1] : nitroChargeUpSfxEvents[^1]);
				AudioManager.PlaySfx(eventRef);
			}
			if (nitroBuildUpLevel < 0f)
			{
				nitroBuildUpLevel = 0f;
			}
			if (_nitroInput && nitroCharges > 0 && !base.entity.GetObject<PlayerStress>().crashingOut && !AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen)
			{
				nitroCharges--;
				LocalPlayerActivateNitro();
			}
		}
		_nitroInput = false;
	}

	public int LocalPlayerGetChargeCount()
	{
		int num = maxNitroCharges;
		if (base.entity.GetObject<PlayerUpgrades>().HasUpgrade(PlayerUpgrade.NitroCountUp))
		{
			num++;
		}
		return num;
	}

	public void LocalPlayerActivateNitro()
	{
		NetworknitroActiveSync = true;
		nitroBurnProgress = 0f;
		nitroBuildUpLevel = 0f;
		if (!playerUpgrades.HasUpgrade(PlayerUpgrade.NitroCountUp))
		{
			AudioManager.PlaySfx(nitroActivateRef, base.entity.transform);
		}
		else
		{
			AudioManager.PlaySfx(nitroActivateUpgradedRef, base.entity.transform);
		}
		nitroUseCount++;
		Aggro.Core.Platform.AddStat("stat_boost_count", 1);
	}

	public void LocalPlayerStopNitro()
	{
		NetworknitroActiveSync = false;
		nitroBurnProgress = 0f;
	}

	protected override void OnUpdatePresentation()
	{
		if (base.isLocalPlayer)
		{
			_nitroInput = _nitroInput || AggroInputManager.input.Game.Gas.IsPressed();
			Network_nitroSFXSpeedSync = _nitroSFXSpeedSync + (nitroActiveSync ? 1f : (-1f)) * nitroLerpSpeed * Time.deltaTime;
			Network_nitroSFXSpeedSync = Mathf.Clamp01(_nitroSFXSpeedSync);
		}
		AudioManager.CheckSetPlayState(nitroLoopInstance, (_nitroSFXSpeedSync > 0.6f || nitroActiveSync) && !playerUpgrades.HasUpgrade(PlayerUpgrade.NitroCountUp));
		AudioManager.CheckSetPlayState(nitroLoopUpgradedInstance, (_nitroSFXSpeedSync > 0.6f || nitroActiveSync) && playerUpgrades.HasUpgrade(PlayerUpgrade.NitroCountUp));
		nitroLoopInstance.setParameterByName("speed", _nitroSFXSpeedSync);
		nitroLoopUpgradedInstance.setParameterByName("speed", _nitroSFXSpeedSync);
		AudioManager.CheckSet3DAttributes(nitroLoopInstance, base.entity.transform, base.entity.GetObject<VehicleController>().velocitySync);
		AudioManager.CheckSet3DAttributes(nitroLoopUpgradedInstance, base.entity.transform, base.entity.GetObject<VehicleController>().velocitySync);
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(_nitroSFXSpeedSync);
			writer.WriteBool(nitroActiveSync);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_nitroSFXSpeedSync);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(nitroActiveSync);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _nitroSFXSpeedSync, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref nitroActiveSync, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _nitroSFXSpeedSync, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref nitroActiveSync, null, reader.ReadBool());
		}
	}
}
