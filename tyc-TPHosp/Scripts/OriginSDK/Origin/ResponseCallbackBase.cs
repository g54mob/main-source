using System;
using Origin.Data;

namespace Origin
{
	internal abstract class ResponseCallbackBase : ICallback
	{
		public DateTime timeout;

		public abstract void HandleResponse(Response response);
	}
}
