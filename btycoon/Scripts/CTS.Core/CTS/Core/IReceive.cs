namespace CTS.Core
{
	public interface IReceive<in TObject>
	{
		void OnReceive(TObject obj);
	}
	public interface IReceive<in TKey, in TObject>
	{
		void OnReceive(TKey key, TObject obj);
	}
}
