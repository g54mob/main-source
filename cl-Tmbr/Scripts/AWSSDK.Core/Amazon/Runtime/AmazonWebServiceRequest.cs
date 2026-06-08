using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;

namespace Amazon.Runtime
{
	public abstract class AmazonWebServiceRequest : IAmazonWebServiceRequest
	{
		private readonly object _lock = new object();

		internal RequestEventHandler mBeforeRequestEvent;

		private Dictionary<string, object> requestState;

		UserAgentDetails IAmazonWebServiceRequest.UserAgentDetails { get; } = new UserAgentDetails();

		EventHandler<StreamTransferProgressArgs> IAmazonWebServiceRequest.StreamUploadProgressCallback { get; set; }

		Dictionary<string, object> IAmazonWebServiceRequest.RequestState
		{
			get
			{
				if (requestState == null)
				{
					requestState = new Dictionary<string, object>();
				}
				return requestState;
			}
		}

		SignatureVersion IAmazonWebServiceRequest.SignatureVersion { get; set; }

		protected virtual bool Expect100Continue => false;

		protected virtual bool IncludeSHA256Header => true;

		protected internal virtual CoreChecksumResponseBehavior CoreChecksumMode
		{
			get
			{
				return CoreChecksumResponseBehavior.DISABLED;
			}
			set
			{
			}
		}

		protected internal virtual ReadOnlyCollection<CoreChecksumAlgorithm> ChecksumResponseAlgorithms => new List<CoreChecksumAlgorithm>(0).AsReadOnly();

		internal event RequestEventHandler BeforeRequestEvent
		{
			add
			{
				lock (_lock)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Combine(mBeforeRequestEvent, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Remove(mBeforeRequestEvent, value);
				}
			}
		}

		void IAmazonWebServiceRequest.AddBeforeRequestHandler(RequestEventHandler handler)
		{
			BeforeRequestEvent += handler;
		}

		void IAmazonWebServiceRequest.RemoveBeforeRequestHandler(RequestEventHandler handler)
		{
			BeforeRequestEvent -= handler;
		}

		internal void FireBeforeRequestEvent(object sender, RequestEventArgs args)
		{
			if (mBeforeRequestEvent != null)
			{
				mBeforeRequestEvent(sender, args);
			}
		}

		internal bool GetExpect100Continue()
		{
			return Expect100Continue;
		}

		internal bool GetIncludeSHA256Header()
		{
			return IncludeSHA256Header;
		}
	}
}
