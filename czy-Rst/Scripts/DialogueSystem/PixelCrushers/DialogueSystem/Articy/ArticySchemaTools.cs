using System.Text;
using PixelCrushers.DialogueSystem.Articy.Articy_1_4;
using PixelCrushers.DialogueSystem.Articy.Articy_2_2;
using PixelCrushers.DialogueSystem.Articy.Articy_2_4;
using PixelCrushers.DialogueSystem.Articy.Articy_3_1;
using PixelCrushers.DialogueSystem.Articy.Articy_4_0;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy
{
	public static class ArticySchemaTools
	{
		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding, ConverterPrefs.ConvertDropdownsModes convertDropdownAs = ConverterPrefs.ConvertDropdownsModes.Int)
		{
			if (Articy_4_0_Tools.IsSchema(xmlData))
			{
				return Articy_4_0_Tools.LoadArticyDataFromXmlData(xmlData, encoding, convertDropdownAs);
			}
			if (Articy_3_1_Tools.IsSchema(xmlData))
			{
				return Articy_3_1_Tools.LoadArticyDataFromXmlData(xmlData, encoding, convertDropdownAs);
			}
			if (Articy_2_4_Tools.IsSchema(xmlData))
			{
				return Articy_2_4_Tools.LoadArticyDataFromXmlData(xmlData, encoding, convertDropdownAs);
			}
			if (Articy_2_2_Tools.IsSchema(xmlData))
			{
				return Articy_2_2_Tools.LoadArticyDataFromXmlData(xmlData, encoding);
			}
			if (Articy_1_4_Tools.IsSchema(xmlData))
			{
				return Articy_1_4_Tools.LoadArticyDataFromXmlData(xmlData, encoding);
			}
			Debug.LogWarning("No valid schema data found in XML data. Remember to tick 'Export XML Namespace' when exporting.");
			return null;
		}

		public static ArticyData LoadArticyDataFromXmlData(string xmlData, ConverterPrefs prefs)
		{
			if (Articy_4_0_Tools.IsSchema(xmlData))
			{
				return Articy_4_0_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding, prefs.ConvertDropdownsAs, prefs);
			}
			if (Articy_3_1_Tools.IsSchema(xmlData))
			{
				return Articy_3_1_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding, prefs.ConvertDropdownsAs, prefs);
			}
			if (Articy_2_4_Tools.IsSchema(xmlData))
			{
				return Articy_2_4_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding, prefs.ConvertDropdownsAs, prefs);
			}
			if (Articy_2_2_Tools.IsSchema(xmlData))
			{
				return Articy_2_2_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding);
			}
			if (Articy_1_4_Tools.IsSchema(xmlData))
			{
				return Articy_1_4_Tools.LoadArticyDataFromXmlData(xmlData, prefs.Encoding);
			}
			Debug.LogWarning("No valid schema data found in XML data. Remember to tick 'Export XML Namespace' when exporting.");
			return null;
		}
	}
}
