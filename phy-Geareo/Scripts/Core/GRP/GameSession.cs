using Rhizomatic;

namespace GRP
{
	public class GameSession
	{
		public EntityManager<Item, ItemConfig> items;

		public GameSessionConfig config;

		public Context context;

		private bool dirty;

		public FilePrefs filePrefs;

		public GameSession(GameSessionConfig config, Context context)
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public MissionItem RequestMissionItem(string key)
		{
			return null;
		}

		public T RequestItem<T, G>(string key) where T : Item where G : ItemConfig
		{
			return null;
		}

		public void Load()
		{
		}

		public void Save()
		{
		}

		public GameSessionData Serialize()
		{
			return null;
		}

		public void Deserialize(GameSessionData data)
		{
		}

		public static GameSession Of(Context context)
		{
			return null;
		}
	}
}
