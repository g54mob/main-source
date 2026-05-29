using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker FwsnUzagIkFjtGHJljRLYLcKKltD;

			private bool HBrbqTerKoIkTVUAWxAhEhINGVJOA;

			public Wrapper(T P_0)
			{
			}

			public Wrapper(T P_0, ObjectInstanceTracker P_1)
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

		private static ObjectInstanceTracker rPsmmYfqAyqolJwIDUMjnJLHcxuh;

		private readonly Dictionary<uint, object> VdnslVAwhDjvcBhLyIwDSHBAJgpE;

		private readonly object HowbZRJANGeiIAtnUrSXZgvYCpWhA;

		private uint qENIBVJpXbJxnRtKsXStDxskSPFN;

		private int FsMweKzCPHpqaIqzSZyibHZlJfSH;

		private bool hSwMhKVRhcNKTnhQizOpeYUoKygl;

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

		private void ktwZqIwbzrgkAPrgtGVKdQllcVXfA(bool P_0)
		{
		}

		~ObjectInstanceTracker()
		{
		}
	}
}
