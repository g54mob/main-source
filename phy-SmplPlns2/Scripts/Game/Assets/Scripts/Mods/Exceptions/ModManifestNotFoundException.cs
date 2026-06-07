using System;
using System.Runtime.Serialization;

namespace Assets.Scripts.Mods.Exceptions
{
	[Serializable]
	public class ModManifestNotFoundException : Exception
	{
		public ModManifestNotFoundException()
		{
		}

		public ModManifestNotFoundException(string message)
			: base(message)
		{
		}

		public ModManifestNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected ModManifestNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
