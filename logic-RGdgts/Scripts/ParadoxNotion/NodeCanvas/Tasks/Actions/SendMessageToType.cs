using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SendMessageToType<T> : ActionTask where T : Component
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
