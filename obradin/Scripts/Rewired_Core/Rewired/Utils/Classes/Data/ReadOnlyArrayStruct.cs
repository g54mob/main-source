namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] AQbwABANpydSVGhHMkmtWznOOYQ;

		public int Length
		{
			get
			{
				if (AQbwABANpydSVGhHMkmtWznOOYQ == null)
				{
					return 0;
				}
				return AQbwABANpydSVGhHMkmtWznOOYQ.Length;
			}
		}

		public T this[int index]
		{
			get
			{
				return AQbwABANpydSVGhHMkmtWznOOYQ[index];
			}
		}

		public ReadOnlyArrayStruct(T[] array)
		{
			AQbwABANpydSVGhHMkmtWznOOYQ = array;
		}
	}
}
