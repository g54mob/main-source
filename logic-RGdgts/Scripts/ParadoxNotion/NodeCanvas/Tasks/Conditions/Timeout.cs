using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
	public class Timeout : ConditionTask
	{
		public BBParameter<float> timeout;

		private float currentTime;

		protected override string info => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void MoveNext()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
