namespace Client
{
	public interface IViewLateTick
	{
		void LateTick(TimeInterval tickTime, float stepAlpha);
	}
}
