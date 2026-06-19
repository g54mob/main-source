namespace Aggro.Core
{
	public abstract class AggroSettingBase : IEntityTyped
	{
		public string id { get; private set; }

		public int idHash { get; private set; }

		public string category { get; private set; }

		public string label { get; private set; }

		public uint globalVersion { get; private set; }

		public uint typeHash { get; private set; }

		public string preferencesKey { get; private set; }

		public bool userEditable { get; protected set; } = true;

		public uint saveVersion { get; private set; } = 1u;

		public abstract void SetToDefault();

		internal void InternalInitialize(string id, int idHash, string category, string label, uint version)
		{
			globalVersion = version;
			this.id = id;
			this.idHash = idHash;
			this.category = category;
			this.label = label;
			typeHash = (uint)Hash.Calculate(GetType());
			preferencesKey = $"AGGRO_SETTING_{version}_{0}_{typeHash}_{id}";
			saveVersion = 1u;
			Initialize(preferencesKey);
		}

		public void Save()
		{
			AggroSettings.IncrementSaveVersion();
			saveVersion++;
			SaveToPrefs(preferencesKey);
		}

		public void Load()
		{
			LoadFromPrefs(preferencesKey);
		}

		protected virtual void Initialize(string preferencesKey)
		{
		}

		protected abstract void SaveToPrefs(string preferencesKey);

		protected abstract void LoadFromPrefs(string preferencesKey);
	}
}
