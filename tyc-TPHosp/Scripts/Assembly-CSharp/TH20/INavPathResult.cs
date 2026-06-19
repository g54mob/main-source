namespace TH20
{
	public interface INavPathResult
	{
		void OnStartPath();

		void OnPathComplete(EPathStatus status);
	}
}
