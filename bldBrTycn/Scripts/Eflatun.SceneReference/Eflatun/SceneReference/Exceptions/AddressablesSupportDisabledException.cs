using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Eflatun.SceneReference.Exceptions
{
	[Serializable]
	[PublicAPI]
	public class AddressablesSupportDisabledException : SceneReferenceException
	{
		private const string ExceptionMessage = "An operation that requires addressables support is attempted while addressables support is disabled. To fix it, make sure addressables support is enabled.";

		internal AddressablesSupportDisabledException()
			: base("An operation that requires addressables support is attempted while addressables support is disabled. To fix it, make sure addressables support is enabled.")
		{
		}

		internal AddressablesSupportDisabledException(Exception inner)
			: base("An operation that requires addressables support is attempted while addressables support is disabled. To fix it, make sure addressables support is enabled.", inner)
		{
		}

		private protected AddressablesSupportDisabledException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
