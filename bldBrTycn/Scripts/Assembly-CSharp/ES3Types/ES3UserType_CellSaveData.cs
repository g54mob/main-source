using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "position", "roomID", "paint", "buildableName", "buildableRotation" })]
	public class ES3UserType_CellSaveData : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_CellSaveData()
			: base(typeof(CellSaveData))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			CellSaveData cellSaveData = (CellSaveData)obj;
			if (cellSaveData.position != default(Vector2Int))
			{
				writer.WriteProperty("position", cellSaveData.position, ES3Type_Vector2Int.Instance);
			}
			if (cellSaveData.roomID != 0)
			{
				writer.WriteProperty("roomID", cellSaveData.roomID, ES3Type_int.Instance);
			}
			if (cellSaveData.paint != null)
			{
				writer.WriteProperty("paint", cellSaveData.paint, ES3Type_intArray.Instance);
			}
			if (!string.IsNullOrEmpty(cellSaveData.buildableName))
			{
				writer.WriteProperty("buildableName", cellSaveData.buildableName, ES3Type_string.Instance);
			}
			if (cellSaveData.buildableRotation != 0)
			{
				writer.WriteProperty("buildableRotation", cellSaveData.buildableRotation, ES3Type_int.Instance);
			}
		}

		public override object Read<T>(ES3Reader reader)
		{
			CellSaveData cellSaveData = default(CellSaveData);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "position":
					cellSaveData.position = reader.Read<Vector2Int>(ES3Type_Vector2Int.Instance);
					break;
				case "roomID":
					cellSaveData.roomID = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "paint":
					cellSaveData.paint = reader.Read<int[]>(ES3Type_intArray.Instance);
					break;
				case "buildableName":
					cellSaveData.buildableName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "buildableRotation":
					cellSaveData.buildableRotation = reader.Read<int>(ES3Type_int.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if (cellSaveData.paint == null)
			{
				cellSaveData.paint = new int[5];
			}
			return cellSaveData;
		}
	}
}
