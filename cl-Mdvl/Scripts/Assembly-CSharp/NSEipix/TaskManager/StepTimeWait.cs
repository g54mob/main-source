namespace NSEipix.TaskManager
{
	public class StepTimeWait : Step
	{
		private float length;

		private bool isUnscaled;

		public StepTimeWait(float length, bool isUnscaled = false)
		{
			this.length = length;
			this.isUnscaled = isUnscaled;
		}

		public override bool IsCompleted()
		{
			if (isUnscaled)
			{
				return base.UnScaledTimer >= length;
			}
			return base.Timer >= length;
		}
	}
}
