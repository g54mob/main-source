using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using CTS.Utilities;
using ES3Internal;
using ES3Types;

namespace CTS
{
	public abstract class ES3UserType_WorkerChore : ES3ObjectType
	{
		private struct BaseChoreSave
		{
			public ChoreCategory Category;

			public GameTime CreationTime;

			public int Priority;

			public GameTime NextAvailabilityTime;
		}

		public ES3UserType_WorkerChore(Type type)
			: base(type)
		{
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			WorkerChore workerChore = (WorkerChore)obj;
			BaseChoreSave baseChoreSave = new BaseChoreSave
			{
				Category = workerChore.Category,
				CreationTime = workerChore.CreationTime,
				Priority = workerChore.ChorePriority,
				NextAvailabilityTime = (GameTime)ES3Reflection.GetES3ReflectedMember(typeof(WorkerChore), "_nextAvailabilityTime").GetValue(workerChore)
			};
			writer.WriteProperty("BaseData", baseChoreSave);
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			WorkerChore workerChore = (WorkerChore)Activator.CreateInstance(GetChoreType(), nonPublic: true);
			ReadObject<T>(reader, workerChore);
			return workerChore;
		}

		protected abstract Type GetChoreType();

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			WorkerChore workerChore = (WorkerChore)obj;
			using (ES3Reader.ES3ReaderPropertyEnumerator.Enumerator enumerator = reader.Properties.GetEnumerator())
			{
				while (enumerator.MoveNext() && !(enumerator.Current == "BaseData"))
				{
					reader.Skip();
				}
			}
			BaseChoreSave baseChoreSave = reader.Read<BaseChoreSave>();
			reader.SetPrivateField("Category".ToBackingField(), baseChoreSave.Category, workerChore);
			reader.SetPrivateField("CreationTime".ToBackingField(), baseChoreSave.CreationTime, workerChore);
			workerChore.ChorePriority = baseChoreSave.Priority;
			reader.SetPrivateField("_nextAvailabilityTime", baseChoreSave.NextAvailabilityTime, workerChore);
		}
	}
}
