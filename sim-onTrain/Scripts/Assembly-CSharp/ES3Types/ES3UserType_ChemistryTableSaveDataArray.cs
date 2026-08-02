namespace ES3Types
{
	public class ES3UserType_ChemistryTableSaveDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ChemistryTableSaveDataArray()
			: base(typeof(ChemistryTableSaveData[]), ES3UserType_ChemistryTableSaveData.Instance)
		{
			Instance = this;
		}
	}
}
