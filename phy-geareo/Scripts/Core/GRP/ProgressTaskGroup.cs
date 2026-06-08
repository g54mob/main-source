using System.Collections.Generic;

namespace GRP
{
	public class ProgressTaskGroup : ProgressTask
	{
		public string info;

		public bool forceActive;

		public List<ProgressTask> tasks;

		public ProgressTaskGroup()
		{
		}

		public ProgressTaskGroup(string info)
		{
		}

		public ProgressTaskNode AddTask(string info)
		{
			return null;
		}

		public ProgressTaskGroup AddTaskGroup(string info = "")
		{
			return null;
		}

		public ProgressTaskGroup AddTaskGroupActive(string info = "")
		{
			return null;
		}

		public T AddTask<T>(T task) where T : ProgressTask
		{
			return null;
		}

		public override string GetInfo()
		{
			return null;
		}

		public override float GetProgress()
		{
			return 0f;
		}

		public override bool IsActive()
		{
			return false;
		}
	}
}
