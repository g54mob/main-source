namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb;

		public int Length
		{
			get
			{
				if (ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb == null)
				{
					return 0;
				}
				return ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.Length;
			}
		}

		public T this[int index] => ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb = P_0;
		}
	}
}
