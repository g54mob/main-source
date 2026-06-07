using System.Collections.Generic;
using System.IO;
using SINetworking;
using UnityEngine;

public abstract class ModMeta
{
	public List<ModBehaviour> ModBehaviours = new List<ModBehaviour>();

	public abstract string Name { get; }

	public abstract void ConstructOptionsScreen(RectTransform parent, bool inGame);

	public virtual void Initialize(ModController.DLLMod parentMod)
	{
	}

	public virtual WriteDictionary Serialize(GameReader.LoadMode mode)
	{
		WriteDictionary writeDictionary = new WriteDictionary();
		foreach (ModBehaviour modBehaviour in ModBehaviours)
		{
			modBehaviour.Serialize(writeDictionary, mode);
		}
		if (writeDictionary.Count <= 0)
		{
			return null;
		}
		return writeDictionary;
	}

	public virtual void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
	{
		foreach (ModBehaviour modBehaviour in ModBehaviours)
		{
			modBehaviour.Deserialize(data, mode);
		}
	}

	public virtual void ReceiveNetworkMessage(NetworkPlayer player, MemoryStream stream)
	{
	}
}
