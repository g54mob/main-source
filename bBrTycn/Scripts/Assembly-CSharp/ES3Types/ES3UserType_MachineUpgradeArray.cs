using CTS;

namespace ES3Types
{
	public class ES3UserType_MachineUpgradeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MachineUpgradeArray()
			: base(typeof(MachineUpgrade[]), ES3UserType_MachineUpgrade.Instance)
		{
			Instance = this;
		}
	}
}
