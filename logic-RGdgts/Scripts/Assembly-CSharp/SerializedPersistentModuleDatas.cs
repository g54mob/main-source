using System.Collections.Generic;

public class SerializedPersistentModuleDatas
{
	public Dictionary<uint, SerializedModuleData.PersistentState> moduleDatas;

	public SerializedPersistentModuleDatas()
	{
	}

	public SerializedPersistentModuleDatas(Gadget gadget)
	{
	}

	public SerializedPersistentModuleDatas(SerializedGadget.PersistentState gadget)
	{
	}

	public void Fill(SerializedGadget.PersistentState gadget)
	{
	}
}
