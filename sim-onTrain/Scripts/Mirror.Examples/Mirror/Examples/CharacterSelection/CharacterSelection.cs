using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror.Examples.CharacterSelection
{
	public class CharacterSelection : NetworkBehaviour
	{
		public Transform floatingInfo;

		[SyncVar]
		public int characterNumber;

		public TextMesh textMeshName;

		[SyncVar(hook = "HookSetName")]
		public string playerName = "";

		[SyncVar(hook = "HookSetColor")]
		public Color characterColour;

		private Material cachedMaterial;

		public int NetworkcharacterNumber
		{
			get
			{
				return characterNumber;
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter(value, ref characterNumber, 1uL, null);
			}
		}

		public string NetworkplayerName
		{
			get
			{
				return playerName;
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter(value, ref playerName, 2uL, HookSetName);
			}
		}

		public Color NetworkcharacterColour
		{
			get
			{
				return characterColour;
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter(value, ref characterColour, 4uL, HookSetColor);
			}
		}

		private void HookSetName(string _old, string _new)
		{
			AssignName();
		}

		private void HookSetColor(Color _old, Color _new)
		{
			AssignColours();
		}

		public void AssignColours()
		{
		}

		private void OnDestroy()
		{
		}

		public void AssignName()
		{
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
				writer.WriteInt(characterNumber);
				writer.WriteString(playerName);
				writer.WriteColor(characterColour);
				return;
			}
			writer.WriteULong(base.syncVarDirtyBits);
			if ((base.syncVarDirtyBits & 1L) != 0L)
			{
				writer.WriteInt(characterNumber);
			}
			if ((base.syncVarDirtyBits & 2L) != 0L)
			{
				writer.WriteString(playerName);
			}
			if ((base.syncVarDirtyBits & 4L) != 0L)
			{
				writer.WriteColor(characterColour);
			}
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
			base.DeserializeSyncVars(reader, initialState);
			if (initialState)
			{
				GeneratedSyncVarDeserialize(ref characterNumber, null, reader.ReadInt());
				GeneratedSyncVarDeserialize(ref playerName, HookSetName, reader.ReadString());
				GeneratedSyncVarDeserialize(ref characterColour, HookSetColor, reader.ReadColor());
				return;
			}
			long num = (long)reader.ReadULong();
			if ((num & 1L) != 0L)
			{
				GeneratedSyncVarDeserialize(ref characterNumber, null, reader.ReadInt());
			}
			if ((num & 2L) != 0L)
			{
				GeneratedSyncVarDeserialize(ref playerName, HookSetName, reader.ReadString());
			}
			if ((num & 4L) != 0L)
			{
				GeneratedSyncVarDeserialize(ref characterColour, HookSetColor, reader.ReadColor());
			}
		}
	}
}
