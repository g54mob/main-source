using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.Helpers.BlockHelpers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Features
{
	[FeatureOrder(int.MaxValue)]
	internal class MissingHelperFeature : IFeature
	{
		private const string HelperMissingKey = "helperMissing";

		private const string BlockHelperMissingKey = "blockHelperMissing";

		private readonly IHelperDescriptor<HelperOptions> _helper;

		private readonly IHelperDescriptor<BlockHelperOptions> _blockHelper;

		public MissingHelperFeature(IHelperDescriptor<HelperOptions> helper, IHelperDescriptor<BlockHelperOptions> blockHelper)
		{
			_helper = helper;
			_blockHelper = blockHelper;
		}

		public void OnCompiling(ICompiledHandlebarsConfiguration configuration)
		{
			PathInfo orAdd = PathInfoStore.Current.GetOrAdd("helperMissing");
			if (!configuration.Helpers.ContainsKey((PathInfoLight)orAdd))
			{
				IHelperDescriptor<HelperOptions> value = _helper ?? new MissingHelperDescriptor();
				if (configuration.Helpers.TryGetValue((PathInfoLight)orAdd, out var value2))
				{
					value2.Value = value;
					return;
				}
				configuration.Helpers.AddOrReplace((PathInfoLight)orAdd, new Ref<IHelperDescriptor<HelperOptions>>(value));
			}
			PathInfo orAdd2 = PathInfoStore.Current.GetOrAdd("blockHelperMissing");
			if (!configuration.BlockHelpers.ContainsKey((PathInfoLight)orAdd2))
			{
				IHelperDescriptor<BlockHelperOptions> value3 = _blockHelper ?? new MissingBlockHelperDescriptor();
				if (configuration.BlockHelpers.TryGetValue((PathInfoLight)orAdd2, out var value4))
				{
					value4.Value = value3;
				}
				else
				{
					configuration.BlockHelpers.AddOrReplace((PathInfoLight)orAdd2, new Ref<IHelperDescriptor<BlockHelperOptions>>(value3));
				}
			}
		}

		public void CompilationCompleted()
		{
		}
	}
}
