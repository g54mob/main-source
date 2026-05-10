using CTS.BBT.TechTree;

namespace ES3Types
{
	public class ES3UserType_TechTreeManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TechTreeManagerArray()
			: base(typeof(TechTreeManager[]), ES3UserType_TechTreeManager.Instance)
		{
			Instance = this;
		}
	}
}
