using System.Collections.Generic;

namespace Gh.Tk
{
	public class ProcessingService : AttachedBehaviour
	{
		public List<ProcessDescription> ProcessingTypes;

		public bool IsProcessSupported(string processName)
		{
			return false;
		}

		public double GetProcessDuration(string processName)
		{
			return 0.0;
		}
	}
}
