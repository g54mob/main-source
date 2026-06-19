using System.IO;
using System.Text;

namespace Sentry.Extensibility
{
	public class DefaultRequestPayloadExtractor : BaseRequestPayloadExtractor
	{
		protected override bool IsSupported(IHttpRequest request)
		{
			return true;
		}

		protected override object? DoExtractPayLoad(IHttpRequest request)
		{
			if (request.Body == null)
			{
				return null;
			}
			using StreamReader streamReader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 1024, leaveOpen: true);
			string result = streamReader.ReadToEndAsync().GetAwaiter().GetResult();
			return (result.Length != 0) ? result : null;
		}
	}
}
