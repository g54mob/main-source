using System;
using System.Collections;
using System.Collections.Generic;
using Coherence;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings.TransformBindings;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors;

public class NetworkPickup : Pickup
{
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public NetworkPickup _003C_003E4__this;

		public VampireSurvivors.Objects.Characters.CharacterController player;

		internal void _003CPerformVacuum_003Eb__0()
		{
			NetworkPickup networkPickup = _003C_003E4__this;
			if (!networkPickup._requestedTake && !networkPickup._performingTake && !((Pickup)networkPickup)._003CDisableGet_003Ek__BackingField && networkPickup.body != null)
			{
				networkPickup._performingVacuum = true;
				bool flag = _003C_003E4__this.Vacuum(player);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public NetworkPickup _003C_003E4__this;

		public VampireSurvivors.Objects.Characters.CharacterController player;

		internal void _003CPerformTake_003Eb__0()
		{
			NetworkPickup networkPickup = _003C_003E4__this;
			if (networkPickup.body != null)
			{
				networkPickup._targetPlayer = player;
				_003C_003E4__this.GetTaken();
			}
		}
	}

	private sealed class _003CWaitForAcksAndReturnToPool_003Ed__39(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkPickup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_009b: Expected I4, but got I8
			//IL_0065: Expected F4, but got I4
			//IL_01c9: Expected O, but got F4
			//IL_018f->IL018f: Incompatible stack heights: 1 vs 0
			//IL_01bb->IL017f: Incompatible stack heights: 2 vs 1
			NetworkPickup networkPickup = _003C_003E4__this;
			bool num;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				num = flag;
				networkPickup._ackTimeout = _003C_003E1__state;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_018f;
				}
				_003C_003E1__state = -1;
				bool flag2 = (object)_003C_003E4__this == null;
				num = flag2;
			}
			if (!_003C_003E4__this.AllConnectedClientsAckedPickup())
			{
				CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
				bool flag3 = (object)CoherenceBridgeStore.masterBridge == null;
				float num2;
				if (masterBridge.controlTimeScale)
				{
					num2 = 3.4028235E+38f;
				}
				else
				{
					object obj = UnityEngine.Time.timeScale;
					float num3 = default(float);
					num2 = num3 * 3.4028235E+38f;
				}
				if (!(num2 < networkPickup._ackTimeout))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
					object obj2 = default(object);
					float ackTimeout = (float)obj2 + networkPickup._ackTimeout;
					networkPickup._ackTimeout = ackTimeout;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			_003C_003E4__this.ReturnPickupToPool();
			goto IL_018f;
			IL_018f:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	protected CoherenceSync _coherenceSync;

	protected bool _vacuumAssigned;

	protected bool _takeAssigned;

	protected bool _performingVacuum;

	protected bool _performingTake;

	protected bool _requestedVacuum;

	protected bool _requestedTake;

	protected List<ClientID> _ackedClients;

	protected bool _taken;

	protected bool _canPauseSyncTimer;

	protected bool _reactivateRenderer;

	protected Coherence.Log.Logger _logger;

	private PositionBinding _positionBinding;

	private float _ackTimeout;

	private const float MaxAckTimeout = 3.4028235E+38f;

	private bool _003CForceDespawn_003Ek__BackingField;

	protected virtual bool UsesOrderedCommand => false;

	public CoherenceSync Sync => _coherenceSync;

	public bool ForceDespawn
	{
		get
		{
			return _003CForceDespawn_003Ek__BackingField;
		}
		set
		{
			_003CForceDespawn_003Ek__BackingField = value;
		}
	}

	public void RequestVacuum(CoherenceSync requestingPlayer)
	{
		if (!_vacuumAssigned)
		{
			_vacuumAssigned = true;
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			PreOnlineVacuum();
			Action<long, CoherenceSync> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
			object param = default(object);
			bool flag = _coherenceSync.SendCommand((Action<long, object>)action, MessageTarget.All, startingOnlineClientFrame, param);
		}
	}

	public void PerformVacuum(long startingSimFrame, CoherenceSync requestingPlayer)
	{
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		VampireSurvivors.Objects.Characters.CharacterController component = requestingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		CS_0024_003C_003E8__locals5.player = component;
		if (body == null)
		{
			return;
		}
		PositionBinding positionBinding = _positionBinding;
		_ = 1;
		Action onSyncedTimer = delegate
		{
			NetworkPickup networkPickup = CS_0024_003C_003E8__locals5._003C_003E4__this;
			if (!networkPickup._requestedTake && !networkPickup._performingTake && !((Pickup)networkPickup)._003CDisableGet_003Ek__BackingField && networkPickup.body != null)
			{
				networkPickup._performingVacuum = true;
				bool flag = CS_0024_003C_003E8__locals5._003C_003E4__this.Vacuum(CS_0024_003C_003E8__locals5.player);
			}
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer, _canPauseSyncTimer);
	}

	public void RequestTake(CoherenceSync requestingPlayer)
	{
		if (!_takeAssigned)
		{
			_takeAssigned = true;
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			PreOnlineTake();
			if (!UsesOrderedCommand)
			{
				Action<long, CoherenceSync> action = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
				object param = default(object);
				bool flag = _coherenceSync.SendCommand((Action<long, object>)action, MessageTarget.All, startingOnlineClientFrame, param);
			}
			else
			{
				Action<long, CoherenceSync> action2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6D7F0");
			}
		}
	}

	public void PerformTake(long startingSimFrame, CoherenceSync requestingPlayer)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		VampireSurvivors.Objects.Characters.CharacterController component = requestingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		CS_0024_003C_003E8__locals5.player = component;
		if (body == null)
		{
			return;
		}
		_performingTake = true;
		Action onSyncedTimer = delegate
		{
			NetworkPickup networkPickup = CS_0024_003C_003E8__locals5._003C_003E4__this;
			if (networkPickup.body != null)
			{
				networkPickup._targetPlayer = CS_0024_003C_003E8__locals5.player;
				CS_0024_003C_003E8__locals5._003C_003E4__this.GetTaken();
			}
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer, _canPauseSyncTimer);
	}

	public void AckTake(uint clientId)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		//IL_0066: Expected O, but got I4
		List<ClientID> ackedClients = _ackedClients;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2 (System.Collections.Generic.List`1<Coherence.Connection.ClientID>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2 (System.Collections.Generic.List`1<Coherence.Connection.ClientID>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2 (System.Collections.Generic.List`1<Coherence.Connection.ClientID>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v3+18]");
		if (num >= 0)
		{
			ackedClients.AddWithResize((ClientID)clientId);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2 (System.Collections.Generic.List`1<Coherence.Connection.ClientID>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public void OnlineForceDespawn()
	{
		Despawn();
	}

	public virtual bool GetOnlineVacuum(VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
	{
		//IL_01a4: Expected I4, but got O
		if (!_requestedVacuum && !_performingVacuum && !base._003CDisableGet_003Ek__BackingField && !_requestedTake && !_performingTake && !base._003CIsStationary_003Ek__BackingField)
		{
			if ((object)targetPlayer != null && (object)targetPlayer._coherenceSync != null)
			{
				if (!targetPlayer._coherenceSync.HasStateAuthority)
				{
					goto IL_0188;
				}
				_requestedVacuum = true;
				Action<CoherenceSync> action = RequestVacuum;
				if ((object)_coherenceSync != null)
				{
					bool flag = _coherenceSync.SendCommand((Action<object>)action, MessageTarget.AuthorityOnly, targetPlayer._coherenceSync);
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_0188;
		IL_0188:
		return false;
	}

	public virtual void GetOnlineTaken()
	{
		if (!_requestedTake && !_performingTake && !base._003CDisableGet_003Ek__BackingField)
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			if (targetPlayer._coherenceSync.HasStateAuthority)
			{
				_requestedTake = true;
				Action<CoherenceSync> action = RequestTake;
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = _targetPlayer;
				bool flag = _coherenceSync.SendCommand((Action<object>)action, MessageTarget.AuthorityOnly, targetPlayer2._coherenceSync);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		CoherenceSync component = GetComponent<CoherenceSync>();
		_coherenceSync = component;
		PositionBinding bakedValueBinding = _coherenceSync.GetBakedValueBinding<PositionBinding>();
		_positionBinding = bakedValueBinding;
		Coherence.Log.Logger logger = Log.GetLogger<NetworkPickup>();
		_logger = logger;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x186F3E930\"");
	}

	protected virtual void PreOnlineVacuum()
	{
	}

	protected virtual void PreOnlineTake()
	{
	}

	protected void Reset()
	{
		PositionBinding positionBinding = _positionBinding;
		_003CForceDespawn_003Ek__BackingField = false;
		_doOnlineDespawn = false;
		_vacuumAssigned = false;
		_requestedVacuum = false;
		_taken = false;
		_ = 0;
		List<ClientID> ackedClients = _ackedClients;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v3 (System.Collections.Generic.List`1<Coherence.Connection.ClientID>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		if (_reactivateRenderer)
		{
			_reactivateRenderer = false;
			_itemRenderer.enabled = true;
		}
	}

	public override void Despawn()
	{
		//IL_0079: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag && _doOnlineDespawn == flag && _003CForceDespawn_003Ek__BackingField == flag)
			{
				return;
			}
		}
		base.Despawn();
		OnlineDespawn();
	}

	protected void OnlineDespawn()
	{
		//IL_0335: Expected O, but got I4
		//IL_013d: Expected I4, but got O
		//IL_0179: Expected I4, but got O
		//IL_0033->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_007f->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_00a1->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_0225->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_0247->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_0117->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_0291->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_015c->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_0197->IL02d7: Incompatible stack heights: 1 vs 0
		//IL_01e9->IL02d7: Incompatible stack heights: 1 vs 0
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			CoherenceSync coherenceSync = _coherenceSync;
			if ((object)_coherenceSync != null)
			{
				if ((nint)coherenceSync._003CEntityState_003Ek__BackingField <= 0)
				{
					return;
				}
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._multiplayer != null)
				{
					if (!core._multiplayer.IsOnlineMultiplayer)
					{
						goto IL_0203;
					}
					if (!_doOnlineDespawn)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
					CoherenceBridge coherenceBridge = default(CoherenceBridge);
					if ((object)coherenceBridge != null)
					{
						ClientID clientID = coherenceBridge.ClientID;
						Action<uint> action = null;
						((NetworkPickup)(object)action).AckTake((uint)(int)this);
						if ((object)_coherenceSync != null)
						{
							bool flag2 = _coherenceSync.SendCommand(action, MessageTarget.AuthorityOnly, (uint)(int)clientID);
							if ((object)_itemRenderer != null)
							{
								if (_itemRenderer.enabled)
								{
									_reactivateRenderer = true;
									if ((object)_itemRenderer == null)
									{
										goto IL_02d7;
									}
									_itemRenderer.enabled = false;
								}
								goto IL_0203;
							}
						}
					}
				}
			}
		}
		goto IL_02d7;
		IL_02d7:
		throw new NullReferenceException();
		IL_0203:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null && core2._multiplayer != null)
		{
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
			if ((object)_coherenceSync != null)
			{
				if (_coherenceSync.HasStateAuthority)
				{
					_003CWaitForAcksAndReturnToPool_003Ed__39 obj2 = null;
					obj2._003C_003E1__state = 0;
					obj2._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj2);
				}
				return;
			}
		}
		goto IL_02d7;
	}

	public override void GetTaken()
	{
		if (!_taken)
		{
			base.GetTaken();
			_taken = true;
		}
	}

	private IEnumerator WaitForAcksAndReturnToPool()
	{
		_003CWaitForAcksAndReturnToPool_003Ed__39 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe bool AllConnectedClientsAckedPickup()
	{
		//IL_0018: Expected I, but got O
		//IL_0070: Expected I, but got O
		//IL_00ac: Expected I, but got O
		//IL_00cc: Expected O, but got Ref
		//IL_00d1: Expected I, but got O
		//IL_0111: Expected I, but got O
		//IL_0133: Expected I, but got O
		//IL_01a4: Expected O, but got I
		nint num = (nint)typeof(CoherenceBridgeStore);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v5 (Il2CppClass<Coherence.Toolkit.CoherenceBridgeStore>)+B8]");
		nint num2 = 0;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge != null)
		{
			bool flag = masterBridge._003CClientConnections_003Ek__BackingField == null;
			num2 = (nint)masterBridge._003CClientConnections_003Ek__BackingField;
			if (!flag)
			{
				IEnumerable<CoherenceClientConnection> other = masterBridge._003CClientConnections_003Ek__BackingField.GetOther();
				bool flag2 = other == null;
				num2 = (nint)masterBridge._003CClientConnections_003Ek__BackingField;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj2 = default(object);
					object obj = (object)(&obj2);
					num2 = unchecked((nint)null);
					object obj3 = default(object);
					object obj4 = default(object);
					while (true)
					{
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj3 != null)
							{
								bool flag3 = obj2 == null;
								num2 = unchecked((nint)null);
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496200");
									num2 = (nint)_ackedClients;
									if (obj4 != null)
									{
										if (_ackedClients == null)
										{
											break;
										}
										if (CoherenceBridgeStore.bridgeResolve != null)
										{
											List<ClientID> ackedClients = _ackedClients;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v25+34]");
											int num3 = ackedClients.IndexOf((ClientID)0);
											if (num3 != -1)
											{
												continue;
											}
										}
										if (obj != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
										}
										return false;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							return true;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual void ReturnPickupToPool()
	{
		PickupManager.ReturnPickup(this);
	}

	private static float GetMaxAckTimeout()
	{
		//IL_005a: Expected O, but got F4
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if (masterBridge.controlTimeScale)
		{
			return 3.4028235E+38f;
		}
		object obj = UnityEngine.Time.timeScale;
		float num = default(float);
		return num * 3.4028235E+38f;
	}

	protected bool IsBeingTaken()
	{
		if (!_requestedTake && !_performingTake)
		{
			return base._003CDisableGet_003Ek__BackingField;
		}
		return true;
	}

	protected bool IsBeingVacuumed()
	{
		if (!_requestedVacuum && !_performingVacuum)
		{
			return base._003CDisableGet_003Ek__BackingField;
		}
		return true;
	}

	private bool IsPickupAlreadyDestroyed()
	{
		return body == null;
	}

	public NetworkPickup()
	{
		List<ClientID> ackedClients = new List<ClientID>();
		_ackedClients = ackedClients;
		_canPauseSyncTimer = true;
		base._002Ector();
	}
}
