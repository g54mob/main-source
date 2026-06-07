namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] tIhanOklbsAskcDIqgcjvFlYQXV;

		public int Length
		{
			get
			{
				if (tIhanOklbsAskcDIqgcjvFlYQXV == null)
				{
					return 0;
				}
				return tIhanOklbsAskcDIqgcjvFlYQXV.Length;
			}
		}

		public T this[int index]
		{
			get
			{
				return tIhanOklbsAskcDIqgcjvFlYQXV[index];
			}
		}

		public ReadOnlyArrayStruct(T[] array)
		{
			tIhanOklbsAskcDIqgcjvFlYQXV = array;
		}
	}
}
