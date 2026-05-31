using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Utility")]
	[Description("Will return true after a specific amount of time has passed and false while still counting down")]
	public class Timeout : ConditionTask
	{
		public BBParameter<float> timeout;

		private float startTime;

		private float elapsedTime => 0f;

		protected override string info => null;

		protected override void OnEnable()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
