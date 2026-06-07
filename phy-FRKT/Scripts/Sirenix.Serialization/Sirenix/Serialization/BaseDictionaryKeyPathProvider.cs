using System.Collections.Generic;

namespace Sirenix.Serialization
{
	public abstract class BaseDictionaryKeyPathProvider<T> : IDictionaryKeyPathProvider<T>, IDictionaryKeyPathProvider, IComparer<T>
	{
		public abstract string ProviderID { get; }

		public abstract T GetKeyFromPathString(string pathStr);

		public abstract string GetPathStringFromKey(T key);

		public abstract int Compare(T x, T y);

		int IDictionaryKeyPathProvider.Compare(object x, object y)
		{
			return 0;
		}

		object IDictionaryKeyPathProvider.GetKeyFromPathString(string pathStr)
		{
			return null;
		}

		string IDictionaryKeyPathProvider.GetPathStringFromKey(object key)
		{
			return null;
		}
	}
}
