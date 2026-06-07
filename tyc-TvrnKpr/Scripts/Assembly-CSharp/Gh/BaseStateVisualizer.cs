namespace Gh
{
	public abstract class BaseStateVisualizer<T>
	{
		public bool IsEnabled { get; set; }

		public abstract void VisualizeState(T view);

		public abstract void CleanUp();
	}
}
