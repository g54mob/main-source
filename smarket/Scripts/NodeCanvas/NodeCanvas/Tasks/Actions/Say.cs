using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Dialogue")]
	[Description("You can use a variable inline with the text by using brackets likeso: [myVarName] or [Global/myVarName].\nThe bracket will be replaced with the variable value ToString")]
	[Icon("Dialogue", false, null)]
	public class Say : ActionTask<IDialogueActor>
	{
		public Statement statement;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
