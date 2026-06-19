namespace FullInspector
{
	public interface ISharedInstance
	{
		int GetID { get; set; }

		object GetInstance { get; }
	}
}
