using System;
using Unity.Netcode;

namespace Player.Customization.Sidekick
{
	public struct CharacterJsonPayload : INetworkSerializable, IEquatable<CharacterJsonPayload>
	{
		public string Json;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(CharacterJsonPayload other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(CharacterJsonPayload a, CharacterJsonPayload b)
		{
			return false;
		}

		public static bool operator !=(CharacterJsonPayload a, CharacterJsonPayload b)
		{
			return false;
		}
	}
}
