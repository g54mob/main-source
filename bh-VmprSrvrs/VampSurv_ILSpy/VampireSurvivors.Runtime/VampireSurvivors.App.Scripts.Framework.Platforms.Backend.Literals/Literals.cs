using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Literals;

public class Literals
{
	private static Dictionary<string, Dictionary<string, string>> LiteralDictionary;

	private static void Load()
	{
		TextAsset textAsset = Resources.Load<TextAsset>("account_en");
		if ((object)textAsset != null && ((UnityEngine.Object)textAsset).m_CachedPtr != (IntPtr)0)
		{
			string text = textAsset.text;
			Dictionary<string, Dictionary<string, string>> literalDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(text);
			LiteralDictionary = literalDictionary;
			return;
		}
		Exception ex = new Exception("Failed to load literals.");
		throw ex;
	}
}
