using System;
using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_WorkerChoreHub : ES3UserType_WorkerChore
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerChoreHub()
			: base(typeof(WorkerChoreHub))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			base.WriteObject(obj, writer);
			WorkerChoreHub workerChoreHub = (WorkerChoreHub)obj;
			writer.WriteClassRefProperty("Action", workerChoreHub.Action);
		}

		protected override Type GetChoreType()
		{
			return typeof(WorkerChoreHub);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			base.ReadObject<T>(reader, obj);
			WorkerChoreHub objectContainingField = (WorkerChoreHub)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "Action")
				{
					AgentHubAction value = reader.ReadClassRef<AgentHubAction>();
					reader.SetPrivateField("Action".ToBackingField(), value, objectContainingField);
				}
			}
		}
	}
}
