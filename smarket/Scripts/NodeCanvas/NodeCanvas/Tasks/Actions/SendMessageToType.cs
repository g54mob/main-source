using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Reflected")]
	[Description("Send a Unity message to all game objects with a component of the specified type.\nNotice: This is slow and should not be called per-fame.")]
	public class SendMessageToType<T> : ActionTask
	{
		[RequiredField]
		public BBParameter<string> message;

		[BlackboardOnly]
		public BBParameter<object> argument;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
