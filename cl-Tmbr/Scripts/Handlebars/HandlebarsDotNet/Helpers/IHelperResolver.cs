using System;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers
{
	public interface IHelperResolver
	{
		bool TryResolveHelper(PathInfo name, Type targetType, out IHelperDescriptor<HelperOptions> helper);

		bool TryResolveBlockHelper(PathInfo name, out IHelperDescriptor<BlockHelperOptions> helper);
	}
}
