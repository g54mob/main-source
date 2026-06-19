using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class BoxScrubber : NetworkEntityBehaviourBase, IBoxUsable
{
	public bool isAlwaysScrubbing;

	[Min(0f)]
	public float scrubRadius = 1f;

	[SyncVar]
	private bool _syncIsScrubbing;

	[Range(0f, 1f)]
	public float scrubSpeedMultiplier = 0.5f;

	public MeshRenderer liquidMeshRenderer;

	private MaterialPropertyBlock _block;

	private Entity _serverPuddle;

	private static Collider[] _colliders = new Collider[8];

	public bool controlAnimator = true;

	public bool showHotkeyHint = true;

	public StudioEventEmitter scrubbingSfx;

	public Rigidbody sfxRb;

	public bool isScrubbing => _syncIsScrubbing;

	public bool Network_syncIsScrubbing
	{
		get
		{
			return _syncIsScrubbing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIsScrubbing, 1uL, null);
		}
	}

	protected override void OnInitializeBehaviour()
	{
		_block = new MaterialPropertyBlock();
	}

	protected override void OnEntityDestroyed()
	{
		if (!GameUtil.isUnloadingScene && base.isServer && _serverPuddle.TryGetObject<Puddle>(out var obj))
		{
			obj.ServerDecrementCleaningRobot();
		}
	}

	protected override void OnUpdateSimulationEarly()
	{
		if (base.isServer)
		{
			Network_syncIsScrubbing = false;
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			if (_syncIsScrubbing && base.entity.TryGetObject<BoxWander>(out var obj))
			{
				obj.MultiplySpeed(scrubSpeedMultiplier);
			}
		}
		else
		{
			if (!isAlwaysScrubbing)
			{
				return;
			}
			Entity entity = Entity.invalid;
			Grabbable grabbable = base.entity.GetObject<Grabbable>();
			if (!grabbable.ServerIsBeingHeldByPlayer() && !grabbable.ServerIsBeingHeldByHolder() && grabbable.isBase)
			{
				Vector3 position = base.entity.transform.position;
				int num = Physics.OverlapSphereNonAlloc(position, scrubRadius, _colliders, 131072);
				float num2 = float.MaxValue;
				for (int i = 0; i < num; i++)
				{
					if (_colliders[i].TryGetEntity(out var entity2) && entity2.HasObject<Puddle>())
					{
						float num3 = math.distancesq(position, entity2.transform.position);
						if (num3 < num2)
						{
							num2 = num3;
							entity = entity2;
						}
					}
				}
			}
			if (entity != _serverPuddle)
			{
				if (_serverPuddle.TryGetObject<Puddle>(out var obj2))
				{
					obj2.ServerDecrementCleaningRobot();
				}
				if (entity.TryGetObject<Puddle>(out obj2))
				{
					obj2.ServerIncrementCleaningRobot();
				}
				_serverPuddle = entity;
			}
			if (_serverPuddle != Entity.invalid)
			{
				ServerSetScrubbing();
				if (base.entity.TryGetObject<BoxWander>(out var obj3))
				{
					obj3.MultiplySpeed(scrubSpeedMultiplier);
				}
			}
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.entity.TryGetObject<Animator>(out var obj) && controlAnimator)
		{
			obj.SetBool("isScrubbing", _syncIsScrubbing);
		}
		_block.Clear();
		_block.SetFloat("_fillLevel", 1f);
		if ((bool)liquidMeshRenderer)
		{
			liquidMeshRenderer.GetPropertyBlock(_block);
			liquidMeshRenderer.SetPropertyBlock(_block);
		}
		if (base.entity.TryGetObject<BoxWander>(out var obj2))
		{
			scrubbingSfx.gameObject.SetActive(obj2.isWandering);
		}
		else
		{
			scrubbingSfx.gameObject.SetActive(isScrubbing);
		}
		if (sfxRb != null)
		{
			scrubbingSfx.SetParameter("velocity", Mathf.Clamp01(sfxRb.velocity.magnitude / 15f));
		}
	}

	[Server]
	public void ServerSetScrubbing()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxScrubber::ServerSetScrubbing()' called when server was not active");
		}
		else
		{
			Network_syncIsScrubbing = true;
		}
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
			writer.WriteBool(_syncIsScrubbing);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncIsScrubbing);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncIsScrubbing, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIsScrubbing, null, reader.ReadBool());
		}
	}
}
