using System;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace CTS
{
	[Preserve]
	public class ES3UserType_WorkerChoreDiscardJunk : ES3UserType_WorkerChore
	{
		public ES3UserType_WorkerChoreDiscardJunk()
			: base(typeof(WorkerChoreDiscardJunk))
		{
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			base.WriteObject(obj, writer);
			WorkerChoreDiscardJunk objectContainingField = (WorkerChoreDiscardJunk)obj;
			writer.WritePrivateFieldByRef("_junkObject", objectContainingField);
		}

		protected override Type GetChoreType()
		{
			return typeof(WorkerChoreDiscardJunk);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			base.ReadObject<T>(reader, obj);
			WorkerChoreDiscardJunk objectContainingField = (WorkerChoreDiscardJunk)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_junkObject")
				{
					JunkObject junkObject = reader.Read<JunkObject>();
					if ((bool)junkObject)
					{
						reader.SetPrivateField("ChoreTarget".ToBackingField(), junkObject.RoomData, objectContainingField);
						reader.SetPrivateField("_junkObject", junkObject, objectContainingField);
					}
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
