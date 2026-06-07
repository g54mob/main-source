namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] enYjqcuugaeRIyehFroZQrKUlfJU;

		public int Length
		{
			get
			{
				if (enYjqcuugaeRIyehFroZQrKUlfJU == null)
				{
					return 0;
				}
				return enYjqcuugaeRIyehFroZQrKUlfJU.Length;
			}
		}

		public T this[int index] => enYjqcuugaeRIyehFroZQrKUlfJU[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			enYjqcuugaeRIyehFroZQrKUlfJU = P_0;
		}
	}
}
