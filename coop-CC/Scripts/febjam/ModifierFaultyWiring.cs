using System.Collections;
using System.Runtime.InteropServices;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class ModifierFaultyWiring : ModifierBase, IShiftChanged
{
	private static readonly int LightsOff;

	public float transitionTime = 2f;

	[SyncVar]
	public float lightsOffValue;

	public Vector2 lightsOnRange = new Vector2(5f, 30f);

	public Vector2 lightsOffRange = new Vector2(5f, 30f);

	public StudioEventEmitter lightsTurnOnSfx;

	public StudioEventEmitter lightsTurnOffSfx;

	public float NetworklightsOffValue
	{
		get
		{
			return lightsOffValue;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref lightsOffValue, 1uL, null);
		}
	}

	private IEnumerator LightsOffCo()
	{
		yield return new WaitForSeconds(UnityEngine.Random.Range(lightsOnRange.x, lightsOnRange.y));
		RpcLightsTurnedOff();
		NetworklightsOffValue = 0f;
		float time = 0f;
		while (time < transitionTime)
		{
			NetworklightsOffValue = time / transitionTime;
			time += Time.deltaTime;
			yield return null;
		}
		NetworklightsOffValue = 1f;
		StartCoroutine(LightsOnCo());
	}

	private IEnumerator LightsOnCo()
	{
		float y = lightsOffRange.y * GameUtil.GetDifficultyMultiplier();
		yield return new WaitForSeconds(UnityEngine.Random.Range(lightsOffRange.x, math.max(lightsOffRange.x, y)));
		RpcLightsTurnedOn();
		NetworklightsOffValue = 1f;
		float time = 0f;
		while (time < transitionTime)
		{
			NetworklightsOffValue = 1f - time / transitionTime;
			time += Time.deltaTime;
			yield return null;
		}
		NetworklightsOffValue = 0f;
		StartCoroutine(LightsOffCo());
	}

	private IEnumerator LightsResetCo()
	{
		float ogLightsOffValue = lightsOffValue;
		float time = 0f;
		while (time < transitionTime)
		{
			NetworklightsOffValue = math.remap(0f, 1f, 0f, ogLightsOffValue, 1f - time / transitionTime);
			time += Time.deltaTime;
			yield return null;
		}
		NetworklightsOffValue = 0f;
	}

	protected override void OnUpdatePresentation()
	{
		Shader.SetGlobalFloat(LightsOff, lightsOffValue);
		RuntimeManager.StudioSystem.setParameterByName("amb-Off", lightsOffValue);
	}

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			NetworklightsOffValue = 0f;
		}
		Shader.SetGlobalFloat(LightsOff, 0f);
	}

	[ClientRpc]
	public void RpcLightsTurnedOn()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ModifierFaultyWiring::RpcLightsTurnedOn()", -1093668666, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcLightsTurnedOff()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ModifierFaultyWiring::RpcLightsTurnedOff()", 623567474, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected override void OnEntityDestroyed()
	{
		if (base.isServer)
		{
			StopAllCoroutines();
			NetworklightsOffValue = 0f;
		}
		Shader.SetGlobalFloat(LightsOff, 0f);
	}

	public void ServerResetLights()
	{
		StopAllCoroutines();
		StartCoroutine(LightsResetCo());
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (base.isServer)
		{
			switch (phase)
			{
			case ShiftPhase.Shift:
				StartCoroutine(LightsOffCo());
				break;
			case ShiftPhase.BreakRoom:
				ServerResetLights();
				break;
			case ShiftPhase.Failed:
				ServerResetLights();
				break;
			case ShiftPhase.Organizational:
				break;
			}
		}
	}

	static ModifierFaultyWiring()
	{
		LightsOff = Shader.PropertyToID("_LightsOff");
		RemoteProcedureCalls.RegisterRpc(typeof(ModifierFaultyWiring), "System.Void ModifierFaultyWiring::RpcLightsTurnedOn()", InvokeUserCode_RpcLightsTurnedOn);
		RemoteProcedureCalls.RegisterRpc(typeof(ModifierFaultyWiring), "System.Void ModifierFaultyWiring::RpcLightsTurnedOff()", InvokeUserCode_RpcLightsTurnedOff);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcLightsTurnedOn()
	{
		lightsTurnOnSfx.Play();
	}

	protected static void InvokeUserCode_RpcLightsTurnedOn(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcLightsTurnedOn called on server.");
		}
		else
		{
			((ModifierFaultyWiring)obj).UserCode_RpcLightsTurnedOn();
		}
	}

	protected void UserCode_RpcLightsTurnedOff()
	{
		lightsTurnOffSfx.Play();
	}

	protected static void InvokeUserCode_RpcLightsTurnedOff(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcLightsTurnedOff called on server.");
		}
		else
		{
			((ModifierFaultyWiring)obj).UserCode_RpcLightsTurnedOff();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(lightsOffValue);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(lightsOffValue);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref lightsOffValue, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref lightsOffValue, null, reader.ReadFloat());
		}
	}
}
