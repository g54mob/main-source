namespace ES3Types
{
	public class ES3UserType_ModuleSlotArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ModuleSlotArray()
			: base(typeof(ModuleSlot[]), ES3UserType_ModuleSlot.Instance)
		{
			Instance = this;
		}
	}
}
