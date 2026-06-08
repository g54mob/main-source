using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Output")]
	public class Output : LayoutModule
	{
		public override void ActOn(LayoutBlueprint blueprint)
		{
		}

		public LayoutBlueprint GetResult()
		{
			UpdateAll();
			return Result;
		}
	}
}
