using HandlebarsDotNet.Helpers;

namespace HandlebarsDotNet.Features
{
	internal class MissingHelperFeatureFactory : IFeatureFactory
	{
		private readonly IHelperDescriptor<HelperOptions> _returnHelper;

		private readonly IHelperDescriptor<BlockHelperOptions> _blockHelper;

		public MissingHelperFeatureFactory(IHelperDescriptor<HelperOptions> returnHelper = null, IHelperDescriptor<BlockHelperOptions> blockHelper = null)
		{
			_returnHelper = returnHelper;
			_blockHelper = blockHelper;
		}

		public IFeature CreateFeature()
		{
			return new MissingHelperFeature(_returnHelper, _blockHelper);
		}
	}
}
