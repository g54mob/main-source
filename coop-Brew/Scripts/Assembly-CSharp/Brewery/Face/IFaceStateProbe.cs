namespace Brewery.Face
{
	public interface IFaceStateProbe
	{
		string ProbeId { get; }

		float Evaluate01();
	}
}
