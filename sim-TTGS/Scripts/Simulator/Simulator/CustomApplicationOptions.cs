using Dhs5.Utility.Settings;

namespace Simulator
{
	public abstract class CustomApplicationOptions<T> : CustomSettings<T> where T : CustomSettings<T>
	{
		public abstract void Load();

		public abstract void ResetSettings();
	}
}
