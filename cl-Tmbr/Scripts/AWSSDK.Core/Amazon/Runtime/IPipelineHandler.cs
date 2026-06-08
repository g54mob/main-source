using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public interface IPipelineHandler
	{
		ILogger Logger { get; set; }

		IPipelineHandler InnerHandler { get; set; }

		IPipelineHandler OuterHandler { get; set; }

		void InvokeSync(IExecutionContext executionContext);

		Task<T> InvokeAsync<T>(IExecutionContext executionContext) where T : AmazonWebServiceResponse, new();
	}
}
