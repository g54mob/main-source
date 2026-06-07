using System;
using UnityEngine;

public class SerializedModule
{
	public class PersistentState
	{
		public ModuleId moduleId;

		public Module.Storage persistentOnlyPermanentStorage;

		[NonSerialized]
		public SerializedModuleData.PersistentState persistentModuleData;

		public PersistentState()
		{
		}

		public PersistentState(Module module)
		{
		}
	}

	public ModuleDescriptor descriptor;

	public PcbSide pcbSide;

	public Vector2 position;

	public int rotation;

	public int color1;

	public int color2;

	public Module.Storage permanentStorage;

	[NonSerialized]
	public SerializedModuleData moduleData;

	public SerializedModule()
	{
	}

	public SerializedModule(Module module)
	{
	}

	public Module Instantiate(Motherboard motherboard, PersistentState persistentState = null)
	{
		return null;
	}
}
