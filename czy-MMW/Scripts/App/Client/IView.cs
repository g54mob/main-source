namespace Client
{
	public interface IView
	{
		TickResult Tick(TimeInterval tickTime, float stepAlpha);

		void SetGameobjectActive(bool isActive);
	}
}
