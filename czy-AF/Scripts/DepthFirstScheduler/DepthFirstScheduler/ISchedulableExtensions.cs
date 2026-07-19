namespace DepthFirstScheduler
{
	public static class ISchedulableExtensions
	{
		public static ISchedulable GetRoot(this ISchedulable self)
		{
			ISchedulable schedulable = self;
			while (schedulable.Parent != null)
			{
				schedulable = schedulable.Parent;
			}
			return schedulable;
		}
	}
}
