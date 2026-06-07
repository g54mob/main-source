using PajamaLlama.Persistence;

namespace PajamaLlama.Flotsam
{
	public class FlotsamSaveTask : SaveTaskBase
	{
		private static FlotsamSaveTask _instance;

		private SaveInfoMetaData _cachedMetaData;

		public WorldPersistentData WorldPersistentData { get; private set; }

		public SaveMetaInfo SaveMetaInfo { get; private set; }

		private FlotsamSaveTask(PlayerProfile player)
			: base(player)
		{
		}

		public static bool Queue(PlayerProfile player, SaveInfo saveInfo)
		{
			if (_instance == null)
			{
				_instance = new FlotsamSaveTask(player);
			}
			return _instance.Queue(saveInfo);
		}

		protected override void OnQueued()
		{
			_cachedMetaData.Copy(base.SaveInfo);
			if (GameManager.PersistenceManager.TryGetWorldPersistentData(out var worldPersistentData))
			{
				WorldPersistentData = worldPersistentData;
			}
		}

		protected override void OnCompleted()
		{
			if (!base.Success)
			{
				base.SaveInfo.SetMetaData(_cachedMetaData);
			}
		}

		protected override byte[] GetData()
		{
			lock (WorldPersistentData)
			{
				byte[] array = WorldPersistentData.Serialize();
				if (base.SaveInfo.ObjectType == SaveObjectType.SaveMetaInfo)
				{
					return PersistenceLifeCycle.Serialize(new SaveMetaInfo(base.SaveInfo, array));
				}
				return array;
			}
		}
	}
}
