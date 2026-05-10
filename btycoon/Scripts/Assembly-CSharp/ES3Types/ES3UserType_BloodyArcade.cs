using CTS;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "MachinePowerState", "MachineProductionMode", "_victim", "_isProcessing" })]
	public class ES3UserType_BloodyArcade : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyArcade()
			: base(typeof(BloodyArcade))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodyArcade bloodyArcade = (BloodyArcade)obj;
			writer.WriteProperty("MachinePowerState", bloodyArcade.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodyArcade.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodyArcade bloodyArcade = (BloodyArcade)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "MachinePowerState"))
				{
					if (property == "MachineProductionMode")
					{
						reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), bloodyArcade);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					bloodyArcade.MachinePowerState = reader.Read<EMachinePowerState>();
				}
			}
		}
	}
}
