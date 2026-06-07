using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class SendEvent : ActionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		public BBParameter<float> delay;

		public bool sendGlobal;

		protected override string info => null;

		protected override void OnUpdate()
		{
		}
	}
	public class SendEvent<T> : ActionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		public BBParameter<T> eventValue;

		public BBParameter<float> delay;

		public bool sendGlobal;

		protected override string info => null;

		protected override void OnUpdate()
		{
		}
	}
}
