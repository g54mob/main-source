using Unity.Netcode;

namespace Player.Customization
{
	public struct CharacterCustomization : INetworkSerializable
	{
		public bool isMale;

		public int hatID;

		public int glassesID;

		public bool hasWheat;

		public int skinColorID;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public static CharacterCustomization Default()
		{
			return default(CharacterCustomization);
		}
	}
}
