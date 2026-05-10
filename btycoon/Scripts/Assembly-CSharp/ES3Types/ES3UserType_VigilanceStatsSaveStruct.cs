using System.Collections.Generic;
using CTS;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "SavedStats" })]
	public class ES3UserType_VigilanceStatsSaveStruct : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_VigilanceStatsSaveStruct()
			: base(typeof(VigilanceStatsSaveStruct))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			writer.WriteProperty("SavedStats", ((VigilanceStatsSaveStruct)obj).SavedStats, ES3TypeMgr.GetOrCreateES3Type(typeof(Dictionary<string, VigilanceStatsSaveStruct.VigilanceElementStats>)));
		}

		public override object Read<T>(ES3Reader reader)
		{
			VigilanceStatsSaveStruct vigilanceStatsSaveStruct = default(VigilanceStatsSaveStruct);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				if (text == "SavedStats")
				{
					vigilanceStatsSaveStruct.SavedStats = reader.Read<Dictionary<string, VigilanceStatsSaveStruct.VigilanceElementStats>>();
				}
				else
				{
					reader.Skip();
				}
			}
			return vigilanceStatsSaveStruct;
		}
	}
}
