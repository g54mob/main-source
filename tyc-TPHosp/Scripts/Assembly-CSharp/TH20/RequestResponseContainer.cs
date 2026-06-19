using System.Collections.Generic;

namespace TH20
{
	public class RequestResponseContainer
	{
		public static readonly RequestResponseContainer Null = new RequestResponseContainer(null);

		public GenericRequestBase Request { get; set; }

		public GenericResponseBase Response { get; set; }

		public RequestResponseContainer(GenericRequestBase request)
		{
			Request = request;
			Response = null;
		}

		public void AddResponse(GenericResponseBase response)
		{
			Response = response;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RequestResponseContainer))
			{
				return false;
			}
			RequestResponseContainer requestResponseContainer = (RequestResponseContainer)obj;
			if (EqualityComparer<GenericRequestBase>.Default.Equals(Request, requestResponseContainer.Request))
			{
				return EqualityComparer<GenericResponseBase>.Default.Equals(Response, requestResponseContainer.Response);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (-1146408160 * -1521134295 + EqualityComparer<GenericRequestBase>.Default.GetHashCode(Request)) * -1521134295 + EqualityComparer<GenericResponseBase>.Default.GetHashCode(Response);
		}
	}
}
