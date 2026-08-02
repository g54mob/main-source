using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror.Examples.BenchmarkIdle
{
	public class Npc : NetworkBehaviour
	{
		public Renderer rend;

		[SyncVar]
		private ulong value;

		[Tooltip("Probability that this object just sleeps the whole time without ever getting dirty. (Npcs, Item drops, etc.)")]
		[Range(0f, 1f)]
		public float sleepingProbability = 0.8f;

		private bool sleeping;

		[Header("Colors")]
		public Color activeColor = Color.white;

		public Color sleepingColor = Color.red;

		public ulong Networkvalue
		{
			get
			{
				return value;
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter(value, ref this.value, 1uL, null);
			}
		}

		public override void OnStartServer()
		{
			sleeping = Random.value < sleepingProbability;
			rend.material.color = (sleeping ? sleepingColor : activeColor);
		}

		[ServerCallback]
		private void Update()
		{
			if (NetworkServer.active && !sleeping)
			{
				Networkvalue = value + 1;
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
				writer.WriteULong(value);
				return;
			}
			writer.WriteULong(base.syncVarDirtyBits);
			if ((base.syncVarDirtyBits & 1L) != 0L)
			{
				writer.WriteULong(value);
			}
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
			base.DeserializeSyncVars(reader, initialState);
			if (initialState)
			{
				GeneratedSyncVarDeserialize(ref value, null, reader.ReadULong());
				return;
			}
			long num = (long)reader.ReadULong();
			if ((num & 1L) != 0L)
			{
				GeneratedSyncVarDeserialize(ref value, null, reader.ReadULong());
			}
		}
	}
}
