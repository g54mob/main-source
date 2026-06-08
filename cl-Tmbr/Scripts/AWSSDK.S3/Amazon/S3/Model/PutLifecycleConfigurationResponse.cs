using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutLifecycleConfigurationResponse : AmazonWebServiceResponse
	{
		private TransitionDefaultMinimumObjectSize _transitionDefaultMinimumObjectSize;

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
