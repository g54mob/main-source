using System;
using System.IO;

public abstract class BaseGameJournalSave : IGameJournalSave, IBinarySerializableSaveData, IStorable
{
	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("BaseUserProfile");

	public Player Player { get; set; }

	public bool IsAuthoritative { get; set; }

	public bool CanDelete => Player != null;

	public DateTime UtcTimestamp { get; set; } = DateTime.MinValue;

	public string DeviceId { get; set; }

	public virtual void InitializeWithBytes(byte[] saveDataAsBytes)
	{
	}

	public abstract byte[] GetBytesForSerializing();

	public virtual void OnSerializeBeforeData(BinaryWriter binaryWriter)
	{
	}

	public virtual IBinarySerializableSaveData.HeaderValidationResult ValidateHeader(BinaryReader binaryReader)
	{
		return IBinarySerializableSaveData.HeaderValidationResult.Success;
	}
}
