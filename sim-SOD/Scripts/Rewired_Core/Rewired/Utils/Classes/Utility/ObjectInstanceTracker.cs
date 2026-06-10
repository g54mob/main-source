using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker wHDAqihkUEklGmDztCRHTBgCmFaA;

			private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

			public Wrapper(T instance)
			{
			}

			public Wrapper(T instance, ObjectInstanceTracker tracker)
			{
			}

			public void Dispose()
			{
			}

			~Wrapper()
			{
			}

			protected virtual void Dispose(bool disposing)
			{
			}
		}

		private static ObjectInstanceTracker zDUAuxExcfohrNlfXRqZQKTFXfx;

		private readonly Dictionary<uint, object> baqguTGwcLFSjkquQtrRVVupGsZc;

		private readonly object kozdzYBoHUkrULLrOwvPbpZsjeaa;

		private uint djgLmovEOrCeKGiRiVIJGEBiKroE;

		private int XVRLHgdJCYAMcVkSkHfXNgnYQhs;

		private bool KYstCAyAQHbkRwgLMQQWSDZdEnG;

		public static ObjectInstanceTracker Default => null;

		public uint Register(object instance)
		{
			return 0u;
		}

		public void Unregister(uint instanceId)
		{
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			instance = null;
			return false;
		}

		public void Dispose()
		{
		}

		private void zLxlEkIWAkHNiMmkcggbuscHLIg(bool P_0)
		{
		}

		~ObjectInstanceTracker()
		{
		}
	}
}
