using CTS;

namespace ES3Types
{
	public class ES3UserType_CharacterDeliveriesArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CharacterDeliveriesArray()
			: base(typeof(CharacterDeliveries[]), ES3UserType_CharacterDeliveries.Instance)
		{
			Instance = this;
		}
	}
}
