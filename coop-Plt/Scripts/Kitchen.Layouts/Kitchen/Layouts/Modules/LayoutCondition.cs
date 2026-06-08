namespace Kitchen.Layouts.Modules
{
	public abstract class LayoutCondition : LayoutModule
	{
		public bool ResultStatus;

		protected abstract bool Test(LayoutBlueprint blueprint);

		public override void ActOn(LayoutBlueprint blueprint)
		{
			ResultStatus = false;
			if (!Test(blueprint))
			{
				throw new LayoutFailureException("Condition failed");
			}
			ResultStatus = true;
		}
	}
}
