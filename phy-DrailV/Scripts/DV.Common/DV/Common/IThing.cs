namespace DV.Common
{
	public interface IThing
	{
		string Name { get; set; }

		int DataVersion { get; }
	}
}
