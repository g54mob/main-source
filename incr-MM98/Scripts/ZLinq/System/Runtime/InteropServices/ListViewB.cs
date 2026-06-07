namespace System.Runtime.InteropServices
{
	internal class ListViewB<T>
	{
		public T[] _items;

		public int _size;

		public int _version;

		private object _syncRoot;
	}
}
