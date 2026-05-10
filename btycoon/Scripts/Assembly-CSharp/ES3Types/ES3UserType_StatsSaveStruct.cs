using System.Collections.Generic;
using CTS;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "SavedStats" })]
	public class ES3UserType_StatsSaveStruct : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_StatsSaveStruct()
			: base(typeof(StatsSaveStruct))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			writer.WriteProperty("SavedStats", ((StatsSaveStruct)obj).SavedStats, ES3TypeMgr.GetOrCreateES3Type(typeof(Dictionary<string, int>)));
		}

		public override object Read<T>(ES3Reader reader)
		{
			StatsSaveStruct statsSaveStruct = default(StatsSaveStruct);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				if (text == "SavedStats")
				{
					statsSaveStruct.SavedStats = reader.Read<Dictionary<string, int>>();
				}
				else
				{
					reader.Skip();
				}
			}
			return statsSaveStruct;
		}
	}
}
