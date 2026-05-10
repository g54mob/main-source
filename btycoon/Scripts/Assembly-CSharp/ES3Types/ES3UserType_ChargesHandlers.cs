using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "ChargesData", "OldChargesData" })]
	public class ES3UserType_ChargesHandlers : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_ChargesHandlers()
			: base(typeof(ChargesHandlers))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			ChargesHandlers chargesHandlers = (ChargesHandlers)obj;
			writer.WriteProperty("ChargesData", chargesHandlers.ChargesData, ES3Type_intArray.Instance);
			writer.WriteProperty("OldChargesData", chargesHandlers.OldChargesData, ES3Type_intArray.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			ChargesHandlers chargesHandlers = (ChargesHandlers)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "ChargesData"))
				{
					if (property == "OldChargesData")
					{
						chargesHandlers.OldChargesData = reader.Read<int[]>(ES3Type_intArray.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					chargesHandlers.ChargesData = reader.Read<int[]>(ES3Type_intArray.Instance);
				}
			}
		}
	}
}
