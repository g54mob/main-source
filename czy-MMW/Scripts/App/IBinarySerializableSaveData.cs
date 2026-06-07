using System.IO;

public interface IBinarySerializableSaveData : IStorable
{
	public enum HeaderValidationResult
	{
		Success = 0,
		HashCodesMismatched = 1,
		InvalidHeader = 2
	}

	void InitializeWithBytes(byte[] saveDataAsBytes);

	byte[] GetBytesForSerializing();

	void OnSerializeBeforeData(BinaryWriter binaryWriter);

	HeaderValidationResult ValidateHeader(BinaryReader binaryReader);
}
