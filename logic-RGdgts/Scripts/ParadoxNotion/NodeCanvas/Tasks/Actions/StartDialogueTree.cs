using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class StartDialogueTree : ActionTask<IDialogueActor>
	{
		[RequiredField]
		public BBParameter<DialogueTreeController> dialogueTreeController;

		public bool waitActionFinish;

		public bool isPrefab;

		private DialogueTreeController instance;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
