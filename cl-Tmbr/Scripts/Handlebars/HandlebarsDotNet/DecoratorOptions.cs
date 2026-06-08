using System.Runtime.CompilerServices;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet
{
	public readonly struct DecoratorOptions : IDecoratorOptions, IOptions, IHelpersRegistry
	{
		public BindingContext Frame { get; }

		public DataValues Data => new DataValues(Frame);

		public PathInfo Name { get; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DecoratorOptions(PathInfo name, BindingContext frame)
		{
			Frame = frame;
			Name = name;
		}

		IIndexed<string, IHelperDescriptor<HelperOptions>> IHelpersRegistry.GetHelpers()
		{
			return Frame.Helpers;
		}

		IIndexed<string, IHelperDescriptor<BlockHelperOptions>> IHelpersRegistry.GetBlockHelpers()
		{
			return Frame.BlockHelpers;
		}
	}
}
