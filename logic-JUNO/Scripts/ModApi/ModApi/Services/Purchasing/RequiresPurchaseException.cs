using System;
using System.Runtime.Serialization;

namespace ModApi.Services.Purchasing
{
	[Serializable]
	public class RequiresPurchaseException : Exception
	{
		public IInAppPurchaseFeature[] RequiredFeatures { get; private set; }

		public RequiresPurchaseException()
		{
		}

		public RequiresPurchaseException(string message, params IInAppPurchaseFeature[] requiredFeatures)
			: base(message)
		{
			RequiredFeatures = requiredFeatures;
		}

		public RequiresPurchaseException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected RequiresPurchaseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
