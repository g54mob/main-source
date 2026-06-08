using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetLifecycleConfigurationResponse : AmazonWebServiceResponse
	{
		private LifecycleConfiguration configuration;

		private TransitionDefaultMinimumObjectSize _transitionDefaultMinimumObjectSize;

		public LifecycleConfiguration Configuration
		{
			get
			{
				if (configuration == null)
				{
					configuration = new LifecycleConfiguration();
				}
				return configuration;
			}
			set
			{
				configuration = value;
			}
		}

		public TransitionDefaultMinimumObjectSize TransitionDefaultMinimumObjectSize
		{
			get
			{
				return _transitionDefaultMinimumObjectSize;
			}
			set
			{
				_transitionDefaultMinimumObjectSize = value;
			}
		}

		internal bool IsSetTransitionDefaultMinimumObjectSize()
		{
			return !string.IsNullOrEmpty(_transitionDefaultMinimumObjectSize);
		}
	}
}
