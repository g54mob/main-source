namespace AltSerialize
{
	public interface IAltSerializable
	{
		bool CanCache { get; }

		void Serialize(AltSerializer serializer, int depth);

		IAltSerializable Deserialize(AltSerializer deserializer);
	}
}
