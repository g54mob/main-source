using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNodePlayerChoicesProperties : DialogueNodeProperties
{
	[Serializable]
	public class PlayerChoice
	{
		[SerializeField]
		private ConcatenatedLocalizedString _text;

		[SerializeField]
		[Tooltip("This should be used for development only! If no localization key is provided, this will be used instead.")]
		private string _fallbackText;

		[SerializeField]
		private DialogueNodeProperties _branch;

		public string Text => _text.GetOrDefault(_fallbackText);

		public DialogueNodeProperties Branch => _branch;

		public void SetBranch(DialogueNodeProperties branch)
		{
			_branch = branch;
		}
	}

	[SerializeField]
	private List<PlayerChoice> _choices = new List<PlayerChoice>();

	protected override string DefaultNodeName => "Player Choices";

	public IReadOnlyList<PlayerChoice> Choices => _choices;
}
