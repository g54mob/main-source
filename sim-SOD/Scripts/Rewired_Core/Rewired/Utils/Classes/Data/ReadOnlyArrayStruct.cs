namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] sSmTpnevSVPhKEJIxFapvCHiCvW;

		public int Length => 0;

		public T this[int index] => default(T);

		public ReadOnlyArrayStruct(T[] array)
		{
			sSmTpnevSVPhKEJIxFapvCHiCvW = null;
		}
	}
}
