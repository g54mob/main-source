using System;
using UnityEngine;

public class SerializedGadget
{
	[Serializable]
	public class PersistentState
	{
		public SerializedMotherboard.PersistentState[] motherboards;

		public PersistentState()
		{
		}

		public PersistentState(Gadget gadget)
		{
		}
	}

	public SerializedMotherboard[] motherboards;

	public GadgetCoverMaterial coverMaterial;

	[NonSerialized]
	public SerializedAssets assets;

	public SerializedGadget()
	{
	}

	public SerializedGadget(MotherboardShape motherboardShape)
	{
	}

	public SerializedGadget(Gadget gadget)
	{
	}

	public Gadget Instantiate(SerializedGadgetMetaData metadata, SerializedGadgetMetaData.PersistentState persistentMetadataState = null, PersistentState persistentState = null)
	{
		return null;
	}

	public Bounds GetBounds()
	{
		return default(Bounds);
	}
}
