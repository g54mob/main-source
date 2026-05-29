using CTS;

namespace ES3Types
{
	public class ES3UserType_MissionItemCapacityArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MissionItemCapacityArray()
			: base(typeof(MissionBasket.MissionItemCapacity[]), ES3UserType_MissionItemCapacity.Instance)
		{
			Instance = this;
		}
	}
}
