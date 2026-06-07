using System.Collections.Generic;
using UnityEngine;

public interface IDialogueTreeNodeViewable
{
	Object SerializeTarget { get; }

	IReadOnlyList<DialogueNodeProperties> Branches { get; }

	string Name { get; }

	string Guid { get; }

	Vector2 Position { get; }

	IReadOnlyList<IDialogueCondition> Conditions { get; }

	DialogueProgressConditions ProgressDialogueConditions { get; }
}
