using FMOD;
using FMODUnity;
using Mirror;
using UnityEngine;

namespace Aggro.Core.Networking
{
	public static class NetworkSerialization
	{
		private enum GameObjectType : byte
		{
			Null = 0,
			Prefab = 1,
			Instanced = 2
		}

		public static void WriteEntity(this NetworkWriter writer, Entity entity)
		{
			if (entity.Exists(allowIsDying: true) && entity.TryGetObject<NetworkIdentity>(out var obj))
			{
				writer.WriteNetworkIdentity(obj);
			}
			else
			{
				writer.WriteNetworkIdentity(null);
			}
		}

		public static Entity ReadEntity(this NetworkReader reader)
		{
			return reader.ReadNetworkIdentity()?.GetEntity() ?? Entity.invalid;
		}

		public static void WriteNetworkScrob(this NetworkWriter writer, NetScrobId scrob)
		{
			writer.WriteUInt(scrob.id);
		}

		public static NetScrobId ReadNetworkScrob(this NetworkReader reader)
		{
			return new NetScrobId(reader.ReadUInt());
		}

		public static void WriteNetworkBehaviour(this NetworkWriter writer, NetBehaviourId behaviour)
		{
			writer.WriteNetworkIdentity(behaviour.networkIdentity);
			writer.WriteUInt(behaviour.behaviourId);
		}

		public static NetBehaviourId ReadNetworkBehaviour(this NetworkReader reader)
		{
			NetworkIdentity networkIdentity = reader.ReadNetworkIdentity();
			uint behaviourId = reader.ReadUInt();
			return new NetBehaviourId(networkIdentity, behaviourId);
		}

		public static void WriteGameObject(this NetworkWriter writer, GameObject value)
		{
			NetworkPrefab component;
			NetworkIdentity component2;
			if (value == null)
			{
				writer.WriteByte(0);
			}
			else if (value.TryGetComponent<NetworkPrefab>(out component))
			{
				writer.WriteByte(1);
				writer.WriteUInt(component.networkId);
			}
			else if (value.TryGetComponent<NetworkIdentity>(out component2) && component2.netId != 0)
			{
				writer.WriteByte(2);
				writer.WriteUInt(component2.netId);
			}
			else
			{
				UnityEngine.Debug.LogWarning($"Attempted to sync a GameObject ({value}) which isn't networked. GameObject without a NetworkIdentity component can't be synced.");
				writer.WriteByte(0);
			}
		}

		public static GameObject ReadGameObject(this NetworkReader reader)
		{
			switch ((GameObjectType)reader.ReadByte())
			{
			case GameObjectType.Null:
				return null;
			case GameObjectType.Prefab:
			{
				if (NetworkObjectDatabase.TryGetNetworkPrefab(reader.ReadUInt(), out var prefab))
				{
					return prefab;
				}
				return null;
			}
			case GameObjectType.Instanced:
			{
				NetworkIdentity spawnedInServerOrClient = Utils.GetSpawnedInServerOrClient(reader.ReadUInt());
				if (spawnedInServerOrClient != null)
				{
					return spawnedInServerOrClient.gameObject;
				}
				return null;
			}
			default:
				return null;
			}
		}

		public static void WriteVector3ValueTypeList4(this NetworkWriter writer, ValueTypeList4<Vector3> list)
		{
			writer.WriteByte((byte)list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				writer.WriteVector3(list[i]);
			}
		}

		public static ValueTypeList4<Vector3> ReadVector3ValueTypeList4(this NetworkReader reader)
		{
			int num = reader.ReadByte();
			ValueTypeList4<Vector3> result = default(ValueTypeList4<Vector3>);
			for (int i = 0; i < num; i++)
			{
				result.Add(reader.ReadVector3());
			}
			return result;
		}

		public static void WriteQuaternionValueTypeList4(this NetworkWriter writer, ValueTypeList4<Quaternion> list)
		{
			writer.WriteByte((byte)list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				writer.WriteQuaternion(list[i]);
			}
		}

		public static ValueTypeList4<Quaternion> ReadQuaternionValueTypeList4(this NetworkReader reader)
		{
			int num = reader.ReadByte();
			ValueTypeList4<Quaternion> result = default(ValueTypeList4<Quaternion>);
			for (int i = 0; i < num; i++)
			{
				result.Add(reader.ReadQuaternion());
			}
			return result;
		}

		public static void WriteEntityValueTypeList4(this NetworkWriter writer, ValueTypeList4<Entity> list)
		{
			writer.WriteByte((byte)list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				writer.WriteEntity(list[i]);
			}
		}

		public static ValueTypeList4<Entity> ReadValueTypeList4(this NetworkReader reader)
		{
			int num = reader.ReadByte();
			ValueTypeList4<Entity> result = default(ValueTypeList4<Entity>);
			for (int i = 0; i < num; i++)
			{
				result.Add(reader.ReadEntity());
			}
			return result;
		}

		public static void WriteEventReference(this NetworkWriter writer, EventReference ev)
		{
			writer.WriteBlittable(ev.Guid);
		}

		public static EventReference ReadEventReference(this NetworkReader reader)
		{
			return new EventReference
			{
				Guid = reader.ReadBlittable<GUID>()
			};
		}
	}
}
