using System;
using CTS;
using CTS.BBT;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_DeadBodyData : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_DeadBodyData()
			: base(typeof(DeadBodyData))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			DeadBodyData deadBodyData = (DeadBodyData)obj;
			writer.WriteProperty("Identifier", deadBodyData.Identifier, ES3Type_Guid.Instance);
			writer.WriteProperty("FirstName", deadBodyData.FirstName, ES3Type_string.Instance);
			writer.WriteProperty("LastName", deadBodyData.LastName, ES3Type_string.Instance);
			writer.WriteProperty("Credibility", deadBodyData.Credibility, ES3Type_int.Instance);
			writer.WriteProperty("Type", deadBodyData.Type, ES3TypeMgr.GetOrCreateES3Type(typeof(ESubSpecies)));
			writer.WriteProperty("BloodQuality", deadBodyData.BloodQuality, ES3Type_int.Instance);
			writer.WriteProperty("Money", deadBodyData.Money, ES3Type_int.Instance);
			writer.WriteAssetReference("VigilanceData", deadBodyData.VigilanceData);
		}

		public override object Read<T>(ES3Reader reader)
		{
			DeadBodyData deadBodyData = default(DeadBodyData);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "Identifier":
					deadBodyData.Identifier = reader.Read<Guid>(ES3Type_Guid.Instance);
					break;
				case "FirstName":
					deadBodyData.FirstName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "LastName":
					deadBodyData.LastName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "Credibility":
					deadBodyData.Credibility = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "Type":
					deadBodyData.Type = reader.Read<ESubSpecies>(ES3Type_enum.Instance);
					break;
				case "BloodQuality":
					deadBodyData.BloodQuality = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "Money":
					deadBodyData.Money = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "VigilanceData":
					deadBodyData.VigilanceData = reader.ReadAssetReference<VigilanceMultipliersData>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			return deadBodyData;
		}
	}
}
