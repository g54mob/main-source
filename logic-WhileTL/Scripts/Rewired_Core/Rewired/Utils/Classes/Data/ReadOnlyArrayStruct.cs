namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] mggYCeqGblCBmIEfiOfqlhelwzZl;

		public int Length
		{
			get
			{
				if (mggYCeqGblCBmIEfiOfqlhelwzZl == null)
				{
					return 0;
				}
				return mggYCeqGblCBmIEfiOfqlhelwzZl.Length;
			}
		}

		public T this[int index] => mggYCeqGblCBmIEfiOfqlhelwzZl[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			mggYCeqGblCBmIEfiOfqlhelwzZl = P_0;
		}
	}
}
