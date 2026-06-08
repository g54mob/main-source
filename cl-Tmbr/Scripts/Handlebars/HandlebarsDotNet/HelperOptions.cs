using System.Runtime.CompilerServices;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet
{
	public readonly struct HelperOptions : IHelperOptions, IOptions
	{
		public BindingContext Frame { get; }

		public DataValues Data => new DataValues(Frame);

		public PathInfo Name { get; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public HelperOptions(PathInfo name, BindingContext frame)
		{
			Frame = frame;
			Name = name;
		}
	}
}
