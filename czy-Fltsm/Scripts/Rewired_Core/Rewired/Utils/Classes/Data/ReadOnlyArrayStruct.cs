namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] qVZfbItCpdtrtMcimGTzrAhISviO;

		public int Length
		{
			get
			{
				if (qVZfbItCpdtrtMcimGTzrAhISviO == null)
				{
					return 0;
				}
				return qVZfbItCpdtrtMcimGTzrAhISviO.Length;
			}
		}

		public T this[int index] => qVZfbItCpdtrtMcimGTzrAhISviO[index];

		public ReadOnlyArrayStruct(T[] P_0)
		{
			qVZfbItCpdtrtMcimGTzrAhISviO = P_0;
		}
	}
}
