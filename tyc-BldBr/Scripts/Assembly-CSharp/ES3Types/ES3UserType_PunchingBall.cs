using CTS;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_PunchingBall : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_PunchingBall()
			: base(typeof(PunchingBall))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			PunchingBall punchingBall = (PunchingBall)obj;
			writer.WriteProperty("MachinePowerState", punchingBall.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", punchingBall.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			PunchingBall punchingBall = (PunchingBall)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "MachinePowerState"))
				{
					if (property == "MachineProductionMode")
					{
						reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), punchingBall);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					punchingBall.MachinePowerState = reader.Read<EMachinePowerState>();
				}
			}
		}
	}
}
