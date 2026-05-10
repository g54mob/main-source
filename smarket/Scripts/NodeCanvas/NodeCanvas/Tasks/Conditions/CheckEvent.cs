using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Utility")]
	[Description("Check if an event is received and return true for one frame")]
	public class CheckEvent : ConditionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		protected override string info => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void OnCustomEvent(string eventName, IEventData data)
		{
		}
	}
	[Category("✫ Utility")]
	[Description("Check if an event is received and return true for one frame. Optionaly save the received event's value")]
	public class CheckEvent<T> : ConditionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		[BlackboardOnly]
		public BBParameter<T> saveEventValue;

		protected override string info => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void OnCustomEvent(string eventName, IEventData data)
		{
		}
	}
}
