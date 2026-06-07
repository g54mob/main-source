using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckEventValue<T> : ConditionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

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
