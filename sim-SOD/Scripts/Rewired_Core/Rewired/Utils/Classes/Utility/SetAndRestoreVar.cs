using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> jHjABsfAFKIAeoUUVjMKnKynKVYc;

		private readonly T bQwVJnFWUVKEYvLeQaEdbrzIUEi;

		public SetAndRestoreVar(T oldValue, T newValue, Action<T> setValueDelegate)
		{
			jHjABsfAFKIAeoUUVjMKnKynKVYc = null;
			bQwVJnFWUVKEYvLeQaEdbrzIUEi = default(T);
		}

		public void Dispose()
		{
		}
	}
}
