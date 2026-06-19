using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

public class AoEEffects : NetworkEntityBehaviourBase
{
	public enum LiquidTrailEffect
	{
		None = 0,
		Oil = 1,
		Water = 2,
		Ooze = 3
	}

	[Range(0f, 20f)]
	public float radius = 5f;

	[Header("Effects")]
	public PlayerEffectContext playerContext;

	public float stressRate;

	public bool stressImpactAdd;

	[Min(0f)]
	public float nitroRate;

	[Range(-100f, 100f)]
	public int vehicleSpeedPercentage;

	public bool checkTractionUpgrade = true;

	[Header("Visuals")]
	public Transform aoeVFXTransform;

	private bool _hasVisual;

	[FormerlySerializedAs("_playerEffected")]
	[SyncVar]
	public bool playerEffected;

	public StudioEventEmitter sfxEmitter;

	public string sfxPlayerEffectedParameter = "";

	private float _paramValue;

	public float paramSmoothingSpeed = 15f;

	public LiquidTrailEffect liquidTrailEffect;

	private bool _hasCheckTractionUpgrade => vehicleSpeedPercentage < 0;

	public bool NetworkplayerEffected
	{
		get
		{
			return playerEffected;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref playerEffected, 1uL, null);
		}
	}

	public void ServerSetPlayerEffectedThisFrame()
	{
		NetworkplayerEffected = true;
	}

	protected override void OnEntityCreated()
	{
		if (sfxEmitter != null)
		{
			sfxEmitter.Play();
		}
	}

	protected override void OnUpdateSimulation()
	{
		if ((bool)sfxEmitter && !string.IsNullOrEmpty(sfxPlayerEffectedParameter))
		{
			float b = (playerEffected ? 1f : 0f);
			_paramValue = Mathf.Lerp(_paramValue, b, paramSmoothingSpeed * Time.deltaTime);
			sfxEmitter.SetParameter(sfxPlayerEffectedParameter, _paramValue);
		}
	}

	protected override void OnUpdateSimulationLate()
	{
		if (base.isServer)
		{
			NetworkplayerEffected = false;
		}
	}

	protected override void OnInitializeBehaviour()
	{
		_hasVisual = aoeVFXTransform != null;
	}

	protected override void OnUpdatePresentationLate()
	{
		if (_hasVisual)
		{
			aoeVFXTransform.rotation = Quaternion.LookRotation(-Vector3.up);
			aoeVFXTransform.localPosition = Vector3.zero;
		}
	}

	public LiquidTrailEffect GetLiquidTrailEffect()
	{
		return liquidTrailEffect;
	}

	public float GetStressRate()
	{
		return stressRate;
	}

	public bool ShouldAddStressOnImpact()
	{
		return stressImpactAdd;
	}

	public int GetVehicleSpeedPercentage(PlayerUpgrades upgrades)
	{
		if (vehicleSpeedPercentage >= 0)
		{
			return vehicleSpeedPercentage;
		}
		if (checkTractionUpgrade && upgrades.HasUpgrade(PlayerUpgrade.Traction))
		{
			return vehicleSpeedPercentage / 2;
		}
		return vehicleSpeedPercentage;
	}

	public float GetNitroRate()
	{
		return nitroRate;
	}

	public PlayerEffectContext GetPlayerContext()
	{
		return playerContext;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(GetComponentInParent<EntityBehaviour>().transform.position, radius);
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
			writer.WriteBool(playerEffected);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(playerEffected);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref playerEffected, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref playerEffected, null, reader.ReadBool());
		}
	}
}
