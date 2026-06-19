namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] ytDxHDZORnrcXxAGzgYOeAjfDsen;

		public int Length
		{
			get
			{
				if (ytDxHDZORnrcXxAGzgYOeAjfDsen == null)
				{
					return 0;
				}
				return ytDxHDZORnrcXxAGzgYOeAjfDsen.Length;
			}
		}

		public T this[int index] => ytDxHDZORnrcXxAGzgYOeAjfDsen[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			ytDxHDZORnrcXxAGzgYOeAjfDsen = P_0;
		}
	}
}
