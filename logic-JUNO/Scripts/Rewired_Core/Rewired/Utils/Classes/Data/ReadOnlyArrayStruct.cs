namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] wtNYlqjdbUQsBqWyloFGqLaTVDjM;

		public int Length
		{
			get
			{
				if (wtNYlqjdbUQsBqWyloFGqLaTVDjM == null)
				{
					return 0;
				}
				return wtNYlqjdbUQsBqWyloFGqLaTVDjM.Length;
			}
		}

		public T this[int index] => wtNYlqjdbUQsBqWyloFGqLaTVDjM[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			wtNYlqjdbUQsBqWyloFGqLaTVDjM = P_0;
		}
	}
}
