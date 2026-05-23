namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] PYtCLifyifmpgnddYdqMpCvwfrpC;

		public int Length
		{
			get
			{
				if (PYtCLifyifmpgnddYdqMpCvwfrpC == null)
				{
					return 0;
				}
				return PYtCLifyifmpgnddYdqMpCvwfrpC.Length;
			}
		}

		public T this[int index] => PYtCLifyifmpgnddYdqMpCvwfrpC[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			PYtCLifyifmpgnddYdqMpCvwfrpC = P_0;
		}
	}
}
