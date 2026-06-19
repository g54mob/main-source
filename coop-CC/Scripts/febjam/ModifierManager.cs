using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class ModifierManager : NetworkAggroManagerBase<ModifierManager>
{
	[CompilerGenerated]
	private sealed class _003CServerSelectModifierCo_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ModifierManager _003C_003E4__this;

		private GameObject _003CoptionA_003E5__2;

		private GameObject _003CoptionB_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CServerSelectModifierCo_003Ed__34(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			ModifierManager modifierManager = _003C_003E4__this;
			PlayersManager.VoteOption voteOption;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				voteOption = NetworkAggroManagerBase<PlayersManager>.instance.ServerGetWinningVote();
			}
			else
			{
				_003C_003E1__state = -1;
				if (modifierManager._serverDeck.cardCount < 2)
				{
					goto IL_017d;
				}
				if (modifierManager._currentModifier != null)
				{
					EntityUtil.Destroy(modifierManager._currentModifier.entity);
				}
				_003CoptionA_003E5__2 = modifierManager._serverDeck.DrawCard();
				_003CoptionB_003E5__3 = null;
				while (_003CoptionB_003E5__3 == null)
				{
					GameObject gameObject = modifierManager._serverDeck.DrawCard();
					if (gameObject != _003CoptionA_003E5__2)
					{
						_003CoptionB_003E5__3 = gameObject;
					}
				}
				if (!NetworkAggroManagerBase<AutoPlayManager>.instance.autoPlaying)
				{
					modifierManager.RpcStartVote(_003CoptionA_003E5__2, _003CoptionB_003E5__3);
					_003C_003E2__current = NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerVoteCo();
					_003C_003E1__state = 1;
					return true;
				}
				voteOption = PlayersManager.VoteOption.A;
			}
			GameObject gameObject2 = voteOption switch
			{
				PlayersManager.VoteOption.A => _003CoptionA_003E5__2, 
				PlayersManager.VoteOption.B => _003CoptionB_003E5__3, 
				_ => throw new InvalidEnumException(), 
			};
			modifierManager._currentModifier = EntityUtil.Instantiate(gameObject2, modifierManager.entity.transform).GetObject<ModifierBase>();
			if (modifierManager._currentModifier.hazardPay > 0)
			{
				NetworkAggroManagerBase<ShiftManager>.instance.ServerAddMoney(modifierManager._currentModifier.hazardPay);
			}
			modifierManager._serverDeck.RemoveCard(gameObject2);
			modifierManager.RpcVoteEnded(modifierManager._currentModifier.networkBehaviourId);
			_003CoptionA_003E5__2 = null;
			_003CoptionB_003E5__3 = null;
			goto IL_017d;
			IL_017d:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Min(0f)]
	public float onePlayerMultiplier = 1f;

	[Min(0f)]
	public float twoPlayerMultiplier = 1f;

	[Min(0f)]
	public float threePlayerMultiplier = 1f;

	[Min(0f)]
	public float fourPlayerMultiplier = 1f;

	[Space]
	[Min(0f)]
	public float shiftTwoMultiplier = 1f;

	[Min(0f)]
	public float shiftThreeMultiplier = 1f;

	[Min(0f)]
	public float shiftFourMultiplier = 1f;

	[Min(0f)]
	public float shiftFiveMultiplier = 1f;

	public GameObject[] modifierPrefabs;

	public GameObject[] demoModifierPrefabs;

	private ModifierBase _currentModifier;

	private Deck<GameObject> _serverDeck;

	[SyncVar]
	private ModifierArtStyle _syncOverrideArtStyle;

	public string modifierAchievement1 { get; private set; }

	public string modifierAchievement2 { get; private set; }

	public Sprite modifierSeen1 { get; private set; }

	public Sprite modifierSeen2 { get; private set; }

	public ModifierArtStyle overrideArtStyle => _syncOverrideArtStyle;

	public ModifierBase currentModifier => _currentModifier;

	public ModifierArtStyle Network_syncOverrideArtStyle
	{
		get
		{
			return _syncOverrideArtStyle;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncOverrideArtStyle, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		if (!base.isServer || GameUtil.isTutorial)
		{
			return;
		}
		_serverDeck = new Deck<GameObject>(Hash.Calculate(GameUtil.seed, Hash.Calculate(GetType())));
		GameObject[] array = GetModifierPrefabs();
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null && gameObject.GetComponent<ModifierBase>().Evaluate())
			{
				_serverDeck.AddCard(gameObject);
			}
		}
		_serverDeck.Shuffle();
	}

	[IteratorStateMachine(typeof(_003CServerSelectModifierCo_003Ed__34))]
	[Server]
	public IEnumerator ServerSelectModifierCo()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator ModifierManager::ServerSelectModifierCo()' called when server was not active");
			return null;
		}
		return new _003CServerSelectModifierCo_003Ed__34(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	public void ServerAlertModifierChanged()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ModifierManager::ServerAlertModifierChanged()' called when server was not active");
		}
		else
		{
			RpcModifierChanged(_currentModifier.networkBehaviourId);
		}
	}

	[ClientRpc]
	private void RpcModifierChanged(NetBehaviourId id)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(id);
		SendRPCInternal("System.Void ModifierManager::RpcModifierChanged(Aggro.Core.Networking.NetBehaviourId)", 445554103, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public bool TryGetModifier(out ModifierBase modifier)
	{
		modifier = _currentModifier;
		return (object)modifier != null;
	}

	public bool TryGetModiferAs<T>(out T modifier) where T : ModifierBase
	{
		modifier = _currentModifier as T;
		return (object)modifier != null;
	}

	public bool HasFlags(ModifierFlags flags)
	{
		if ((object)_currentModifier == null)
		{
			return false;
		}
		return (_currentModifier.flags & flags) == flags;
	}

	public ModifierFlags GetFlags()
	{
		if ((object)_currentModifier == null)
		{
			return ModifierFlags.None;
		}
		return _currentModifier.flags;
	}

	public ModifierArtStyle GetArtStyle()
	{
		if ((object)_currentModifier == null)
		{
			return ModifierArtStyle.None;
		}
		return _currentModifier.modifierArtStyle;
	}

	public float GetPatienceMultiplier()
	{
		if ((object)_currentModifier == null)
		{
			return 1f;
		}
		return _currentModifier.patienceMultiplier;
	}

	public float GetPayoutMultiplier()
	{
		if ((object)_currentModifier == null)
		{
			return 1f;
		}
		return _currentModifier.payoutMultiplier;
	}

	[ClientRpc]
	private void RpcStartVote(GameObject modifierObjA, GameObject modifierObjB)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(modifierObjA);
		writer.WriteGameObject(modifierObjB);
		SendRPCInternal("System.Void ModifierManager::RpcStartVote(UnityEngine.GameObject,UnityEngine.GameObject)", -1052188080, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcVoteEnded(NetBehaviourId modifier)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(modifier);
		SendRPCInternal("System.Void ModifierManager::RpcVoteEnded(Aggro.Core.Networking.NetBehaviourId)", 754788076, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetModifier(GameObject prefab)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(prefab);
		SendCommandInternal("System.Void ModifierManager::CmdSetModifier(UnityEngine.GameObject)", -2086303312, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetOverrideArtStyle(ModifierArtStyle style)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ModifierArtStyle(writer, style);
		SendCommandInternal("System.Void ModifierManager::CmdSetOverrideArtStyle(ModifierArtStyle)", 321785260, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSetModifier(NetBehaviourId modifier)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(modifier);
		SendRPCInternal("System.Void ModifierManager::RpcSetModifier(Aggro.Core.Networking.NetBehaviourId)", -1848644203, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public GameObject[] GetModifierPrefabs()
	{
		if (GameUtil.isDemo)
		{
			return demoModifierPrefabs;
		}
		return modifierPrefabs;
	}

	[DevCmd("modifier", "Interact with run modifiers.\r\n\r\nUsage:\r\n    modifier\r\n        Prints the current modifier.\r\n\r\n    modifier <prefab_name>\r\n        Adds the current modifier to the run.\r\n\r\n    modifier -style <style_name>\r\n        Sets the art style to the supplied style as an override.", new string[] { "style" })]
	[DevCmdVerify("^$")]
	[DevCmdVerify("^[\\S]+$")]
	[DevCmdVerify("^-style [\\S]+$")]
	[DevCmdComplete("style", DevCmdCompleteFlags.ValueCaseInsensitive, typeof(ModifierArtStyle))]
	private static void ModifierDevCmd(DevCmdArg[] args)
	{
		if (GameUtil.isLobby)
		{
			UnityEngine.Debug.LogWarning("Can't interact with modifiers in the lobby!");
		}
		else if (NetworkAggroManagerBase<ModifierManager>.instance == null)
		{
			UnityEngine.Debug.LogWarning("ModifierManager instance not set!");
		}
		else if (args.Length != 0)
		{
			string text = args[0].name;
			if (text == null || text.Length != 0)
			{
				if (text == "style")
				{
					if (Enum.TryParse<ModifierArtStyle>(args[0].value, ignoreCase: true, out var result))
					{
						NetworkAggroManagerBase<ModifierManager>.instance.CmdSetOverrideArtStyle(result);
					}
					else
					{
						UnityEngine.Debug.LogWarning("Unknown art style! " + args[0].value);
					}
				}
				else
				{
					UnityEngine.Debug.LogWarning("Unknown parameter name! " + args[0].name);
				}
				return;
			}
			string text2 = args[0].value.ToLowerInvariant();
			for (int i = 0; i < NetworkAggroManagerBase<ModifierManager>.instance.GetModifierPrefabs().Length; i++)
			{
				GameObject gameObject = NetworkAggroManagerBase<ModifierManager>.instance.GetModifierPrefabs()[i];
				if (gameObject.name.ToLowerInvariant() == text2)
				{
					NetworkAggroManagerBase<ModifierManager>.instance.CmdSetModifier(gameObject);
					return;
				}
			}
			UnityEngine.Debug.LogWarning("Invalid prefab name! (" + args[0].value + ")");
		}
		else if (NetworkAggroManagerBase<ModifierManager>.instance._currentModifier != null)
		{
			UnityEngine.Debug.Log(NetworkAggroManagerBase<ModifierManager>.instance._currentModifier.name, NetworkAggroManagerBase<ModifierManager>.instance._currentModifier);
		}
		else
		{
			UnityEngine.Debug.Log("No modifier!");
		}
	}

	[DevCmdCompleteFunction("modifier", "", DevCmdCompleteFlags.ValueCaseInsensitive | DevCmdCompleteFlags.Sort)]
	private static string[] ModifierDevCmdComplete()
	{
		if (!GameUtil.isReady || !NetworkAggroManagerBase<ModifierManager>.ManagerExists())
		{
			return new string[0];
		}
		List<string> list = new List<string>();
		for (int i = 0; i < NetworkAggroManagerBase<ModifierManager>.instance.GetModifierPrefabs().Length; i++)
		{
			list.Add(NetworkAggroManagerBase<ModifierManager>.instance.GetModifierPrefabs()[i].name);
		}
		return list.ToArray();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcModifierChanged__NetBehaviourId(NetBehaviourId id)
	{
		ObjectQuery<IModifierAdded> objectQuery = base.entityManager.CreateObjectQuery<IModifierAdded>();
		objectQuery.Run();
		ModifierBase modifier = id.Get<ModifierBase>();
		for (int i = 0; i < objectQuery.count; i++)
		{
			objectQuery[i].OnModifierAdded(modifier);
		}
	}

	protected static void InvokeUserCode_RpcModifierChanged__NetBehaviourId(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcModifierChanged called on server.");
		}
		else
		{
			((ModifierManager)obj).UserCode_RpcModifierChanged__NetBehaviourId(Aggro.Core.Networking.NetworkSerialization.ReadNetworkBehaviour(reader));
		}
	}

	protected void UserCode_RpcStartVote__GameObject__GameObject(GameObject modifierObjA, GameObject modifierObjB)
	{
		ModifierBase component = modifierObjA.GetComponent<ModifierBase>();
		ModifierBase component2 = modifierObjB.GetComponent<ModifierBase>();
		AggroManagerBase<ModifierChoiceManagerUI>.instance.SetUpModifiers(component, component2);
	}

	protected static void InvokeUserCode_RpcStartVote__GameObject__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcStartVote called on server.");
		}
		else
		{
			((ModifierManager)obj).UserCode_RpcStartVote__GameObject__GameObject(reader.ReadGameObject(), reader.ReadGameObject());
		}
	}

	protected void UserCode_RpcVoteEnded__NetBehaviourId(NetBehaviourId modifier)
	{
		_currentModifier = modifier.Get<ModifierBase>();
		AggroManagerBase<ModifierChoiceManagerUI>.instance.EndVote();
		if (modifierSeen1 == null)
		{
			modifierSeen1 = _currentModifier.modifierIcon;
			modifierAchievement1 = _currentModifier.contractCompleteAchievement;
		}
		else
		{
			modifierSeen2 = _currentModifier.modifierIcon;
			modifierAchievement2 = _currentModifier.contractCompleteAchievement;
		}
	}

	protected static void InvokeUserCode_RpcVoteEnded__NetBehaviourId(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcVoteEnded called on server.");
		}
		else
		{
			((ModifierManager)obj).UserCode_RpcVoteEnded__NetBehaviourId(Aggro.Core.Networking.NetworkSerialization.ReadNetworkBehaviour(reader));
		}
	}

	protected void UserCode_CmdSetModifier__GameObject(GameObject prefab)
	{
		if (_currentModifier != null)
		{
			EntityUtil.Destroy(_currentModifier.entity);
		}
		_currentModifier = EntityUtil.Instantiate(prefab, base.entity.transform).GetObject<ModifierBase>();
		RpcSetModifier(_currentModifier.networkBehaviourId);
		ServerAlertModifierChanged();
	}

	protected static void InvokeUserCode_CmdSetModifier__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetModifier called on client.");
		}
		else
		{
			((ModifierManager)obj).UserCode_CmdSetModifier__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_CmdSetOverrideArtStyle__ModifierArtStyle(ModifierArtStyle style)
	{
		Network_syncOverrideArtStyle = style;
	}

	protected static void InvokeUserCode_CmdSetOverrideArtStyle__ModifierArtStyle(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetOverrideArtStyle called on client.");
		}
		else
		{
			((ModifierManager)obj).UserCode_CmdSetOverrideArtStyle__ModifierArtStyle(GeneratedNetworkCode._Read_ModifierArtStyle(reader));
		}
	}

	protected void UserCode_RpcSetModifier__NetBehaviourId(NetBehaviourId modifier)
	{
		_currentModifier = modifier.Get<ModifierBase>();
	}

	protected static void InvokeUserCode_RpcSetModifier__NetBehaviourId(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcSetModifier called on server.");
		}
		else
		{
			((ModifierManager)obj).UserCode_RpcSetModifier__NetBehaviourId(Aggro.Core.Networking.NetworkSerialization.ReadNetworkBehaviour(reader));
		}
	}

	static ModifierManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ModifierManager), "System.Void ModifierManager::CmdSetModifier(UnityEngine.GameObject)", InvokeUserCode_CmdSetModifier__GameObject, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ModifierManager), "System.Void ModifierManager::CmdSetOverrideArtStyle(ModifierArtStyle)", InvokeUserCode_CmdSetOverrideArtStyle__ModifierArtStyle, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ModifierManager), "System.Void ModifierManager::RpcModifierChanged(Aggro.Core.Networking.NetBehaviourId)", InvokeUserCode_RpcModifierChanged__NetBehaviourId);
		RemoteProcedureCalls.RegisterRpc(typeof(ModifierManager), "System.Void ModifierManager::RpcStartVote(UnityEngine.GameObject,UnityEngine.GameObject)", InvokeUserCode_RpcStartVote__GameObject__GameObject);
		RemoteProcedureCalls.RegisterRpc(typeof(ModifierManager), "System.Void ModifierManager::RpcVoteEnded(Aggro.Core.Networking.NetBehaviourId)", InvokeUserCode_RpcVoteEnded__NetBehaviourId);
		RemoteProcedureCalls.RegisterRpc(typeof(ModifierManager), "System.Void ModifierManager::RpcSetModifier(Aggro.Core.Networking.NetBehaviourId)", InvokeUserCode_RpcSetModifier__NetBehaviourId);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_ModifierArtStyle(writer, _syncOverrideArtStyle);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_ModifierArtStyle(writer, _syncOverrideArtStyle);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncOverrideArtStyle, null, GeneratedNetworkCode._Read_ModifierArtStyle(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncOverrideArtStyle, null, GeneratedNetworkCode._Read_ModifierArtStyle(reader));
		}
	}
}
