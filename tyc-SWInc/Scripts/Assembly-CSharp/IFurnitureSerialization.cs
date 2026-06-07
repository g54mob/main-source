public interface IFurnitureSerialization
{
	void Serialize(WriteDictionary dict);

	void Deserialize(WriteDictionary dict, bool loading);

	void PostDeserialize();
}
