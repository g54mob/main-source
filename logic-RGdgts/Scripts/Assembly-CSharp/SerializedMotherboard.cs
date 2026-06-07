using System;
using UnityEngine;

public class SerializedMotherboard
{
	[Serializable]
	public class PersistentState
	{
		public Vector2 position;

		public SerializedModule.PersistentState[] modules;

		public PersistentState()
		{
		}

		public PersistentState(Motherboard motherboard)
		{
		}
	}

	public MotherboardShape shape;

	public Vector2 position;

	public byte[] colorData;

	public SerializedModule[] modules;

	public SerializedSticker[] stickers;

	public SerializedMotherboard()
	{
	}

	public SerializedMotherboard(MotherboardShape shape)
	{
	}

	public SerializedMotherboard(Motherboard motherboard)
	{
	}

	public Motherboard Instantiate(Gadget gadget, PersistentState persistentState = null)
	{
		return null;
	}
}
