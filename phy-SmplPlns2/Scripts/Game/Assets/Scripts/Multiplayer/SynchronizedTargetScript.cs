using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Events;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class SynchronizedTargetScript : NetworkBehaviour
	{
		private Target _target;

		private int _targetPlayerId;

		private TargetRegistry _targetRegistry;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ESynchronizedTargetScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ESynchronizedTargetScriptGame_002Edll_Excuted;

		public Target Target => _target;

		public int TargetPlayerId => _targetPlayerId;

		public event Action<Target> TargetChanged;

		public void SetTarget(Target target)
		{
			if (_target == target)
			{
				return;
			}
			if (!base.IsOwner)
			{
				Debug.LogError("Unabled to set the synchronized target because the local client is not the owner of the network object.");
				return;
			}
			if (target != null && target.Player == null)
			{
				Debug.LogError("Unable to set target. The SynchronizedTargetScript only supports targets with the Player property set to non-null values.");
				return;
			}
			int targetPlayerId = GetTargetPlayerId(target);
			if (targetPlayerId != _targetPlayerId)
			{
				SetTargetInternal(targetPlayerId, target);
				SetTargetServerRpc(targetPlayerId);
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ESynchronizedTargetScript_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual void OnDestroy()
		{
			_targetRegistry.TargetRegistered -= OnTargetRegistered;
			_targetRegistry.TargetUnregistered -= OnTargetUnregistered;
		}

		private Target FindPlayerTarget(int playerId)
		{
			if (playerId >= 0)
			{
				IReadOnlyList<Target> targets = FlightSceneScript.Instance.TargetRegistry.Targets;
				for (int i = 0; i < targets.Count; i++)
				{
					if (GetTargetPlayerId(targets[i]) == playerId)
					{
						return targets[i];
					}
				}
			}
			return null;
		}

		private int GetTargetPlayerId(Target target)
		{
			return target?.Player?.NetworkPlayer.PlayerId ?? (-1);
		}

		private void OnTargetRegistered(object sender, TargetEventArgs e)
		{
			int targetPlayerId = GetTargetPlayerId(e.Target);
			if (targetPlayerId >= 0 && targetPlayerId == _targetPlayerId)
			{
				Target target = FindPlayerTarget(targetPlayerId);
				SetTargetInternal(targetPlayerId, target);
			}
		}

		private void OnTargetUnregistered(object sender, TargetEventArgs e)
		{
			if (e.Target == _target)
			{
				if (base.IsOwner)
				{
					SetTarget(null);
				}
				else
				{
					SetTargetInternal(-1, null);
				}
			}
		}

		private void SetTargetInternal(int targetPlayerId, Target target)
		{
			_targetPlayerId = targetPlayerId;
			if (_target != target)
			{
				_target = target;
				this.TargetChanged?.Invoke(_target);
			}
		}

		[ObserversRpc(BufferLast = true, ExcludeOwner = true)]
		private void SetTargetObserversRpc(int targetPlayerId)
		{
			RpcWriter___Observers_SetTargetObserversRpc___3316948804(targetPlayerId);
		}

		[ServerRpc]
		private void SetTargetServerRpc(int targetPlayerId)
		{
			RpcWriter___Server_SetTargetServerRpc___3316948804(targetPlayerId);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ESynchronizedTargetScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ESynchronizedTargetScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterObserversRpc(0u, RpcReader___Observers_SetTargetObserversRpc___3316948804);
				RegisterServerRpc(1u, RpcReader___Server_SetTargetServerRpc___3316948804);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ESynchronizedTargetScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ESynchronizedTargetScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Observers_SetTargetObserversRpc___3316948804(int targetPlayerId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(targetPlayerId);
			SendObserversRpc(0u, pooledWriter, channel, DataOrderType.Default, bufferLast: true, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SetTargetObserversRpc___3316948804(int P_0)
		{
			Target target = FindPlayerTarget(P_0);
			SetTargetInternal(P_0, target);
		}

		private void RpcReader___Observers_SetTargetObserversRpc___3316948804(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___SetTargetObserversRpc___3316948804(num);
			}
		}

		private void RpcWriter___Server_SetTargetServerRpc___3316948804(int targetPlayerId)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			if (!base.IsOwner)
			{
				NetworkManager networkManager2 = base.NetworkManager;
				networkManager2.LogWarning("Cannot complete action because you are not the owner of this object. .");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(targetPlayerId);
			SendServerRpc(1u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SetTargetServerRpc___3316948804(int P_0)
		{
			SetTargetObserversRpc(P_0);
		}

		private void RpcReader___Server_SetTargetServerRpc___3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___SetTargetServerRpc___3316948804(num);
			}
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ESynchronizedTargetScript_Game_002Edll()
		{
			_targetRegistry = FlightSceneScript.Instance.TargetRegistry;
			_targetRegistry.TargetRegistered += OnTargetRegistered;
			_targetRegistry.TargetUnregistered += OnTargetUnregistered;
			_targetPlayerId = -1;
		}
	}
}
