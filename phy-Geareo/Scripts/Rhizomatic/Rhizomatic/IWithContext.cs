namespace Rhizomatic
{
	public interface IWithContext
	{
		Context context { get; set; }

		void OnContext();
	}
}
