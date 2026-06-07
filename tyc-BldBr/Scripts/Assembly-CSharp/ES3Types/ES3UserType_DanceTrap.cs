using CTS;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "MachinePowerState", "MachineProductionMode", "_victim", "_isProcessing" })]
	public class ES3UserType_DanceTrap : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_DanceTrap()
			: base(typeof(DanceTrap))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			DanceTrap danceTrap = (DanceTrap)obj;
			writer.WriteProperty("MachinePowerState", danceTrap.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", danceTrap.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			DanceTrap danceTrap = (DanceTrap)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "MachinePowerState"))
				{
					if (property == "MachineProductionMode")
					{
						reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), danceTrap);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					danceTrap.MachinePowerState = reader.Read<EMachinePowerState>();
				}
			}
		}
	}
}
