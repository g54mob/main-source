using UnityEngine;

namespace Restory.Data.SaveLoad
{
	public static class RunInBackgroundSolver
	{
		public static void OnConcurrentTasksStarted()
		{
			Application.runInBackground = true;
		}

		public static void OnConcurrentTasksFinished()
		{
			Application.runInBackground = false;
		}
	}
}
