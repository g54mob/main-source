using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Reflected")]
	[Description("SendMessage to the agent, optionaly with an argument")]
	public class SendMessage : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> methodName;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
	[Category("✫ Reflected")]
	[Description("SendMessage to the agent, optionaly with an argument")]
	public class SendMessage<T> : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> methodName;

		public BBParameter<T> argument;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
