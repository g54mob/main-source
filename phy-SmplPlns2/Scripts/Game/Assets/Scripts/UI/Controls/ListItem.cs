namespace Assets.Scripts.UI.Controls
{
	public class ListItem<T>
	{
		public bool CanDelete { get; set; }

		public bool CanRename { get; set; }

		public T Item { get; set; }

		public string Name { get; set; }

		public ListItem(string name, T item)
		{
			Name = name;
			Item = item;
		}
	}
}
