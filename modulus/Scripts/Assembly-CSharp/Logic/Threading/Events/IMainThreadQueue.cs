namespace Logic.Threading.Events
{
	public interface IMainThreadQueue
	{
		void DequeueAndFire();
	}
}
