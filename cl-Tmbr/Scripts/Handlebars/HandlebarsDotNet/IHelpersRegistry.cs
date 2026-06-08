using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Helpers;

namespace HandlebarsDotNet
{
	public interface IHelpersRegistry
	{
		IIndexed<string, IHelperDescriptor<HelperOptions>> GetHelpers();

		IIndexed<string, IHelperDescriptor<BlockHelperOptions>> GetBlockHelpers();
	}
}
