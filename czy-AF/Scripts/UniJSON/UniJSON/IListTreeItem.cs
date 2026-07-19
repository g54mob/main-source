namespace UniJSON
{
	public interface IListTreeItem
	{
		int ParentIndex { get; }

		int ChildCount { get; }

		void SetChildCount(int count);
	}
}
