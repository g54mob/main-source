using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{
	public class SayRandom : ActionTask<IDialogueActor>
	{
		public List<Statement> statements;

		protected override void OnExecute()
		{
		}
	}
}
