namespace Mandragora.AnimationTools
{
	public class AnimationManager
	{
		public enum Threads
		{
			baseThread = 0,
			thread1 = 1,
			thread2 = 2,
			thread3 = 3,
			thread4 = 4,
			thread5 = 5
		}

		private static AnimationManager instance;

		private bool isAutoUpdate = true;

		public static AnimationManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new AnimationManager();
				}
				return instance;
			}
		}

		public bool IsAutoUpdate
		{
			get
			{
				return isAutoUpdate;
			}
			set
			{
				isAutoUpdate = value;
			}
		}

		private event OnUpdate onUpdateEventHandler;

		public event OnUpdate OnUpdateEventHandler
		{
			add
			{
				onUpdateEventHandler -= value;
				onUpdateEventHandler += value;
			}
			remove
			{
				onUpdateEventHandler -= value;
			}
		}

		public void Update(float dt, string thread = "")
		{
			if (!IsAutoUpdate && this.onUpdateEventHandler != null)
			{
				this.onUpdateEventHandler(dt, thread);
			}
		}
	}
}
