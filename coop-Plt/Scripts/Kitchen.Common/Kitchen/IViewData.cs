using MessagePack;

namespace Kitchen
{
	[AutoUnion]
	public interface IViewData : IViewResponseData
	{
		public interface ICheckForChanges<T>
		{
			bool IsChangedFrom(T check);
		}
	}
}
