using Rhizomatic;

namespace GRP
{
	public class ProgressContainer
	{
		public ProgressTask task;

		public ProgressPage page;

		public Context context;

		public ProgressContainer(Context context)
		{
		}

		public ProgressContainer OpenPage()
		{
			return null;
		}

		public T SetTask<T>(T task) where T : ProgressTask
		{
			return null;
		}

		public void Finish()
		{
		}
	}
}
