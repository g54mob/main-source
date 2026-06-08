using System.Collections.Generic;
using System.Linq;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.Helpers.BlockHelpers;

namespace HandlebarsDotNet.Features
{
	public static class MissingHelperFeatureExtension
	{
		public static HandlebarsConfiguration RegisterMissingHelperHook(this HandlebarsConfiguration configuration, IHelperDescriptor<HelperOptions> helperMissing = null, IHelperDescriptor<BlockHelperOptions> blockHelperMissing = null)
		{
			MissingHelperFeatureFactory item = new MissingHelperFeatureFactory(helperMissing, blockHelperMissing);
			IList<IFeatureFactory> features = configuration.CompileTimeConfiguration.Features;
			features.Remove(features.OfType<MissingHelperFeatureFactory>().Single());
			features.Add(item);
			return configuration;
		}

		public static HandlebarsConfiguration RegisterMissingHelperHook(this HandlebarsConfiguration configuration, HandlebarsReturnWithOptionsHelper helperMissing = null, HandlebarsBlockHelper blockHelperMissing = null)
		{
			return configuration.RegisterMissingHelperHook((helperMissing != null) ? new DelegateReturnHelperWithOptionsDescriptor("helperMissing", helperMissing) : null, (blockHelperMissing != null) ? new DelegateBlockHelperDescriptor("blockHelperMissing", blockHelperMissing) : null);
		}
	}
}
