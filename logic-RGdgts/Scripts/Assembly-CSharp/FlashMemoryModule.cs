public class FlashMemoryModule : Module
{
	public class SerializedData : SerializedModuleData
	{
		public LuaTable dataTable;
	}

	public class SerializedDataPersistentState : SerializedModuleData.PersistentState
	{
		public LuaTable dataTable;
	}

	public int maxDataSize;

	private ModuleProperty sizeProperty;

	private ModuleProperty usageProperty;

	private LuaTable dataTable;

	protected override void OnSetupFinished()
	{
	}

	public override void ApplyPermanentStorage(Storage storage, Storage permanentOnlyStorage = null)
	{
	}

	private void SetupSize()
	{
	}

	private void UpdateUsagePropeprty()
	{
	}

	public override SerializedModuleData ComposeSerializedData()
	{
		return null;
	}

	public override SerializedModuleData.PersistentState ComposePersistentSerializedData()
	{
		return null;
	}

	public override void ApplySerializedData(SerializedModuleData serializedData, SerializedModuleData.PersistentState persistentSerializedData = null)
	{
	}

	public bool Script_Save(LuaTable table)
	{
		return false;
	}

	public LuaTable Script_Load()
	{
		return null;
	}
}
