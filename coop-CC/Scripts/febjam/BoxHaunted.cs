using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class BoxHaunted : NetworkEntityBehaviourBase, IBoxActivated, IBoxStackedOn
{
	private struct Haunting
	{
		public int seed;

		public float startTime;
	}

	public ParticleSystem hauntedParticle;

	public float liftDuration;

	[Min(0f)]
	public float liftAcceleration = 0.5f;

	public AnimationCurve liftCurve;

	[Min(0f)]
	public float targetHeight = 3.5f;

	public float[] stackGravityMultipliers;

	[Space]
	[Min(0f)]
	public float horizontalAcceleration = 4f;

	public AnimationCurve horizontalCurve;

	[Min(0f)]
	public float horizontalSinScale;

	[Space]
	[Min(0f)]
	public float angularAcceleration;

	public AnimationCurve angularCurve;

	public float angularSinScale;

	[Space]
	[Min(0f)]
	public float launchSpeed = 15f;

	[SyncVar]
	private Haunting _syncHaunting;

	private int _launchedSeed;

	private int _initSeed;

	private float _horizontalSinOffset;

	private float _angularSinOffset;

	private static List<Entity> _grabbables = new List<Entity>();

	private Vector3 _launchDir;

	public GameObject ghostLaunchVFX;

	public StudioEventEmitter hauntedSfxEmitter;

	public bool isHaunted
	{
		get
		{
			if (_syncHaunting.seed != 0)
			{
				return _launchedSeed != _syncHaunting.seed;
			}
			return false;
		}
	}

	public Haunting Network_syncHaunting
	{
		get
		{
			return _syncHaunting;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncHaunting, 1uL, null);
		}
	}

	protected override void OnEntityDestroyed()
	{
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer && (base.entity.rigidbody.isKinematic || base.entity.GetObject<Grabbable>().isInStackAndNotBase))
		{
			ServerStopHaunting();
		}
		if (_syncHaunting.seed == 0)
		{
			return;
		}
		if (_initSeed != _syncHaunting.seed)
		{
			_initSeed = _syncHaunting.seed;
			Unity.Mathematics.Random random = MathUtil.GetRandom(_initSeed);
			_launchDir = new Vector3(random.NextFloat(-1f, 1f), 0f, random.NextFloat(-1f, 1f));
			_launchDir.Normalize();
			_horizontalSinOffset = random.NextFloat(0f, liftDuration);
			_angularSinOffset = random.NextFloat(0f, liftDuration);
		}
		if (NetworkTime.predictedTime > (double)(_syncHaunting.startTime + liftDuration))
		{
			if (_launchedSeed != _syncHaunting.seed)
			{
				_launchedSeed = _syncHaunting.seed;
				Grabbable grabbable = base.entity.GetObject<Grabbable>();
				_grabbables.Clear();
				grabbable.GetStack(_grabbables);
				if (base.isServer)
				{
					ServerStopHaunting();
					grabbable.ServerBreakEntireStack();
				}
				for (int i = 0; i < _grabbables.Count; i++)
				{
					_grabbables[i].rigidbody.AddForce(_launchDir * launchSpeed, ForceMode.Impulse);
				}
				NetworkAggroManagerBase<VFXManager>.instance.Play(ghostLaunchVFX, base.transform.position, Quaternion.LookRotation(_launchDir, Vector3.up));
			}
			return;
		}
		float time = (float)math.saturate((NetworkTime.predictedTime - (double)_syncHaunting.startTime) / (double)liftDuration);
		float num = liftCurve.Evaluate(time);
		_grabbables.Clear();
		base.entity.GetObject<Grabbable>().GetStack(_grabbables);
		float num2 = stackGravityMultipliers[_grabbables.Count - 1];
		if (base.entity.rigidbody.position.y >= targetHeight)
		{
			num2 = 1f;
		}
		Vector3 force = -Physics.gravity * num2 + Vector3.up * (liftAcceleration * num);
		float num3 = horizontalCurve.Evaluate(time);
		float num4 = (float)math.sin(((double)_horizontalSinOffset + NetworkTime.predictedTime) * (double)horizontalSinScale);
		force += Vector3.right * (num4 * horizontalAcceleration * num3);
		for (int j = 0; j < _grabbables.Count; j++)
		{
			_grabbables[j].rigidbody.AddForce(force, ForceMode.Acceleration);
		}
		float num5 = angularCurve.Evaluate(time);
		float num6 = (float)math.sin(((double)_angularSinOffset + NetworkTime.predictedTime) * (double)angularSinScale);
		float z = num5 * num6 * angularAcceleration;
		for (int k = 0; k < _grabbables.Count; k++)
		{
			_grabbables[k].rigidbody.AddTorque(new Vector3(0f, 0f, z), ForceMode.Acceleration);
		}
	}

	protected override void OnUpdatePresentation()
	{
		ParticleSystem.EmissionModule emission = hauntedParticle.emission;
		emission.enabled = isHaunted;
		if (isHaunted)
		{
			if (!hauntedSfxEmitter.IsPlaying())
			{
				hauntedSfxEmitter.Play();
			}
		}
		else
		{
			hauntedSfxEmitter.Stop();
		}
	}

	[Server]
	public void ServerStartHaunted(int seed)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxHaunted::ServerStartHaunted(System.Int32)' called when server was not active");
			return;
		}
		Network_syncHaunting = new Haunting
		{
			seed = seed,
			startTime = (float)NetworkTime.time
		};
	}

	[Server]
	public void ServerStopHaunting()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxHaunted::ServerStopHaunting()' called when server was not active");
			return;
		}
		Network_syncHaunting = new Haunting
		{
			seed = 0
		};
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		if (context.type != ActivationContextType.Fire)
		{
			ServerStopHaunting();
		}
	}

	public void ServerBoxStackedOn()
	{
		ServerStopHaunting();
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
			GeneratedNetworkCode._Write_BoxHaunted_002FHaunting(writer, _syncHaunting);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_BoxHaunted_002FHaunting(writer, _syncHaunting);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncHaunting, null, GeneratedNetworkCode._Read_BoxHaunted_002FHaunting(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncHaunting, null, GeneratedNetworkCode._Read_BoxHaunted_002FHaunting(reader));
		}
	}
}
