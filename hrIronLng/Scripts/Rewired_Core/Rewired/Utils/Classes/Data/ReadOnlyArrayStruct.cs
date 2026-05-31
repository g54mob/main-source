namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] mHIHoAhEEDIKZGxjPoowvVovytZb;

		public int Length
		{
			get
			{
				if (mHIHoAhEEDIKZGxjPoowvVovytZb == null)
				{
					return 0;
				}
				return mHIHoAhEEDIKZGxjPoowvVovytZb.Length;
			}
		}

		public T this[int index] => mHIHoAhEEDIKZGxjPoowvVovytZb[index];

		public ReadOnlyArrayStruct(T[] array)
		{
			mHIHoAhEEDIKZGxjPoowvVovytZb = array;
		}
	}
}
