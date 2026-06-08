using System.IO;

namespace MLAPI.NetworkedVar
{
	public interface INetworkedVar
	{
		string GetChannel();

		void ResetDirty();

		bool IsDirty();

		bool CanClientWrite(ulong clientId);

		bool CanClientRead(ulong clientId);

		void WriteDelta(Stream stream);

		void WriteField(Stream stream);

		void ReadField(Stream stream);

		void ReadDelta(Stream stream, bool keepDirtyDelta);

		void SetNetworkedBehaviour(NetworkedBehaviour behaviour);
	}
}
