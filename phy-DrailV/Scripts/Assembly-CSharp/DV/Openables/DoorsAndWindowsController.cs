using DV.Simulation.Controllers;

namespace DV.Openables
{
	public class DoorsAndWindowsController : ARefreshableChildrenController<OpenableControl>
	{
		private bool isInitialized;

		private void Start()
		{
			OpenableControl[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init();
			}
			isInitialized = true;
		}

		public bool AnythingOpen()
		{
			if (!isInitialized)
			{
				return false;
			}
			OpenableControl[] array = entries;
			foreach (OpenableControl openableControl in array)
			{
				if (openableControl != null && openableControl.IsOpen)
				{
					return true;
				}
			}
			return false;
		}
	}
}
