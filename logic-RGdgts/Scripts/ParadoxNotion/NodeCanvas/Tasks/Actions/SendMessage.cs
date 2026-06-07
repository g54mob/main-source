using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SendMessage : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> methodName;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
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
