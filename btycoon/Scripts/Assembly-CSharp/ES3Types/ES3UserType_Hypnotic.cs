using CTS;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "MachinePowerState", "TextureSelected", "MachineProductionMode" })]
	public class ES3UserType_Hypnotic : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Hypnotic()
			: base(typeof(Hypnotic))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Hypnotic hypnotic = (Hypnotic)obj;
			writer.WriteProperty("MachinePowerState", hypnotic.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", hypnotic.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WriteProperty("PictureIndex", hypnotic.PictureIndex);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Hypnotic hypnotic = (Hypnotic)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					hypnotic.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					hypnotic.MachineProductionMode = reader.Read<EMachineProductionMode>();
					break;
				case "PictureIndex":
					reader.SetPrivateField("PictureIndex".ToBackingField(), reader.Read<int>(), hypnotic);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			hypnotic.ResetSave();
		}
	}
}
