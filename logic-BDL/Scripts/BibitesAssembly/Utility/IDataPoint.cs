namespace Utility
{
	public interface IDataPoint
	{
		float this[int i] { get; set; }

		int GetLenght();
	}
}
