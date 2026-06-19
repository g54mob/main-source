using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerEffects : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float maxRadiusCheck = 20f;

	[Range(0f, 100f)]
	public int minVehiclePercentage = 20;

	[Min(0f)]
	public int lockedInSpeedPercentage = 20;

	private float _stressChangeRateMin;

	private float _stressChangeRateMax;

	private bool _stressImpactAdd;

	private int _vehicleSpeedPercentageRaw;

	private int _vehicleSpeedPercentageMin;

	private int _vehicleSpeedPercentageMax;

	private int _nitroChargePercentageRaw;

	private float _nitroChangeRateMax;

	public Vector3 _accumForce;

	[SyncVar]
	private PlayerEffectContext _syncContext;

	private static List<Entity> _entities = new List<Entity>();

	private static Collider[] _colliders = new Collider[32];

	private static List<Vector3> _positions = new List<Vector3>();

	private ObjectQuery<GlobalEffects> _globalQuery;

	public AoEEffects.LiquidTrailEffect activeLiquidTrailEffect;

	[FormerlySerializedAs("playerInPuddle")]
	public bool playerInLiquidPuddle;

	[SyncVar]
	public bool syncInvisible;

	public GameObject becomeVisibleVfxPrefab;

	public GameObject becomeInvisibleVfxPrefab;

	private bool _previouslyInvisible;

	private Timer _holdTimer;

	private int _prevHoldSpeedPercentage;

	private int _holdSpeedPercentage;

	public StudioEventEmitter sfxPuddleDrivingSfxEmitter;

	private float sfxPuddleVol;

	public float sfxPuddleVolInSpeed = 15f;

	public float sfxPuddleVolOutSpeed = 5f;

	private VehicleController _vehicleController;

	private const float MIN_HOLD_DURATION = 0.5f;

	public PlayerEffectContext context => _syncContext;

	public PlayerEffectContext Network_syncContext
	{
		get
		{
			return _syncContext;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncContext, 1uL, null);
		}
	}

	public bool NetworksyncInvisible
	{
		get
		{
			return syncInvisible;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncInvisible, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_globalQuery = base.entityManager.CreateObjectQuery<GlobalEffects>();
		_vehicleController = base.entity.GetObject<VehicleController>();
	}

	[UpdateInGroup(-100)]
	protected override void OnUpdateSimulationEarly()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		_stressChangeRateMin = 0f;
		_stressChangeRateMax = 0f;
		_stressImpactAdd = false;
		_nitroChangeRateMax = 0f;
		_vehicleSpeedPercentageRaw = 0;
		_vehicleSpeedPercentageMin = 0;
		_vehicleSpeedPercentageMax = 0;
		_nitroChargePercentageRaw = 0;
		NetworksyncInvisible = false;
		Network_syncContext = PlayerEffectContext.None;
		_accumForce = Vector3.zero;
		_globalQuery.Run();
		for (int i = 0; i < _globalQuery.count; i++)
		{
			GlobalEffects globalEffects = _globalQuery[i];
			AddStressChangeRateMinMax(globalEffects.GetStressRate());
			if (globalEffects.ShouldAddStressOnImpact())
			{
				SetAddStressOnImpact();
			}
			AddVehicleSpeedPercentageRaw(globalEffects.GetVehicleSpeedPercentage());
			AddNitroChargePercentageRaw(globalEffects.GetNitroChargePercentage());
		}
		int num = 0;
		PlayerGrabber playerGrabber = base.entity.GetObject<PlayerGrabber>();
		if (playerGrabber.grabState == PlayerGrabState.Grabbed && playerGrabber.localPlayerGrabTarget.TryGetObject<Grabbable>(out var obj))
		{
			_entities.Clear();
			obj.GetStack(_entities);
			bool nitroActiveSync = base.entity.GetObject<NitroController>().nitroActiveSync;
			for (int j = 0; j < _entities.Count; j++)
			{
				if (_entities[j].TryGetObject<HeldEffects>(out var obj2) && !(obj2.disableWhenBoosting && nitroActiveSync))
				{
					if (obj2.ghost)
					{
						NetworksyncInvisible = true;
					}
					AddStressChangeRateMinMax(obj2.GetStressRate(base.entity));
					if (obj2.ShouldAddStressOnImpact(base.entity))
					{
						SetAddStressOnImpact();
					}
					num += obj2.GetVehicleSpeedPercentage(base.entity);
					AddNitroChargePercentageRaw(obj2.GetNitroChargePercentage(base.entity));
					Network_syncContext = _syncContext | obj2.context;
				}
			}
			if (num < _prevHoldSpeedPercentage)
			{
				_holdTimer.SetTimer(0.5f);
				_holdSpeedPercentage = num;
			}
		}
		_prevHoldSpeedPercentage = num;
		if (_holdTimer.IsFinished())
		{
			_holdSpeedPercentage = 0;
		}
		else
		{
			_holdTimer.DecrementTimer();
			num = _holdSpeedPercentage;
		}
		AddVehicleSpeedPercentageRaw(num);
		int speedPercentage = 0;
		PlayerScrubber obj3;
		bool flag = base.entity.TryGetObject<PlayerScrubber>(out obj3) && obj3.IsScrubbing(out speedPercentage);
		if (flag)
		{
			AddVehicleSpeedPercentageRaw(speedPercentage);
		}
		Vector3 position = base.entity.transform.position;
		int num2 = Physics.OverlapSphereNonAlloc(position, maxRadiusCheck, _colliders, 163840);
		activeLiquidTrailEffect = AoEEffects.LiquidTrailEffect.None;
		PlayerUpgrades playerUpgrades = base.entity.GetObject<PlayerUpgrades>();
		for (int k = 0; k < num2; k++)
		{
			if (_colliders[k].TryGetEntity(out var entity) && entity.TryGetObject<AoEEffects>(out var obj4) && (!flag || !entity.HasObject<Puddle>()) && math.distancesq(position, obj4.entity.transform.position) <= obj4.radius * obj4.radius)
			{
				obj4.ServerSetPlayerEffectedThisFrame();
				if (entity.TryGetObject<Puddle>(out var obj5) && obj5.isLiquid)
				{
					playerInLiquidPuddle = true;
				}
				AddStressChangeRateMinMax(obj4.GetStressRate());
				if (obj4.ShouldAddStressOnImpact())
				{
					SetAddStressOnImpact();
				}
				AddNitroChangeRateMax(obj4.GetNitroRate());
				AddVehicleSpeedPercentageMinMax(obj4.GetVehicleSpeedPercentage(playerUpgrades));
				AoEEffects.LiquidTrailEffect liquidTrailEffect = obj4.GetLiquidTrailEffect();
				if (liquidTrailEffect != AoEEffects.LiquidTrailEffect.None && math.distancesq(position, obj4.entity.transform.position) < obj4.radius - 1.5f)
				{
					activeLiquidTrailEffect = liquidTrailEffect;
				}
				Network_syncContext = _syncContext | obj4.GetPlayerContext();
			}
		}
		num2 = Physics.OverlapSphereNonAlloc(position, maxRadiusCheck, _colliders, 147464);
		for (int l = 0; l < num2; l++)
		{
			if (_colliders[l].TryGetEntity(out var entity2) && entity2.TryGetObject<Flammable>(out var obj6) && (obj6.fireState == FireState.OnFireBurnt || obj6.fireState == FireState.OnFireSavable) && math.distancesq(position, obj6.entity.transform.position) <= obj6.playerSpreadRadius * obj6.playerSpreadRadius)
			{
				if (playerUpgrades.HasUpgrade(PlayerUpgrade.FireResistance))
				{
					AddStressChangeRateMinMax(obj6.stressValueRate / 2f);
				}
				else
				{
					AddStressChangeRateMinMax(obj6.stressValueRate);
				}
				Network_syncContext = _syncContext | PlayerEffectContext.Fire;
				break;
			}
		}
		if (NetworkAggroManagerBase<ModifierManager>.instance.TryGetModiferAs<ModifierLava>(out var modifier) && modifier.state == ModifierLava.State.Lava)
		{
			_positions.Clear();
			modifier.GetPositions(_positions);
			float num3 = modifier.lavaRadius * modifier.lavaRadius;
			for (int m = 0; m < _positions.Count; m++)
			{
				if (math.distancesq(position, _positions[m]) < num3)
				{
					if (playerUpgrades.HasUpgrade(PlayerUpgrade.FireResistance))
					{
						AddStressChangeRateMinMax(modifier.stressValueRate / 2f);
					}
					else
					{
						AddStressChangeRateMinMax(modifier.stressValueRate);
					}
					Network_syncContext = _syncContext | PlayerEffectContext.Fire;
					break;
				}
			}
		}
		float num4 = 0f;
		num4 = ((!playerInLiquidPuddle) ? 0f : (_vehicleController.rb.velocity.magnitude / _vehicleController.maxSpeedForward));
		num4 = Mathf.Clamp01(num4 * 2f);
		sfxPuddleVol = Mathf.Lerp(sfxPuddleVol, num4, (playerInLiquidPuddle ? sfxPuddleVolInSpeed : sfxPuddleVolOutSpeed) * Time.deltaTime);
		sfxPuddleDrivingSfxEmitter.SetParameter("volume", sfxPuddleVol);
	}

	protected override void OnUpdateSimulation()
	{
		if (NetworkAggroManagerBase<ShiftManager>.instance.playersLockedIn)
		{
			AddContext(PlayerEffectContext.Shield);
		}
	}

	protected override void OnUpdateSimulationLate()
	{
		if (base.isServer)
		{
			if (syncInvisible && !_previouslyInvisible)
			{
				NetworkAggroManagerBase<VFXManager>.instance.Play(becomeInvisibleVfxPrefab, base.transform.position);
			}
			if (!syncInvisible && _previouslyInvisible)
			{
				NetworkAggroManagerBase<VFXManager>.instance.Play(becomeVisibleVfxPrefab, base.transform.position);
			}
			_previouslyInvisible = syncInvisible;
		}
		playerInLiquidPuddle = false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddStressChangeRateMinMax(float value)
	{
		_stressChangeRateMax = math.max(value, _stressChangeRateMax);
		_stressChangeRateMin = math.min(value, _stressChangeRateMin);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float GetStressChangeRate()
	{
		return _stressChangeRateMax + _stressChangeRateMin;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetAddStressOnImpact()
	{
		_stressImpactAdd = true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool ShouldAddStressOnImpact()
	{
		return _stressImpactAdd;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddNitroChangeRateMax(float value)
	{
		_nitroChangeRateMax = math.max(value, _nitroChangeRateMax);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float GetNitroChangeRate()
	{
		return _nitroChangeRateMax;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddVehicleSpeedPercentageRaw(int percentage)
	{
		_vehicleSpeedPercentageRaw += percentage;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddVehicleSpeedPercentageMinMax(int percentage)
	{
		_vehicleSpeedPercentageMax = math.max(_vehicleSpeedPercentageMax, percentage);
		_vehicleSpeedPercentageMin = math.min(_vehicleSpeedPercentageMin, percentage);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float GetVehicleSpeedMultiplier()
	{
		int num = ((!NetworkAggroManagerBase<ShiftManager>.instance.playersLockedIn) ? (_vehicleSpeedPercentageRaw + _vehicleSpeedPercentageMax + _vehicleSpeedPercentageMin) : (math.max(_vehicleSpeedPercentageRaw, 0) + _vehicleSpeedPercentageMax + lockedInSpeedPercentage));
		return math.max(1f + (float)num / 100f, (float)minVehiclePercentage / 100f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddNitroChargePercentageRaw(int percentage)
	{
		_nitroChargePercentageRaw += percentage;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float GetNitroChargeMultiplier()
	{
		return math.max(1f + (float)_nitroChargePercentageRaw / 100f, 0f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddForce(Vector3 force)
	{
		force.y = 0f;
		_accumForce += force;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddContext(PlayerEffectContext context)
	{
		Network_syncContext = _syncContext | context;
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
			GeneratedNetworkCode._Write_PlayerEffectContext(writer, _syncContext);
			writer.WriteBool(syncInvisible);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_PlayerEffectContext(writer, _syncContext);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(syncInvisible);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncContext, null, GeneratedNetworkCode._Read_PlayerEffectContext(reader));
			GeneratedSyncVarDeserialize(ref syncInvisible, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncContext, null, GeneratedNetworkCode._Read_PlayerEffectContext(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncInvisible, null, reader.ReadBool());
		}
	}
}
