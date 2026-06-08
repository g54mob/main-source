using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet
{
	public interface IHelperOptions : IOptions
	{
		DataValues Data { get; }

		PathInfo Name { get; }
	}
}
