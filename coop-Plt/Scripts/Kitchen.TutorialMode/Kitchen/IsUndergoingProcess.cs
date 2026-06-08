namespace Kitchen
{
	public class IsUndergoingProcess : TutorialCondition
	{
		public int Process;

		public IsUndergoingProcess(int process)
		{
			Process = process;
		}
	}
}
