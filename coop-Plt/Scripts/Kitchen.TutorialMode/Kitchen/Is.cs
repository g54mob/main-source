namespace Kitchen
{
	public static class Is
	{
		public static TutorialCondition Always => new Always();

		public static TutorialCondition Mess => new HasMess();

		public static TutorialCondition PressButton => new PressButton();

		public static TutorialCondition OnFire => new HasFire();

		public static TutorialCondition HasAny(int item)
		{
			return new HasAnyCondition(item);
		}

		public static TutorialCondition Process(int item)
		{
			return new IsUndergoingProcess(item);
		}

		public static TutorialCondition InStage<T>()
		{
			return new GroupStage(typeof(T));
		}

		public static TutorialCondition InState<T>()
		{
			return new TableState(typeof(T));
		}
	}
}
