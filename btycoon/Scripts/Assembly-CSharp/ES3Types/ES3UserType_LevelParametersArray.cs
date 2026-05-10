using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_LevelParametersArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelParametersArray()
			: base(typeof(LevelParameters[]), ES3UserType_LevelParameters.Instance)
		{
			Instance = this;
		}
	}
}
