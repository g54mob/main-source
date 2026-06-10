using System;

namespace NSMedieval.Village.Map.Pathfinding
{
	public sealed class PathProcessingTask
	{
		private readonly Path path;

		private PathProcessingTaskState state;

		private Action<PathProcessingTask> onInit;

		private Action<PathProcessingTask> onComplete;

		private bool abort;

		public Path Path => path;

		public PathProcessingTaskState State
		{
			get
			{
				return state;
			}
			internal set
			{
				state = value;
			}
		}

		public bool IsAbort => abort;

		public Action<PathProcessingTask> OnInit
		{
			get
			{
				return onInit;
			}
			set
			{
				onInit = value;
			}
		}

		public Action<PathProcessingTask> OnComplete
		{
			get
			{
				return onComplete;
			}
			set
			{
				onComplete = value;
			}
		}

		public PathProcessingTask(Path path)
		{
			this.path = path;
		}

		public void Abort()
		{
			abort = true;
			path.Abort();
		}
	}
}
