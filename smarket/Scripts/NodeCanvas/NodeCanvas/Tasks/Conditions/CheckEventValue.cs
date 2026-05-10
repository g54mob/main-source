using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Utility")]
	[Description("Check if an event is received and it's value is equal to specified value, then return true for one frame")]
	public class CheckEventValue<T> : ConditionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		[Name("Compare Value To", 0)]
		public BBParameter<T> value;

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

		private void OnCustomEvent(string eventName, IEventData msg)
		{
		}
	}
}
