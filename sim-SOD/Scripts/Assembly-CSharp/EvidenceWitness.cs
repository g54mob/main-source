using System;
using System.Collections.Generic;

public class EvidenceWitness : Evidence
{
	[Serializable]
	public class DialogOption
	{
		public DialogPreset preset;

		public SideJob jobRef;

		public NewRoom roomRef;

		public Human.InteractionDialogInstance interactionInstance;
	}

	public Dictionary<DataKey, List<DialogOption>> dialogOptions;

	public EvidenceWitness(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public DialogOption AddDialogOption(DataKey key, DialogPreset newPreset, SideJob newSideJob = null, NewRoom roomRef = null, Human.InteractionDialogInstance interactionInstance = null, bool allowPresetDuplicates = true, bool allowPresetDuplicatesByMessage = true)
	{
		return null;
	}

	public void RemoveDialogOption(DataKey key, DialogPreset newPreset, SideJob newSideJob = null, NewRoom roomRef = null)
	{
	}

	public void RemoveDialogOption(DataKey key, DialogOption newOption)
	{
	}

	public List<DialogOption> GetDialogOptions(DataKey key)
	{
		return null;
	}

	public List<DialogOption> GetDialogOptions(List<DataKey> keys)
	{
		return null;
	}

	public override List<DataKey> GetTiedKeys(List<DataKey> inputKeys)
	{
		return null;
	}
}
