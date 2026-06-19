using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAllergies : NetworkEntityBehaviourBase
{
	public enum State : byte
	{
		None = 0,
		PreparingToSneeze = 1,
		Sneezing = 2
	}

	[Min(0f)]
	public float preparingToSneezeDuration = 1f;

	[Min(0f)]
	public float sneezingDuration = 1f;

	[Min(0f)]
	public float sneezeBackwardsForce = 20f;

	private Timer _localPlayerTimer;

	private State _localPlayerState;

	private static List<Pollen> _pollens;

	private static readonly int Sneeze;

	private static readonly int InPollen;

	public EventReference sneezeSFXEvent;

	public StudioEventEmitter sneezeBuild;

	[Command]
	public void CmdPlaySneezeSFX()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerAllergies::CmdPlaySneezeSFX()", 693938363, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	public void CmdPlaySneezeBuildSFX()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerAllergies::CmdPlaySneezeBuildSFX()", -550463123, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcPlaySneezeSFX()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerAllergies::RpcPlaySneezeSFX()", -1139866238, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcPlaySneezeBuildSFX()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerAllergies::RpcPlaySneezeBuildSFX()", -1894468662, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		_pollens.Clear();
		base.entityManager.GetAllObjects(_pollens);
		bool flag = false;
		Vector3 position = base.entity.transform.position;
		for (int i = 0; i < _pollens.Count; i++)
		{
			Pollen pollen = _pollens[i];
			if (math.distancesq(pollen.transform.position, position) <= pollen.pollenRadius * pollen.pollenRadius)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			base.entity.GetObject<PlayerAnimation>().animator.SetBool(InPollen, value: true);
			switch (_localPlayerState)
			{
			case State.None:
				_localPlayerState = State.PreparingToSneeze;
				CmdPlaySneezeBuildSFX();
				_localPlayerTimer.SetTimer(preparingToSneezeDuration);
				break;
			case State.PreparingToSneeze:
				_localPlayerTimer.DecrementTimer();
				if (_localPlayerTimer.IsFinished())
				{
					_localPlayerState = State.Sneezing;
					_localPlayerTimer.SetTimer(sneezingDuration);
					base.entity.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
					base.entity.GetObject<VehicleController>().LocalPlayerTakeForce(-base.entity.transform.forward * sneezeBackwardsForce);
					CmdPlaySneezeSFX();
				}
				break;
			case State.Sneezing:
				_localPlayerTimer.DecrementTimer();
				if (_localPlayerTimer.IsFinished())
				{
					CmdPlaySneezeBuildSFX();
					_localPlayerState = State.PreparingToSneeze;
					_localPlayerTimer.SetTimer(preparingToSneezeDuration);
				}
				break;
			default:
				throw new InvalidEnumException();
			}
			return;
		}
		base.entity.GetObject<PlayerAnimation>().animator.SetBool(InPollen, value: false);
		switch (_localPlayerState)
		{
		case State.PreparingToSneeze:
			_localPlayerState = State.None;
			break;
		case State.Sneezing:
			_localPlayerTimer.DecrementTimer();
			if (_localPlayerTimer.IsFinished())
			{
				_localPlayerState = State.None;
			}
			break;
		default:
			throw new InvalidEnumException();
		case State.None:
			break;
		}
	}

	static PlayerAllergies()
	{
		_pollens = new List<Pollen>();
		Sneeze = Animator.StringToHash("sneeze");
		InPollen = Animator.StringToHash("inPollen");
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerAllergies), "System.Void PlayerAllergies::CmdPlaySneezeSFX()", InvokeUserCode_CmdPlaySneezeSFX, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerAllergies), "System.Void PlayerAllergies::CmdPlaySneezeBuildSFX()", InvokeUserCode_CmdPlaySneezeBuildSFX, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerAllergies), "System.Void PlayerAllergies::RpcPlaySneezeSFX()", InvokeUserCode_RpcPlaySneezeSFX);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerAllergies), "System.Void PlayerAllergies::RpcPlaySneezeBuildSFX()", InvokeUserCode_RpcPlaySneezeBuildSFX);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlaySneezeSFX()
	{
		RpcPlaySneezeSFX();
	}

	protected static void InvokeUserCode_CmdPlaySneezeSFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlaySneezeSFX called on client.");
		}
		else
		{
			((PlayerAllergies)obj).UserCode_CmdPlaySneezeSFX();
		}
	}

	protected void UserCode_CmdPlaySneezeBuildSFX()
	{
		RpcPlaySneezeBuildSFX();
	}

	protected static void InvokeUserCode_CmdPlaySneezeBuildSFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlaySneezeBuildSFX called on client.");
		}
		else
		{
			((PlayerAllergies)obj).UserCode_CmdPlaySneezeBuildSFX();
		}
	}

	protected void UserCode_RpcPlaySneezeSFX()
	{
		AudioManager.PlaySfx(sneezeSFXEvent, base.transform.position);
		base.entity.GetObject<PlayerAnimation>().animator.SetTrigger(Sneeze);
	}

	protected static void InvokeUserCode_RpcPlaySneezeSFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlaySneezeSFX called on server.");
		}
		else
		{
			((PlayerAllergies)obj).UserCode_RpcPlaySneezeSFX();
		}
	}

	protected void UserCode_RpcPlaySneezeBuildSFX()
	{
		sneezeBuild.Play();
	}

	protected static void InvokeUserCode_RpcPlaySneezeBuildSFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlaySneezeBuildSFX called on server.");
		}
		else
		{
			((PlayerAllergies)obj).UserCode_RpcPlaySneezeBuildSFX();
		}
	}
}
