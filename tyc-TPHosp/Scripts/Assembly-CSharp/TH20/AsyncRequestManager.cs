using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public static class AsyncRequestManager
	{
		public static List<RequestResponseContainer> CurrentRequests;

		static AsyncRequestManager()
		{
			CurrentRequests = new List<RequestResponseContainer>();
		}

		public static void AddRequest(GenericRequestBase request)
		{
			CurrentRequests.Add(new RequestResponseContainer(request));
		}

		public static bool AddResponse(GenericResponseBase response)
		{
			try
			{
				CurrentRequests.Find((RequestResponseContainer x) => x.Request.RequestID == response.RequestID).AddResponse(response);
				return true;
			}
			catch (ArgumentNullException ex)
			{
				UnityEngine.Debug.LogWarning("Unable to find Request with matching RequestID to Response + " + ex.ToString());
				return false;
			}
		}

		public static RequestResponseContainer PollRequest(int requestID, out bool responseReady)
		{
			RequestResponseContainer requestResponseContainer = RequestResponseContainer.Null;
			requestResponseContainer = CurrentRequests.Find((RequestResponseContainer x) => x.Request.RequestID == requestID && x.Response != null);
			if (requestResponseContainer == null || requestResponseContainer.Equals(null))
			{
				responseReady = false;
				return RequestResponseContainer.Null;
			}
			CurrentRequests.Remove(requestResponseContainer);
			responseReady = true;
			return requestResponseContainer;
		}

		public static bool CancelReequest(int requestID)
		{
			RequestResponseContainer item = CurrentRequests.Find((RequestResponseContainer x) => x.Request.RequestID == requestID);
			return CurrentRequests.Remove(item);
		}
	}
}
