namespace MLAPI.Transports.Tasks
{
	public class SocketTasks
	{
		public SocketTask[] Tasks { get; set; }

		public bool IsDone
		{
			get
			{
				for (int i = 0; i < Tasks.Length; i++)
				{
					if (!Tasks[i].IsDone)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool Success
		{
			get
			{
				for (int i = 0; i < Tasks.Length; i++)
				{
					if (!Tasks[i].Success)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool AnySuccess
		{
			get
			{
				for (int i = 0; i < Tasks.Length; i++)
				{
					if (Tasks[i].Success)
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool AnyDone
		{
			get
			{
				for (int i = 0; i < Tasks.Length; i++)
				{
					if (Tasks[i].IsDone)
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
