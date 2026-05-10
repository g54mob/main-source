using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	[Description("Loads the blackboard variables previously saved in the provided PlayerPrefs key if at all. Returns false if no saves found or load was failed")]
	public class LoadBlackboard : ActionTask<Blackboard>
	{
		[RequiredField]
		public BBParameter<string> saveKey;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
