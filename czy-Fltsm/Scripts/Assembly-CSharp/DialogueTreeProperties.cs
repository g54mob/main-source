using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Flotsam/Narrative/Dialogue Tree Properties", fileName = "New Dialogue", order = 0)]
public class DialogueTreeProperties : PersistentProperties, IDialogueTreeNodeViewable
{
	[NamedArrayElement("_name", "_type")]
	[SerializeField]
	private List<DialogueBranch> _entryBranches = new List<DialogueBranch>();

	[SerializeField]
	private DialogueContext.ActorType _speaker = DialogueContext.ActorType.FirstMate;

	[SerializeField]
	[HideInInspector]
	private List<DialogueNodeProperties> _nodes = new List<DialogueNodeProperties>();

	public IReadOnlyList<DialogueNodeProperties> Nodes => _nodes;

	Object IDialogueTreeNodeViewable.SerializeTarget => this;

	public IReadOnlyList<DialogueBranch> DialogueBranches => _entryBranches;

	public IReadOnlyList<DialogueNodeProperties> Branches
	{
		get
		{
			List<DialogueNodeProperties> list = new List<DialogueNodeProperties>(_entryBranches.Count);
			foreach (DialogueBranch entryBranch in _entryBranches)
			{
				if (entryBranch.IsDefaultBranch)
				{
					list.Clear();
					list.Add(entryBranch.EntryNode);
					break;
				}
				if (entryBranch.TriggerConditions.IsNullOrEmpty() && entryBranch.EntryNode != null)
				{
					list.Add(entryBranch.EntryNode);
				}
			}
			return list;
		}
	}

	public IReadOnlyList<DialogueBranch> EntryBranches => _entryBranches;

	public DialogueContext.ActorType Speaker => _speaker;

	string IDialogueTreeNodeViewable.Name => base.name;

	string IDialogueTreeNodeViewable.Guid => GetInstanceID().ToString();

	Vector2 IDialogueTreeNodeViewable.Position => Vector2.zero;

	public IReadOnlyList<IDialogueCondition> Conditions => null;

	public DialogueProgressConditions ProgressDialogueConditions => null;

	public override Types Type => Types.DialogueProperties;

	public void StartDialogue(DialogueNodeProperties specificBranchEntryNode = null, float delay = 0f, bool isRepeat = false, bool isRadioMessage = false)
	{
		DialogueGameEvent.DispatchDialogueStartRequest(this, specificBranchEntryNode, delay, isRepeat, isRadioMessage);
	}

	public bool HasDialogueBranchType(DialogueBranchType type)
	{
		return _entryBranches.Find((DialogueBranch branch) => branch.Type == type && branch.EntryNode != null) != null;
	}

	public DialogueNodeProperties ReturnBranchEntryNode(DialogueBranchType branchType)
	{
		if (branchType == DialogueBranchType.None || branchType == DialogueBranchType.Reference)
		{
			return null;
		}
		foreach (DialogueBranch entryBranch in _entryBranches)
		{
			if (entryBranch.Type == branchType)
			{
				return entryBranch.EntryNode;
			}
		}
		return null;
	}

	public DialogueBranch ReturnBranch(ushort id)
	{
		if (_entryBranches.IsNullOrEmpty() || id <= 0)
		{
			return null;
		}
		foreach (DialogueBranch entryBranch in _entryBranches)
		{
			if (entryBranch.UniqueID == id)
			{
				return entryBranch;
			}
		}
		return null;
	}

	public DialogueBranch ReturnBranch(DialogueNodeProperties entryNode)
	{
		if (_entryBranches.IsNullOrEmpty())
		{
			return null;
		}
		foreach (DialogueBranch entryBranch in _entryBranches)
		{
			if (entryBranch.EntryNode == entryNode)
			{
				return entryBranch;
			}
		}
		return null;
	}
}
