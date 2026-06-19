namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] YDiWHoGivIfdThkTSDalbHHbBzrD;

		public int Length
		{
			get
			{
				if (YDiWHoGivIfdThkTSDalbHHbBzrD == null)
				{
					return 0;
				}
				return YDiWHoGivIfdThkTSDalbHHbBzrD.Length;
			}
		}

		public T this[int index] => YDiWHoGivIfdThkTSDalbHHbBzrD[index];

		public ReadOnlyArrayStruct(T[] array)
		{
			YDiWHoGivIfdThkTSDalbHHbBzrD = array;
		}
	}
}
