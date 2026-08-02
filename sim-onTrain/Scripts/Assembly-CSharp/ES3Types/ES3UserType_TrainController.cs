using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "fuelLevel", "waterLevel", "breakState", "networkEngineRunning", "networkGasValue", "lastSavedPos", "lastSavedEulerAngles" })]
	public class ES3UserType_TrainController : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_TrainController()
			: base(typeof(TrainController))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			TrainController objectContainingField = (TrainController)obj;
			writer.WritePrivateField("fuelLevel", objectContainingField);
			writer.WritePrivateField("waterLevel", objectContainingField);
			writer.WritePrivateField("breakState", objectContainingField);
			writer.WritePrivateField("networkEngineRunning", objectContainingField);
			writer.WritePrivateField("networkGasValue", objectContainingField);
			writer.WritePrivateField("lastSavedPos", objectContainingField);
			writer.WritePrivateField("lastSavedEulerAngles", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			TrainController objectContainingField = (TrainController)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "fuelLevel":
					objectContainingField = (TrainController)reader.SetPrivateField("fuelLevel", reader.Read<float>(), objectContainingField);
					break;
				case "waterLevel":
					objectContainingField = (TrainController)reader.SetPrivateField("waterLevel", reader.Read<float>(), objectContainingField);
					break;
				case "breakState":
					objectContainingField = (TrainController)reader.SetPrivateField("breakState", reader.Read<bool>(), objectContainingField);
					break;
				case "networkEngineRunning":
					objectContainingField = (TrainController)reader.SetPrivateField("networkEngineRunning", reader.Read<bool>(), objectContainingField);
					break;
				case "networkGasValue":
					objectContainingField = (TrainController)reader.SetPrivateField("networkGasValue", reader.Read<float>(), objectContainingField);
					break;
				case "lastSavedPos":
					objectContainingField = (TrainController)reader.SetPrivateField("lastSavedPos", reader.Read<Vector3>(), objectContainingField);
					break;
				case "lastSavedEulerAngles":
					objectContainingField = (TrainController)reader.SetPrivateField("lastSavedEulerAngles", reader.Read<Vector3>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
