using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{
	public class Say : ActionTask<IDialogueActor>
	{
		public Statement statement;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
