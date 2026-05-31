using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Eflatun.SceneReference.Exceptions
{
	[Serializable]
	[PublicAPI]
	public class SceneNotAddressableException : SceneReferenceException
	{
		private const string ExceptionMessage = "An addressables-specific operation is attempted on a SceneReference that is assigned a non-addressable scene.\nYou can avoid this exception by making sure the State property is Addressable.";

		internal SceneNotAddressableException()
			: base("An addressables-specific operation is attempted on a SceneReference that is assigned a non-addressable scene.\nYou can avoid this exception by making sure the State property is Addressable.")
		{
		}

		internal SceneNotAddressableException(Exception inner)
			: base("An addressables-specific operation is attempted on a SceneReference that is assigned a non-addressable scene.\nYou can avoid this exception by making sure the State property is Addressable.", inner)
		{
		}

		private protected SceneNotAddressableException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
