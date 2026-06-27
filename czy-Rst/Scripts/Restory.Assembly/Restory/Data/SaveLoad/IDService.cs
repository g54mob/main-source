using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Identifications;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Sirenix.Utilities;
using UnityEngine;

namespace Restory.Data.SaveLoad
{
	public class IDService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly HashSet<string> generatedIDs = new HashSet<string>();

		public void Generate(Identificator identificator)
		{
			identificator.SetID(GenerateNew());
		}

		public string GenerateNew()
		{
			int num = 100;
			string text;
			do
			{
				text = GenerateID();
				num--;
			}
			while (!generatedIDs.Add(text) && num > 0);
			if (num == 0 && generatedIDs.Contains(text))
			{
				Debug.LogError("<color=red>Duplicate ID generated! " + text + "</color>");
			}
			return text;
		}

		public static string GenerateID()
		{
			return Guid.NewGuid().ToString();
		}

		public object CaptureState()
		{
			try
			{
				return new GeneratedIDsSaveData
				{
					IDs = generatedIDs.ToList()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				GeneratedIDsSaveData generatedIDsSaveData = DataMigrationWizard.Migrate<GeneratedIDsSaveData>(state, base.gameObject);
				generatedIDs.Clear();
				if (generatedIDsSaveData.IDs != null)
				{
					generatedIDs.AddRange(generatedIDsSaveData.IDs);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
