namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct ReadOnlyArrayStruct<T>
	{
		private T[] MHrpKPSmIyPSdBajdKTerCRXLIi;

		public int Length
		{
			get
			{
				if (MHrpKPSmIyPSdBajdKTerCRXLIi == null)
				{
					return 0;
				}
				return MHrpKPSmIyPSdBajdKTerCRXLIi.Length;
			}
		}

		public T this[int index] => MHrpKPSmIyPSdBajdKTerCRXLIi[index];

		public ReadOnlyArrayStruct(T[] array)
		{
			MHrpKPSmIyPSdBajdKTerCRXLIi = array;
		}
	}
}
