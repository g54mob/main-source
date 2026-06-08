using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Runtime.SharedInterfaces
{
	public interface ICoreAmazonSQS
	{
		Task<Dictionary<string, string>> GetAttributesAsync(string queueUrl);

		Task SetAttributesAsync(string queueUrl, Dictionary<string, string> attributes);
	}
}
