namespace Alekrus.UnivarsalPlatform.SaveLoad
{
	public interface IUserSaveLoad : IInitializable, IUpdatable, ISubInterface<ISaveLoad>
	{
		int SaveDataMaxSize { get; }

		SaveState State { get; }

		ILocalUserId TargetUserId { get; }

		GameSlotDetails CurrentSlotDetails { get; }

		byte[] CurrentData { get; }

		event GameSavedEventHandler GameSaved;

		event GameLoadedEventHandler GameLoaded;

		event GameDeletedEventHandler GameDeleted;

		event CanceledEventHandler Canceled;

		bool CanSave(byte[] parData, GameSlotDetails parDetails);

		bool Save(byte[] parData, GameSlotDetails parDetails);

		bool CanLoad();

		bool Load();

		bool CanDelete();

		bool Delete();

		bool GetDetails(out GameSlotDetails outDetails);

		bool Exists();
	}
}
