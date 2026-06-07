namespace CTS.Core
{
	public interface IParentable<out T>
	{
		T GetParent();
	}
}
