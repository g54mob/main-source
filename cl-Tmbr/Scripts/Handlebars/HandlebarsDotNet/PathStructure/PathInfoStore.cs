using System;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.PathStructure
{
	public class PathInfoStore
	{
		private static readonly Func<string, DeferredValue<string, PathInfo>> ValueFactory = (string s) => new DeferredValue<string, PathInfo>(s, (string pathString) => PathInfo.Parse(pathString));

		private readonly LookupSlim<string, DeferredValue<string, PathInfo>, StringEqualityComparer> _paths = new LookupSlim<string, DeferredValue<string, PathInfo>, StringEqualityComparer>(new StringEqualityComparer(StringComparison.Ordinal));

		public static PathInfoStore Current => AmbientContext.Current?.PathInfoStore;

		internal PathInfoStore()
		{
		}

		public PathInfo GetOrAdd(string path)
		{
			PathInfo value = _paths.GetOrAdd(path, ValueFactory).Value;
			string trimmedPath = value.TrimmedPath;
			if (value.IsBlockHelper || value.IsInversion)
			{
				_paths.GetOrAdd(trimmedPath, ValueFactory);
			}
			return value;
		}
	}
}
