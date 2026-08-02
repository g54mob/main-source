using System.Collections.Generic;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"fuelSlotItems", "remainingFuelTime", "maxFuelTime", "inputItems", "inputItemCounts", "outputItemName", "outputItemCount", "currentRecipeItemName", "currentProductionProgress", "totalProductionDuration",
		"isProcessing"
	})]
	public class ES3UserType_ChemistryTableSaveData : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_ChemistryTableSaveData()
			: base(typeof(ChemistryTableSaveData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			ChemistryTableSaveData chemistryTableSaveData = (ChemistryTableSaveData)obj;
			writer.WriteProperty("fuelSlotItems", chemistryTableSaveData.fuelSlotItems, ES3TypeMgr.GetOrCreateES3Type(typeof(List<string>)));
			writer.WriteProperty("remainingFuelTime", chemistryTableSaveData.remainingFuelTime, ES3Type_float.Instance);
			writer.WriteProperty("maxFuelTime", chemistryTableSaveData.maxFuelTime, ES3Type_float.Instance);
			writer.WriteProperty("inputItems", chemistryTableSaveData.inputItems, ES3TypeMgr.GetOrCreateES3Type(typeof(List<string>)));
			writer.WriteProperty("inputItemCounts", chemistryTableSaveData.inputItemCounts, ES3TypeMgr.GetOrCreateES3Type(typeof(List<int>)));
			writer.WriteProperty("outputItemName", chemistryTableSaveData.outputItemName, ES3Type_string.Instance);
			writer.WriteProperty("outputItemCount", chemistryTableSaveData.outputItemCount, ES3Type_int.Instance);
			writer.WriteProperty("currentRecipeItemName", chemistryTableSaveData.currentRecipeItemName, ES3Type_string.Instance);
			writer.WriteProperty("currentProductionProgress", chemistryTableSaveData.currentProductionProgress, ES3Type_float.Instance);
			writer.WriteProperty("totalProductionDuration", chemistryTableSaveData.totalProductionDuration, ES3Type_float.Instance);
			writer.WriteProperty("isProcessing", chemistryTableSaveData.isProcessing, ES3Type_bool.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			ChemistryTableSaveData chemistryTableSaveData = (ChemistryTableSaveData)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "fuelSlotItems":
					chemistryTableSaveData.fuelSlotItems = reader.Read<List<string>>();
					break;
				case "remainingFuelTime":
					chemistryTableSaveData.remainingFuelTime = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "maxFuelTime":
					chemistryTableSaveData.maxFuelTime = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "inputItems":
					chemistryTableSaveData.inputItems = reader.Read<List<string>>();
					break;
				case "inputItemCounts":
					chemistryTableSaveData.inputItemCounts = reader.Read<List<int>>();
					break;
				case "outputItemName":
					chemistryTableSaveData.outputItemName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "outputItemCount":
					chemistryTableSaveData.outputItemCount = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "currentRecipeItemName":
					chemistryTableSaveData.currentRecipeItemName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "currentProductionProgress":
					chemistryTableSaveData.currentProductionProgress = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "totalProductionDuration":
					chemistryTableSaveData.totalProductionDuration = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "isProcessing":
					chemistryTableSaveData.isProcessing = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			ChemistryTableSaveData chemistryTableSaveData = new ChemistryTableSaveData();
			ReadObject<T>(reader, chemistryTableSaveData);
			return chemistryTableSaveData;
		}
	}
}
