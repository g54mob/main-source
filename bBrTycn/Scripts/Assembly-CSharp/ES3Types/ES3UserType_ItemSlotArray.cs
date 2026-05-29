using CTS;

namespace ES3Types
{
	public class ES3UserType_ItemSlotArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemSlotArray()
			: base(typeof(ItemSlot[]), ES3UserType_ItemSlot.Instance)
		{
			Instance = this;
		}
	}
}
