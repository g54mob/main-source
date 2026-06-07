public interface IGameJournalSave : IBinarySerializableSaveData, IStorable
{
	Player Player { get; set; }

	string DeviceId { get; set; }

	bool CanDelete { get; }
}
