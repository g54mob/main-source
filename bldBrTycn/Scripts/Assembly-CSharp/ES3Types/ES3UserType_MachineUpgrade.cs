using CTS;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "currentLevel" })]
	public class ES3UserType_MachineUpgrade : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MachineUpgrade()
			: base(typeof(MachineUpgrade))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MachineUpgrade machineUpgrade = (MachineUpgrade)obj;
			writer.WriteProperty("currentLevel", machineUpgrade.currentLevel, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineUpgrade)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MachineUpgrade machineUpgrade = (MachineUpgrade)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "currentLevel")
				{
					machineUpgrade.currentLevel = reader.Read<EMachineUpgrade>();
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
