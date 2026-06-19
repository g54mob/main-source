using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMOD.Studio;
using FMODUnity;
using Mirror;
using UnityEngine;

public class PingController : NetworkEntityBehaviourBase
{
	public EventReference beepEventReference;

	private EventInstance beepInstance;

	[SyncVar]
	public bool beeping;

	public bool _wasBeeping;

	public ParticleSystem honkParticleSystem;

	private PlayerColorManager _playerColorManager;

	public bool Networkbeeping
	{
		get
		{
			return beeping;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref beeping, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		beepInstance = RuntimeManager.CreateInstance(beepEventReference);
		beepInstance.setPitch(Random.Range(0.95f, 1.05f));
		_playerColorManager = base.entity.GetObject<PlayerColorManager>();
		AudioManager.CheckResult(beepInstance.setParameterByName("doppler", 1f));
	}

	public override void OnStartLocalPlayer()
	{
		AudioManager.CheckResult(beepInstance.setParameterByName("doppler", 0f));
	}

	protected override void OnEntityDestroyed()
	{
		AudioManager.CheckStop(beepInstance);
		beepInstance.release();
	}

	protected override void OnUpdatePresentation()
	{
		ParticleSystem.MainModule main = honkParticleSystem.main;
		main.startColor = _playerColorManager.GetPlayerColor(ui: true);
		if (base.isLocalPlayer)
		{
			Networkbeeping = AggroInputManager.input.Game.Beep.IsPressed() && !AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen;
		}
		if (!_wasBeeping && beeping)
		{
			beepInstance.start();
			honkParticleSystem.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmittingAndClear);
			honkParticleSystem.Play();
		}
		if (_wasBeeping && !beeping)
		{
			beepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		}
		if (AudioManager.CheckResult(beepInstance.getPlaybackState(out var state)) && state == PLAYBACK_STATE.PLAYING)
		{
			AudioManager.CheckResult(beepInstance.set3DAttributes(base.entity.transform.To3DAttributes(base.entity.GetObject<VehicleController>().velocitySync)));
		}
		_wasBeeping = beeping;
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
			writer.WriteBool(beeping);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(beeping);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref beeping, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref beeping, null, reader.ReadBool());
		}
	}
}
