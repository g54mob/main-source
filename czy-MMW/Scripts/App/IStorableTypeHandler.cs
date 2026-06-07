public interface IStorableTypeHandler
{
	bool IsFilenameRecognized(string filename, out string playerId, out string deviceId);

	string GetFilename(IStorable storable);

	string GetFilename(string playerId, string deviceId);

	IStorable Load(byte[] data);

	byte[] Store(IStorable storable);

	bool ProcessLoadedStorable(IStorable storable, string playerId, string deviceId);

	void ProcessDeletedStorable(string playerId, string deviceId);
}
