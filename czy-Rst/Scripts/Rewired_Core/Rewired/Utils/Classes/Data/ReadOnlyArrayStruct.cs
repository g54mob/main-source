namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] lMwDzDiaqzPXOCeuROghLOcdbNLRA;

		public int Length
		{
			get
			{
				if (lMwDzDiaqzPXOCeuROghLOcdbNLRA == null)
				{
					return 0;
				}
				return lMwDzDiaqzPXOCeuROghLOcdbNLRA.Length;
			}
		}

		public T this[int index] => lMwDzDiaqzPXOCeuROghLOcdbNLRA[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			lMwDzDiaqzPXOCeuROghLOcdbNLRA = P_0;
		}
	}
}
