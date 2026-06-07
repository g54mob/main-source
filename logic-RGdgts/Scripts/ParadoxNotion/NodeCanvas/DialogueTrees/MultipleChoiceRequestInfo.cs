using System;
using System.Collections.Generic;

namespace NodeCanvas.DialogueTrees
{
	public class MultipleChoiceRequestInfo
	{
		public IDialogueActor actor;

		public Dictionary<IStatement, int> options;

		public float availableTime;

		public bool showLastStatement;

		public Action<int> SelectOption;

		public MultipleChoiceRequestInfo(IDialogueActor actor, Dictionary<IStatement, int> options, float availableTime, bool showLastStatement, Action<int> callback)
		{
		}

		public MultipleChoiceRequestInfo(IDialogueActor actor, Dictionary<IStatement, int> options, float availableTime, Action<int> callback)
		{
		}
	}
}
