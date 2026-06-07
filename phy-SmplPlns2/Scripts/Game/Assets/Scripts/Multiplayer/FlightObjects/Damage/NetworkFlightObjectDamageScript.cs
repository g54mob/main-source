using System;
using System.Collections.Generic;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using FishNet.Connection;
using FishNet.Managing.Timing;
using FishNet.Serializing;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage
{
	public class NetworkFlightObjectDamageScript : NetworkFlightObjectComponent
	{
		private enum RpcType : byte
		{
			SyncDamage = 0,
			SyncNotableDamage = 1
		}

		private class DamageReceiver : INetworkedDamage
		{
			public short Damage;

			public byte Id;

			public List<NotableDamage> NotableDamage;

			public NetworkFlightObjectDamageReceiverScript Script;

			public short UnsyncedDamage;

			public List<NotableDamage> UnsyncedNotableDamage;

			short INetworkedDamage.Damage => Damage;

			IReadOnlyList<NotableDamage> INetworkedDamage.NotableDamage => NotableDamage;

			short INetworkedDamage.UnsyncedDamage => UnsyncedDamage;

			IReadOnlyList<NotableDamage> INetworkedDamage.UnsyncedNotableDamage => UnsyncedNotableDamage;

			public DamageReceiver(byte id, NetworkFlightObjectDamageReceiverScript script)
			{
				Id = id;
				Script = script;
				Damage = 0;
				UnsyncedDamage = 0;
				NotableDamage = new List<NotableDamage>();
				UnsyncedNotableDamage = new List<NotableDamage>();
			}
		}

		[SerializeField]
		private bool _autoRegisterReceivers;

		private List<DamageReceiver> _damageReceivers;

		private DamageReceiver[] _damageReceiversById;

		public override void Initialize(PooledReader spawnDataReader, PooledReader stateDataReader)
		{
			base.Initialize(spawnDataReader, stateDataReader);
			if (_autoRegisterReceivers)
			{
				NetworkFlightObjectDamageReceiverScript[] componentsInChildren = GetComponentsInChildren<NetworkFlightObjectDamageReceiverScript>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].Initialize((byte)i, this);
				}
			}
			ProcessNotableDamageSyncRpc(stateDataReader, isServerRpc: false);
			ProcessDamageSyncRpc(stateDataReader, isServerRpc: false);
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			base.NetworkFlightObject.TimeManager.OnPostTick += OnPostTick;
		}

		public override void ReceiveClientRpc(PooledReader data)
		{
			base.ReceiveClientRpc(data);
			ProcessRpc(data, isServerRpc: false);
		}

		public override void ReceiveServerRpc(PooledReader data, NetworkConnection sender)
		{
			base.ReceiveServerRpc(data, sender);
			ProcessRpc(data, isServerRpc: true);
		}

		public INetworkedDamage RegisterDamageReceiver(NetworkFlightObjectDamageReceiverScript damageReceiver)
		{
			byte id = damageReceiver.Id;
			DamageReceiver damageReceiver2 = _damageReceiversById[id];
			if (damageReceiver2 != null)
			{
				if (damageReceiver2.Script != null)
				{
					Debug.LogError($"Damage receiver with id '{id}' is already registered with this network flight object's damage script.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + base.NetworkFlightObject.GetType().FullName + ")" + System.Environment.NewLine + "Component: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Damage Receiver: " + (damageReceiver?.name ?? "null") + " (" + (damageReceiver?.GetType().FullName ?? "null") + ")");
					return null;
				}
				damageReceiver2.Script = damageReceiver;
			}
			else
			{
				damageReceiver2 = new DamageReceiver(id, damageReceiver);
			}
			_damageReceiversById[id] = damageReceiver2;
			_damageReceivers.Add(damageReceiver2);
			damageReceiver.LocalDamageReceived += OnLocalDamageReceived;
			damageReceiver.LocalNotableDamageReceived += OnLocalNotableDamageReceived;
			if (damageReceiver2.NotableDamage.Count > 0)
			{
				foreach (NotableDamage item in damageReceiver2.NotableDamage)
				{
					damageReceiver2.Script.OnNotableDamageSynced(item);
				}
			}
			if (damageReceiver2.Damage != 0)
			{
				damageReceiver2.Script.OnDamageSynced(damageReceiver2.Damage, damageReceiver2.Damage);
			}
			return damageReceiver2;
		}

		public void UnregisterDamageReceiver(NetworkFlightObjectDamageReceiverScript damageReceiver)
		{
			byte id = damageReceiver.Id;
			DamageReceiver damageReceiver2 = _damageReceiversById[id];
			if (damageReceiver2 == null || damageReceiver2.Script != damageReceiver)
			{
				Debug.LogError($"Damage receiver with id '{id}' cannot be unregistered with this network flight object's damage script because it is not registered.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + base.NetworkFlightObject.GetType().FullName + ")" + System.Environment.NewLine + "Component: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Damage Receiver: " + (damageReceiver?.name ?? "null") + " (" + (damageReceiver?.GetType().FullName ?? "null") + ")");
			}
			else
			{
				_damageReceiversById[id] = null;
				_damageReceivers.Remove(damageReceiver2);
				damageReceiver.LocalDamageReceived -= OnLocalDamageReceived;
				damageReceiver.LocalNotableDamageReceived -= OnLocalNotableDamageReceived;
			}
		}

		public override void WriteStateInitializationData(PooledWriter writer)
		{
			base.WriteStateInitializationData(writer);
			List<DamageReceiver> value;
			using (CollectionPool<List<DamageReceiver>, DamageReceiver>.Get(out value))
			{
				foreach (DamageReceiver damageReceiver in _damageReceivers)
				{
					if (damageReceiver.NotableDamage.Count > 0)
					{
						value.Add(damageReceiver);
					}
				}
				writer.WriteUInt8Unpacked((byte)value.Count);
				foreach (DamageReceiver item in value)
				{
					writer.WriteUInt8Unpacked(item.Id);
					writer.WriteUInt16((ushort)item.NotableDamage.Count);
					foreach (NotableDamage item2 in item.NotableDamage)
					{
						item2.Write(writer);
					}
				}
				value.Clear();
				foreach (DamageReceiver damageReceiver2 in _damageReceivers)
				{
					if (damageReceiver2.Damage != 0)
					{
						value.Add(damageReceiver2);
					}
				}
				writer.WriteUInt8Unpacked((byte)value.Count);
				foreach (DamageReceiver item3 in value)
				{
					writer.WriteUInt8Unpacked(item3.Id);
					writer.WriteInt16(item3.Damage);
				}
			}
		}

		protected virtual void Awake()
		{
			_damageReceivers = new List<DamageReceiver>();
			_damageReceiversById = new DamageReceiver[256];
		}

		protected virtual void OnDestroy()
		{
			TimeManager timeManager = base.NetworkFlightObject?.TimeManager;
			if (timeManager != null)
			{
				timeManager.OnPostTick -= OnPostTick;
			}
		}

		private void GetUnsyncedDamage(List<DamageReceiver> unsyncedDamage)
		{
			foreach (DamageReceiver damageReceiver in _damageReceivers)
			{
				if (damageReceiver.UnsyncedDamage != 0)
				{
					unsyncedDamage.Add(damageReceiver);
				}
			}
		}

		private void GetUnsyncedNotableDamage(List<DamageReceiver> unsyncedDamage)
		{
			foreach (DamageReceiver damageReceiver in _damageReceivers)
			{
				if (damageReceiver.UnsyncedNotableDamage.Count > 0)
				{
					unsyncedDamage.Add(damageReceiver);
				}
			}
		}

		private void OnLocalDamageReceived(object sender, LocalDamageReceivedEventArgs e)
		{
			byte id = e.Receiver.Id;
			DamageReceiver damageReceiver = _damageReceiversById[id];
			if (damageReceiver == null)
			{
				Debug.LogError($"Local damage from damage receiver with id '{id}' could not be registered because the receiver does not appear to be registered.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + base.NetworkFlightObject.GetType().FullName + ")" + System.Environment.NewLine + "Component: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Damage Receiver: " + (e.Receiver?.name ?? "null") + " (" + (e.Receiver?.GetType().FullName ?? "null") + ")");
			}
			else
			{
				damageReceiver.UnsyncedDamage = (damageReceiver.UnsyncedDamage + e.DamageReceived).ClampToInt16();
			}
		}

		private void OnLocalNotableDamageReceived(object sender, NotableDamageReceivedEventArgs e)
		{
			byte id = e.Receiver.Id;
			DamageReceiver damageReceiver = _damageReceiversById[id];
			if (damageReceiver == null)
			{
				Debug.LogError($"Local notable damage from damage receiver with id '{id}' could not be registered because the receiver does not appear to be registered.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + base.NetworkFlightObject.GetType().FullName + ")" + System.Environment.NewLine + "Component: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Damage Receiver: " + (e.Receiver?.name ?? "null") + " (" + (e.Receiver?.GetType().FullName ?? "null") + ")");
			}
			else
			{
				damageReceiver.UnsyncedNotableDamage.Add(e.Damage);
			}
		}

		private void OnPostTick()
		{
			ProcessUnsyncedNotableDamage();
			ProcessUnsyncedDamage();
		}

		private void ProcessDamageSyncRpc(PooledReader data, bool isServerRpc)
		{
			int num = data.ReadUInt8Unpacked();
			for (int i = 0; i < num; i++)
			{
				byte b = data.ReadUInt8Unpacked();
				short num2 = data.ReadInt16();
				DamageReceiver damageReceiver = _damageReceiversById[b];
				if (damageReceiver == null)
				{
					damageReceiver = new DamageReceiver(b, null);
					_damageReceiversById[b] = damageReceiver;
					_damageReceivers.Add(damageReceiver);
				}
				if (isServerRpc)
				{
					damageReceiver.UnsyncedDamage = (damageReceiver.UnsyncedDamage + num2).ClampToInt16();
					continue;
				}
				short damage = damageReceiver.Damage;
				short syncedDamage = (num2 - damage).ClampToInt16();
				damageReceiver.Damage = num2;
				damageReceiver.Script?.OnDamageSynced(syncedDamage, num2);
			}
		}

		private void ProcessNotableDamageSyncRpc(PooledReader data, bool isServerRpc)
		{
			int num = data.ReadUInt8Unpacked();
			for (int i = 0; i < num; i++)
			{
				byte b = data.ReadUInt8Unpacked();
				DamageReceiver damageReceiver = _damageReceiversById[b];
				if (damageReceiver == null)
				{
					damageReceiver = new DamageReceiver(b, null);
					_damageReceiversById[b] = damageReceiver;
					_damageReceivers.Add(damageReceiver);
				}
				short num2 = data.ReadInt16();
				if (isServerRpc)
				{
					for (int j = 0; j < num2; j++)
					{
						NotableDamage item = NotableDamage.Read(data);
						damageReceiver.UnsyncedNotableDamage.Add(item);
					}
					continue;
				}
				for (int k = 0; k < num2; k++)
				{
					NotableDamage notableDamage = NotableDamage.Read(data);
					damageReceiver.NotableDamage.Add(notableDamage);
					damageReceiver.Script?.OnNotableDamageSynced(notableDamage);
				}
			}
		}

		private void ProcessRpc(PooledReader data, bool isServerRpc)
		{
			RpcType rpcType = (RpcType)data.ReadUInt8Unpacked();
			switch (rpcType)
			{
			case RpcType.SyncDamage:
				ProcessDamageSyncRpc(data, isServerRpc);
				break;
			case RpcType.SyncNotableDamage:
				ProcessNotableDamageSyncRpc(data, isServerRpc);
				break;
			default:
				throw new NotSupportedException($"Unknown RPC type: '{rpcType}'");
			}
		}

		private void ProcessUnsyncedDamage()
		{
			List<DamageReceiver> value;
			using (CollectionPool<List<DamageReceiver>, DamageReceiver>.Get(out value))
			{
				GetUnsyncedDamage(value);
				if (value.Count <= 0)
				{
					return;
				}
				using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = base.NetworkFlightObject.GetPooledWriter(value.Count * 3 + 2);
				PooledWriter writer = pooledWriterDisposableWrapper.Writer;
				bool isServerStarted = base.NetworkFlightObject.IsServerStarted;
				writer.WriteUInt8Unpacked(0);
				writer.WriteUInt8Unpacked((byte)value.Count);
				foreach (DamageReceiver item in value)
				{
					short num = item.UnsyncedDamage;
					if (isServerStarted)
					{
						num = (num + item.Damage).ClampToInt16(0);
					}
					item.UnsyncedDamage = 0;
					writer.WriteUInt8Unpacked(item.Id);
					writer.WriteInt16(num);
				}
				ArraySegment<byte> arraySegment = writer.GetArraySegment();
				if (isServerStarted)
				{
					SendObserversRpc(arraySegment, excludeOwner: false, runLocally: true);
				}
				else
				{
					SendServerRpc(arraySegment);
				}
			}
		}

		private void ProcessUnsyncedNotableDamage()
		{
			List<DamageReceiver> value;
			using (CollectionPool<List<DamageReceiver>, DamageReceiver>.Get(out value))
			{
				GetUnsyncedNotableDamage(value);
				if (value.Count <= 0)
				{
					return;
				}
				using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = base.NetworkFlightObject.GetPooledWriter();
				PooledWriter writer = pooledWriterDisposableWrapper.Writer;
				bool isServerStarted = base.NetworkFlightObject.IsServerStarted;
				writer.WriteUInt8Unpacked(1);
				writer.WriteUInt8Unpacked((byte)value.Count);
				foreach (DamageReceiver item in value)
				{
					writer.WriteUInt8Unpacked(item.Id);
					writer.WriteUInt16((ushort)item.UnsyncedNotableDamage.Count);
					foreach (NotableDamage item2 in item.UnsyncedNotableDamage)
					{
						item2.Write(writer);
					}
					item.UnsyncedNotableDamage.Clear();
				}
				ArraySegment<byte> arraySegment = writer.GetArraySegment();
				if (isServerStarted)
				{
					SendObserversRpc(arraySegment, excludeOwner: false, runLocally: true);
				}
				else
				{
					SendServerRpc(arraySegment);
				}
			}
		}
	}
}
