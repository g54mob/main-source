namespace System.Runtime.InteropServices
{
	internal class ListViewB<T> where T : notnull
	{
		public T[] _items;

		public int _size;

		public int _version;

		private object _syncRoot;
	}
}
