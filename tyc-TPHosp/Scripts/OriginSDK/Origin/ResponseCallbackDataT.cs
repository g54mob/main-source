using System;
using System.Reflection;
using Origin.Data;

namespace Origin
{
	internal class ResponseCallbackDataT<ResponseType> : ResponseCallbackBase
	{
		private FieldInfo fieldInfo;

		private ResponseCallbackT<ResponseType> responseCallback;

		private ResponseType payload;

		private OriginErrorT err;

		public override void callback()
		{
			if (responseCallback != null)
			{
				responseCallback(payload, err);
			}
		}

		public ResponseCallbackDataT(int timeout, ResponseCallbackT<ResponseType> callback)
		{
			base.timeout = DateTime.Now.AddMilliseconds(timeout);
			responseCallback = callback;
			fieldInfo = typeof(Response).GetField(typeof(ResponseType).Name.Substring(0, typeof(ResponseType).Name.Length - 1));
		}

		public override void HandleResponse(Response response)
		{
			payload = (ResponseType)fieldInfo.GetValue(response);
			if (response.ErrorSuccess != null)
			{
				err = (OriginErrorT)response.ErrorSuccess.Code;
			}
			else if (payload != null)
			{
				err = OriginErrorT.ORIGIN_SUCCESS;
			}
			else
			{
				err = OriginErrorT.ORIGIN_ERROR_CORE_RECEIVE_FAILED;
			}
			OriginSDK.sdk.AddCallback(this);
		}
	}
}
